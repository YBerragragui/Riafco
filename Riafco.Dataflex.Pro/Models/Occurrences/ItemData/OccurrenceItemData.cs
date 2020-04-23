using System;

namespace Riafco.Dataflex.Pro.Models.Occurrences.ItemData
{
    /// <summary>
    /// The Activite dto class.
    /// </summary>
    public class OccurrenceItemData
    {
        /// <summary>
        /// Gets or Sets The  OccurrenceId.
        /// </summary>
        public int OccurrenceId { get; set; }

        /// <summary>
        /// Gets or Sets The  OccurrencStarteDate.
        /// </summary>
        public DateTime OccurrenceStratDate { get; set; }

        /// <summary>
        /// Gets or Sets The  OccurrenceDate.
        /// </summary>
        public DateTime OccurrenceEndDate { get; set; }
        /// <summary>
        /// Gets or Sets The  OccurrenceLink.
        /// </summary>
        public string OccurrenceLink { get; set; }
    }
}