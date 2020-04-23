using Riafco.Dataflex.Pro.Models.About.ItemData;
using Riafco.Dataflex.Pro.Models.About.ItemData.Enum;
using System.Runtime.Serialization;

namespace Riafco.Dataflex.Pro.Models.About.RequestData
{
    /// <summary>
    /// The StepRequest class.
    /// </summary>
    [DataContract]
    public class StepRequestData
    {
        /// <summary>
        /// Gets or Sets StepDto.
        /// </summary>
        [DataMember]
        public StepItemData StepDto { get; set; }

        /// <summary>
        /// Gets or sets FindStepDto.
        /// </summary>
        [DataMember]
        public FindStepItemData FindStepDto { get; set; }
    }
}