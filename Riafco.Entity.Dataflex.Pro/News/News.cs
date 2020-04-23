using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Riafco.Entity.Dataflex.Pro.News
{
    /// <summary>
    /// The News class.
    /// </summary>
    [Table("news_News")]
    public class News
    {
        /// <summary>
        /// Get or sets NewsId
        /// </summary>
        [Key]
        public int NewsId { get; set; }

        /// <summary>
        /// Gets or sets NewsImage
        /// </summary>
        public string NewsImage { get; set; }

        /// <summary>
        /// Gets or sets NewsDate
        /// </summary>
        public DateTime NewsDate { get; set; }
    }
}
