using System.Runtime.Serialization;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Dto.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Activites.Request
{
    /// <summary>
    /// The ActivityFile request class.
    /// </summary>
    [DataContract]
    public class ActivityFileRequest
    {
        /// <summary>
        /// Gets or Sets The ActivityFileDto requested.
        /// </summary>
        [DataMember]
        public ActivityFileDto ActivityFileDto { get; set; }

        /// <summary>
        /// Gets or sets The Find ActivityFileDto.
        /// </summary>
        [DataMember]
        public FindActivityFileDto FindActivityFileDto { get; set; }
    }
}