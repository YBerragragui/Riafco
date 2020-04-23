using Riafco.Service.Dataflex.Pro.Occurrences.Data;
using Riafco.Service.Dataflex.Pro.Occurrences.Data.Enum;
using System;

namespace Riafco.Service.Dataflex.Pro.Occurrences.Request
{
    /// <summary>
    /// Gets or Sets The  Occurrence request class.
    /// </summary>
    public class OccurrenceRequestPivot
    {
        /// <summary>
        /// Gets or Sets The  OccurrencePivot requested.
        /// </summary>
        public OccurrencePivot OccurrencePivot { get; set; }

        /// <summary>
        /// Gets or Sets The  Find OccurrenceEnum.
        /// </summary>
        public FindOccurrencePivot FindOccurrencePivot { get; set; }
    }
}