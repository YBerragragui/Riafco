using Riafco.Dataflex.Pro.Models.Settings.ItemData;

namespace Riafco.Dataflex.Pro.Models.Ressources.ItemData
{
    /// <summary>
    /// The ThemeTranslationItemData class.
    /// </summary>
    public class ThemeTranslationItemData
    {
        /// <summary>
        /// Gets or Sets The  TranslationId.
        /// </summary>
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The ThemeName.
        /// </summary>
        public string ThemeName { get; set; }

        #region navigation attributes

        /// <summary>
        /// Gets or Sets The  ThemeId.
        /// </summary>
        public int? ThemeId { get; set; }

        /// <summary>
        /// Gets or Sets The  Theme.
        /// </summary>
        public ThemeItemData Theme { get; set; }

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