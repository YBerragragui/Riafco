using Riafco.Dataflex.Pro.Models.About.ItemData;
using Riafco.Dataflex.Pro.Models.About.ItemData.Enum;
using System.Runtime.Serialization;

namespace Riafco.Dataflex.Pro.Models.About.RequestData
{
    /// <summary>
    /// The StepParagraphRequest class.
    /// </summary>
    [DataContract]
    public class StepParagraphRequestData
    {
        /// <summary>
        /// Gets or Sets StepParagraphDto.
        /// </summary>
        [DataMember]
        public StepParagraphItemData StepParagraphDto { get; set; }

        /// <summary>
        /// Gets or sets FindStepParagraphDto.
        /// </summary>
        [DataMember]
        public FindStepParagraphItemData FindStepParagraphDto { get; set; }
    }
}