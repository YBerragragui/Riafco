using Riafco.Dataflex.Pro.Models.Settings.ItemData;

namespace Riafco.Dataflex.Pro.Models.Offices.ItemData
{
    /// <summary>
    /// The SheetTranslationItemData class.
    /// </summary>
    public class SheetTranslationItemData
    {
        /// <summary>
        /// Gets or Sets The TraslationId.
        /// </summary>
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The SheetTitle.
        /// </summary>
        public string SheetTitle { get; set; }

        /// <summary>
        /// Gets or Sets The SheetDescription.
        /// </summary>
        public string SheetValue { get; set; }

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
        /// Gets or Sets The  SheetId.
        /// </summary>
        public int? SheetId { get; set; }

        /// <summary>
        /// Gets or Sets The  Sheet.
        /// </summary>
        public SheetItemData Sheet { get; set; }

        #endregion
    }
}