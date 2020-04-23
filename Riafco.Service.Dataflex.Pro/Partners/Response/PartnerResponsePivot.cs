using System;
using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.Partners.Data;

namespace Riafco.Service.Dataflex.Pro.Partners.Response
{
    /// <summary>
    /// The Partner response class.
    /// </summary>
    public class PartnerResponsePivot
    {
        /// <summary>
        /// Gets or Sets The  PartnerPivotList.
        /// </summary>
        public List<PartnerPivot> PartnerPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  PartnerPivot.
        /// </summary>
        public PartnerPivot PartnerPivot { get; set; }

    }
}