using Riafco.Service.Dataflex.Pro.About.Data;
using Riafco.Service.Dataflex.Pro.About.Data.Enum;
using System;
using System.Collections.Generic;

namespace Riafco.Service.Dataflex.Pro.About.Request
{
    /// <summary>
    /// Gets or Sets The  SectionTranslation request class.
    /// </summary>
    public class SectionTranslationRequestPivot
    {
        /// <summary>
        /// Gets or Sets The  SectionTranslationPivot requested.
        /// </summary>
        public SectionTranslationPivot SectionTranslationPivot { get; set; }

        /// <summary>
        /// Gets or Sets The  SectionTranslationPivot requested.
        /// </summary>
        public List<SectionTranslationPivot> SectionTranslationPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  Find SectionTranslationEnum.
        /// </summary>
        public FindSectionTranslationPivot FindSectionTranslationPivot { get; set; }
    }
}