using Admin.Riafco.Dataflex.Pro.GlobalResources;
using System.ComponentModel.DataAnnotations;

namespace Admin.Riafco.Dataflex.Pro.Models.About.FormData
{
    /// <summary>
    /// The SectionTranslationFormData class.
    /// </summary>
    public class SectionTranslationFormData
    {
        /// <summary>
        /// Gets or sets TranslationId.
        /// </summary>
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or sets SectionId.
        /// </summary>
        public int SectionId { get; set; }

        /// <summary>
        /// Gets or sets LanguageId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SectionResources), ErrorMessageResourceName = nameof(SectionResources.RequiredField))]
        public int LanguageId { get; set; }

        /// <summary>
        /// Gets or sets SectionTitle.
        /// </summary>
        [Display(ResourceType = typeof(SectionResources), Name = nameof(SectionResources.DisplaySectionTitle))]
        [Required(ErrorMessageResourceType = typeof(SectionResources), ErrorMessageResourceName = nameof(SectionResources.RequiredSectionTitle))]
        public string SectionTitle { get; set; }

        /// <summary>
        /// Gets or sets SectionDesciption.
        /// </summary>
        [Display(ResourceType = typeof(SectionResources), Name = nameof(SectionResources.DisplaySectionDesciption))]
        [Required(ErrorMessageResourceType = typeof(SectionResources), ErrorMessageResourceName = nameof(SectionResources.RequiredSectionDesciption))]
        public string SectionDesciption { get; set; }

        /// <summary>
        /// Gets or sets LanguagePrefix.
        /// </summary>
        public string LanguagePrefix { get; set; }
    }
}
