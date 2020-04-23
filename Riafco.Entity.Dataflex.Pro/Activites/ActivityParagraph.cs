using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Riafco.Entity.Dataflex.Pro.Activites
{
    /// <summary>
    /// The ActivityParagraph class.
    /// </summary>
    [Table("act_Subsections")]
    public class ActivityParagraph
    {
        /// <summary>
        /// Gets or sets ParagraphId.
        /// </summary>
        [Key]
        public int ParagraphId { get; set; }

        /// <summary>
        /// Gets or sets ParagraphImage.
        /// </summary>
        public string ParagraphImage { get; set; }

        #region navigation attributes

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
