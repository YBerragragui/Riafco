using System.Security.Policy;
using Admin.Riafco.Dataflex.Pro.Models.About.FormData;
using Admin.Riafco.Dataflex.Pro.Models.About.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.About.ItemData.Enum;
using Admin.Riafco.Dataflex.Pro.Models.About.RequestData;
using Admin.Riafco.Dataflex.Pro.Models.About.ResultData;
using Riafco.Framework.Dataflex.pro.Util;

namespace Admin.Riafco.Dataflex.Pro.Models.About.Assembler
{
    /// <summary>
    /// The StepAssembler class.
    /// </summary>
    public static class StepAssembler
    {
        /// <summary>
        /// From step form data to request data.
        /// </summary>
        /// <param name="formData">the step form data to convert.</param>
        /// <returns>step request result.</returns>
        public static StepRequestData ToRequestData(this ManageStepFormData formData)
        {
            return new StepRequestData
            {
                FindStepDto = FindStepItemData.StepId,
                StepDto = formData.ToItemData()
            };
        }

        /// <summary>
        /// From form data to item data.
        /// </summary>
        /// <param name="formData">Step form data to convert</param>
        /// <returns>the result item data.</returns>
        public static StepItemData ToItemData(this ManageStepFormData formData)
        {
            return new StepItemData
            {
                StepDate = formData.StepDate.StringToDateTime(),
                StepId = formData.StepId
            };
        }

        /// <summary>
        /// From result data to form data.
        /// </summary>
        /// <param name="result">the result data.</param>
        /// <returns></returns>
        public static ManageStepFormData ToFormData(this StepResultData result)
        {
            return new ManageStepFormData
            {
                StepDate = result.StepDto.StepDate.ToString("dd/MM/yyyy"),
                StepId = result.StepDto.StepId
            };
        }
    }
}