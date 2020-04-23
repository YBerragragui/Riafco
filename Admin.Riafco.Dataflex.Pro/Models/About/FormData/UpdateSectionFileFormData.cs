using Admin.Riafco.Dataflex.Pro.GlobalResources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Admin.Riafco.Dataflex.Pro.Models.About.FormData
{
    /// <summary>
    /// The UpdateSectionFileFormData class.
    /// </summary>
    public class UpdateSectionFileFormData
    {
        /// <summary>
        /// Gets or Sets The SectionFileId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SectionFileResources), ErrorMessageResourceName = "RequiredSectionFileId")]
        public int SectionFileId { get; set; }

        #region NAVIGATION ATTRIBUTES

        /// <summary>
        /// Gets or Sets The  SectionId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SectionFileResources), ErrorMessageResourceName = "RequiredSectionId")]
        public int? SectionId { get; set; }

        /// <summary>
        /// Gets or sets TranslationsList.
        /// </summary>
        public List<UpdateSectionFileTranslationFormData> TranslationsList { get; set; }
        #endregion
    }
}