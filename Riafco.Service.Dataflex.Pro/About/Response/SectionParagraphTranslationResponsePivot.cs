using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.About.Data;

namespace Riafco.Service.Dataflex.Pro.About.Response
{
    /// <summary>
    /// The SectionParagraphTraslation response class.
    /// </summary>
    public class SectionParagraphTranslationResponsePivot
    {
        /// <summary>
        /// Gets or Sets The  SectionParagraphTranslationPivotList.
        /// </summary>
        public List<SectionParagraphTranslationPivot> SectionParagraphTranslationPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The SectionParagraphTranslationPivot.
        /// </summary>
        public SectionParagraphTranslationPivot SectionParagraphTranslationPivot { get; set; }

    }
}