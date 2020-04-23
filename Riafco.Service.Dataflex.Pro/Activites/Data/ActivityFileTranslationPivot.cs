using Riafco.Service.Dataflex.Pro.Languages.Data;

namespace Riafco.Service.Dataflex.Pro.Activites.Data
{
    /// <summary>
    /// The ActivityFileTranslation pivot class.
    /// </summary>
    public class ActivityFileTranslationPivot
    {
        /// <summary>
        /// Gets or Sets The  TranslationId.
        /// </summary>
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The  ActivityFileSource.
        /// </summary>
        public string ActivityFileSource { get; set; }

        /// <summary>
        /// Gets or Sets The  ActivityFileText.
        /// </summary>
        public string ActivityFileText { get; set; }

        #region NAVIGATION ATTRIBUTES

        /// <summary>
        /// Gets or Sets The  ActivityFileId.
        /// </summary>
        public int? ActivityFileId { get; set; }

        /// <summary>
        /// Gets or Sets The  ActivityFile.
        /// </summary>
        public ActivityFilePivot ActivityFile { get; set; }

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