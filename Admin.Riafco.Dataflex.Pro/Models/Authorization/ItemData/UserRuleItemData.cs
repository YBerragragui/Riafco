using Admin.Riafco.Dataflex.Pro.GlobalResources;
using Admin.Riafco.Dataflex.Pro.Models.Settings.ItemData;
using System.ComponentModel.DataAnnotations;

namespace Admin.Riafco.Dataflex.Pro.Models.Authorization.ItemData
{
    /// <summary>
    /// The UserRuleDto class.
    /// </summary>
    public class UserRuleItemData
    {
        /// <summary>
        /// Gets or Sets The  UserRuleId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(UserRuleResources), ErrorMessageResourceName = "RequiredId")]
        public int UserRuleId { get; set; }

        /// <summary>
        /// Gets or sets UserRuleStatus
        /// </summary>
        public bool UserRuleStatus { get; set; }

        #region navigation attributes

        /// <summary>
        /// Gets or Sets The  UserId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(UserRuleResources), ErrorMessageResourceName = "RequiredId")]
        public int? UserId { get; set; }

        /// <summary>
        /// Gets or Sets The  User.
        /// </summary>
        public UserItemData User { get; set; }

        /// <summary>
        /// Gets or Sets The  RuleId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(UserRuleResources), ErrorMessageResourceName = "RequiredId")]
        public int? RuleId { get; set; }

        /// <summary>
        /// Gets or Sets The  Rule.
        /// </summary>
        public RuleItemData Rule { get; set; }

        #endregion
    }
}
