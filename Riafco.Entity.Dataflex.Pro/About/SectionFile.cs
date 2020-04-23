using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Riafco.Entity.Dataflex.Pro.About
{
    /// <summary>
    /// The ActiviteFile class
    /// </summary>
    [Table("about_SectionFiles")]
    public class SectionFile
    {
        /// <summary>
        /// Gets or sets FileId.
        /// </summary>
        [Key]
        public int SectionFileId { get; set; }

        #region NAVIGATION ATTRIBUTES

        /// <summary>
        /// Gets or sets ActiviteId
        /// </summary>
        [ForeignKey("Section")]
        public int? SectionId { get; set; }

        /// <summary>
        /// Gets or sets activity
        /// </summary>
        public virtual Section Section { get; set; }

        #endregion
    }
}
