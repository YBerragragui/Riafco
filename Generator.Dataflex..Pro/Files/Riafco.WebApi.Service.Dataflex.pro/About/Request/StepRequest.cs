using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Request{
/// <summary>
/// The Step request class.
/// </summary>
[DataContract]
public class StepRequest{
/// <summary>
/// Gets or Sets The StepDto requested.
/// </summary>
[DataMember]
public StepDto StepDto { get; set; }

/// <summary>
/// Gets or sets The Find StepDto.
/// </summary>
[DataMember]
public FindStepDto FindStepDto { get; set; }
}
}