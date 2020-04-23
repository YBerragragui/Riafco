using Riafco.Dataflex.Pro.Models.Settings.ItemData;

namespace Riafco.Dataflex.Pro.Models.News.ItemData
{
    /// <summary>
    /// The ActiviteTraduction dto class.
    /// </summary>
    public class NewsTranslationItemData
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

        #region navigation attributes

        /// <summary>
        /// Gets or Sets The  LanguageId.
        /// </summary>
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or Sets The  Language.
        /// </summary>
        public LanguageItemData Language { get; set; }

        /// <summary>
        /// Gets or Sets The  NewsId.
        /// </summary>
        public int? NewsId { get; set; }

        /// <summary>
        /// Gets or Sets The  News.
        /// </summary>
        public NewsItemData News { get; set; }

        #endregion
    }
}