using Riafco.Dataflex.Pro.Models;
using Riafco.Dataflex.Pro.Models.News.ItemData;
using Riafco.Dataflex.Pro.Models.News.ItemData.Enum;
using Riafco.Dataflex.Pro.Models.News.RequestData;
using Riafco.Dataflex.Pro.Models.News.ResultData;
using Riafco.Dataflex.Pro.Models.News.ViewData;
using Riafco.Dataflex.Pro.Models.Occurrences.ItemData;
using Riafco.Dataflex.Pro.Models.Occurrences.ItemData.Enum;
using Riafco.Dataflex.Pro.Models.Occurrences.RequestData;
using Riafco.Dataflex.Pro.Models.Occurrences.ResultData;
using Riafco.Dataflex.Pro.Models.Occurrences.ViewData;
using Riafco.Dataflex.Pro.Models.Partners.ResultData;
using Riafco.Dataflex.Pro.Models.Partners.ViewData;
using Riafco.Dataflex.Pro.Models.Ressources.FormData;
using Riafco.Dataflex.Pro.Models.Ressources.ItemData;
using Riafco.Dataflex.Pro.Models.Ressources.ItemData.Enum;
using Riafco.Dataflex.Pro.Models.Ressources.RequestData;
using Riafco.Dataflex.Pro.Models.Ressources.ResultData;
using Riafco.Dataflex.Pro.Models.Ressources.ViewData;
using Riafco.Framework.Dataflex.pro.Web.WebApi;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace Riafco.Dataflex.Pro.Controllers
{
    /// <summary>
    /// The ResourcesController class.
    /// </summary>
    public class ResourcesController : BaseController
    {
        /// <summary>
        /// The lang id.
        /// </summary>
        private int _lang = 1;

        /// <summary>
        /// The ressources page.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            FilterFormData filterFormData = new FilterFormData();

            //authors
            AuthorsViewData authorsViewData = await GetAuthors();

            List<SelectListItem> authors = (from author in authorsViewData.Authors
                                            where author?.Author != null
                                            select new SelectListItem
                                            {
                                                Text = author.Author.AuthorFirstName + $@" " + author.Author.AuthorLastName,
                                                Value = author.Author.AuthorId.ToString()
                                            }).ToList();
            ViewBag.Authors = authors;

            //Themes : 
            ThemesViewData themesViewData = await GetThemes();
            List<SelectListItem> themes = (from theme in themesViewData.Themes
                                           where theme?.Theme != null
                                           select new SelectListItem()
                                           {
                                               Text = theme.TranslationsList.First(t => t.LanguageId == _lang).ThemeName,
                                               Value = theme.Theme.ThemeId.ToString(),
                                           }).ToList();
            ViewBag.Themes = themes;

            //Areas
            AreasViewData areasViewData = await GetAreas();

            List<SelectListItem> areas = (from area in areasViewData.Areas
                                          where area?.Area != null
                                          select new SelectListItem
                                          {
                                              Text = area.TranslationsList.First(t => t.LanguageId == _lang).AreaName,
                                              Value = area.Area.AreaId.ToString()
                                          }).ToList();
            ViewBag.Areas = areas;

            RessourcesModel ressourcesModel = new RessourcesModel
            {
                PublicationsViewData = await GetPublications(),
                OccurrencesViewData = await GetOccurrences(),
                PartnersViewData = await GetPartners(),
                NewsViewDatas = await GetNews(),
                FilterFormData = filterFormData
            };
            return View(ressourcesModel);

        }

        /// <summary>
        /// Sors publications.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> SortPublications(FilterFormData filterFormData)
        {
            PublicationsViewData publicationsViewDataFiltred = new PublicationsViewData { Publications = new List<PublicationViewData>() };
            PublicationsViewData publicationsViewData = await GetPublications();
            foreach (var publicationViewData in publicationsViewData.Publications)
            {
                //if (publicationViewData.Publication.AuthorId == filterFormData.AuthorId)
                //{
                //    publicationsViewDataFiltred.Publications.Add(publicationViewData);
                //}

                if (publicationViewData.ThemesViewData.Themes.Any(t => t.Theme.ThemeId == filterFormData.ThemeId))
                {
                    publicationsViewDataFiltred.Publications.Add(publicationViewData);
                }
            }
            return View("_Publication", publicationsViewDataFiltred);
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

        #region PRIVATE METHODS

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

        #region AREAS

        /// <summary>
        /// Get Area
        /// </summary>
        /// <returns></returns>
        private async Task<AreasViewData> GetAreas()
        {
            AreaResultData areaResultData =
                await WebApiClient.GetAsync<AreaResultData>(Constant.WebApiControllerRessources, Constant.WebApiAreaList);
            List<AreaViewData> areaList = new List<AreaViewData>();

            if (areaResultData == null || !areaResultData.OperationSuccess ||
                areaResultData.AreaDtoList == null) return null;
            foreach (var areaDto in areaResultData.AreaDtoList)
            {
                AreaViewData area = new AreaViewData
                {
                    TranslationsList = new List<AreaTranslationItemData>(),
                    Area = areaDto
                };
                area.TranslationsList = await GetAreaTranslations(areaDto.AreaId);
                areaList.Add(area);
            }
            AreasViewData areaslistdata = new AreasViewData { Areas = areaList };
            return areaslistdata;
        }


        /// <summary>
        /// Get Area Translations
        /// </summary>
        /// <param name="areaId"></param>
        /// <returns></returns>
        private async Task<List<AreaTranslationItemData>> GetAreaTranslations(int areaId)
        {
            List<AreaTranslationItemData> translationsList = new List<AreaTranslationItemData>();
            AreaTranslationRequestData findAreaTranslationRequest = new AreaTranslationRequestData()
            {
                AreaTranslationDto = new AreaTranslationItemData { AreaId = areaId },
                FindAreaTranslationDto = FindAreaTranslationItemData.AreaId
            };
            AreaTranslationResultData resultAreaTranslation =
                await WebApiClient.PostFormJsonAsync<AreaTranslationRequestData, AreaTranslationResultData>(
                    Constant.WebApiControllerRessources, Constant.WebApiFindAreaTranslations, findAreaTranslationRequest);
            if (resultAreaTranslation != null && resultAreaTranslation.OperationSuccess &&
                resultAreaTranslation.AreaTranslationDtoList != null)
            {
                translationsList.AddRange(resultAreaTranslation.AreaTranslationDtoList.Where(n => n.LanguageId == _lang)
                    .ToList());
            }
            return translationsList;
        }
        #endregion

        #region PUBLICATIONS

        /// <summary>
        /// Get all publications
        /// </summary>
        /// <returns></returns>
        private async Task<PublicationsViewData> GetPublications()
        {
            PublicationResultData publicationResultData =
                await WebApiClient.GetAsync<PublicationResultData>(Constant.WebApiControllerRessources, Constant.WebApiPublicationList);
            List<PublicationViewData> publicationList = new List<PublicationViewData>();

            if (publicationResultData == null || !publicationResultData.OperationSuccess ||
                publicationResultData.PublicationDtoList == null) return null;
            foreach (var publicationDto in publicationResultData.PublicationDtoList)
            {
                PublicationViewData publication = new PublicationViewData
                {
                    TranslationsList = await GetpublicationTranslations(publicationDto.PublicationId),
                    ThemesViewData = await GetPublicationThemes(publicationDto.PublicationId),
                    Publication = publicationDto
                };
                publicationList.Add(publication);
            }
            PublicationsViewData publicationslistdata = new PublicationsViewData
            {
                Publications = publicationList
            };

            return publicationslistdata;
        }

        /// <summary>
        /// /Get the publication translation list.
        /// </summary>
        /// <param name="publicationId">the publication id.</param>
        /// <returns></returns>
        private async Task<List<PublicationTranslationItemData>> GetpublicationTranslations(int? publicationId)
        {
            List<PublicationTranslationItemData> translationsList = new List<PublicationTranslationItemData>();
            PublicationTranslationRequestData findPublicationTranslationRequest =
                new PublicationTranslationRequestData
                {
                    PublicationTranslationDto = new PublicationTranslationItemData { PublicationId = publicationId },
                    FindPublicationTranslationDto = FindPublicationTranslationItemData.PublicationId
                };
            PublicationTranslationResultData resultPublicationTranslation =
                await WebApiClient
                    .PostFormJsonAsync<PublicationTranslationRequestData, PublicationTranslationResultData>(
                        Constant.WebApiControllerRessources, Constant.WebApiFindPublicationTranslations,
                        findPublicationTranslationRequest);
            if (resultPublicationTranslation != null && resultPublicationTranslation.OperationSuccess &&
                resultPublicationTranslation.PublicationTranslationDtoList != null)
            {
                translationsList.AddRange(resultPublicationTranslation.PublicationTranslationDtoList
                    .Where(n => n.LanguageId == _lang)
                    .ToList());
            }
            return translationsList;
        }
        #endregion

        #region THEMES

        /// <summary>
        /// Get publicationThemes list.
        /// </summary>
        /// <returns>publications view.</returns>
        public async Task<ThemesViewData> GetPublicationThemes(int publicationId)
        {
            ThemesViewData themesViewData = new ThemesViewData { Themes = new List<ThemeViewData>() };
            PublicationThemeRequestData findPublicationThemeRequest = new PublicationThemeRequestData
            {
                PublicationThemeDto = new PublicationThemeItemData { PublicationId = publicationId },
                FindPublicationThemeDto = FindPublicationThemeItemData.PublicationId
            };

            PublicationThemeResultData publicationThemeResultData =
                await WebApiClient.PostFormJsonAsync<PublicationThemeRequestData, PublicationThemeResultData>(
                    Constant.WebApiControllerRessources, Constant.WebApiFindPublicationThemes,
                    findPublicationThemeRequest);

            if (!publicationThemeResultData.ThemeTranslationDtoList.Any()) return themesViewData;
            foreach (var themeTranslationItemData in publicationThemeResultData.ThemeTranslationDtoList.Where(t => t.LanguageId == _lang).ToList())
            {
                ThemeViewData themeViewData = new ThemeViewData
                {
                    Theme = new ThemeItemData { ThemeId = themeTranslationItemData.Theme.ThemeId },
                    TranslationsList = new List<ThemeTranslationItemData>()
                };
                themeViewData.TranslationsList.Add(themeTranslationItemData);
                themesViewData.Themes.Add(themeViewData);
            }

            return themesViewData;
        }

        /// <summary>
        /// GetTheme
        /// </summary>
        /// <returns></returns>
        private async Task<ThemesViewData> GetThemes()
        {
            ThemeResultData themeResultData =
                await WebApiClient.GetAsync<ThemeResultData>(Constant.WebApiControllerRessources, Constant.WebApiThemeList);
            List<ThemeViewData> themeList = new List<ThemeViewData>();

            if (themeResultData == null || !themeResultData.OperationSuccess ||
                themeResultData.ThemeDtoList == null) return null;
            foreach (var themeDto in themeResultData.ThemeDtoList)
            {
                ThemeViewData theme = new ThemeViewData
                {
                    TranslationsList = new List<ThemeTranslationItemData>(),
                    Theme = themeDto
                };
                theme.TranslationsList = await GetThemeTranslations(themeDto.ThemeId);
                themeList.Add(theme);
            }
            ThemesViewData themeslistdata = new ThemesViewData { Themes = themeList };
            return themeslistdata;
        }

        /// <summary>
        /// Get Theme Translations
        /// </summary>
        /// <param name="themeId"></param>
        /// <returns></returns>
        private async Task<List<ThemeTranslationItemData>> GetThemeTranslations(int? themeId)
        {
            List<ThemeTranslationItemData> translationsList = new List<ThemeTranslationItemData>();
            ThemeTranslationRequestData findThemeTranslationRequest = new ThemeTranslationRequestData()
            {
                ThemeTranslationDto = new ThemeTranslationItemData { ThemeId = themeId },
                FindThemeTranslationDto = FindThemeTranslationItemData.ThemeId
            };
            ThemeTranslationResultData resultThemeTranslation =
                await WebApiClient.PostFormJsonAsync<ThemeTranslationRequestData, ThemeTranslationResultData>(
                    Constant.WebApiControllerRessources, Constant.WebApiFindThemeTranslations, findThemeTranslationRequest);
            if (resultThemeTranslation != null && resultThemeTranslation.OperationSuccess &&
                resultThemeTranslation.ThemeTranslationDtoList != null)
            {
                translationsList.AddRange(resultThemeTranslation.ThemeTranslationDtoList.Where(n => n.LanguageId == _lang)
                    .ToList());
            }
            return translationsList;
        }
        #endregion

        #region AUTHORS

        /// <summary>
        /// Get Autors List
        /// </summary>
        /// <returns></returns>
        private async Task<AuthorsViewData> GetAuthors()
        {
            AuthorResultData authorResultData =
                await WebApiClient.GetAsync<AuthorResultData>(Constant.WebApiControllerRessources, Constant.WebApiAuthorList);
            List<AuthorViewData> authorList = new List<AuthorViewData>();

            if (authorResultData == null || !authorResultData.OperationSuccess ||
                authorResultData.AuthorDtoList == null) return null;
            foreach (var authorDto in authorResultData.AuthorDtoList)
            {
                AuthorViewData author = new AuthorViewData
                {

                    Author = authorDto
                };

                authorList.Add(author);
            }
            AuthorsViewData authorslistdata = new AuthorsViewData { Authors = authorList };
            return authorslistdata;
        }

        #endregion

        #endregion
    }
}