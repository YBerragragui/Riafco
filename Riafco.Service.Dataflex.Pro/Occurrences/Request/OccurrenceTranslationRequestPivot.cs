using Riafco.Service.Dataflex.Pro.Occurrences.Data;
using Riafco.Service.Dataflex.Pro.Occurrences.Data.Enum;
using System;
using System.Collections.Generic;

namespace Riafco.Service.Dataflex.Pro.Occurrences.Request
{
    /// <summary>
    /// Gets or Sets The  OccurrenceTranslation request class.
    /// </summary>
    public class OccurrenceTranslationRequestPivot
    {
        /// <summary>
        /// Gets or Sets The  OccurrenceTranslationPivot requested.
        /// </summary>
        public OccurrenceTranslationPivot OccurrenceTranslationPivot { get; set; }

        /// <summary>
        /// Gets or Sets The  OccurrenceTranslationPivot requested.
        /// </summary>
        public List<OccurrenceTranslationPivot> OccurrenceTranslationPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  Find OccurrenceTranslationEnum.
        /// </summary>
        public FindOccurrenceTranslationPivot FindOccurrenceTranslationPivot { get; set; }
    }
}