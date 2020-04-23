using Riafco.Framework.Dataflex.pro.Communication.Messages;
using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Message{
/// <summary>
///    The Step message class.
/// </summary>
[DataContract]
public class StepMessage : ServiceMessage {
/// <summary>
/// Gets or Sets The  StepDtoList.
/// </summary>
[DataMember]
public List<StepDto> StepDtoList { get; set; }

/// <summary>
/// Gets or Sets The  StepDto.
/// </summary>
[DataMember]
public StepDto StepDto { get; set; }
}
}