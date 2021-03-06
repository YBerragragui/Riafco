using Riafco.Service.Dataflex.Pro.Languages.Data;

namespace Riafco.Service.Dataflex.Pro.About.Data
{
    /// <summary>
    /// The SectionParagraphTraslation pivot class.
    /// </summary>
    public class SectionParagraphTranslationPivot
    {
        /// <summary>
        /// Gets or Sets The TranslationId.
        /// </summary>
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The  ParagraphTitle.
        /// </summary>
        public string ParagraphTitle { get; set; }

        /// <summary>
        /// Gets or Sets The  ParagraphDescription.
        /// </summary>
        public string ParagraphDescription { get; set; }

        #region navigation proportises

        /// <summary>
        /// Gets or Sets The  LanguageId.
        /// </summary>
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or Sets The  Language.
        /// </summary>
        public LanguagePivot Language { get; set; }

        /// <summary>
        /// Gets or Sets The  ParagraphId.
        /// </summary>
        public int? ParagraphId { get; set; }

        /// <summary>
        /// Gets or Sets The  SectionParagraph.
        /// </summary>
        public SectionParagraphPivot SectionParagraph { get; set; }

        #endregion
    }
}