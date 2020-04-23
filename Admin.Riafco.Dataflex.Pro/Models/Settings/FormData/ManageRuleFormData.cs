using Admin.Riafco.Dataflex.Pro.GlobalResources;
using System.ComponentModel.DataAnnotations;

namespace Admin.Riafco.Dataflex.Pro.Models.Settings.FormData
{
    /// <summary>
    /// The ManageRuleFormData class.
    /// </summary>
    public class ManageRuleFormData
    {
        /// <summary>
        /// Gets or Sets The RuleId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(RuleResources), ErrorMessageResourceName = "RequiredId")]
        public int RuleId { get; set; }

        /// <summary>
        /// Gets or Sets The RulePrefix.
        /// </summary>
        [Display(ResourceType = typeof(RuleResources), Name = "DisplayRulePrefix")]
        [Required(ErrorMessageResourceType = typeof(RuleResources), ErrorMessageResourceName = "RequiredPrefix")]
        public string RulePrefix { get; set; }

        /// <summary>
        /// Gets or sets RuleName.
        /// </summary>
        [Display(ResourceType = typeof(RuleResources), Name = "DisplayRuleName")]
        [Required(ErrorMessageResourceType = typeof(RuleResources), ErrorMessageResourceName = "RequiredName")]
        public string RuleName { get; set; }
    }
}