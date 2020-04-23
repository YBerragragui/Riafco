using Admin.Riafco.Dataflex.Pro.GlobalResources;
using System.ComponentModel.DataAnnotations;

namespace Admin.Riafco.Dataflex.Pro.Models.Authorization.FormData
{
    /// <summary>
    /// The UserRuleFormData class.
    /// </summary>
    public class ManageUserRuleFormData
    {
        /// <summary>
        /// Gets or sets RuleId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(UserRuleResources), ErrorMessageResourceName = "RequiredId")]
        public int UserRuleId { get; set; }

        /// <summary>
        /// Gets or sets RuleId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(UserRuleResources), ErrorMessageResourceName = "RequiredId")]
        public int RuleId { get; set; }

        /// <summary>
        /// Gets or sets RulePrefix.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(UserRuleResources), ErrorMessageResourceName = "RequiredPrefix")]
        public string RulePrefix { get; set; }

        /// <summary>
        /// Gets or sets RuleName.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(UserRuleResources), ErrorMessageResourceName = "RequiredName")]
        public string RuleName { get; set; }

        /// <summary>
        /// Gets or sets RuleStatus.
        /// </summary>
        public bool RuleStatus { get; set; }
    }
}