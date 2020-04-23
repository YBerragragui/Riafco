using System.Collections.Generic;

namespace Riafco.Dataflex.Pro.Models.About.ItemData
{
    /// <summary>
    /// The SectionParagraphItemData class.
    /// </summary>
    public class SectionParagraphItemData
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
        public SectionItemData Section { get; set; }

        /// <summary>
        /// Gets or sets TranslationItemDataList.
        /// </summary>
        public List<SectionParagraphTranslationItemData> TranslationItemDataList { get; set; }

        #endregion
    }
}