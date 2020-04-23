using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.About.Data;
using Riafco.Service.Dataflex.Pro.About.Data.Enum;

namespace Riafco.Service.Dataflex.Pro.About.Request
{
    /// <summary>
    /// Gets or Sets The  SectionParagraphTraslation request class.
    /// </summary>
    public class SectionParagraphTranslationRequestPivot
    {
        /// <summary>
        /// Gets or Sets The SectionParagraphTranslationPivot requested.
        /// </summary>
        public SectionParagraphTranslationPivot SectionParagraphTranslationPivot { get; set; }

        /// <summary>
        /// Gets or Sets The SectionParagraphTranslationPivotList requested.
        /// </summary>
        public List<SectionParagraphTranslationPivot> SectionParagraphTranslationPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The FindSectionParagraphTranslationPivot.
        /// </summary>
        public FindSectionParagraphTranslationPivot FindSectionParagraphTranslationPivot { get; set; }
    }
}