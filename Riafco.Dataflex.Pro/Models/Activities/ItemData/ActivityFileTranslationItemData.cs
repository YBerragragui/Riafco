using Riafco.Dataflex.Pro.Models.Settings.ItemData;

namespace Riafco.Dataflex.Pro.Models.Activities.ItemData
{
    /// <summary>
    /// The ActivityFileTranslationItemData class.
    /// </summary>
    public class ActivityFileTranslationItemData
    {
        /// <summary>
        /// Gets or Sets The TranslationId.
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

        #region navigation attributes

        /// <summary>
        /// Gets or Sets The  ActivityFileId.
        /// </summary>
        public int? ActivityFileId { get; set; }

        /// <summary>
        /// Gets or Sets The  ActivityFile.
        /// </summary>
        public ActivityFileItemData ActivityFile { get; set; }

        /// <summary>
        /// Gets or Sets The  LanguageId.
        /// </summary>
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or Sets The  Language.
        /// </summary>
        public LanguageItemData Language { get; set; }
        #endregion
    }
}