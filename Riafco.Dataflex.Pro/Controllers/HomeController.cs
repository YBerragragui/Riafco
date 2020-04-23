using Riafco.Dataflex.Pro.GlobalResources;
using Riafco.Dataflex.Pro.GlobalResources.Shared.newsletter;
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
using Riafco.Dataflex.Pro.Models.Offices.ItemData;
using Riafco.Dataflex.Pro.Models.Offices.ItemData.Enum;
using Riafco.Dataflex.Pro.Models.Offices.RequestData;
using Riafco.Dataflex.Pro.Models.Offices.ResultData;
using Riafco.Dataflex.Pro.Models.Offices.ViewData;
using Riafco.Dataflex.Pro.Models.Partners.ResultData;
using Riafco.Dataflex.Pro.Models.Partners.ViewData;
using Riafco.Framework.Dataflex.pro.Web.ActionResult;
using Riafco.Framework.Dataflex.pro.Web.AjaxComponent;
using Riafco.Framework.Dataflex.pro.Web.WebApi;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace Riafco.Dataflex.Pro.Controllers
{
    /// <summary>
    /// The Home page controller.
    /// </summary>
    public class HomeController : BaseController
    {
        /// <summary>
        /// The current lang.
        /// </summary>
        private int _lang = 1;

        /// <summary>
        /// The index page.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            HomeModel homeModel = new HomeModel
            {
                SubscriberFormData = new SubscriberFormData(),
                OccurrencesViewData = await GetOccurrences(),
                PartnersViewData = await GetPartners(),
                NewsViewDatas = await GetNews(),
            };
            return View(homeModel);
        }

        /// <summary>
        /// Get country IFCL
        /// </summary>
        /// <param name="countryCode">the country code to retrive</param>
        /// <returns></returns>
        public async Task<ActionResult> GetCountry(string countryCode)
        {
            CountryViewData countryViewData = await FindCountriesByCode(countryCode);
            return View("Partial/_Country", countryViewData);
        }

        /// <summary>
        /// Get the list of the countrises.
        /// </summary>
        /// <returns></returns>
        public async Task<JsonResult> GetCountriesMap()
        {
            var countries = await GetCountries();
            var mapCountries = new string[countries.Count][];
            for (int i = 0; i < countries.Count; i++)
            {
                mapCountries[i] = new[]
                {
                    countries[i].Country.CountryShortName.ToLowerInvariant(),
                    countries[i].Country.CountryCode.ToString()
                };
            }
            return Json(mapCountries);
        }

        #region IFCL

        /// <summary>
        /// The Ifcl page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Ifcl(int id)
        {
            IfclModel ifclModel = new IfclModel
            {
                CountryViewData = await FindCountries(id),
                PartnersViewData = await GetPartners(),
                SheetsViewData = await GetSheets(id),
                NewsViewDatas = await GetNews()
            };
            return View(ifclModel);
        }


        #endregion

        #region SHARED METHODS

        /// <summary>
        /// create new subscriber.
        /// </summary>
        /// <param name="subscriberFormData"></param>
        /// <returns></returns>
        [HttpPost, ValidateInput(false)]
        public async Task<OmsJsonResult> CreateSubscribe(SubscriberFormData subscriberFormData)
        {
            JsonReturnData data = new JsonReturnData();
            if (ModelState.IsValid)
            {
                SubscriberRequestData request = subscriberFormData.ToRequestData();
                SubscriberResultData result =
                    await WebApiClient.PostFormJsonAsync<SubscriberRequestData, SubscriberResultData>(
                        Constant.WebApiControllerNewsletters, Constant.WebApiCreateSubscriber, request);
                if (result == null)
                {
                    data.ErrorMessage = SharedResources.ServerError;
                    data.OperationSuccess = false;
                }
                else if (!result.OperationSuccess && result.Errors != null && result.Errors.Count > 0)
                {
                    data.ErrorMessage = result.Errors.First();
                    data.OperationSuccess = false;
                }
                else if (result.OperationSuccess)
                {
                    data.SuccessMessage = NewsletterResources.ResourceManager.GetString("Ok", Thread.CurrentThread.CurrentCulture);
                    data.OperationSuccess = true;
                }
                return new OmsJsonResult(data);
            }
            data = new JsonReturnData
            {
                OperationSuccess = false,
                ErrorMessage = SharedResources.ValidationErrors
            };
            return new OmsJsonResult(data);
        }
        #endregion

        /// <summary>
        /// Initialize the langue.
        /// </summary>
        /// <param name="requestContext">the request to get the langue.</param>
        protected override void Initialize(RequestContext requestContext)
        {
            string currentLanguageCode = requestContext.RouteData.Values["lang"] as string;
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

        #region COUNTRISES

        /// <summary>
        /// Get the list of the countrises.
        /// </summary>
        /// <returns></returns>
        private async Task<List<CountryViewData>> GetCountries()
        {
            CountryResultData countryResultData =
                await WebApiClient.GetAsync<CountryResultData>(Constant.WebApiControllerOffices,
                    Constant.WebApiCountryList);
            List<CountryViewData> countriesList = new List<CountryViewData>();

            if (countryResultData == null || !countryResultData.OperationSuccess ||
                countryResultData.CountryDtoList == null) return countriesList;
            foreach (var countryDto in countryResultData.CountryDtoList)
            {
                CountryViewData country = new CountryViewData
                {
                    TranslationsList = new List<CountryTranslationItemData>(),
                    Country = countryDto
                };
                country.TranslationsList = await GetCountryTranslations(countryDto.CountryId);
                countriesList.Add(country);
            }
            return countriesList;
        }


        /// <summary>
        /// Find country by id.
        /// </summary>
        /// <param name="countryCode">The country name.</param>
        /// <returns>The CountryViewData.</returns>
        private async Task<CountryViewData> FindCountriesByCode(string countryCode)
        {
            CountryRequestData request = new CountryRequestData
            {
                CountryDto = new CountryItemData { CountryShortName = countryCode },
                FindCountryDto = FindCountryItemData.CountryShortName
            };
            CountryResultData result =
                await WebApiClient.PostFormJsonAsync<CountryRequestData, CountryResultData>(
                    Constant.WebApiControllerOffices, Constant.WebApiFindCountries, request);


            CountryViewData countryViewData = new CountryViewData();

            if (result == null || !result.OperationSuccess ||
                result.CountryDtoList == null) return countryViewData;

            countryViewData = new CountryViewData
            {
                TranslationsList = await GetCountryTranslations(result.CountryDto.CountryId),
                Country = result.CountryDto
            };
            return countryViewData;
        }

        /// <summary>
        /// Find country by id.
        /// </summary>
        /// <param name="countryId">The country name.</param>
        /// <returns>The CountryViewData.</returns>
        private async Task<CountryViewData> FindCountries(int countryId)
        {
            CountryRequestData request = new CountryRequestData
            {
                CountryDto = new CountryItemData { CountryId = countryId },
                FindCountryDto = FindCountryItemData.CountryId
            };
            CountryResultData result =
                await WebApiClient.PostFormJsonAsync<CountryRequestData, CountryResultData>(
                    Constant.WebApiControllerOffices, Constant.WebApiFindCountries, request);


            CountryViewData countryViewData = new CountryViewData();

            if (result == null || !result.OperationSuccess ||
                result.CountryDtoList == null) return countryViewData;

            countryViewData = new CountryViewData
            {
                TranslationsList = await GetCountryTranslations(result.CountryDto.CountryId),
                Country = result.CountryDto
            };
            return countryViewData;
        }

        /// <summary>
        /// Find the country translations
        /// </summary>
        /// <param name="countryId">the country id to search.</param>
        /// <returns>the transalations</returns>
        private async Task<List<CountryTranslationItemData>> GetCountryTranslations(int countryId)
        {
            List<CountryTranslationItemData> translationsList = new List<CountryTranslationItemData>();
            CountryTranslationRequestData findCountryTranslationRequest = new CountryTranslationRequestData()
            {
                CountryTranslationDto = new CountryTranslationItemData { CountryId = countryId },
                FindCountryTranslationDto = FindCountryTranslationItemData.CountryId
            };
            CountryTranslationResultData resultCountryTranslation =
                await WebApiClient.PostFormJsonAsync<CountryTranslationRequestData, CountryTranslationResultData>(
                    Constant.WebApiControllerOffices, Constant.WebApiFindCountryTranslations,
                    findCountryTranslationRequest);
            if (resultCountryTranslation != null && resultCountryTranslation.OperationSuccess &&
                resultCountryTranslation.CountryTranslationDtoList != null)
            {
                translationsList.AddRange(resultCountryTranslation.CountryTranslationDtoList
                    .Where(c => c.LanguageId == _lang).ToList());
            }
            return translationsList;
        }

        #endregion

        #region SHEET

        /// <summary>
        /// Get sheet by country
        /// </summary>
        /// <param name="countryId">the country id.</param>
        /// <returns>The sheetViewData</returns>
        private async Task<SheetsViewData> GetSheets(int countryId)
        {
            SheetsViewData sheetsViewData = new SheetsViewData
            {
                Sheets = await GetSheetsList(countryId),
                CountryId = countryId
            };
            return sheetsViewData;
        }

        /// <summary>
        /// Get the sheete of the country .
        /// </summary>
        /// <returns></returns>
        private async Task<List<SheetViewData>> GetSheetsList(int countryId)
        {
            SheetRequestData findSheetRequestData = new SheetRequestData
            {
                SheetDto = new SheetItemData { CountryId = countryId },
                FindSheetDto = FindSheetItemData.CountryId
            };

            SheetResultData sheetResultData = await WebApiClient.PostFormJsonAsync<SheetRequestData, SheetResultData>(Constant.WebApiControllerOffices, Constant.WebApiFindSheets, findSheetRequestData);
            List<SheetViewData> sheetsList = new List<SheetViewData>();

            if (sheetResultData != null && sheetResultData.OperationSuccess && sheetResultData.SheetDtoList != null)
            {
                foreach (var sheetDto in sheetResultData.SheetDtoList)
                {
                    SheetViewData sheet = new SheetViewData
                    {
                        TranslationsList = new List<SheetTranslationItemData>(),
                        Sheet = sheetDto
                    };

                    sheet.TranslationsList = await GetSheetTranslations(sheetDto.SheetId);
                    sheetsList.Add(sheet);
                }
            }
            return sheetsList;
        }


        /// <summary>
        /// Get sheet translations
        /// </summary>
        /// <param name="sheetId"></param>
        /// <returns></returns>
        private async Task<List<SheetTranslationItemData>> GetSheetTranslations(int sheetId)
        {
            List<SheetTranslationItemData> translationsList = new List<SheetTranslationItemData>();
            SheetTranslationRequestData findSheetTranslationRequest = new SheetTranslationRequestData()
            {
                SheetTranslationDto = new SheetTranslationItemData { SheetId = sheetId },
                FindSheetTranslationDto = FindSheetTranslationItemData.SheetId
            };
            SheetTranslationResultData resultSheetTranslation =
                await WebApiClient.PostFormJsonAsync<SheetTranslationRequestData, SheetTranslationResultData>(
                    Constant.WebApiControllerOffices, Constant.WebApiFindSheetTranslations,
                    findSheetTranslationRequest);
            if (resultSheetTranslation != null && resultSheetTranslation.OperationSuccess &&
                resultSheetTranslation.SheetTranslationDtoList != null)
            {
                translationsList.AddRange(resultSheetTranslation.SheetTranslationDtoList
                    .Where(c => c.LanguageId == _lang).ToList());
            }
            return translationsList;
        }

        #endregion

        #endregion
    }
}