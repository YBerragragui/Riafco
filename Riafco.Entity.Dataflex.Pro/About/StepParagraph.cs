using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Riafco.Entity.Dataflex.Pro.About
{
    /// <summary>
    /// The StepParagraph class.
    /// </summary>
    [Table("about_StepParagraphs")]
    public class StepParagraph
    {
        /// <summary>
        /// Gets or sets ParagraphId.
        /// </summary>
        [Key]
        public int ParagraphId { get; set; }

        #region navigation attributes

        /// <summary>
        /// Gets or sets StepId
        /// </summary>
        [ForeignKey("Step")]
        public int? StepId { get; set; }

        /// <summary>
        /// Gets or sets Step
        /// </summary>
        public virtual Step Step { get; set; }

        #endregion
    }
}
