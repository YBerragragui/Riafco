using System;
using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.Occurrences.Data;
using Riafco.Service.Dataflex.Pro.Languages.Data;

namespace Riafco.Service.Dataflex.Pro.Occurrences.Data
{
    /// <summary>
    /// The OccurrenceTranslation pivot class.
    /// </summary>
    public class OccurrenceTranslationPivot
    {
        /// <summary>
        /// Gets or Sets The  TranslationId.
        /// </summary>
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The  OccurrenceTitle.
        /// </summary>
        public string OccurrenceTitle { get; set; }

        /// <summary>
        /// Gets or Sets The  OccurrenceDescription.
        /// </summary>
        public string OccurrenceDescription { get; set; }

        #region navigation properties
        /// <summary>
        /// Gets or Sets The  OccurrenceId.
        /// </summary>
        public int? OccurrenceId { get; set; }

        /// <summary>
        /// Gets or Sets The  Occurrence.
        /// </summary>
        public OccurrencePivot Occurrence { get; set; }

        /// <summary>
        /// Gets or Sets The  LanguageId.
        /// </summary>
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or Sets The  Language.
        /// </summary>
        public LanguagePivot Language { get; set; }
        #endregion
    }
}