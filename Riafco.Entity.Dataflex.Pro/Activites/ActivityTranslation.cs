using Riafco.Entity.Dataflex.Pro.Languages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Riafco.Entity.Dataflex.Pro.Activites
{
    /// <summary>
    /// The ActivityTraduction class.
    /// </summary>
    [Table("act_ActivityTranslations")]
    public class ActivityTranslation
    {
        /// <summary>
        /// Gets or sets TranslationId
        /// </summary>
        [Key]
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or sets ActiviteTitle
        /// </summary>
        public string ActivityTitle { get; set; }

        /// <summary>
        /// Gets or sets ActiviteIntroduction
        /// </summary>
        public string ActivityIntroduction { get; set; }

        /// <summary>
        /// Gets or sets ActiviteDescription
        /// </summary>
        public string ActivityDescription { get; set; }

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
        /// Gets or sets ActiviteId
        /// </summary>
        [ForeignKey("Activity")]
        public int? ActivityId { get; set; }

        /// <summary>
        /// Gets or sets activity
        /// </summary>
        public virtual Activity Activity { get; set; }

        #endregion
    }
}
