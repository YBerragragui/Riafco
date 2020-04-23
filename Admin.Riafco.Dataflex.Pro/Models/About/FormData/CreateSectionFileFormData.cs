using Admin.Riafco.Dataflex.Pro.GlobalResources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Admin.Riafco.Dataflex.Pro.Models.About.FormData
{
    /// <summary>
    /// The CreateSectionFileFormData class.
    /// </summary>
    public class CreateSectionFileFormData
    {
        /// <summary>
        /// Gets or Sets The SectionFileId.
        /// </summary>
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
        public List<CreateSectionFileTranslationFormData> TranslationsList { get; set; }
        #endregion
    }
}