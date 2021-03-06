﻿using System.Runtime.Serialization;
using Admin.Riafco.Dataflex.Pro.Models.Ressources.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Ressources.ItemData.Enum;

namespace Admin.Riafco.Dataflex.Pro.Models.Ressources.RequestData
{
    /// <summary>
    /// The PublicationRequestData class.
    /// </summary>
    [DataContract]
    public class PublicationRequestData
    {
        /// <summary>
        /// Gets or Sets The PublicationDto requested.
        /// </summary>
        [DataMember]
        public PublicationItemData PublicationDto { get; set; }

        /// <summary>
        /// Gets or sets The FindPublicationDto.
        /// </summary>
        [DataMember]
        public FindPublicationItemData FindPublicationDto { get; set; }
    }
}