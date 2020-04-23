using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.About.Data;

namespace Riafco.Service.Dataflex.Pro.About.Response
{
    /// <summary>
    /// The SectionParagraph response class.
    /// </summary>
    public class SectionParagraphResponsePivot
    {
        /// <summary>
        /// Gets or Sets The  SectionParagraphPivotList.
        /// </summary>
        public List<SectionParagraphPivot> SectionParagraphPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  SectionParagraphPivot.
        /// </summary>
        public SectionParagraphPivot SectionParagraphPivot { get; set; }
    }
}