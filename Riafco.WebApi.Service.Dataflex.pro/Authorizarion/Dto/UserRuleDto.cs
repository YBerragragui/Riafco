using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Ressource;
using System.ComponentModel.DataAnnotations;

namespace Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Dto
{
    /// <summary>
    /// The UserRule dto class.
    /// </summary>
    public class UserRuleDto
    {
        /// <summary>
        /// Gets or Sets The  UserRuleId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(UserRuleMessageResource), ErrorMessageResourceName = "RequiredUserRuleId")]
        public int UserRuleId { get; set; }

        /// <summary>
        /// Gets or sets UserRuleStatus
        /// </summary>
        public bool UserRuleStatus { get; set; }

        #region navigation attributes

        /// <summary>
        /// Gets or Sets The  UserId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(UserRuleMessageResource), ErrorMessageResourceName = "RequiredUserId")]
        public int? UserId { get; set; }

        /// <summary>
        /// Gets or Sets The  User.
        /// </summary>
        public UserDto User { get; set; }

        /// <summary>
        /// Gets or Sets The  RuleId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(UserRuleMessageResource), ErrorMessageResourceName = "RequiredUserId")]
        public int? RuleId { get; set; }

        /// <summary>
        /// Gets or Sets The  Rule.
        /// </summary>
        public RuleDto Rule { get; set; }

        #endregion
    }
}