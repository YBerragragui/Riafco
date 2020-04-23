using Riafco.Dataflex.Pro.Models;
using Riafco.Dataflex.Pro.Models.About.ItemData;
using Riafco.Dataflex.Pro.Models.About.ItemData.Enum;
using Riafco.Dataflex.Pro.Models.About.RequestData;
using Riafco.Dataflex.Pro.Models.About.ResultData;
using Riafco.Dataflex.Pro.Models.About.ViewData;
using Riafco.Dataflex.Pro.Models.News.ItemData;
using Riafco.Dataflex.Pro.Models.News.ItemData.Enum;
using Riafco.Dataflex.Pro.Models.News.RequestData;
using Riafco.Dataflex.Pro.Models.News.ResultData;
using Riafco.Dataflex.Pro.Models.News.ViewData;
using Riafco.Dataflex.Pro.Models.Newsletters.FormData;
using Riafco.Dataflex.Pro.Models.Partners.ResultData;
using Riafco.Dataflex.Pro.Models.Partners.ViewData;
using Riafco.Framework.Dataflex.pro.Web.WebApi;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace Riafco.Dataflex.Pro.Controllers
{
    /// <summary>
    /// The AproposController class.
    /// </summary>
    public class AproposController : BaseController
    {
        /// <summary>
        /// The langue id.
        /// </summary>
        private int _lang = 1;

        /// <summary>
        ///  index 
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            AboutModel aboutModel = new AboutModel
            {
                SubscriberFormData = new SubscriberFormData(),
                SectionViewData = await GetSections(9),
                PartnersViewData = await GetPartners(),
                NewsViewDatas = await GetNews(),
                FilesViewData = await GetFiles(9),
                ParagraphsViewData = await GetParagraphs(9)
            };
            return View(aboutModel);
        }

        /// <summary>
        /// Gouvernence page
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Gouvernance()
        {
            AboutModel aboutModel = new AboutModel
            {
                SubscriberFormData = new SubscriberFormData(),
                SectionViewData = await GetSections(10),
                PartnersViewData = await GetPartners(),
                NewsViewDatas = await GetNews(),
                FilesViewData = await GetFiles(10),
                ParagraphsViewData = await GetParagraphs(10)
            };
            return View(aboutModel);
        }

        public async Task<ActionResult> Historique()
        {
            HistoryModel historyModel = new HistoryModel
            {
                NewsViewDatas = await GetNews(),
                PartnersViewData = await GetPartners(),
                SubscriberFormData = new SubscriberFormData(),
                StepsViewData = await GetStepsList()
            };

            return View(historyModel);
        }

        /// <summary>
        /// Initialize the langue.
        /// </summary>
        /// <param name="requestContext">the request to get the langue.</param>
        protected override void Initialize(RequestContext requestContext)
        {
            string currentLanguageCode = requestContext.RouteData.Values["lang"] as string;
            if (currentLanguageCode == "en") _lang = 2;
            base.Initialize(requestContext);
        }


        #region RIVATE GET INFO FROM WEB API

        #region SECTION

        /// <summary>
        /// Get the sections list.
        /// </summary>
        /// <returns></returns>
        private async Task<SectionViewData> GetSections(int sectionId)
        {
            SectionViewData sectionViewData = new SectionViewData();
            SectionRequestData request = new SectionRequestData
            {
                SectionDto = new SectionItemData { SectionId = sectionId },
                FindSectionDto = FindSectionItemData.SectionId
            };
            SectionResultData result =
                await WebApiClient.PostFormJsonAsync<SectionRequestData, SectionResultData>(
                    Constant.WebApiControllerAbout, Constant.WebApiFindSections, request);

            if (result != null && result.OperationSuccess && result.SectionDto != null)
            {
                SectionTranslationRequestData findSectionTranslationRequest = new SectionTranslationRequestData()
                {
                    SectionTranslationDto = new SectionTranslationItemData { SectionId = sectionId },
                    FindSectionTranslationDto = FindSectionTranslationItemData.SectionId
                };
                SectionTranslationResultData resultSectionTranslation =
                    await WebApiClient.PostFormJsonAsync<SectionTranslationRequestData, SectionTranslationResultData>(
                        Constant.WebApiControllerAbout, Constant.WebApiFindSectionTranslations,
                        findSectionTranslationRequest);
                if (resultSectionTranslation != null && resultSectionTranslation.OperationSuccess && resultSectionTranslation.SectionTranslationDtoList != null)
                {
                    sectionViewData.SectionTranslationsList = resultSectionTranslation.SectionTranslationDtoList
                        .Where(s => s.LanguageId == _lang).ToList();
                    sectionViewData.Section = result.SectionDto;
                }
            }
            return sectionViewData;
        }
        #endregion

        #region SECTION PARAGRAPHS

        /// <summary>
        /// Get the paragraphe of the section.
        /// </summary>
        /// <returns></returns>
        private async Task<ParagraphsViewData> GetParagraphs(int sectionId)
        {
            SectionParagraphRequestData findSectionParagraphRequestData = new SectionParagraphRequestData
            {
                SectionParagraphDto = new SectionParagraphItemData { SectionId = sectionId },
                FindSectionParagraphDto = FindSectionParagraphItemData.SectionId
            };

            SectionParagraphResultData sectionParagraphResultData =
                await WebApiClient.PostFormJsonAsync<SectionParagraphRequestData, SectionParagraphResultData>(
                    Constant.WebApiControllerAbout, Constant.WebApiFindSectionParagraphs,
                    findSectionParagraphRequestData);

            ParagraphsViewData paragraphsViewData = new ParagraphsViewData
            {
                Paragraphs = new List<ParagraphViewData>()
            };
            List<ParagraphViewData> paragraphsList = new List<ParagraphViewData>();

            if (sectionParagraphResultData == null || !sectionParagraphResultData.OperationSuccess ||
                sectionParagraphResultData.SectionParagraphDtoList == null) return paragraphsViewData;
            foreach (var paragraphDto in sectionParagraphResultData.SectionParagraphDtoList)
            {
                ParagraphViewData paragraph = new ParagraphViewData
                {
                    TranslationsList = new List<SectionParagraphTranslationItemData>(),
                    Paragraph = paragraphDto
                };

                paragraph.TranslationsList = await GetParagraphTranslations(paragraphDto.ParagraphId);
                paragraphsList.Add(paragraph);
            }

            paragraphsViewData.Paragraphs = paragraphsList;
            return paragraphsViewData;
        }

        /// <summary>
        /// Find the paragraph translations
        /// </summary>
        /// <param name="paragraphId">the section id to search.</param>
        /// <returns>the transalations</returns>
        private async Task<List<SectionParagraphTranslationItemData>> GetParagraphTranslations(int paragraphId)
        {
            List<SectionParagraphTranslationItemData>
                translationsList = new List<SectionParagraphTranslationItemData>();
            SectionParagraphTranslationRequestData findSectionParagraphTranslationRequest =
                new SectionParagraphTranslationRequestData()
                {
                    SectionParagraphTranslationDto =
                        new SectionParagraphTranslationItemData { ParagraphId = paragraphId },
                    FindSectionParagraphTranslationDto = FindSectionParagraphTranslationItemData.SectionParagraphId
                };

            SectionParagraphTranslationResultData sectionParagraphTranslationResultData =
                await WebApiClient
                    .PostFormJsonAsync<SectionParagraphTranslationRequestData, SectionParagraphTranslationResultData>(
                        Constant.WebApiControllerAbout, Constant.WebApiFindSectionParagraphTranslations,
                        findSectionParagraphTranslationRequest);
            if (sectionParagraphTranslationResultData != null &&
                sectionParagraphTranslationResultData.OperationSuccess &&
                sectionParagraphTranslationResultData.SectionParagraphTranslationDtoList != null)
            {
                translationsList.AddRange(sectionParagraphTranslationResultData.SectionParagraphTranslationDtoList
                    .Where(p => p.LanguageId == _lang).ToList());
            }

            return translationsList;
        }

        #endregion

        #region SECTION FILE

        /// <summary>
        /// Get the paragraphe of the section.
        /// </summary>
        /// <returns></returns>
        private async Task<FilesViewData> GetFiles(int sectionId)
        {
            SectionFileRequestData findSectionFileRequestData = new SectionFileRequestData
            {
                SectionFileDto = new SectionFileItemData { SectionId = sectionId },
                FindSectionFileDto = FindSectionFileItemData.SectionId
            };

            SectionFileResultData sectionFileResultData =
                await WebApiClient.PostFormJsonAsync<SectionFileRequestData, SectionFileResultData>(
                    Constant.WebApiControllerAbout, Constant.WebApiFindSectionFiles, findSectionFileRequestData);
            List<FileViewData> filesList = new List<FileViewData>();

            if (sectionFileResultData != null && sectionFileResultData.OperationSuccess && sectionFileResultData.SectionFileDtoList != null)
            {
                foreach (var fileDto in sectionFileResultData.SectionFileDtoList)
                {
                    FileViewData file = new FileViewData
                    {
                        TranslationsList = new List<SectionFileTranslationItemData>(),
                        File = fileDto
                    };

                    file.TranslationsList = await GetFileTranslations(fileDto.SectionFileId);
                    filesList.Add(file);
                }
            }

            FilesViewData filesViewData = new FilesViewData { Files = filesList };
            return filesViewData;
        }


        /// <summary>
        /// Find the file translations
        /// </summary>
        /// <param name="sectionFileId">the file id to search.</param>
        /// <returns>the transalations</returns>
        private async Task<List<SectionFileTranslationItemData>> GetFileTranslations(int sectionFileId)
        {
            List<SectionFileTranslationItemData> translationsList = new List<SectionFileTranslationItemData>();
            SectionFileTranslationRequestData findSectionFileTranslationRequest = new SectionFileTranslationRequestData
            {
                SectionFileTranslationDto = new SectionFileTranslationItemData { SectionFileId = sectionFileId },
                FindSectionFileTranslationDto = FindSectionFileTranslationItemData.SectionFileId
            };

            SectionFileTranslationResultData sectionFileTranslationResultData =
                await WebApiClient
                    .PostFormJsonAsync<SectionFileTranslationRequestData, SectionFileTranslationResultData>(
                        Constant.WebApiControllerAbout, Constant.WebApiFindSectionFileTranslations,
                        findSectionFileTranslationRequest);
            if (sectionFileTranslationResultData != null && sectionFileTranslationResultData.OperationSuccess && sectionFileTranslationResultData.SectionFileTranslationDtoList != null)
            {
                translationsList.AddRange(sectionFileTranslationResultData.SectionFileTranslationDtoList);
            }
            return translationsList;
        }

        #endregion

        #region PARTNERS
        /// <summary>
        /// Get Partners
        /// </summary>
        /// <returns></returns>
        private async Task<PartnersViewData> GetPartners()
        {
            PartnersViewData partnerViewData = new PartnersViewData();
            PartnerResultData result =
                await WebApiClient.GetAsync<PartnerResultData>(Constant.WebApiControllerPartners,
                    Constant.WebApiPartnerList);
            if (result?.PartnerDtoList != null && result.OperationSuccess)
            {
                partnerViewData.Partners = result.PartnerDtoList;
            }
            return partnerViewData;
        }


        #endregion

        #region NEWS

        /// <summary>
        /// Get the news list.
        /// </summary>
        /// <returns></returns>
        private async Task<NewsViewDatas> GetNews()
        {
            NewsResultData newsResultData =
                await WebApiClient.GetAsync<NewsResultData>(Constant.WebApiControllerNews, Constant.WebApiNewsList);
            List<NewsViewData> newsViewDataList = new List<NewsViewData>();

            if (newsResultData == null || !newsResultData.OperationSuccess ||
                newsResultData.NewsDtoList == null) return null;
            foreach (var newsDto in newsResultData.NewsDtoList)
            {
                NewsViewData newsViewData = new NewsViewData
                {
                    TranslationsList = new List<NewsTranslationItemData>(),
                    News = newsDto
                };
                newsViewData.TranslationsList = await GetNewsTranslations(newsDto.NewsId);
                newsViewDataList.Add(newsViewData);
            }
            NewsViewDatas newlistdatas = new NewsViewDatas { NewsViewDataList = newsViewDataList };
            return newlistdatas;
        }

        /// <summary>
        /// Get the news translation list.
        /// </summary>
        /// <param name="newsId">the news id.</param>
        /// <returns></returns>
        private async Task<List<NewsTranslationItemData>> GetNewsTranslations(int newsId)
        {
            List<NewsTranslationItemData> translationsList = new List<NewsTranslationItemData>();
            NewsTranslationRequestData findNewsTranslationRequest = new NewsTranslationRequestData
            {
                NewsTranslationDto = new NewsTranslationItemData { NewsId = newsId },
                FindNewsTranslationDto = FindNewsTranslationItemData.NewsId
            };
            NewsTranslationResultData resultNewsTranslation =
                await WebApiClient.PostFormJsonAsync<NewsTranslationRequestData, NewsTranslationResultData>(
                    Constant.WebApiControllerNews, Constant.WebApiFindNewsTranslations, findNewsTranslationRequest);
            if (resultNewsTranslation != null && resultNewsTranslation.OperationSuccess &&
                resultNewsTranslation.NewsTranslationDtoList != null)
            {
                translationsList.AddRange(resultNewsTranslation.NewsTranslationDtoList.Where(n => n.LanguageId == _lang)
                    .ToList());
            }
            return translationsList;
        }

        #endregion


        #region PRIVATE STEP METHODS
        /// <summary>
        /// Get the list of the steps using web api.
        /// </summary>
        /// <returns>the list of the steps.</returns>
        private async Task<StepsViewData> GetStepsList()
        {
            StepsViewData stepsViewData = new StepsViewData { Steps = new List<StepViewData>() };
            StepResultData stepResultData =
                await WebApiClient.GetAsync<StepResultData>(Constant.WebApiControllerSteps, Constant.WebApiStepList);

            if (stepResultData == null || !stepResultData.OperationSuccess ||
                stepResultData.StepDtoList == null) return stepsViewData;

            foreach (var stepItem in stepResultData.StepDtoList.OrderByDescending(s => s.StepDate).ToList())
            {
                StepViewData step = new StepViewData
                {
                    ParagraphsItemData = await GetStepParagraphs(stepItem.StepId),
                    Step = stepItem
                };
                stepsViewData.Steps.Add(step);
            }
            return stepsViewData;
        }

        /// <summary>
        /// Get the list of the paragraphs.
        /// </summary>
        /// <param name="stepId">the step id.</param>
        /// <returns>paragraph return</returns>
        private async Task<List<StepParagraphItemData>> GetStepParagraphs(int stepId = 0)
        {
            List<StepParagraphItemData> stepParagraphItemDataList = new List<StepParagraphItemData>();
            if (stepId == 0) return stepParagraphItemDataList;

            StepParagraphRequestData request = new StepParagraphRequestData
            {
                StepParagraphDto = new StepParagraphItemData { StepId = stepId },
                FindStepParagraphDto = FindStepParagraphItemData.StepId
            };

            StepParagraphResultData result =
                await WebApiClient.PostFormJsonAsync<StepParagraphRequestData, StepParagraphResultData>(
                    Constant.WebApiControllerSteps, Constant.WebApiFindStepParagraphs, request);

            if (result == null || !result.OperationSuccess ||
                result.StepParagraphDtoList == null) return stepParagraphItemDataList;

            foreach (var paragraph in result.StepParagraphDtoList)
            {
                StepParagraphItemData paragraphItemData = paragraph;
                paragraphItemData.TranslationItemDataList = await GetStepParagraphTranslations(paragraph.ParagraphId);
                stepParagraphItemDataList.Add(paragraphItemData);

            }
            return stepParagraphItemDataList;
        }

        /// <summary>
        /// Get the stap paragraph translations.
        /// </summary>
        /// <param name="paragraphId">the paragrapraph id</param>
        /// <returns>translation list.</returns>
        private async Task<List<StepParagraphTranslationItemData>> GetStepParagraphTranslations(int paragraphId = 0)
        {
            List<StepParagraphTranslationItemData> translations = new List<StepParagraphTranslationItemData>();
            if (paragraphId == 0) { return translations; }
            StepParagraphTranslationRequestData request = new StepParagraphTranslationRequestData
            {
                FindStepParagraphTranslationDto = FindStepParagraphTranslationItemData.StepParagraphId,
                StepParagraphTranslationDto = new StepParagraphTranslationItemData { ParagraphId = paragraphId }
            };

            StepParagraphTranslationResultData result =
                await WebApiClient
                    .PostFormJsonAsync<StepParagraphTranslationRequestData, StepParagraphTranslationResultData>(
                        Constant.WebApiControllerSteps, Constant.WebApiFindStepParagraphTranslation, request);
            if (result == null || !result.OperationSuccess ||
                result.StepParagraphTranslationDtoList == null) return translations;

            foreach (var translation in result.StepParagraphTranslationDtoList.Where(t => t.LanguageId == _lang)
                .ToList())
            {
                translations.Add(translation);
            }
            return translations;
        }

        #endregion

        #endregion
    }
}
