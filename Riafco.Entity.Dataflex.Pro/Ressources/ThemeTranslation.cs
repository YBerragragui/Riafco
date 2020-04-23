using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Riafco.Entity.Dataflex.Pro.Languages;

namespace Riafco.Entity.Dataflex.Pro.Ressources
{
    /// <summary>
    /// The ThemeTranslation class.
    /// </summary>
    [Table("Ressource_ThemeTranslations")]
    public class ThemeTranslation
    {
        /// <summary>
        /// Gets or sets TranslationId.
        /// </summary>
        [Key]
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or sets ThemeName.
        /// </summary>
        public string ThemeName { get; set; }

        #region navigation properties
        /// <summary>
        /// Gets or sets ThemeId.
        /// </summary>
        [ForeignKey("Theme")]
        public int? ThemeId { get; set; }

        /// <summary>
        /// Gets or sets Theme.
        /// </summary>
        public virtual Theme Theme { get; set; }

        /// <summary>
        /// Gets or sets LanguageId.
        /// </summary>
        [ForeignKey("Language")]
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or sets Language.
        /// </summary>
        public virtual Language Language { get; set; }
        #endregion
    }
}
