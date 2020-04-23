using System;
using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.Occurrences.Data;

namespace Riafco.Service.Dataflex.Pro.Occurrences.Response
{
    /// <summary>
    /// The Occurrence response class.
    /// </summary>
    public class OccurrenceResponsePivot
    {
        /// <summary>
        /// Gets or Sets The  OccurrencePivotList.
        /// </summary>
        public List<OccurrencePivot> OccurrencePivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  OccurrencePivot.
        /// </summary>
        public OccurrencePivot OccurrencePivot { get; set; }

    }
}