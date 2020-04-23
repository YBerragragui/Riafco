using Riafco.Dataflex.Pro.Models.Ressources.ItemData;
using Riafco.Framework.Dataflex.pro.Web.ResultData;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Riafco.Dataflex.Pro.Models.Ressources.ResultData
{
    /// <summary>
    /// The PublicationResultData class.
    /// </summary>
    [DataContract, Serializable]
    public class PublicationThemeResultData : BaseResultData
    {
        #region publication theme

        /// <summary>
        /// Gets or sets PublicationThemeDto.
        /// </summary>
        [DataMember]
        public PublicationThemeItemData PublicationThemeDto { get; set; }

        /// <summary>
        /// Gets or sets PublicationThemeDtoList.
        /// </summary>
        [DataMember]
        public List<PublicationThemeItemData> PublicationThemeDtoList { get; set; }

        #endregion

        #region publication translation

        /// <summary>
        /// Gets or sets PublicationTranslationDtoList.
        /// </summary>
        [DataMember]
        public List<PublicationTranslationItemData> PublicationTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets PublicationTranslationDto.
        /// </summary>
        [DataMember]
        public PublicationTranslationItemData PublicationTranslationDto { get; set; }

        #endregion

        #region theme translations

        /// <summary>
        /// Gets or sets ThemeTranslationDtoList.
        /// </summary>
        [DataMember]
        public List<ThemeTranslationItemData> ThemeTranslationDtoList { get; set; }

        /// <summary>
        /// Gets or sets ThemeTranslationDto.
        /// </summary>
        [DataMember]
        public ThemeTranslationItemData ThemeTranslationDto { get; set; }

        #endregion
    }
}