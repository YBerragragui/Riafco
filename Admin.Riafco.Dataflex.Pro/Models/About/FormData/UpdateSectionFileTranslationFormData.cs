﻿using Admin.Riafco.Dataflex.Pro.GlobalResources;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Admin.Riafco.Dataflex.Pro.Models.About.FormData
{
    /// <summary>
    /// The UpdateSectionFileTranslationFormData class.
    /// </summary>
    public class UpdateSectionFileTranslationFormData
    {
        /// <summary>
        /// Gets or Sets The TranslationId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SectionFileResources), ErrorMessageResourceName = "RequiredTranslationId")]
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The  SectionFileSource.
        /// </summary>
        [Display(ResourceType = typeof(SectionFileResources), Name = nameof(SectionFileResources.DisplaySectionFileSource))]
        public HttpPostedFileBase SectionFileSource { get; set; }
        public string SectionFileSourceValue { get; set; }

        /// <summary>
        /// Gets or Sets The  SectionFileText.
        /// </summary>
        [Display(ResourceType = typeof(SectionFileResources), Name = nameof(SectionFileResources.DisplaySectionFileText))]
        [Required(ErrorMessageResourceType = typeof(SectionFileResources), ErrorMessageResourceName = "RequiredSectionFileText")]
        public string SectionFileText { get; set; }

        #region navigation attributes

        /// <summary>
        /// Gets or Sets The SectionFileId.
        /// </summary>
        public int? SectionFileId { get; set; }

        /// <summary>
        /// Gets or Sets The LanguageId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(SectionFileResources), ErrorMessageResourceName = "RequiredLanguageId")]
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or sets LanguagePrefix.
        /// </summary>
        public string LanguagePrefix { get; set; }

        #endregion
    }
}