using System.Collections.Generic;

namespace Riafco.Dataflex.Pro.Models.About.ItemData
{
    /// <summary>
    /// The SectionParagraphItemData class.
    /// </summary>
    public class StepParagraphItemData
    {
        /// <summary>
        /// Gets or Sets The  ParagraphId.
        /// </summary>
        public int ParagraphId { get; set; }

        #region navigation proportises

        /// <summary>
        /// Gets or Sets The  StepId.
        /// </summary>
        public int? StepId { get; set; }

        /// <summary>
        /// Gets or Sets The  Step.
        /// </summary>
        public SectionItemData Step { get; set; }

        /// <summary>
        /// Gets or sets TranslationItemDataList.
        /// </summary>
        public List<StepParagraphTranslationItemData> TranslationItemDataList { get; set; }

        #endregion
    }
}