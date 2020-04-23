using System.ComponentModel.DataAnnotations;
using Admin.Riafco.Dataflex.Pro.GlobalResources;

namespace Admin.Riafco.Dataflex.Pro.Models.About.FormData
{
    /// <summary>
    /// The SectionParagraphTranslationFormData class.
    /// </summary>
    public class SectionParagraphTranslationFormData
    {
        /// <summary>
        /// Gets or Sets The TraslationId.
        /// </summary>
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The  ParagraphTitle.
        /// </summary>
        [Display(ResourceType = typeof(SectionParagraphResources), Name = nameof(SectionParagraphResources.DisplayParagraphTitle))]
        [Required(ErrorMessageResourceType = typeof(SectionParagraphResources), ErrorMessageResourceName = "RequiredParagraphTitle")]
        public string ParagraphTitle { get; set; }


        /// <summary>
        /// Gets or Sets The ParagraphDescription.
        /// </summary>
        [Display(ResourceType = typeof(SectionParagraphResources), Name = nameof(SectionParagraphResources.DisplayParagraphDescription))]
        [Required(ErrorMessageResourceType = typeof(SectionParagraphResources), ErrorMessageResourceName = "RequiredParagraphDescription")]
        public string ParagraphDescription { get; set; }

        /// <summary>
        /// Gets or Sets The LanguageId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SectionParagraphResources), ErrorMessageResourceName = "RequiredLanguageId")]
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or Sets The  ParagraphId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SectionParagraphResources), ErrorMessageResourceName = "RequiredParagraphId")]
        public int? ParagraphId { get; set; }

        /// <summary>
        /// Gets or sets LanguagePrefix.
        /// </summary>
        public string LanguagePrefix { get; set; }
    }
}