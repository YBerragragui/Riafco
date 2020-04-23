using Riafco.Service.Dataflex.Pro.Partners.Data;
using Riafco.Service.Dataflex.Pro.Partners.Data.Enum;
using System;
using System.Collections.Generic;

namespace Riafco.Service.Dataflex.Pro.Partners.Request
{
    /// <summary>
    /// Gets or Sets The  Partner request class.
    /// </summary>
    public class PartnerRequestPivot
    {
        /// <summary>
        /// Gets or Sets The  PartnerPivot requested.
        /// </summary>
        public PartnerPivot PartnerPivot { get; set; }

        /// <summary>
        /// Gets or Sets The  Find PartnerEnum.
        /// </summary>
        public FindPartnerPivot FindPartnerPivot { get; set; }
    }
}