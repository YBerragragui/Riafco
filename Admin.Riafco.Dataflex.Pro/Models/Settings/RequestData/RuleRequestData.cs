using Admin.Riafco.Dataflex.Pro.Models.Settings.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Settings.ItemData.Enum;

namespace Admin.Riafco.Dataflex.Pro.Models.Settings.RequestData
{
    /// <summary>
    /// The Rule request class.
    /// </summary>
    public class RuleRequestData
    {
        /// <summary>
        /// Gets or Sets The RuleDto requested.
        /// </summary>
        public RuleItemData RuleDto { get; set; }

        /// <summary>
        /// Gets or sets The Find RuleDtoEnum.
        /// </summary>
        public FindRuleItemData FindRuleItemData { get; set; }
    }
}