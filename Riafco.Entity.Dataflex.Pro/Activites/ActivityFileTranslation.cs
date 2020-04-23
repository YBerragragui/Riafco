using Riafco.Entity.Dataflex.Pro.Languages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Riafco.Entity.Dataflex.Pro.Activites
{
    /// <summary>
    /// The ActivityFileTranslation class
    /// </summary>
    [Table("act_FileTranslations")]
    public class ActivityFileTranslation
    {
        /// <summary>
        /// Gets or sets TranslationId.
        /// </summary>
        [Key]
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or sets ActivityFileSource
        /// </summary>
        public string ActivityFileSource { get; set; }

        /// <summary>
        /// Gets or sets 
        /// </summary>
        public string ActivityFileText { get; set; }

        #region NAVIGATION PROPORTISES

        /// <summary>
        /// Gets or sets ActiviteId
        /// </summary>
        [ForeignKey("ActivityFile")]
        public int? ActivityFileId { get; set; }

        /// <summary>
        /// Gets or sets activity
        /// </summary>
        public virtual ActivityFile ActivityFile { get; set; }

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
