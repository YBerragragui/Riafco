using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Riafco.Entity.Dataflex.Pro.About
{
    /// <summary>
    /// The AboutSection class
    /// </summary>
    [Table("about_Sections")]
    public class Section
    {
        /// <summary>
        /// Gets or sets SectionId class
        /// </summary>
        [Key]
        public int SectionId { get; set; }

        /// <summary>
        /// Gets or sets NewsImage
        /// </summary>
        public string SectionImage { get; set; }
    }
}
