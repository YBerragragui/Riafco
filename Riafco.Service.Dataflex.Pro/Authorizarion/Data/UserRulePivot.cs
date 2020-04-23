namespace Riafco.Service.Dataflex.Pro.Authorizarion.Data
{
    /// <summary>
    /// The UserRule pivot class.
    /// </summary>
    public class UserRulePivot
    {
        /// <summary>
        /// Gets or Sets The  UserRuleId.
        /// </summary>
        public int UserRuleId { get; set; }

        /// <summary>
        /// Gets or sets UserRuleStatus
        /// </summary>
        public bool UserRuleStatus { get; set; }

        #region navigation attributes

        /// <summary>
        /// Gets or Sets The  UserId.
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// Gets or Sets The  User.
        /// </summary>
        public UserPivot User { get; set; }

        /// <summary>
        /// Gets or Sets The  RuleId.
        /// </summary>
        public int? RuleId { get; set; }

        /// <summary>
        /// Gets or Sets The  Rule.
        /// </summary>
        public RulePivot Rule { get; set; }

        #endregion
    }
}