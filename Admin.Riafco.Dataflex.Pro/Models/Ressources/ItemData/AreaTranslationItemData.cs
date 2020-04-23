using Admin.Riafco.Dataflex.Pro.Models.Settings.ItemData;

namespace Admin.Riafco.Dataflex.Pro.Models.Ressources.ItemData
{
    /// <summary>
    /// The AreaTranslationItemData class.
    /// </summary>
    public class AreaTranslationItemData
    {
        /// <summary>
        /// Gets or Sets The  TranslationId.
        /// </summary>
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The AreaName.
        /// </summary>
        public string AreaName { get; set; }

        #region navigation attributes

        /// <summary>
        /// Gets or Sets The  AreaId.
        /// </summary>
        public int? AreaId { get; set; }

        /// <summary>
        /// Gets or Sets The  Area.
        /// </summary>
        public AreaItemData Area { get; set; }

        /// <summary>
        /// Gets or Sets The  LanguageId.
        /// </summary>
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or Sets The Language.
        /// </summary>
        public LanguageItemData Language { get; set; }

        #endregion
    }
}