using System.Runtime.Serialization;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Request
{
    /// <summary>
    /// The Step request class.
    /// </summary>
    [DataContract]
    public class StepRequest
    {
        /// <summary>
        /// Gets or Sets StepDto requested.
        /// </summary>
        [DataMember]
        public StepDto StepDto { get; set; }

        /// <summary>
        /// Gets or sets The FindStepDto.
        /// </summary>
        [DataMember]
        public FindStepDto FindStepDto { get; set; }
    }
}