using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Riafco.Entity.Dataflex.Pro.Occurrences
{
    /// <summary>
    /// The Occurrence class
    /// </summary>
    [Table("occu_Occurrences")]
    public class Occurrence
    {
        /// <summary>
        /// Gets or sets OccurrenceId.
        /// </summary>
        [Key]
        public int OccurrenceId { get; set; }

        /// <summary>
        /// Gets or sets OccurrenceStartDate.
        /// </summary>
        public DateTime OccurrenceStartDate { get; set; }

        /// <summary>
        /// Gets or sets OccurrenceEndDate.
        /// </summary>
        public DateTime OccurrenceEndDate { get; set; }

        /// <summary>
        /// Gets or sets OccurrenceLink.
        /// </summary>
        public string OccurrenceLink { get; set; }
    }
}
