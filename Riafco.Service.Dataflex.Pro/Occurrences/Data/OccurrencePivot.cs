using System;

namespace Riafco.Service.Dataflex.Pro.Occurrences.Data
{
    /// <summary>
    /// The Occurrence pivot class.
    /// </summary>
    public class OccurrencePivot
    {
        /// <summary>
        /// Gets or Sets The OccurrenceId.
        /// </summary>
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
        /// Gets or Sets The OccurrenceLink.
        /// </summary>
        public string OccurrenceLink { get; set; }

    }
}