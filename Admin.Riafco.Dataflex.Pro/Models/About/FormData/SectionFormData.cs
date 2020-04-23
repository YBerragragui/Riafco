using Admin.Riafco.Dataflex.Pro.GlobalResources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Admin.Riafco.Dataflex.Pro.Models.About.FormData
{
    /// <summary>
    /// The SectionFormData class
    /// </summary>
    public class SectionFormData
    {
        /// <summary>
        /// Get or sets SectionId.
        /// </summary>
        public int SectionId { get; set; }

        /// <summary>
        /// Gets or sets SectionImage.
        /// </summary>
        [Display(ResourceType = typeof(SectionResources), Name = nameof(SectionResources.DisplaySectionImage))]
        public HttpPostedFileBase SectionImage { get; set; }

        /// <summary>
        /// Gets or sets TranslationsList.
        /// </summary>
        public List<SectionTranslationFormData> TranslationsList { get; set; }
    }
}
