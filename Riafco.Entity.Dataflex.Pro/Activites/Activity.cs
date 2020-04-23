using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Riafco.Entity.Dataflex.Pro.Activites
{
    /// <summary>
    /// The Activite class.
    /// </summary>
    [Table("act_Activites")]
    public class Activity
    {
        /// <summary>
        /// Gets or sets ActivityId
        /// </summary>
        [Key]
        public int ActivityId { get; set; }

        /// <summary>
        /// Gets or sets ActivityIcon
        /// </summary>
        public string ActivityIcon { get; set; }

        /// <summary>
        /// Gets or sets ActivityImage
        /// </summary>
        public string ActivityImage { get; set; }
    }
}
