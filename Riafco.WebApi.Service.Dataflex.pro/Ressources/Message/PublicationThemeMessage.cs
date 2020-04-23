using Riafco.Framework.Dataflex.pro.Communication.Messages;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources.Message
{
    /// <summary>
    /// The PublicationTheme message class.
    /// </summary>
    [DataContract]
    public class PublicationThemeMessage : ServiceMessage
    {
        #region publication theme

        /// <summary>
        /// Gets or Sets The PublicationThemeDtoList.
        /// </summary>
        [DataMember]
        public List<PublicationThemeDto> PublicationThemeDtoList { get; set; }

        /// <summary>
        /// Gets or Sets The  PublicationThemeDto.
        /// </summary>
        [DataMember]
        public PublicationThemeDto PublicationThemeDto { get; set; }

        #endregion

        #region publication translation

        /// <summary>
        /// Gets or sets PublicationTranslationDtoList.
        /// </summary>
        [DataMember]
        public List<PublicationTranslationDto> PublicationTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets PublicationTranslationDto.
        /// </summary>
        [DataMember]
        public PublicationTranslationDto PublicationTranslationDto { get; set; }

        #endregion

        #region theme translation

        /// <summary>
        /// Gets or sets ThemeTranslationDtoList.
        /// </summary>
        [DataMember]
        public List<ThemeTranslationDto> ThemeTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets ThemeTranslationDto.
        /// </summary>
        [DataMember]
        public ThemeTranslationDto ThemeTranslationDto { get; set; }

        #endregion
    }
}