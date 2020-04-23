using Riafco.Framework.Dataflex.pro.Communication.Messages;
using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Message{
/// <summary>
///    The StepParagraph message class.
/// </summary>
[DataContract]
public class StepParagraphMessage : ServiceMessage {
/// <summary>
/// Gets or Sets The  StepParagraphDtoList.
/// </summary>
[DataMember]
public List<StepParagraphDto> StepParagraphDtoList { get; set; }

/// <summary>
/// Gets or Sets The  StepParagraphDto.
/// </summary>
[DataMember]
public StepParagraphDto StepParagraphDto { get; set; }
}
}