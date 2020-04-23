using System.ComponentModel.DataAnnotations;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Ressource;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto
{
    /// <summary>
    /// The ThemeTranslation dto class.
    /// </summary>
    public class ThemeTranslationDto
    {
        /// <summary>
        /// Gets or Sets The  TranslationId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ThemeMessageResource), ErrorMessageResourceName = "RequiredTranslationId")]
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The  ThemeName.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(ThemeMessageResource), ErrorMessageResourceName = "RequiredThemeName")]
        public string ThemeName { get; set; }

        #region navigation attributes

        /// <summary>
        /// Gets or Sets The ThemeId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ThemeMessageResource), ErrorMessageResourceName = "RequiredId")]
        public int? ThemeId { get; set; }

        /// <summary>
        /// Gets or Sets The  Theme.
        /// </summary>
        public ThemeDto Theme { get; set; }

        /// <summary>
        /// Gets or Sets The  LanguageId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ThemeMessageResource), ErrorMessageResourceName = "RequiredLanguageId")]
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or Sets The  Language.
        /// </summary>
        public LanguageDto Language { get; set; }

        #endregion
    }
}