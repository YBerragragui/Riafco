using Riafco.WebApi.Service.Dataflex.pro.Activites.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Dto.Enum;
using System.Runtime.Serialization;

namespace Riafco.WebApi.Service.Dataflex.pro.Activites.Request
{
    /// <summary>
    /// The Activity request class.
    /// </summary>
    [DataContract]
    public class ActivityRequest
    {
        /// <summary>
        /// Gets or Sets The ActivityDto requested.
        /// </summary>
        [DataMember]
        public ActivityDto ActivityDto { get; set; }

        /// <summary>
        /// Gets or sets The Find ActivityDto.
        /// </summary>
        [DataMember]
        public FindActivityDto FindActivityDto { get; set; }
    }
}