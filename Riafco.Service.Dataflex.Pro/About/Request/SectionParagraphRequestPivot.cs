using Riafco.Service.Dataflex.Pro.About.Data;
using Riafco.Service.Dataflex.Pro.About.Data.Enum;

namespace Riafco.Service.Dataflex.Pro.About.Request
{
    /// <summary>
    /// Gets or Sets The  SectionParagraph request class.
    /// </summary>
    public class SectionParagraphRequestPivot
    {
        /// <summary>
        /// Gets or Sets The  SectionParagraphPivot requested.
        /// </summary>
        public SectionParagraphPivot SectionParagraphPivot { get; set; }

        /// <summary>
        /// Gets or Sets The  Find SectionParagraphEnum.
        /// </summary>
        public FindSectionParagraphPivot FindSectionParagraphPivot { get; set; }
    }
}