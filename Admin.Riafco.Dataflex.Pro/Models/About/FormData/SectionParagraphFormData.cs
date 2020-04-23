
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Admin.Riafco.Dataflex.Pro.GlobalResources;

namespace Admin.Riafco.Dataflex.Pro.Models.About.FormData
{
    /// <summary>
    /// The SectionParagraphFormData class.
    /// </summary>
    public class SectionParagraphFormData
    {
        /// <summary>
        /// Gets or Sets The  ParagraphId.
        /// </summary>
        public int ParagraphId { get; set; }

        #region navigation properties

        /// <summary>
        /// Gets or Sets The SectionId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SectionParagraphResources), ErrorMessageResourceName = "RequiredSectionId")]
        public int? SectionId { get; set; }

        /// <summary>
        /// Gets or sets TranslationItemDataList.
        /// </summary>
        public List<SectionParagraphTranslationFormData> TranslationsList { get; set; }

        #endregion
    }
}