using Riafco.Service.Dataflex.Pro.Languages.Data;

namespace Riafco.Service.Dataflex.Pro.About.Data
{
    /// <summary>
    /// The SectionTranslation pivot class.
    /// </summary>
    public class SectionTranslationPivot
    {
        /// <summary>
        /// Gets or Sets The  TranslationId.
        /// </summary>
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The  SectionTitle.
        /// </summary>
        public string SectionTitle { get; set; }

        /// <summary>
        /// Gets or sets SectionDesciption.
        /// </summary>
        public string SectionDesciption { get; set; }

        #region navigation properties
        /// <summary>
        /// Gets or Sets The  LanguageId.
        /// </summary>
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or Sets The  Language.
        /// </summary>
        public LanguagePivot Language { get; set; }

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