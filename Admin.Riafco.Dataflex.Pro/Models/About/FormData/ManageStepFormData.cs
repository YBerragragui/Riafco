using System.ComponentModel.DataAnnotations;
using Admin.Riafco.Dataflex.Pro.GlobalResources;

namespace Admin.Riafco.Dataflex.Pro.Models.About.FormData
{
    /// <summary>
    /// The ManageStepFormData class.
    /// </summary>
    public class ManageStepFormData
    {
        /// <summary>
        /// Gets or Sets The StepId.
        /// </summary>
        public int StepId { get; set; }

        /// <summary>
        /// Gets or Sets The StepDate.
        /// </summary>
        [Display(ResourceType = typeof(StepResources), Name = nameof(StepResources.DisplayStepDate))]
        [Required(ErrorMessageResourceType = typeof(StepResources), ErrorMessageResourceName = "RequiredStepDate")]
        [RegularExpression(@"((0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/([0-9])*)", ErrorMessageResourceType = typeof(StepResources), ErrorMessageResourceName = nameof(StepResources.InvalideDate))]
        public string StepDate { get; set; }
    }
}