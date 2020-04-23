using Admin.Riafco.Dataflex.Pro.Models.Settings.ItemData;

namespace Admin.Riafco.Dataflex.Pro.Models.About.ItemData
{
    /// <summary>
    /// The SectionFileTranslationItemData class.
    /// </summary>
    public class SectionFileTranslationItemData
    {
        /// <summary>
        /// Gets or Sets The TranslationId.
        /// </summary>
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The  SectionFileSource.
        /// </summary>
        public string  SectionFileSource { get; set; }

        /// <summary>
        /// Gets or Sets The  SectionFileText.
        /// </summary>
        public string SectionFileText { get; set; }

        #region navigation attributes

        /// <summary>
        /// Gets or Sets The  SectionFileId.
        /// </summary>
        public int? SectionFileId { get; set; }

        /// <summary>
        /// Gets or Sets The  SectionFile.
        /// </summary>
        public SectionFileItemData SectionFile { get; set; }

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