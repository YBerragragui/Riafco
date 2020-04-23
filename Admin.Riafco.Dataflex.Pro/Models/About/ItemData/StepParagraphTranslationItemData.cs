using Admin.Riafco.Dataflex.Pro.Models.Settings.ItemData;

namespace Admin.Riafco.Dataflex.Pro.Models.About.ItemData
{
    /// <summary>
    /// The SectionParagraphTranslationItemData class.
    /// </summary>
    public class StepParagraphTranslationItemData
    {
        /// <summary>
        /// Gets or Sets The TranslationId.
        /// </summary>
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The ParagraphTitle.
        /// </summary>
        public string ParagraphTitle { get; set; }

        /// <summary>
        /// Gets or Sets The ParagraphDescription.
        /// </summary>
        public string ParagraphDescription { get; set; }

        #region navigation attributes

        /// <summary>
        /// Gets or Sets The  LanguageId.
        /// </summary>
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or Sets The  Language.
        /// </summary>
        public LanguageItemData Language { get; set; }

        /// <summary>
        /// Gets or Sets The  ParagraphId.
        /// </summary>
        public int? ParagraphId { get; set; }

        /// <summary>
        /// Gets or Sets The StepParagraph.
        /// </summary>
        public StepParagraphItemData StepParagraph { get; set; }
        #endregion
    }
}