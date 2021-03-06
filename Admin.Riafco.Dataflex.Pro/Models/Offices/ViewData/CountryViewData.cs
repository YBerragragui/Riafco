﻿using System.Collections.Generic;
using Admin.Riafco.Dataflex.Pro.Models.Offices.ItemData;

namespace Admin.Riafco.Dataflex.Pro.Models.Offices.ViewData
{
    /// <summary>
    /// The CountryViewData class.
    /// </summary>
    public class CountryViewData
    {
        /// <summary>
        /// Gets or sets Country.
        /// </summary>
        public CountryItemData Country { get; set; }

        /// <summary>
        /// Gets or sets TranslationsList.
        /// </summary>
        public List<CountryTranslationItemData> TranslationsList { get; set; }
    }
}