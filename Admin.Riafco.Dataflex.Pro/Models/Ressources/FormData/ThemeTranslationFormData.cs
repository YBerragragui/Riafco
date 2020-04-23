using System.ComponentModel.DataAnnotations;
using Admin.Riafco.Dataflex.Pro.GlobalResources;

namespace Admin.Riafco.Dataflex.Pro.Models.Ressources.FormData
{
    /// <summary>
    /// The ThemeTranslationFormData class.
    /// </summary>
    public class ThemeTranslationFormData
    {
        /// <summary>
        /// Gets or Sets The  TranslationId.
        /// </summary>
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The ThemeName.
        /// </summary>
        [Display(ResourceType = typeof(ThemeResources), Name = nameof(ThemeResources.DisplayThemeName))]
        [Required(ErrorMessageResourceType = typeof(ThemeResources), ErrorMessageResourceName = "RequiredThemeName")]
        public string ThemeName { get; set; }

        #region navigation attributes

        /// <summary>
        /// Gets or Sets The  ThemeId.
        /// </summary>
        public int? ThemeId { get; set; }

        /// <summary>
        /// Gets or Sets The  LanguageId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ThemeResources), ErrorMessageResourceName = "RequiredLanguageId")]
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or sets LanguagePrefix.
        /// </summary>
        public string LanguagePrefix { get; set; }
        #endregion
    }
}