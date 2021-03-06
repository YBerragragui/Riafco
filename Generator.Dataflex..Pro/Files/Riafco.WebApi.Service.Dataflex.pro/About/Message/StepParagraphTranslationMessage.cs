using Riafco.Framework.Dataflex.pro.Communication.Messages;
using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Message{
/// <summary>
///    The StepParagraphTranslation message class.
/// </summary>
[DataContract]
public class StepParagraphTranslationMessage : ServiceMessage {
/// <summary>
/// Gets or Sets The  StepParagraphTranslationDtoList.
/// </summary>
[DataMember]
public List<StepParagraphTranslationDto> StepParagraphTranslationDtoList { get; set; }

/// <summary>
/// Gets or Sets The  StepParagraphTranslationDto.
/// </summary>
[DataMember]
public StepParagraphTranslationDto StepParagraphTranslationDto { get; set; }
}
}