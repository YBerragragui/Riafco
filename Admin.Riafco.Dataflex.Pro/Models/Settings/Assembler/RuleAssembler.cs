using Admin.Riafco.Dataflex.Pro.Models.Settings.FormData;
using Admin.Riafco.Dataflex.Pro.Models.Settings.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Settings.RequestData;
using Admin.Riafco.Dataflex.Pro.Models.Settings.ResultData;

namespace Admin.Riafco.Dataflex.Pro.Models.Settings.Assembler
{
    /// <summary>
    /// The RuleAssembler class.
    /// </summary>
    public static class RuleAssembler
    {
        /// <summary>
        /// From Langue result data to connection form data
        /// </summary>
        /// <param name="resultData">the Langue result data from web api.</param>
        /// <returns>the form data.</returns>
        public static ManageRuleFormData ToFormData(this RuleResultData resultData)
        {
            ManageRuleFormData formData = new ManageRuleFormData();
            if (resultData?.RuleDto != null)
            {
                formData = new ManageRuleFormData
                {
                    RulePrefix = resultData.RuleDto.RulePrefix,
                    RuleName = resultData.RuleDto.RuleName,
                    RuleId = resultData.RuleDto.RuleId
                };
            }
            return formData;
        }

        /// <summary>
        /// From itemData from ManageRuleFormData
        /// </summary>
        /// <param name="itemData"></param>
        /// <returns></returns>
        public static ManageRuleFormData ToFormData(this RuleItemData itemData)
        {
            ManageRuleFormData formData = new ManageRuleFormData();
            if (itemData != null)
            {
                formData = new ManageRuleFormData
                {
                    RulePrefix = itemData.RulePrefix,
                    RuleName = itemData.RuleName,
                    RuleId = itemData.RuleId
                };
            }

            return formData;
        }

        /// <summary>
        /// From ManageRuleFormData to RuleRequestData
        /// </summary>
        /// <param name="formData">the formData to convert</param>
        /// <returns>the ManageRuleFormData result.</returns>
        public static RuleRequestData ToRequestData(this ManageRuleFormData formData)
        {
            RuleRequestData requestData = new RuleRequestData();
            if (formData != null)
            {
                requestData = new RuleRequestData
                {
                    RuleDto = new RuleItemData
                    {
                        RulePrefix = formData.RulePrefix,
                        RuleName = formData.RuleName,
                        RuleId = formData.RuleId
                    }
                };
            }
            return requestData;
        }
    }
}