using System;
using System.ComponentModel.DataAnnotations;
using Riafco.WebApi.Service.Dataflex.pro.About.Ressource;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Dto
{
    /// <summary>
    /// The StepDto class.
    /// </summary>
    public class StepDto
    {
        /// <summary>
        /// Gets or Sets The StepId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(StepMessageResource), ErrorMessageResourceName = "RequiredStepId")]
        public int StepId { get; set; }

        /// <summary>
        /// Gets or Sets The StepDate.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(StepMessageResource), ErrorMessageResourceName = "RequiredStepDate")]
        [RegularExpression(@"((0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/([0-9])*)", ErrorMessageResourceType = typeof(StepMessageResource), ErrorMessageResourceName = nameof(StepMessageResource.InvalideDate))]
        public DateTime StepDate { get; set; }
    }
}