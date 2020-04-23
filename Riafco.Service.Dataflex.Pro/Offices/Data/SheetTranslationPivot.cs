using Riafco.Service.Dataflex.Pro.Languages.Data;

namespace Riafco.Service.Dataflex.Pro.Offices.Data
{
    /// <summary>
    /// The SheetTranslation pivot class.
    /// </summary>
    public class SheetTranslationPivot
    {
        /// <summary>
        /// Gets or Sets The  TranslationId.
        /// </summary>
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The  SheetTitle.
        /// </summary>
        public string SheetTitle { get; set; }

        /// <summary>
        /// Gets or Sets The  SheetValue.
        /// </summary>
        public string SheetValue { get; set; }

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
        /// Gets or Sets The  SheetId.
        /// </summary>
        public int? SheetId { get; set; }

        /// <summary>
        /// Gets or Sets The  Sheet.
        /// </summary>
        public SheetPivot Sheet { get; set; }
        #endregion
    }
}