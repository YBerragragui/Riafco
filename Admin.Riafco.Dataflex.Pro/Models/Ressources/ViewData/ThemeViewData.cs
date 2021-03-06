﻿using System.Collections.Generic;
using Admin.Riafco.Dataflex.Pro.Models.Ressources.ItemData;

namespace Admin.Riafco.Dataflex.Pro.Models.Ressources.ViewData
{
    /// <summary>
    /// The ThemeViewData class.
    /// </summary>
    public class ThemeViewData
    {
        /// <summary>
        /// Gets or sets Theme.
        /// </summary>
        public ThemeItemData Theme { get; set; }

        /// <summary>
        /// Gets or sets TranslationsList.
        /// </summary>
        public List<ThemeTranslationItemData> TranslationsList { get; set; }
    }
}