using Riafco.Dataflex.Pro.Models.Settings.ItemData;

namespace Riafco.Dataflex.Pro.Models.About.ItemData
{
    /// <summary>
    /// The SectionParagraphTranslationItemData class.
    /// </summary>
    public class SectionParagraphTranslationItemData
    {
        /// <summary>
        /// Gets or Sets The TraslationId.
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

        #region navigation proportises

        /// <summary>
        /// Gets or Sets The  LanguageId.
        /// </summary>
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or Sets The Language.
        /// </summary>
        public LanguageItemData Language { get; set; }

        /// <summary>
        /// Gets or Sets The  ParagraphId.
        /// </summary>
        public int? ParagraphId { get; set; }

        /// <summary>
        /// Gets or Sets The  SectionParagraph.
        /// </summary>
        public SectionParagraphItemData SectionParagraph { get; set; }

        #endregion
    }
}