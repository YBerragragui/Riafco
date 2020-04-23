using System.ComponentModel.DataAnnotations;
using Riafco.WebApi.Service.Dataflex.pro.About.Ressource;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Dto
{
    /// <summary>
    /// The StepParagraph dto class.
    /// </summary>
    public class StepParagraphDto
    {
        /// <summary>
        /// Gets or Sets The ParagraphId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(StepMessageResource), ErrorMessageResourceName = "RequiredParagraphId")]
        public int ParagraphId { get; set; }

        #region navigation attributes

        /// <summary>
        /// Gets or Sets The StepId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(StepMessageResource), ErrorMessageResourceName = "RequiredStepId")]
        public int? StepId { get; set; }

        /// <summary>
        /// Gets or Sets The Step.
        /// </summary>
        public StepDto Step { get; set; }

        #endregion
    }
}