using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Admin.Riafco.Dataflex.Pro.GlobalResources;

namespace Admin.Riafco.Dataflex.Pro.Models.About.FormData
{
    /// <summary>
    /// The StepParagraphFormData class.
    /// </summary>
    public class StepParagraphFormData
    {
        /// <summary>
        /// Gets or Sets The ParagraphId.
        /// </summary>
        public int ParagraphId { get; set; }

        /// <summary>
        /// Gets or Sets The StepId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(StepResources), ErrorMessageResourceName = "RequiredStepId")]
        public int? StepId { get; set; }

        #region TRANSLATIONS

        /// <summary>
        /// Gets or sets Translations.
        /// </summary>
        public List<StepParagraphTranslationFormData> TranslationsList { get; set; }

        #endregion
    }
}