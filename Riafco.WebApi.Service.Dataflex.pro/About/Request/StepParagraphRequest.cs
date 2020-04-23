using System.Runtime.Serialization;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Request
{
    /// <summary>
    /// The StepParagraph request class.
    /// </summary>
    [DataContract]
    public class StepParagraphRequest
    {
        /// <summary>
        /// Gets or Sets The StepParagraphDto requested.
        /// </summary>
        [DataMember]
        public StepParagraphDto StepParagraphDto { get; set; }

        /// <summary>
        /// Gets or sets The Find StepParagraphDto.
        /// </summary>
        [DataMember]
        public FindStepParagraphDto FindStepParagraphDto { get; set; }
    }
}