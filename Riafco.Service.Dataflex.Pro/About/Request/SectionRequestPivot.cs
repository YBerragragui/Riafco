using Riafco.Service.Dataflex.Pro.About.Data;
using Riafco.Service.Dataflex.Pro.About.Data.Enum;
using System;
using System.Collections.Generic;

namespace Riafco.Service.Dataflex.Pro.About.Request
{
    /// <summary>
    /// Gets or Sets The  Section request class.
    /// </summary>
    public class SectionRequestPivot
    {
        /// <summary>
        /// Gets or Sets The  SectionPivot requested.
        /// </summary>
        public SectionPivot SectionPivot { get; set; }

        /// <summary>
        /// Gets or Sets The  Find SectionEnum.
        /// </summary>
        public FindSectionPivot FindSectionPivot { get; set; }
    }
}