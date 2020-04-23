using Riafco.Service.Dataflex.Pro.Languages.Data;

namespace Riafco.Service.Dataflex.Pro.News.Data
{
    /// <summary>
    /// The NewsTranslation pivot class.
    /// </summary>
    public class NewsTranslationPivot
    {
        /// <summary>
        /// Gets or Sets The  TranslationId.
        /// </summary>
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The  NewsTitle.
        /// </summary>
        public string NewsTitle { get; set; }

        /// <summary>
        /// Gets or Sets The  NewsSummary.
        /// </summary>
        public string NewsSummary { get; set; }

        /// <summary>
        /// Gets or Sets The  NewsDescription.
        /// </summary>
        public string NewsDescription { get; set; }

        #region navigation properties

        /// <summary>
        /// Gets or Sets The  LanguageId.
        /// </summary>
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or Sets The  Language.
        /// </summary>
        public LanguagePivot Language { get; set; }

        /// <summary>
        /// Gets or Sets The  NewsId.
        /// </summary>
        public int? NewsId { get; set; }

        /// <summary>
        /// Gets or Sets The  News.
        /// </summary>
        public NewsPivot News { get; set; }
        #endregion
    }
}