using Riafco.Entity.Dataflex.Pro.Languages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Riafco.Entity.Dataflex.Pro.About
{
    /// <summary>
    /// The SectionFileTranslation class
    /// </summary>
    [Table("about_SectionFileTranslations")]
    public class SectionFileTranslation
    {
        /// <summary>
        /// Gets or sets TranslationId.
        /// </summary>
        [Key]
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or sets SectionFileSource
        /// </summary>
        public string SectionFileSource { get; set; }

        /// <summary>
        /// Gets or sets 
        /// </summary>
        public string SectionFileText { get; set; }

        #region NAVIGATION PROPORTISES

        /// <summary>
        /// Gets or sets ActiviteId
        /// </summary>
        [ForeignKey("SectionFile")]
        public int? SectionFileId { get; set; }

        /// <summary>
        /// Gets or sets activity
        /// </summary>
        public virtual SectionFile SectionFile { get; set; }

        /// <summary>
        /// Gets or sets LangueId
        /// </summary>
        [ForeignKey("Language")]
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or sets Langue
        /// </summary>
        public virtual Language Language { get; set; }

        #endregion
    }
}
