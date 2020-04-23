using System;
using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.Occurrences.Data;

namespace Riafco.Service.Dataflex.Pro.Occurrences.Response
{
    /// <summary>
    /// The OccurrenceTranslation response class.
    /// </summary>
    public class OccurrenceTranslationResponsePivot
    {
        /// <summary>
        /// Gets or Sets The  OccurrenceTranslationPivotList.
        /// </summary>
        public List<OccurrenceTranslationPivot> OccurrenceTranslationPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  OccurrenceTranslationPivot.
        /// </summary>
        public OccurrenceTranslationPivot OccurrenceTranslationPivot { get; set; }
    }
}