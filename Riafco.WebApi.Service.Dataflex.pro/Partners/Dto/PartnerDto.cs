using System;
using System.Collections.Generic;

namespace Riafco.WebApi.Service.Dataflex.pro.Partners.Dto
{
    /// <summary>
    /// The Partner dto class.
    /// </summary>
    public class PartnerDto
    {
        /// <summary>
        /// Gets or Sets The  PartnerId.
        /// </summary>
        public int PartnerId { get; set; }

        /// <summary>
        /// Gets or Sets The  PartnerImage.
        /// </summary>
        public string  PartnerImage { get; set; }

        /// <summary>
        /// Gets or Sets The  PartnerName.
        /// </summary>
        public string PartnerName { get; set; }

        /// <summary>
        /// Gets or Sets The  PartnerLink.
        /// </summary>
        public string PartnerLink { get; set; }

        /// <summary>
        /// Gets or Sets The  PartnerPosition.
        /// </summary>
        public int PartnerPosition { get; set; }

    }
}