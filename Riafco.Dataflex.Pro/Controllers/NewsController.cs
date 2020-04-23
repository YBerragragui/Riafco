using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MvcPaging;
using Riafco.Dataflex.Pro.GlobalResources;
using Riafco.Dataflex.Pro.Models;
using Riafco.Dataflex.Pro.Models.News.ItemData;
using Riafco.Dataflex.Pro.Models.News.ItemData.Enum;
using Riafco.Dataflex.Pro.Models.News.RequestData;
using Riafco.Dataflex.Pro.Models.News.ResultData;
using Riafco.Dataflex.Pro.Models.News.ViewData;
using Riafco.Dataflex.Pro.Models.Newsletters.Assembler;
using Riafco.Dataflex.Pro.Models.Newsletters.FormData;
using Riafco.Dataflex.Pro.Models.Newsletters.RequestData;
using Riafco.Dataflex.Pro.Models.Newsletters.ResultData;
using Riafco.Dataflex.Pro.Models.Occurrences.ItemData;
using Riafco.Dataflex.Pro.Models.Occurrences.ItemData.Enum;
using Riafco.Dataflex.Pro.Models.Occurrences.RequestData;
using Riafco.Dataflex.Pro.Models.Occurrences.ResultData;
using Riafco.Dataflex.Pro.Models.Occurrences.ViewData;
using Riafco.Dataflex.Pro.Models.Partners.ResultData;
using Riafco.Dataflex.Pro.Models.Partners.ViewData;
using Riafco.Framework.Dataflex.pro.Web.ActionResult;
using Riafco.Framework.Dataflex.pro.Web.AjaxComponent;
using Riafco.Framework.Dataflex.pro.Web.WebApi;
using System.Web.Routing;

namespace Riafco.Dataflex.Pro.Controllers
{
    /// <summary>
    /// The newsController class.
    /// </summary>
    public class NewsController : BaseController
    {
        /// <summary>
        /// The lang id.
        /// </summary>
        private int _lang = 1;

        /// <summary>
        /// The index page.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            NewsModel newsModel = new NewsModel
            {
                SubscriberFormData = new SubscriberFormData(),
                OccurrencesViewData = await GetOccurrences(),
                PartnersViewData = await GetPartners(),
                NewsViewDatas = await GetNews(),
            };
            return View(newsModel);
        }

        /// <summary>
        /// The detail page.
        /// </summary>
        /// <param name="id">the news id.</param>
        /// <returns></returns>
        public async Task<ActionResult> Details(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");
            NewsDetailsModel detail = new NewsDetailsModel
            {
                SubscriberFormData = new SubscriberFormData(),
                OccurrencesViewData = await GetOccurrences(),
                PartnersViewData = await GetPartners(),
                NewsViewData = await FindNews(id),
                NewsViewDatas = await GetNews()
            };
            return View(detail);
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
                    newsViewData.TranslationsList.Add(resultNewsTranslation.NewsTranslationDtoList.First(t => t.LanguageId == _lang));
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