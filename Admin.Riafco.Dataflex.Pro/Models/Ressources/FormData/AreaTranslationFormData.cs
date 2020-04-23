using System.ComponentModel.DataAnnotations;
using Admin.Riafco.Dataflex.Pro.GlobalResources;

namespace Admin.Riafco.Dataflex.Pro.Models.Ressources.FormData
{
    /// <summary>
    /// The AreaTranslationFormData class.
    /// </summary>
    public class AreaTranslationFormData
    {
        /// <summary>
        /// Gets or Sets The  TranslationId.
        /// </summary>
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The AreaName.
        /// </summary>
        [Display(ResourceType = typeof(AreaResources), Name = nameof(AreaResources.DisplayAreaName))]
        [Required(ErrorMessageResourceType = typeof(AreaResources), ErrorMessageResourceName = "RequiredAreaName")]
        public string AreaName { get; set; }

        #region navigation attributes

        /// <summary>
        /// Gets or Sets The  AreaId.
        /// </summary>
        public int? AreaId { get; set; }

        /// <summary>
        /// Gets or Sets The  LanguageId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(AreaResources), ErrorMessageResourceName = "RequiredLanguageId")]
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or sets LanguagePrefix.
        /// </summary>
        public string LanguagePrefix { get; set; }
        #endregion
    }
}