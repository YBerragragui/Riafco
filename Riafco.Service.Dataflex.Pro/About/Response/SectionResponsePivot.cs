using System;
using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.About.Data;

namespace Riafco.Service.Dataflex.Pro.About.Response
{
    /// <summary>
    /// The Section response class.
    /// </summary>
    public class SectionResponsePivot
    {
        /// <summary>
        /// Gets or Sets The  SectionPivotList.
        /// </summary>
        public List<SectionPivot> SectionPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  SectionPivot.
        /// </summary>
        public SectionPivot SectionPivot { get; set; }

    }
}