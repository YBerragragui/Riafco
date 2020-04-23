using Riafco.Framework.Dataflex.pro.Communication.Messages;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources.Message
{
    /// <summary>
    /// The Theme message class.
    /// </summary>
    [DataContract]
    public class ThemeMessage : ServiceMessage
    {
        /// <summary>
        /// Gets or Sets The  ThemeDtoList.
        /// </summary>
        [DataMember]
        public List<ThemeDto> ThemeDtoList { get; set; }

        /// <summary>
        /// Gets or Sets The  ThemeDto.
        /// </summary>
        [DataMember]
        public ThemeDto ThemeDto { get; set; }
    }
}