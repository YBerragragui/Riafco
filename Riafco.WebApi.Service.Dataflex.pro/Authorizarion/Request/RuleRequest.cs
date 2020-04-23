using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Dto.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Request{
/// <summary>
/// The Rule request class.
/// </summary>
[DataContract]
public class RuleRequest{
/// <summary>
/// Gets or Sets The RuleDto requested.
/// </summary>
[DataMember]
public RuleDto RuleDto { get; set; }

/// <summary>
/// Gets or sets The Find RuleDto.
/// </summary>
[DataMember]
public FindRuleDto FindRuleDto { get; set; }
}
}