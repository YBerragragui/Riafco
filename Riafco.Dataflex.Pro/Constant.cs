namespace Riafco.Dataflex.Pro
{
    /// <summary>
    /// Constant for the front layer
    /// </summary>
    public static class Constant
    {
        /// <summary>
        /// The Web Api Url constant.
        /// </summary>
        internal const string WebApiUrl = "http://service.riafco.org/api/";

        /// <summary>
        /// The default Web Api Url constant.
        /// </summary>
        internal const string DefaultWebApiUrl = "http://service.riafco.org/api/";

        /// <summary>
        /// The Return Url constant
        /// </summary>
        internal const string ReturnUrl = "ReturnUrl";

        /// <summary>
        /// The Application Cookie constant
        /// </summary>
        internal const string ApplicationCookie = "ApplicationCookie";

        /// <summary>
        /// The token grant type constant
        /// </summary>
        internal const string TokenGrantType = "grant_type";

        /// <summary>
        /// URL Images
        /// </summary>
        public const string ImagesUrl = "http://admin.riafco.org/";

        /// <summary>
        /// The token Bearer constant
        /// </summary>
        internal const string TokenBearer = "Bearer";

        #region Web API Controllers
        /// <summary>
        /// The web api authorization controller constant
        /// </summary>
        internal const string WebApiControllerUser = "Users";

        /// <summary>
        /// The web api authorization controller constant
        /// </summary>
        internal const string WebApiControllerLanguages = "Languages";

        /// <summary>
        /// The web api authorization controller constant
        /// </summary>
        internal const string WebApiControllerOffices = "Offices";

        /// <summary>
        /// The web api authorization controller constant
        /// </summary>
        internal const string WebApiControllerActivities = "Activities";

        /// <summary>
        /// The web api rule controller constant
        /// </summary>
        internal const string WebApiControllerRule = "Rules";

        /// <summary>
        /// The web api news controller constant
        /// </summary>
        internal const string WebApiControllerNews = "News";

        /// <summary>
        /// The web api news controller constant
        /// </summary>
        internal const string WebApiControllerNewsletters = "Newsletters";
        /// <summary>
        /// The web api news controller constant
        /// </summary>
        internal const string WebApiControllerContacts = "Contacts";

        /// <summary>
        /// The web api Events controller constant
        /// </summary>
        internal const string WebApiControllerOccurrences = "Occurrences";

        /// <summary>
        /// The web api Events controller constant
        /// </summary>
        internal const string WebApiControllerAbout = "About";

        /// <summary>
        /// The ressource web api controller. 
        /// </summary>
        internal const string WebApiControllerRessources = "Ressources";

        /// <summary>
        /// The web api Partners controller constant
        /// </summary>
        internal const string WebApiControllerPartners = "Partners";

        /// <summary>
        /// The web api Steps controller constant.
        /// </summary>
        internal const string WebApiControllerSteps = "Steps";
        #endregion

        #region User Web API Actions

        /// <summary>
        /// The create user method.
        /// </summary>
        internal const string WebApiCreateUser = "CreateUser";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiUpdateUser = "UpdateUser";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiDeleteUser = "RemoveUser";

        /// <summary>
        /// The user list action.
        /// </summary>
        internal const string WebApiUserList = "GetUsers";

        /// <summary>
        /// The user list action.
        /// </summary>
        internal const string WebApiFindUser = "FindUsers";

        #endregion

        #region Langue Web API Actions

        /// <summary>
        /// The user list action.
        /// </summary>
        internal const string WebApiLanguageList = "GetLanguages";

        /// <summary>
        /// The user list action.
        /// </summary>
        internal const string WebApiFindLanguage = "FindLanguages";

        /// <summary>
        /// The create user method.
        /// </summary>
        internal const string WebApiCreateLanguage = "CreateLanguage";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiUpdateLanguage = "UpdateLanguage";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiRemoveLanguage = "RemoveLanguage";


        #endregion

        #region Rule Web API Actions

        /// <summary>
        /// The user list action.
        /// </summary>
        internal const string WebApiRuleList = "GetRules";

        /// <summary>
        /// The user list action.
        /// </summary>
        internal const string WebApiFindRules = "FindRules";

        /// <summary>
        /// The create user method.
        /// </summary>
        internal const string WebApiCreateRule = "CreateRule";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiUpdateRule = "UpdateRule";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiRemoveRule = "RemoveRule";
        #endregion

        #region User UserRule Web API Actions

        /// <summary>
        /// The user list action.
        /// </summary>
        internal const string WebApiUserRuleList = "GetUserRules";

        /// <summary>
        /// The user list action.
        /// </summary>
        internal const string WebApiFindUserRules = "FindUserRules";

        /// <summary>
        /// The create user method.
        /// </summary>
        internal const string WebApiCreateUserRule = "CreateUserRule";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiUpdateUserRule = "UpdateUserRule";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiUpdateUserRuleRange = "UpdateUserRuleRange";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiRemoveUserRule = "RemoveUserRule";
        #endregion

        #region Activity Web API Actions
        /// <summary>
        /// The user list action.
        /// </summary>
        internal const string WebApiActivityList = "GetActivities";

        /// <summary>
        /// The user list action.
        /// </summary>
        internal const string WebApiFindActivities = "FindActivities";

        /// <summary>
        /// The create user method.
        /// </summary>
        internal const string WebApiCreateActivity = "CreateActivity";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiUpdateActivity = "UpdateActivity";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiRemoveActivity = "RemoveActivity";
        #endregion

        #region Activity Translation Web API Actions
        /// <summary>
        /// The user list action.
        /// </summary>
        internal const string WebApiActivityTranslationList = "GetActivityTranslations";

        /// <summary>
        /// The user list action.
        /// </summary>
        internal const string WebApiFindActivityTranslations = "FindActivityTranslations";

        /// <summary>
        /// The create user method.
        /// </summary>
        internal const string WebApiCreateActivityTranslation = "CreateActivityTranslation";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiCreateActivityTranslationRange = "CreateActivityTranslationRange";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiUpdateActivityTranslation = "UpdateActivityTranslation";

        /// <summary>
        /// The method roote to update activity translation list.
        /// </summary>
        internal const string WebApiUpdateActivityTranslationRange = "UpdateActivityTranslationRange";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiRemoveActivityTranslation = "RemoveActivityTranslation";
        #endregion

        #region Activity paragraph Web Api Actions
        /// <summary>
        /// The create activity paragraph method.
        /// </summary>
        internal const string WebApiCreateActivityParagraph = "CreateActivityParagraph";

        /// <summary>
        /// The update activity paragraph method.
        /// </summary>
        internal const string WebApiUpdateActivityParagraph = "UpdateActivityParagraph";

        /// <summary>
        /// The remove activity paragraph method. 
        /// </summary>
        internal const string WebApiRemoveActivityParagraph = "RemoveActivityParagraph";

        /// <summary>
        /// The list of the paragraph method.
        /// </summary>
        internal const string WebApiActivityParagraphList = "GetActivityParagraphs";

        /// <summary>
        /// The find activity paragraph.
        /// </summary>
        internal const string WebApiFindActivityParagraphs = "FindActivityParagraphs";
        #endregion

        #region Activity paragraph translation web api actions

        /// <summary>
        /// The create activity paragraph translation method.
        /// </summary>
        internal const string WebApiCreateActivityParagraphTranslation = "CreateActivityParagraphTranslation";

        /// <summary>
        /// The create activity paragraph translation range method.
        /// </summary>
        internal const string WebApiCreateActivityParagraphTranslationRange = "CreateActivityParagraphTranslationRange";

        /// <summary>
        /// The update activity paragraph translation mathod.
        /// </summary>
        internal const string WebApiUpdateActivityParagraphTranslation = "UpdateActivityParagraphTranslation";

        /// <summary>
        /// The update activity paragraph translation range method.
        /// </summary>
        internal const string WebApiUpdateActivityParagraphTranslationRange = "UpdateActivityParagraphTranslationRange";

        /// <summary>
        /// The delete activity paragraph translation method.
        /// </summary>
        internal const string WebApiDeleteActivityParagraphTranslation = "DeleteActivityParagraphTranslation";

        /// <summary>
        /// The GetActivityParagraphTranslations method.
        /// </summary>
        internal const string WebApiActivityParagraphTranslationList = "GetActivityParagraphTranslations";

        /// <summary>
        /// The find activity paragraph translations method.
        /// </summary>
        internal const string WebApiFindActivityParagraphTranslations = "FindActivityParagraphTranslations";
        #endregion

        #region Activity file web api actions
        /// <summary>
        /// The create activity paragraph method.
        /// </summary>
        internal const string WebApiCreateActivityFile = "CreateActivityFile";

        /// <summary>
        /// The update activity paragraph method.
        /// </summary>
        internal const string WebApiUpdateActivityFile = "UpdateActivityFile";

        /// <summary>
        /// The remove activity paragraph method. 
        /// </summary>
        internal const string WebApiRemoveActivityFile = "RemoveActivityFile";

        /// <summary>
        /// The list of the paragraph method.
        /// </summary>
        internal const string WebApiActivityFileList = "GetActivityFiles";

        /// <summary>
        /// The find activity files method.
        /// </summary>
        internal const string WebApiFindActivityFiles = "FindActivityFiles";
        #endregion

        #region Activity file translation web api actions

        /// <summary>
        /// The create activity paragraph translation method.
        /// </summary>
        internal const string WebApiCreateActivityFileTranslation = "CreateActivityFileTranslation";

        /// <summary>
        /// The create activity paragraph translation range method.
        /// </summary>
        internal const string WebApiCreateActivityFileTranslationRange = "CreateActivityFileTranslationRange";

        /// <summary>
        /// The update activity paragraph translation mathod.
        /// </summary>
        internal const string WebApiUpdateActivityFileTranslation = "UpdateActivityFileTranslation";

        /// <summary>
        /// The update activity paragraph translation range method.
        /// </summary>
        internal const string WebApiUpdateActivityFileTranslationRange = "UpdateActivityFileTranslationRange";

        /// <summary>
        /// The delete activity paragraph translation method.
        /// </summary>
        internal const string WebApiDeleteActivityFileTranslation = "DeleteActivityFileTranslation";

        /// <summary>
        /// The GetActivityParagraphTranslations method.
        /// </summary>
        internal const string WebApiActivityFileTranslationList = "GetActivityFileTranslations";

        /// <summary>
        /// The find activity paragraph translations method.
        /// </summary>
        internal const string WebApiFindActivityFileTranslations = "FindActivityFileTranslations";

        #endregion

        #region Occurrence Web API Actions
        /// <summary>
        /// The user list action.
        /// </summary>
        internal const string WebApiOccurrenceList = "GetOccurrences";

        /// <summary>
        /// The user list action.
        /// </summary>
        internal const string WebApiFindOccurrences = "FindOccurrences";

        /// <summary>
        /// The create user method.
        /// </summary>
        internal const string WebApiCreateOccurrence = "CreateOccurrence";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiUpdateOccurrence = "UpdateOccurrence";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiRemoveOccurrence = "RemoveOccurrence";
        #endregion

        #region Occurrence Translation Web API Actions
        /// <summary>
        /// The user list action.
        /// </summary>
        internal const string WebApiOccurrenceTranslationList = "GetOccurrenceTranslations";

        /// <summary>
        /// The user list action.
        /// </summary>
        internal const string WebApiFindOccurrenceTranslations = "FindOccurrenceTranslations";

        /// <summary>
        /// The create user method.
        /// </summary>
        internal const string WebApiCreateOccurrenceTranslation = "CreateOccurrenceTranslation";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiCreateOccurrenceTranslationRange = "CreateOccurrenceTranslationRange";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiUpdateOccurrenceTranslation = "UpdateOccurrenceTranslation";

        /// <summary>
        /// The method roote to update occurrence translation list.
        /// </summary>
        internal const string WebApiUpdateOccurrenceTranslationRange = "UpdateOccurrenceTranslationRange";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiRemoveOccurrenceTranslation = "RemoveOccurrenceTranslation";
        #endregion

        #region Section Web API Actions

        /// <summary>
        /// The section list action.
        /// </summary>
        internal const string WebApiSectionList = "GetSections";

        /// <summary>
        /// The section list action.
        /// </summary>
        internal const string WebApiFindSections = "FindSections";

        /// <summary>
        /// The create section method.
        /// </summary>
        internal const string WebApiCreateSection = "CreateSection";

        /// <summary>
        /// The update section method.
        /// </summary>
        internal const string WebApiUpdateSection = "UpdateSection";

        /// <summary>
        /// The update section method.
        /// </summary>
        internal const string WebApiRemoveSection = "RemoveSection";

        #endregion

        #region Section Translation Web API Actions
        /// <summary>
        /// The user list action.
        /// </summary>
        internal const string WebApiSectionTranslationList = "GetSectionTranslations";

        /// <summary>
        /// The user list action.
        /// </summary>
        internal const string WebApiFindSectionTranslations = "FindSectionTranslations";

        /// <summary>
        /// The user list action.
        /// </summary>
        internal const string WebApiFindStepTranslations = "FindStepTranslations";
        /// <summary>
        /// The create user method.
        /// </summary>
        internal const string WebApiCreateSectionTranslation = "CreateSectionTranslation";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiCreateSectionTranslationRange = "CreateSectionTranslationRange";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiUpdateSectionTranslation = "UpdateSectionTranslation";

        /// <summary>
        /// The method roote to update section translation list.
        /// </summary>
        internal const string WebApiUpdateSectionTranslationRange = "UpdateSectionTranslationRange";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiRemoveSectionTranslation = "RemoveSectionTranslation";
        #endregion

        #region Section paragraph Web Api Actions
        /// <summary>
        /// The create section paragraph method.
        /// </summary>
        internal const string WebApiCreateSectionParagraph = "CreateSectionParagraph";

        /// <summary>
        /// The update section paragraph method.
        /// </summary>
        internal const string WebApiUpdateSectionParagraph = "UpdateSectionParagraph";

        /// <summary>
        /// The remove section paragraph method. 
        /// </summary>
        internal const string WebApiRemoveSectionParagraph = "RemoveSectionParagraph";

        /// <summary>
        /// The list of the paragraph method.
        /// </summary>
        internal const string WebApiSectionParagraphList = "GetSectionParagraphs";

        /// <summary>
        /// The find section paragraph.
        /// </summary>
        internal const string WebApiFindSectionParagraphs = "FindSectionParagraphs";
        #endregion

        #region Section paragraph translation web api actions

        /// <summary>
        /// The create section paragraph translation method.
        /// </summary>
        internal const string WebApiCreateSectionParagraphTranslation = "CreateSectionParagraphTranslation";

        /// <summary>
        /// The create section paragraph translation range method.
        /// </summary>
        internal const string WebApiCreateSectionParagraphTranslationRange = "CreateSectionParagraphTranslationRange";

        /// <summary>
        /// The update section paragraph translation mathod.
        /// </summary>
        internal const string WebApiUpdateSectionParagraphTranslation = "UpdateSectionParagraphTranslation";

        /// <summary>
        /// The update section paragraph translation range method.
        /// </summary>
        internal const string WebApiUpdateSectionParagraphTranslationRange = "UpdateSectionParagraphTranslationRange";

        /// <summary>
        /// The delete section paragraph translation method.
        /// </summary>
        internal const string WebApiDeleteSectionParagraphTranslation = "DeleteSectionParagraphTranslation";

        /// <summary>
        /// The GetSectionParagraphTranslations method.
        /// </summary>
        internal const string WebApiSectionParagraphTranslationList = "GetSectionParagraphTranslations";

        /// <summary>
        /// The find section paragraph translations method.
        /// </summary>
        internal const string WebApiFindSectionParagraphTranslations = "FindSectionParagraphTranslations";
        #endregion

        #region Section file web api actions
        /// <summary>
        /// The create activity paragraph method.
        /// </summary>
        internal const string WebApiCreateSectionFile = "CreateSectionFile";

        /// <summary>
        /// The update activity paragraph method.
        /// </summary>
        internal const string WebApiUpdateSectionFile = "UpdateSectionFile";

        /// <summary>
        /// The remove activity paragraph method. 
        /// </summary>
        internal const string WebApiRemoveSectionFile = "RemoveSectionFile";

        /// <summary>
        /// The list of the paragraph method.
        /// </summary>
        internal const string WebApiSectionFileList = "GetSectionFiles";

        /// <summary>
        /// The find activity files method.
        /// </summary>
        internal const string WebApiFindSectionFiles = "FindSectionFiles";
        #endregion

        #region Section file translation web api actions

        /// <summary>
        /// The create activity paragraph translation method.
        /// </summary>
        internal const string WebApiCreateSectionFileTranslation = "CreateSectionFileTranslation";

        /// <summary>
        /// The create activity paragraph translation range method.
        /// </summary>
        internal const string WebApiCreateSectionFileTranslationRange = "CreateSectionFileTranslationRange";

        /// <summary>
        /// The update activity paragraph translation mathod.
        /// </summary>
        internal const string WebApiUpdateSectionFileTranslation = "UpdateSectionFileTranslation";

        /// <summary>
        /// The update activity paragraph translation range method.
        /// </summary>
        internal const string WebApiUpdateSectionFileTranslationRange = "UpdateSectionFileTranslationRange";

        /// <summary>
        /// The delete activity paragraph translation method.
        /// </summary>
        internal const string WebApiDeleteSectionFileTranslation = "DeleteSectionFileTranslation";

        /// <summary>
        /// The GetSectionParagraphTranslations method.
        /// </summary>
        internal const string WebApiSectionFileTranslationList = "GetSectionFileTranslations";

        /// <summary>
        /// The find activity paragraph translations method.
        /// </summary>
        internal const string WebApiFindSectionFileTranslations = "FindSectionFileTranslations";

        #endregion

        #region Steps web api actions

        /// <summary>
        /// The create step method.
        /// </summary>
        internal const string WebApiCreateStep = "CreateStep";

        /// <summary>
        /// The update step method.
        /// </summary>
        internal const string WebApiUpdateStep = "UpdateStep";

        /// <summary>
        /// The update step method.
        /// </summary>
        internal const string WebApiRemoveStep = "RemoveStep";

        /// <summary>
        /// The user list action.
        /// </summary>
        internal const string WebApiFindSteps = "FindSteps";

        /// <summary>
        /// The user list action.
        /// </summary>
        internal const string WebApiStepList = "GetSteps";

        #endregion

        #region Step paragraph web api actions

        /// <summary>
        /// The create step paragraph method.
        /// </summary>
        internal const string WebApiCreateStepParagraph = "CreateStepParagraph";

        /// <summary>
        /// The update step paragraph method.
        /// </summary>
        internal const string WebApiUpdateStepParagraph = "UpdateStepParagraph";

        /// <summary>
        /// The update step paragraph method.
        /// </summary>
        internal const string WebApiRemoveStepParagraph = "RemoveStepParagraph";

        /// <summary>
        /// The step paragraph find action.
        /// </summary>
        internal const string WebApiFindStepParagraphs = "FindStepParagraphs";

        /// <summary>
        /// The step paragraph list action.
        /// </summary>
        internal const string WebApiStepStepParagraphList = "GetStepParagraphs";

        #endregion

        #region Step paragraph translation

        /// <summary>
        /// The create step paragraph method.
        /// </summary>
        internal const string WebApiCreateStepParagraphTranslation = "CreateStepParagraphTranslation";

        /// <summary>
        /// The create step paragraph method.
        /// </summary>
        internal const string WebApiCreateStepParagraphTranslationRange = "CreateStepParagraphTranslationRange";

        /// <summary>
        /// The update step paragraph method.
        /// </summary>
        internal const string WebApiUpdateStepParagraphTranslation = "UpdateStepParagraphTranslation";

        /// <summary>
        /// The update step paragraph method.
        /// </summary>
        internal const string WebApiUpdateStepParagraphTranslationRange = "UpdateStepParagraphTranslationRange";

        /// <summary>
        /// The update step paragraph method.
        /// </summary>
        internal const string WebApiRemoveStepParagraphTranslation = "RemoveStepParagraphTranslation";

        /// <summary>
        /// The step paragraph find action.
        /// </summary>
        internal const string WebApiFindStepParagraphTranslation = "FindStepParagraphTranslations";

        /// <summary>
        /// The step paragraph list action.
        /// </summary>
        internal const string WebApiStepParagraphTranslationList = "GetStepParagraphTranslations";

        #endregion

        #region News Web API Actions
        /// <summary>
        /// The user list action.
        /// </summary>
        internal const string WebApiNewsList = "GetNews";

        /// <summary>
        /// The user list action.
        /// </summary>
        internal const string WebApiFindNews = "FindNews";

        /// <summary>
        /// The create user method.
        /// </summary>
        internal const string WebApiCreateNews = "CreateNews";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiUpdateNews = "UpdateNews";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiRemoveNews = "RemoveNews";
        #endregion

        #region NewsTranslation Web API Actions
        /// <summary>
        /// The user list action.
        /// </summary>
        internal const string WebApiNewsTranslationList = "GetNewsTranslations";

        /// <summary>
        /// The user list action.
        /// </summary>
        internal const string WebApiFindNewsTranslations = "FindNewsTranslation";

        /// <summary>
        /// The create user method.
        /// </summary>
        internal const string WebApiCreateNewsTranslation = "CreateNewsTranslation";

        /// <summary>
        /// The create user method.
        /// </summary>
        internal const string WebApiCreateNewsTranslationRange = "CreateNewsTranslationRange";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiUpdateNewsTranslation = "UpdateNewsTranslation";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiUpdateNewsTranslationRange = "UpdateNewsTranslationRange";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiRemoveNewsTranslation = "RemoveNewsTranslation";
        #endregion

        #region Country Web API Actions
        /// <summary>
        /// The user list action.
        /// </summary>
        internal const string WebApiCountryList = "GetCountries";

        /// <summary>
        /// The user list action.
        /// </summary>
        internal const string WebApiFindCountries = "FindCountries";

        /// <summary>
        /// The create user method.
        /// </summary>
        internal const string WebApiCreateCountry = "CreateCountry";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiUpdateCountry = "UpdateCountry";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiRemoveCountry = "RemoveCountry";
        #endregion

        #region Country Translation Web API Actions
        /// <summary>
        /// The user list action.
        /// </summary>
        internal const string WebApiCountryTranslationList = "GetCountryTranslations";

        /// <summary>
        /// The user list action.
        /// </summary>
        internal const string WebApiFindCountryTranslations = "FindCountryTranslations";

        /// <summary>
        /// The create user method.
        /// </summary>
        internal const string WebApiCreateCountryTranslation = "CreateCountryTranslation";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiCreateCountryTranslationRange = "CreateCountryTranslationRange";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiUpdateCountryTranslation = "UpdateCountryTranslation";

        /// <summary>
        /// The method roote to update country translation list.
        /// </summary>
        internal const string WebApiUpdateCountryTranslationRange = "UpdateCountryTranslationRange";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiRemoveCountryTranslation = "RemoveCountryTranslation";
        #endregion

        #region Sheet Web Api Actions
        /// <summary>
        /// The create activity sheet method.
        /// </summary>
        internal const string WebApiCreateSheet = "CreateSheet";

        /// <summary>
        /// The update activity sheet method.
        /// </summary>
        internal const string WebApiUpdateSheet = "UpdateSheet";

        /// <summary>
        /// The remove activity sheet method. 
        /// </summary>
        internal const string WebApiRemoveSheet = "RemoveSheet";

        /// <summary>
        /// The list of the sheet method.
        /// </summary>
        internal const string WebApiSheetList = "GetSheets";

        /// <summary>
        /// The find activity sheet.
        /// </summary>
        internal const string WebApiFindSheets = "FindSheets";
        #endregion

        #region Sheet Translation web api actions

        /// <summary>
        /// The create activity sheet translation method.
        /// </summary>
        internal const string WebApiCreateSheetTranslation = "CreateSheetTranslation";

        /// <summary>
        /// The create activity sheet translation range method.
        /// </summary>
        internal const string WebApiCreateSheetTranslationRange = "CreateSheetTranslationRange";

        /// <summary>
        /// The update activity sheet translation mathod.
        /// </summary>
        internal const string WebApiUpdateSheetTranslation = "UpdateSheetTranslation";

        /// <summary>
        /// The update activity sheet translation range method.
        /// </summary>
        internal const string WebApiUpdateSheetTranslationRange = "UpdateSheetTranslationRange";

        /// <summary>
        /// The delete activity sheet translation method.
        /// </summary>
        internal const string WebApiDeleteSheetTranslation = "DeleteSheetTranslation";

        /// <summary>
        /// The GetSheetTranslations method.
        /// </summary>
        internal const string WebApiSheetTranslationList = "GetSheetTranslations";

        /// <summary>
        /// The find activity sheet translations method.
        /// </summary>
        internal const string WebApiFindSheetTranslations = "FindSheetTranslations";
        #endregion

        #region Author web api methods

        /// <summary>
        /// The create web api author method. 
        /// </summary>
        internal const string WebApiCreateAuthor = "CreateAuthor";

        /// <summary>
        /// The update web api author method. 
        /// </summary>
        internal const string WebApiUpdateAuthor = "UpdateAuthor";

        /// <summary>
        /// The delete web api author method. 
        /// </summary>
        internal const string WebApiRemoveAuthor = "RemoveAuthor";

        /// <summary>
        /// The getAll web api author method. 
        /// </summary>
        internal const string WebApiAuthorList = "GetAuthors";

        /// <summary>
        /// The find author web api method.
        /// </summary>
        internal const string WebApiFindAuthors = "FindAuthors";

        #endregion

        #region Theme web api methods

        /// <summary>
        /// The create web api theme method. 
        /// </summary>
        internal const string WebApiCreateTheme = "CreateTheme";

        /// <summary>
        /// The update web api theme method. 
        /// </summary>
        internal const string WebApiUpdateTheme = "UpdateTheme";

        /// <summary>
        /// The delete web api theme method. 
        /// </summary>
        internal const string WebApiRemoveTheme = "RemoveTheme";

        /// <summary>
        /// The getAll web api theme method. 
        /// </summary>
        internal const string WebApiThemeList = "GetThemes";

        /// <summary>
        /// The find theme web api method.
        /// </summary>
        internal const string WebApiFindThemes = "FindThemes";

        #endregion

        #region Theme translation web api methods

        /// <summary>
        /// The create web api theme translation method. 
        /// </summary>
        internal const string WebApiCreateThemeTranslation = "CreateThemeTranslation";

        /// <summary>
        /// The create range web api theme translation method. 
        /// </summary>
        internal const string WebApiCreateThemeTranslationRange = "CreateThemeTranslationRange";

        /// <summary>
        /// The update web api theme translation method. 
        /// </summary>
        internal const string WebApiUpdateThemeTranslation = "UpdateThemeTranslation";

        /// <summary>
        /// The update range web api theme translation method. 
        /// </summary>
        internal const string WebApiUpdateThemeTranslationRange = "UpdateThemeTranslationRange";

        /// <summary>
        /// The delete web api theme translation method. 
        /// </summary>
        internal const string WebApiRemoveThemeTranslation = "RemoveThemeTranslation";

        /// <summary>
        /// The getAll web api theme translation method. 
        /// </summary>
        internal const string WebApiThemeTranslationList = "GetThemeTranslations";

        /// <summary>
        /// The find author web api method.
        /// </summary>
        internal const string WebApiFindThemeTranslations = "FindThemeTranslations";

        #endregion

        #region Area web api methods

        /// <summary>
        /// The create web api area method. 
        /// </summary>
        internal const string WebApiCreateArea = "CreateArea";

        /// <summary>
        /// The update web api area method. 
        /// </summary>
        internal const string WebApiUpdateArea = "UpdateArea";

        /// <summary>
        /// The delete web api area method. 
        /// </summary>
        internal const string WebApiRemoveArea = "RemoveArea";

        /// <summary>
        /// The getAll web api area method. 
        /// </summary>
        internal const string WebApiAreaList = "GetAreas";

        /// <summary>
        /// The find area web api method.
        /// </summary>
        internal const string WebApiFindAreas = "FindAreas";

        #endregion

        #region Area translation web api methods

        /// <summary>
        /// The create web api area translation method. 
        /// </summary>
        internal const string WebApiCreateAreaTranslation = "CreateAreaTranslation";

        /// <summary>
        /// The create range web api area translation method. 
        /// </summary>
        internal const string WebApiCreateAreaTranslationRange = "CreateAreaTranslationRange";

        /// <summary>
        /// The update web api area translation method. 
        /// </summary>
        internal const string WebApiUpdateAreaTranslation = "UpdateAreaTranslation";

        /// <summary>
        /// The update range web api area translation method. 
        /// </summary>
        internal const string WebApiUpdateAreaTranslationRange = "UpdateAreaTranslationRange";

        /// <summary>
        /// The delete web api area translation method. 
        /// </summary>
        internal const string WebApiRemoveAreaTranslation = "RemoveAreaTranslation";

        /// <summary>
        /// The getAll web api area translation method. 
        /// </summary>
        internal const string WebApiAreaTranslationsList = "GetAreaTranslations";

        /// <summary>
        /// The find author web api method.
        /// </summary>
        internal const string WebApiFindAreaTranslations = "FindAreaTranslations";

        #endregion

        #region Publication web api methods

        /// <summary>
        /// The create web api area method. 
        /// </summary>
        internal const string WebApiCreatePublication = "CreatePublication";

        /// <summary>
        /// The update web api area method. 
        /// </summary>
        internal const string WebApiUpdatePublication = "UpdatePublication";

        /// <summary>
        /// The delete web api area method. 
        /// </summary>
        internal const string WebApiRemovePublication = "RemovePublication";

        /// <summary>
        /// The getAll web api area method. 
        /// </summary>
        internal const string WebApiPublicationList = "GetPublications";

        /// <summary>
        /// The find area web api method.
        /// </summary>
        internal const string WebApiFindPublications = "FindPublications";

        #endregion

        #region Publication translation web api methods

        /// <summary>
        /// The create web api publucation translation method. 
        /// </summary>
        internal const string WebApiCreatePublicationTranslation = "CreatePublicationTranslation";

        /// <summary>
        /// The create range web api publucation translation method. 
        /// </summary>
        internal const string WebApiCreatePublicationTranslationRange = "CreatePublicationTranslationRange";

        /// <summary>
        /// The update web api publucation translation method. 
        /// </summary>
        internal const string WebApiUpdatePublicationTranslation = "UpdatePublicationTranslation";

        /// <summary>
        /// The update range web api publucation translation method. 
        /// </summary>
        internal const string WebApiUpdatePublicationTranslationRange = "UpdatePublicationTranslationRange";

        /// <summary>
        /// The delete web api publucation translation method. 
        /// </summary>
        internal const string WebApiRemovePublicationTranslation = "RemovePublicationTranslation";

        /// <summary>
        /// The getAll web api publucation translation method. 
        /// </summary>
        internal const string WebApiPublicationTranslationList = "GetPublicationTranslations";

        /// <summary>
        /// The find author web api method.
        /// </summary>
        internal const string WebApiFindPublicationTranslations = "FindPublicationTranslations";

        #endregion

        #region Publication theme

        /// <summary>
        /// The create web api publucation theme method. 
        /// </summary>
        internal const string WebApiCreatePublicationTheme = "CreatePublicationTheme";

        /// <summary>
        /// The create web api publucation theme method. 
        /// </summary>
        internal const string WebApiCreatePublicationThemeRange = "CreatePublicationThemeRange";

        /// <summary>
        /// The update web api publucation theme method. 
        /// </summary>
        internal const string WebApiUpdatePublicationTheme = "UpdatePublicationTheme";

        /// <summary>
        /// The update web api publucation theme method. 
        /// </summary>
        internal const string WebApiUpdatePublicationThemeRange = "UpdatePublicationThemeRange";

        /// <summary>
        /// The delete web api publucation theme method. 
        /// </summary>
        internal const string WebApiRemovePublicationTheme = "RemovePublicationTheme";

        /// <summary>
        /// The getAll web api publucation theme method. 
        /// </summary>
        internal const string WebApiPublicationThemeList = "GetPublicationThemes";

        /// <summary>
        /// The find publucation theme web api method.
        /// </summary>
        internal const string WebApiFindPublicationThemes = "FindPublicationThemes";

        #endregion

        #region Subscriber Web API Actions

        /// <summary>
        /// The user list action.
        /// </summary>
        internal const string WebApiSubscriberList = "GetSubscribers";

        /// <summary>
        /// The user list action.
        /// </summary>
        internal const string WebApiFindSubscribers = "FindSubscribers";

        /// <summary>
        /// The create user method.
        /// </summary>
        internal const string WebApiCreateSubscriber = "CreateSubscriber";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiUpdateSubscriber = "UpdateSubscriber";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiRemoveSubscriber = "RemoveSubscriber";


        #endregion

        #region NewsletterMail Web API Actions
        /// <summary>
        /// The user list action.
        /// </summary>
        internal const string WebApiNewsletterMailList = "GetNewsletterMails";

        /// <summary>
        /// The user list action.
        /// </summary>
        internal const string WebApiFindNewsletterMails = "FindNewsletterMails";

        /// <summary>
        /// The create user method.
        /// </summary>
        internal const string WebApiCreateNewsletterMail = "CreateNewsletterMail";
        /// <summary>
        /// The create user method.
        /// </summary>
        internal const string WebApiCreateContact = "CreateContact";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiUpdateNewsletterMail = "UpdateNewsletterMail";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiRemoveNewsletterMail = "RemoveNewsletterMail";
        #endregion

        #region NewsletterMail Translation Web API Actions
        /// <summary>
        /// The user list action.
        /// </summary>
        internal const string WebApiNewsletterMailTranslationList = "GetNewsletterMailTranslations";

        /// <summary>
        /// The user list action.
        /// </summary>
        internal const string WebApiFindNewsletterMailTranslations = "FindNewsletterMailTranslations";

        /// <summary>
        /// The create user method.
        /// </summary>
        internal const string WebApiCreateNewsletterMailTranslation = "CreateNewsletterMailTranslation";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiCreateNewsletterMailTranslationRange = "CreateNewsletterMailTranslationRange";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiUpdateNewsletterMailTranslation = "UpdateNewsletterMailTranslation";

        /// <summary>
        /// The method roote to update newsletterMail translation list.
        /// </summary>
        internal const string WebApiUpdateNewsletterMailTranslationRange = "UpdateNewsletterMailTranslationRange";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiRemoveNewsletterMailTranslation = "RemoveNewsletterMailTranslation";
        #endregion

        #region Partner Web API Actions

        /// <summary>
        /// The user list action.
        /// </summary>
        internal const string WebApiPartnerList = "GetPartners";

        /// <summary>
        /// The user list action.
        /// </summary>
        internal const string WebApiFindPartners = "FindPartners";

        /// <summary>
        /// The create user method.
        /// </summary>
        internal const string WebApiCreatePartner = "CreatePartner";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiUpdatePartner = "UpdatePartner";

        /// <summary>
        /// The update user method.
        /// </summary>
        internal const string WebApiRemovePartner = "RemovePartner";


        #endregion

        ///FRONTS

        #region Controllers
        /// <summary>
        /// The home controller constant
        /// </summary>
        internal const string BackHomeController = "Home";

        /// <summary>
        /// The home controller constant
        /// </summary>
        internal const string FrontUsersController = "Home";
        #endregion


        #region Actions
        /// <summary>
        /// The index action constant
        /// </summary>
        internal const string FrontActionIndex = "Index";

        /// <summary>
        /// The login action constant
        /// </summary>
        internal const string FrontActionLogin = "Connection";
        #endregion
    }
}