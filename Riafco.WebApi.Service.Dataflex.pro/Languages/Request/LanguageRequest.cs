using Riafco.WebApi.Service.Dataflex.pro.Languages.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Dto.Enum;
using System.Runtime.Serialization;

namespace Riafco.WebApi.Service.Dataflex.pro.Languages.Request
{
    /// <summary>
    /// The Language request class.
    /// </summary>
    [DataContract]
    public class LanguageRequest
    {
        /// <summary>
        /// Gets or Sets The LanguageDto requested.
        /// </summary>
        [DataMember]
        public LanguageDto LanguageDto { get; set; }

        /// <summary>
        /// Gets or sets The Find LanguageDto.
        /// </summary>
        [DataMember]
        public FindLanguageDto FindLanguageDto { get; set; }
    }
}