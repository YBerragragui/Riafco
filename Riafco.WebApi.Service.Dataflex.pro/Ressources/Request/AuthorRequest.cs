using System.Runtime.Serialization;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources.Request
{
    /// <summary>
    /// The Author request class.
    /// </summary>
    [DataContract]
    public class AuthorRequest
    {
        /// <summary>
        /// Gets or Sets The AuthorDto requested.
        /// </summary>
        [DataMember]
        public AuthorDto AuthorDto { get; set; }

        /// <summary>
        /// Gets or sets The Find AuthorDto.
        /// </summary>
        [DataMember]
        public FindAuthorDto FindAuthorDto { get; set; }
    }
}