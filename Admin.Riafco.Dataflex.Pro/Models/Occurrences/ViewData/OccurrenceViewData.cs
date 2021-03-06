﻿using System.Collections.Generic;
using Admin.Riafco.Dataflex.Pro.Models.Occurrences.ItemData;

namespace Admin.Riafco.Dataflex.Pro.Models.Occurrences.ViewData
{
    /// <summary>
    /// The OccurrenceViewData class.
    /// </summary>
    public class OccurrenceViewData
    {
        /// <summary>
        /// Gets or sets Occurrence.
        /// </summary>
        public OccurrenceItemData Occurrence { get; set; }

        /// <summary>
        /// Gets or sets TranslationsList.
        /// </summary>
        public List<OccurrenceTranslationItemData> TranslationsList { get; set; }
    }
}