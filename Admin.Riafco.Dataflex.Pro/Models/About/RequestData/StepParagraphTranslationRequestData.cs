using System.Collections.Generic;
using System.Runtime.Serialization;
using Admin.Riafco.Dataflex.Pro.Models.About.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.About.ItemData.Enum;

namespace Admin.Riafco.Dataflex.Pro.Models.About.RequestData
{
    /// <summary>
    /// The StepParagraphTranslation request class.
    /// </summary>
    [DataContract]
    public class StepParagraphTranslationRequestData
    {
        /// <summary>
        /// Gets or Sets StepParagraphTranslationDto.
        /// </summary>
        [DataMember]
        public StepParagraphTranslationItemData StepParagraphTranslationDto { get; set; }

        /// <summary>
        /// Gets or Sets StepParagraphTranslationDtoList.
        /// </summary>
        [DataMember]
        public List<StepParagraphTranslationItemData> StepParagraphTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets FindStepParagraphTranslationDto.
        /// </summary>
        [DataMember]
        public FindStepParagraphTranslationItemData FindStepParagraphTranslationDto { get; set; }
    }
}