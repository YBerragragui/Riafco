using System.Collections.Generic;

namespace Admin.Riafco.Dataflex.Pro.Models.Authorization.FormData
{
    /// <summary>
    /// The ManageUserRulesFormData class.
    /// </summary>
    public class ManageUserRulesFormData
    {
        /// <summary>
        /// Gets or sets UserId.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets Rules.
        /// </summary>
        public List<ManageUserRuleFormData> Rules { get; set; }
    }
}