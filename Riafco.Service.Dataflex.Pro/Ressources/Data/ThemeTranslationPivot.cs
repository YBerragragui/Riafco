using Riafco.Service.Dataflex.Pro.Languages.Data;

namespace Riafco.Service.Dataflex.Pro.Ressources.Data
{
    /// <summary>
    /// The ThemeTranslation pivot class.
    /// </summary>
    public class ThemeTranslationPivot
    {
        /// <summary>
        /// Gets or Sets The  TranslationId.
        /// </summary>
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The  ThemeName.
        /// </summary>
        public string ThemeName { get; set; }

        #region navigation attribues

        /// <summary>
        /// Gets or Sets The  ThemeId.
        /// </summary>
        public int? ThemeId { get; set; }

        /// <summary>
        /// Gets or Sets The  Theme.
        /// </summary>
        public ThemePivot Theme { get; set; }

        /// <summary>
        /// Gets or Sets The  LanguageId.
        /// </summary>
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or Sets The  Language.
        /// </summary>
        public LanguagePivot Language { get; set; }

        #endregion
    }
}