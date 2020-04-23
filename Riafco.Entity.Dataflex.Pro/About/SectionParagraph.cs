using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Riafco.Entity.Dataflex.Pro.About
{
    /// <summary>
    /// The SectionParagraph class.
    /// </summary>
    [Table("about_SectionParagraphs")]
    public class SectionParagraph
    {
        /// <summary>
        /// Gets or sets ParagraphId.
        /// </summary>
        [Key]
        public int ParagraphId { get; set; }

        #region navigation attributes

        /// <summary>
        /// Gets or sets ActiviteId
        /// </summary>
        [ForeignKey("Section")]
        public int? SectionId { get; set; }

        /// <summary>
        /// Gets or sets section
        /// </summary>
        public virtual Section Section { get; set; }

        #endregion
    }
}
