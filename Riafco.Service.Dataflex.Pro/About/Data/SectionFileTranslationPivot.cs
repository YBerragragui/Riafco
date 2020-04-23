using Riafco.Service.Dataflex.Pro.Languages.Data;

namespace Riafco.Service.Dataflex.Pro.About.Data
{
    /// <summary>
    /// The SectionFileTranslation pivot class.
    /// </summary>
    public class SectionFileTranslationPivot
    {
        /// <summary>
        /// Gets or Sets The  TranslationId.
        /// </summary>
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The  SectionFileSource.
        /// </summary>
        public string SectionFileSource { get; set; }

        /// <summary>
        /// Gets or Sets The  SectionFileText.
        /// </summary>
        public string SectionFileText { get; set; }

        #region NAVIGATION ATTRIBUTES

        /// <summary>
        /// Gets or Sets The  SectionFileId.
        /// </summary>
        public int? SectionFileId { get; set; }

        /// <summary>
        /// Gets or Sets The  SectionFile.
        /// </summary>
        public SectionFilePivot SectionFile { get; set; }

        /// <summary>
        /// Gets or Sets The  LanguageId.
        /// </summary>
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or Sets The  Language.
        /// </summary>
        public LanguagePivot Language { get; set; }

        #endregion
    }
}