
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Riafco.Entity.Dataflex.Pro.Languages;

namespace Riafco.Entity.Dataflex.Pro.Offices
{
    /// <summary>
    /// The CountrySheetTraslation class.
    /// </summary>
    [Table("office_SheetTranslations")]
    public class SheetTranslation
    {
        /// <summary>
        /// Gets or sets TranslationId
        /// </summary>
        [Key]
        public int TranslationId { get; set; }

        /// <summary>
        /// Get or sets SheetTitle.
        /// </summary>
        public string SheetTitle { get; set; }

        /// <summary>
        /// Get or sets SheetValue.
        /// </summary>
        public string SheetValue { get; set; }

        #region navigation proportises

        /// <summary>
        /// Gets or sets LangueId
        /// </summary>
        [ForeignKey("Language")]
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or sets Langue
        /// </summary>
        public virtual Language Language { get; set; }

        /// <summary>
        /// Gets or sets SheetId.
        /// </summary>
        [ForeignKey("Sheet")]
        public int? SheetId { get; set; }

        /// <summary>
        /// Gets or sets activity.
        /// </summary>
        public virtual Sheet Sheet { get; set; }

        #endregion
    }
}
