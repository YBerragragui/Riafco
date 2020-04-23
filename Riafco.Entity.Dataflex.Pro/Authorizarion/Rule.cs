using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Riafco.Entity.Dataflex.Pro.Authorizarion
{
    /// <summary>
    /// The Rule classe.
    /// </summary>
    [Table("auth_Rules")]
    public class Rule
    {
        /// <summary>
        /// Gets or sets rule id.
        /// </summary>
        [Key]
        public int RuleId { get; set; }

        /// <summary>
        /// Gets or sets rue prefix.
        /// </summary>
        public string RulePrefix { get; set; }

        /// <summary>
        /// Gets or sets rule name.
        /// </summary>
        public string RuleName { get; set; }
    }
}
