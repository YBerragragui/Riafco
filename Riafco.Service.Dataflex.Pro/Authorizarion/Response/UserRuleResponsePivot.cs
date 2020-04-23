using Riafco.Service.Dataflex.Pro.Authorizarion.Data;
using System.Collections.Generic;

namespace Riafco.Service.Dataflex.Pro.Authorizarion.Response
{
    /// <summary>
    /// The UserRuleResponsePivot class.
    /// </summary>
    public class UserRuleResponsePivot
    {
        /// <summary>
        /// Gets or Sets The  UserRulePivotList.
        /// </summary>
        public List<UserRulePivot> UserRulePivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  UserRulePivot.
        /// </summary>
        public UserRulePivot UserRulePivot { get; set; }

    }
}