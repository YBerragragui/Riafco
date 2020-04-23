using Riafco.Dataflex.Pro.Models;
using Riafco.Dataflex.Pro.Models.Activities.ItemData;
using Riafco.Dataflex.Pro.Models.Activities.ItemData.Enum;
using Riafco.Dataflex.Pro.Models.Activities.RequestData;
using Riafco.Dataflex.Pro.Models.Activities.ResultData;
using Riafco.Dataflex.Pro.Models.Activities.ViewData;
using Riafco.Dataflex.Pro.Models.News.ItemData;
using Riafco.Dataflex.Pro.Models.News.ItemData.Enum;
using Riafco.Dataflex.Pro.Models.News.RequestData;
using Riafco.Dataflex.Pro.Models.News.ResultData;
using Riafco.Dataflex.Pro.Models.News.ViewData;
using Riafco.Dataflex.Pro.Models.Newsletters.FormData;
using Riafco.Dataflex.Pro.Models.Occurrences.ItemData;
using Riafco.Dataflex.Pro.Models.Occurrences.ItemData.Enum;
using Riafco.Dataflex.Pro.Models.Occurrences.RequestData;
using Riafco.Dataflex.Pro.Models.Occurrences.ResultData;
using Riafco.Dataflex.Pro.Models.Occurrences.ViewData;
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
    /// The activites controller.
    /// </summary>
    public class ActivitiesController : BaseController
    {
        /// <summary>
        /// The current lang.
        /// </summary>
        private int _lang = 1;

        /// <summary>
        /// The indecx page.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            ActivitiesModel activitiesModel = new ActivitiesModel
            {
                SubscriberFormData = new SubscriberFormData(),
                OccurrencesViewData = await GetOccurrences(),
                ActivitiesViewData = await GetActivities(),
                PartnersViewData = await GetPartners(),
                NewsViewDatas = await GetNews()
            };
            return View(activitiesModel);
        }

        /// <summary>
        /// The details page.
        /// </summary>
        /// <param name="id">the activity id.</param>
        /// <returns></returns>
        public async Task<ActionResult> Details(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");

            ActivityModel activityModel = new ActivityModel
            {
                ParagraphsViewData = await GetActivityParagraph(id),
                SubscriberFormData = new SubscriberFormData(),
                OccurrencesViewData = await GetOccurrences(),
                ActivityViewData = await FindActivity(id),
                PartnersViewData = await GetPartners(),
                FilesViewData = await GetFiles(id),
                NewsViewDatas = await GetNews()
            };
            return View(activityModel);
        }

        /// <summary>
        /// Initialize the langue.
        /// </summary>
        /// <param name="requestContext">the request to get the langue.</param>
        protected override void Initialize(RequestContext requestContext)
        {
            string currentLanguageCode = (string)requestContext.RouteData.Values["lang"];
            if (currentLanguageCode == "en") this._lang = 2;
            base.Initialize(requestContext);
        }

        #region RIVATE GET INFO FROM WEB API

        #region ACTIVITIES
        /// <summary>
        /// Get the activites list.
        /// </summary>
        /// <returns></returns>
        public async Task<ActivityViewData> FindActivity(int idActivity)
        {
            ActivityViewData activityViewData = new ActivityViewData
            {
                TranslationsList = new List<ActivityTranslationItemData>(),
                Activity = new ActivityItemData()
            };
            ActivityRequestData findActivityRequest = new ActivityRequestData
            {
                ActivityDto = new ActivityItemData { ActivityId = idActivity },
                FindActivityDto = FindActivityItemData.ActivityId
            };
            ActivityResultData resultActivity = await WebApiClient.PostFormJsonAsync<ActivityRequestData, ActivityResultData>(Constant.WebApiControllerActivities, Constant.WebApiFindActivities, findActivityRequest);

            if (resultActivity != null && resultActivity.OperationSuccess && resultActivity.ActivityDto != null)
            {
                activityViewData.Activity = resultActivity.ActivityDto;
                ActivityTranslationRequestData findActivityTranslationRequest = new ActivityTranslationRequestData()
                {
                    ActivityTranslationDto = new ActivityTranslationItemData { ActivityId = idActivity },
                    FindActivityTranslationDto = FindActivityTranslationItemData.ActivityId
                };
                ActivityTranslationResultData resultActivityTranslation = await WebApiClient.PostFormJsonAsync<ActivityTranslationRequestData, ActivityTranslationResultData>(Constant.WebApiControllerActivities, Constant.WebApiFindActivityTranslations, findActivityTranslationRequest);
                if (resultActivityTranslation != null && resultActivityTranslation.OperationSuccess && resultActivityTranslation.ActivityTranslationDtoList != null)
                {
                    activityViewData.TranslationsList.Add(resultActivityTranslation.ActivityTranslationDtoList.First(t => t.LanguageId == _lang));
                }
            }
            return activityViewData;
        }

        /// <summary>
        /// Get the activites list.
        /// </summary>
        /// <returns></returns>
        public async Task<ActivitiesViewData> GetActivities()
        {
            List<ActivityViewData> activities = await GetActivitiesList();
            ActivitiesViewData activitiesViewData = new ActivitiesViewData { Activities = activities };
            return (activitiesViewData);
        }

        /// <summary>
        /// Get the list of the activites.
        /// </summary>
        /// <returns></returns>
        private async Task<List<ActivityViewData>> GetActivitiesList()
        {
            ActivityResultData activityResultData = await WebApiClient.GetAsync<ActivityResultData>(Constant.WebApiControllerActivities, Constant.WebApiActivityList);
            List<ActivityViewData> activitiesList = new List<ActivityViewData>();

            if (activityResultData == null || !activityResultData.OperationSuccess ||
                activityResultData.ActivityDtoList == null) return activitiesList;
            foreach (var activityDto in activityResultData.ActivityDtoList)
            {
                ActivityViewData activity = new ActivityViewData
                {
                    TranslationsList = new List<ActivityTranslationItemData>(),
                    Activity = activityDto
                };

                activity.TranslationsList = await GetActivityTranslations(activityDto.ActivityId);
                activitiesList.Add(activity);
            }
            return activitiesList;
        }

        /// <summary>
        /// Get the activites translations.
        /// </summary>
        /// <param name="activityId">the activite id.</param>
        /// <returns></returns>
        private async Task<List<ActivityTranslationItemData>> GetActivityTranslations(int activityId)
        {
            List<ActivityTranslationItemData> translationsList = new List<ActivityTranslationItemData>();
            ActivityTranslationRequestData findActivityTranslationRequest = new ActivityTranslationRequestData()
            {
                ActivityTranslationDto = new ActivityTranslationItemData { ActivityId = activityId },
                FindActivityTranslationDto = FindActivityTranslationItemData.ActivityId
            };
            ActivityTranslationResultData resultActivityTranslation = await WebApiClient.PostFormJsonAsync<ActivityTranslationRequestData, ActivityTranslationResultData>(Constant.WebApiControllerActivities, Constant.WebApiFindActivityTranslations, findActivityTranslationRequest);
            if (resultActivityTranslation != null && resultActivityTranslation.OperationSuccess && resultActivityTranslation.ActivityTranslationDtoList != null)
            {
                translationsList.AddRange(resultActivityTranslation.ActivityTranslationDtoList.Where(c => c.LanguageId == _lang).ToList());
            }
            return translationsList;
        }


        #endregion

        #region PARAGRAPHS
        /// <summary>
        /// Get the list of the paragraph
        /// </summary>
        /// <param name="activityId">the activity id</param>
        /// <returns></returns>
        private async Task<ParagraphsViewData> GetActivityParagraph(int activityId)
        {
            ActivityParagraphResultData activityParagraphResultData = await WebApiClient.GetAsync<ActivityParagraphResultData>(Constant.WebApiControllerActivities, Constant.WebApiActivityParagraphList);
            List<ParagraphViewData> activityparagraphList = new List<ParagraphViewData>();

            foreach (var activityParagraphDto in activityParagraphResultData.ActivityParagraphDtoList)
            {
                ParagraphViewData activityparagraph = new ParagraphViewData
                {
                    TranslationsList = new List<ActivityParagraphTranslationItemData>(),
                    Paragraph = activityParagraphDto
                };

                if (activityParagraphDto.ActivityId == activityId)
                {
                    activityparagraph.TranslationsList = await GetActivityParagraphTranslation(activityParagraphDto.ParagraphId);
                    activityparagraphList.Add(activityparagraph);
                }
            }
            ParagraphsViewData paragraphsViewData = new ParagraphsViewData { Paragraphs = activityparagraphList };
            return paragraphsViewData;
        }

        /// <summary>
        /// Get the paragraphs translations
        /// </summary>
        /// <param name="paragraphid">the paragraph id.</param>
        /// <returns></returns>
        private async Task<List<ActivityParagraphTranslationItemData>> GetActivityParagraphTranslation(int paragraphid)
        {
            List<ActivityParagraphTranslationItemData> translationsList = new List<ActivityParagraphTranslationItemData>();
            ActivityParagraphTranslationRequestData findActivityParagraphTranslationRequest = new ActivityParagraphTranslationRequestData()
            {
                ActivityParagraphTranslationDto = new ActivityParagraphTranslationItemData { ParagraphId = paragraphid },
                FindActivityParagraphTranslationDto = FindActivityParagraphTranslationItemData.ActivityParagraphId
            };

            ActivityParagraphTranslationResultData resultActivityParagraphTranslation = await WebApiClient.PostFormJsonAsync<ActivityParagraphTranslationRequestData, ActivityParagraphTranslationResultData>(Constant.WebApiControllerActivities, Constant.WebApiFindActivityParagraphTranslations, findActivityParagraphTranslationRequest);
            if (resultActivityParagraphTranslation.OperationSuccess &&
                resultActivityParagraphTranslation.ActivityParagraphTranslationDtoList != null)
            {
                translationsList.AddRange(resultActivityParagraphTranslation.ActivityParagraphTranslationDtoList.Where(c => c.LanguageId == _lang).ToList());
            }
            return translationsList;
        }
        #endregion

        #region FILES

        /// <summary>
        /// Get the file list.
        /// </summary>
        /// <param name="activityId">the activity id</param>
        /// <returns></returns>
        private async Task<FilesViewData> GetFiles(int activityId)
        {
            ActivityFileResultData activityFileResultData = await WebApiClient.GetAsync<ActivityFileResultData>(Constant.WebApiControllerActivities, Constant.WebApiActivityFileList);
            List<FileViewData> activityfileList = new List<FileViewData>();
            foreach (var activityFileDto in activityFileResultData.ActivityFileDtoList)
            {
                FileViewData activityfile = new FileViewData
                {
                    TranslationsList = new List<ActivityFileTranslationItemData>(),
                    File = activityFileDto
                };

                if (activityFileDto.ActivityId == activityId)
                {
                    activityfile.TranslationsList = await GetFileTranslations(activityFileDto.ActivityFileId);
                    activityfileList.Add(activityfile);
                }
            }

            FilesViewData filesViewData = new FilesViewData { Files = activityfileList };
            return filesViewData;
        }

        /// <summary>
        /// Get the file translations
        /// </summary>
        /// <param name="fileId">the file id.</param>
        /// <returns></returns>
        private async Task<List<ActivityFileTranslationItemData>> GetFileTranslations(int fileId)
        {
            List<ActivityFileTranslationItemData> translationsList = new List<ActivityFileTranslationItemData>();
            ActivityFileTranslationRequestData findFileTranslationRequest = new ActivityFileTranslationRequestData()
            {
                ActivityFileTranslationDto = new ActivityFileTranslationItemData { ActivityFileId = fileId },
                FindActivityFileTranslationDto = FindActivityFileTranslationItemData.ActivityFileId
            };
            ActivityFileTranslationResultData resultFileTranslation =
                await WebApiClient.PostFormJsonAsync<ActivityFileTranslationRequestData, ActivityFileTranslationResultData>(
                    Constant.WebApiControllerActivities, Constant.WebApiFindActivityFileTranslations,
                    findFileTranslationRequest);
            if (resultFileTranslation != null && resultFileTranslation.OperationSuccess &&
                resultFileTranslation.ActivityFileTranslationDtoList != null)
            {
                translationsList.AddRange(resultFileTranslation.ActivityFileTranslationDtoList
                    .Where(o => o.LanguageId == _lang).ToList());
            }
            return translationsList;
        }
        #endregion

        #region OCCURENCES
        /// <summary>
        /// Get the occurences list.
        /// </summary>
        /// <returns></returns>
        private async Task<OccurrencesViewData> GetOccurrences()
        {
            OccurrenceResultData occurrenceResultData =
                await WebApiClient.GetAsync<OccurrenceResultData>(Constant.WebApiControllerOccurrences,
                    Constant.WebApiOccurrenceList);
            List<OccurrenceViewData> occurrencesList = new List<OccurrenceViewData>();

            if (occurrenceResultData == null || !occurrenceResultData.OperationSuccess ||
                occurrenceResultData.OccurrenceDtoList == null) return null;
            foreach (var occurrenceDto in occurrenceResultData.OccurrenceDtoList)
            {
                OccurrenceViewData occurrence = new OccurrenceViewData
                {
                    TranslationsList = new List<OccurrenceTranslationItemData>(),
                    Occurrence = occurrenceDto
                };
                occurrence.TranslationsList = await GetOccurrenceTranslations(occurrenceDto.OccurrenceId);
                occurrencesList.Add(occurrence);
            }

            OccurrencesViewData occurrencesViewData = new OccurrencesViewData { Occurrences = occurrencesList };
            return occurrencesViewData;
        }

        /// <summary>
        /// Find the occurrence translations
        /// </summary>
        /// <param name="occurrenceId">the occurrence id to search.</param>
        /// <returns>the transalations</returns>
        private async Task<List<OccurrenceTranslationItemData>> GetOccurrenceTranslations(int occurrenceId)
        {
            List<OccurrenceTranslationItemData> translationsList = new List<OccurrenceTranslationItemData>();
            OccurrenceTranslationRequestData findOccurrenceTranslationRequest = new OccurrenceTranslationRequestData()
            {
                OccurrenceTranslationDto = new OccurrenceTranslationItemData { OccurrenceId = occurrenceId },
                FindOccurrenceTranslationDto = FindOccurrenceTranslationItemData.OccurrenceId
            };
            OccurrenceTranslationResultData resultOccurrenceTranslation =
                await WebApiClient.PostFormJsonAsync<OccurrenceTranslationRequestData, OccurrenceTranslationResultData>(
                    Constant.WebApiControllerOccurrences, Constant.WebApiFindOccurrenceTranslations,
                    findOccurrenceTranslationRequest);
            if (resultOccurrenceTranslation != null && resultOccurrenceTranslation.OperationSuccess &&
                resultOccurrenceTranslation.OccurrenceTranslationDtoList != null)
            {
                translationsList.AddRange(resultOccurrenceTranslation.OccurrenceTranslationDtoList
                    .Where(o => o.LanguageId == _lang).ToList());
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
        /// Find the news by id.
        /// </summary>
        /// <param name="newsId">the news id to find.</param>
        /// <returns></returns>
        private async Task<NewsViewData> FindNews(int newsId)
        {
            NewsViewData newsViewData = new NewsViewData()
            {
                TranslationsList = new List<NewsTranslationItemData>(),
                News = new NewsItemData()
            };
            NewsRequestData findNewsRequest = new NewsRequestData
            {
                NewsDto = new NewsItemData { NewsId = newsId },
                FindNewsDto = FindNewsItemData.NewsId
            };
            NewsResultData resultNews = await WebApiClient.PostFormJsonAsync<NewsRequestData, NewsResultData>(Constant.WebApiControllerNews, Constant.WebApiFindNews, findNewsRequest);

            if (resultNews != null && resultNews.OperationSuccess && resultNews.NewsDto != null)
            {
                newsViewData.News = resultNews.NewsDto;
                NewsTranslationRequestData findNewsTranslationRequest = new NewsTranslationRequestData()
                {
                    NewsTranslationDto = new NewsTranslationItemData { NewsId = newsId },
                    FindNewsTranslationDto = FindNewsTranslationItemData.NewsId
                };
                NewsTranslationResultData resultNewsTranslation = await WebApiClient.PostFormJsonAsync<NewsTranslationRequestData, NewsTranslationResultData>(Constant.WebApiControllerNews, Constant.WebApiFindNewsTranslations, findNewsTranslationRequest);
                if (resultNewsTranslation != null && resultNewsTranslation.OperationSuccess && resultNewsTranslation.NewsTranslationDtoList != null)
                {
                    foreach (var translation in resultNewsTranslation.NewsTranslationDtoList)
                    {
                        newsViewData.TranslationsList.Add(translation);
                    }
                }
            }
            return newsViewData;
        }


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

        #endregion
    }
}