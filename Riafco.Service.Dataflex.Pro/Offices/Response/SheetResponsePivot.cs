using System;
using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.Offices.Data;

namespace Riafco.Service.Dataflex.Pro.Offices.Response
{
    /// <summary>
    /// The Sheet response class.
    /// </summary>
    public class SheetResponsePivot
    {
        /// <summary>
        /// Gets or Sets The  SheetPivotList.
        /// </summary>
        public List<SheetPivot> SheetPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  SheetPivot.
        /// </summary>
        public SheetPivot SheetPivot { get; set; }

    }
}