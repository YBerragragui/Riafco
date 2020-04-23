using Riafco.Service.Dataflex.Pro.Authorizarion.Data;
using Riafco.Service.Dataflex.Pro.Authorizarion.Data.Enum;
using System.Collections.Generic;

namespace Riafco.Service.Dataflex.Pro.Authorizarion.Request
{
    /// <summary>
    /// The UserRuleRequestPivot class.
    /// </summary>
    public class UserRuleRequestPivot
    {
        /// <summary>
        /// Gets or Sets the UserRulePivot
        /// </summary>
        public UserRulePivot UserRulePivot { get; set; }

        /// <summary>
        /// Gets or Sets the UserRulePivotList
        /// </summary>
        public List<UserRulePivot> UserRulePivotList { get; set; }

        /// <summary>
        /// Gets or Sets the FindUserRulePivot.
        /// </summary>
        public FindUserRulePivot FindUserRulePivot { get; set; }
    }
}