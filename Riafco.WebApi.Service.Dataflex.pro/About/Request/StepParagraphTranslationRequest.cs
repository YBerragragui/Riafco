using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Request
{
    /// <summary>
    /// The StepParagraphTranslation request class.
    /// </summary>
    [DataContract]
    public class StepParagraphTranslationRequest
    {
        /// <summary>
        /// Gets or Sets The StepParagraphTranslationDto requested.
        /// </summary>
        [DataMember]
        public StepParagraphTranslationDto StepParagraphTranslationDto { get; set; }

        /// <summary>
        /// Gets or Sets The StepParagraphTranslationDtoList requested.
        /// </summary>
        [DataMember]
        public List<StepParagraphTranslationDto> StepParagraphTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets The Find StepParagraphTranslationDto.
        /// </summary>
        [DataMember]
        public FindStepParagraphTranslationDto FindStepParagraphTranslationDto { get; set; }
    }
}