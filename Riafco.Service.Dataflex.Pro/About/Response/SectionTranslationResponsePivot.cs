using System;
using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.About.Data;

namespace Riafco.Service.Dataflex.Pro.About.Response
{
    /// <summary>
    /// The SectionTranslation response class.
    /// </summary>
    public class SectionTranslationResponsePivot
    {
        /// <summary>
        /// Gets or Sets The  SectionTranslationPivotList.
        /// </summary>
        public List<SectionTranslationPivot> SectionTranslationPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  SectionTranslationPivot.
        /// </summary>
        public SectionTranslationPivot SectionTranslationPivot { get; set; }

    }
}