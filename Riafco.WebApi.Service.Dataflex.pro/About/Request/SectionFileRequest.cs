using System.Runtime.Serialization;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto;
using Riafco.WebApi.Service.Dataflex.pro.About.Dto.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Request
{
    /// <summary>
    /// The SectionFile request class.
    /// </summary>
    [DataContract]
    public class SectionFileRequest
    {
        /// <summary>
        /// Gets or Sets The SectionFileDto requested.
        /// </summary>
        [DataMember]
        public SectionFileDto SectionFileDto { get; set; }

        /// <summary>
        /// Gets or sets The Find SectionFileDto.
        /// </summary>
        [DataMember]
        public FindSectionFileDto FindSectionFileDto { get; set; }
    }
}