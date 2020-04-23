using System;

namespace Riafco.Service.Dataflex.Pro.About.Data
{
    /// <summary>
    /// The SectionParagraph pivot class.
    /// </summary>
    public class SectionParagraphPivot
    {
        /// <summary>
        /// Gets or Sets The  ParagraphId.
        /// </summary>
        public int ParagraphId { get; set; }

        #region navigation proportises

        /// <summary>
        /// Gets or Sets The  SectionId.
        /// </summary>
        public int? SectionId { get; set; }

        /// <summary>
        /// Gets or Sets The  Section.
        /// </summary>
        public SectionPivot Section { get; set; }

        #endregion
    }
}