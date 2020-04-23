using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.About.Data;
using Riafco.Service.Dataflex.Pro.About.Data.Enum;

namespace Riafco.Service.Dataflex.Pro.About.Request
{
    /// <summary>
    /// Gets or Sets The  SectionFileTranslation request class.
    /// </summary>
    public class SectionFileTranslationRequestPivot
    {
        /// <summary>
        /// Gets or Sets The  SectionFileTranslationPivot requested.
        /// </summary>
        public SectionFileTranslationPivot SectionFileTranslationPivot { get; set; }

        /// <summary>
        /// Gets or Sets The SectionFileTranslationPivotList requested.
        /// </summary>
        public List<SectionFileTranslationPivot> SectionFileTranslationPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  Find SectionFileTranslationEnum.
        /// </summary>
        public FindSectionFileTranslationPivot FindSectionFileTranslationPivot { get; set; }
    }
}