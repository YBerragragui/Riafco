using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Riafco.Entity.Dataflex.Pro.Authorizarion
{
    /// <summary>
    /// The UserRule class.
    /// </summary>
    [Table("auth_UserRules")]
    public class UserRule
    {
        /// <summary>
        /// Gets or sets UserRuleId.
        /// </summary>
        [Key]
        public int UserRuleId { get; set; }

        /// <summary>
        /// Gets or sets UserRuleStatus.
        /// </summary>
        public bool UserRuleStatus { get; set; }

        #region pavigation attributes.

        /// <summary>
        /// Gets or sets UserId.
        /// </summary>
        [ForeignKey("User")]
        public int? UserId { get; set; }

        /// <summary>
        /// Gets or sets User
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// Gets or sets RuleId.
        /// </summary>
        [ForeignKey("Rule")]
        public int? RuleId { get; set; }

        /// <summary>
        /// Gets or sets Rule
        /// </summary>
        public virtual Rule Rule { get; set; }

        #endregion
    }
}
