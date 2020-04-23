using System.Collections.Generic;

namespace Admin.Riafco.Dataflex.Pro.Models.Ressources.FormData
{
    /// <summary>
    /// The ThemeFormData class.
    /// </summary>
    public class ThemeFormData
    {
        /// <summary>
        /// Gets or Sets The  ThemeId.
        /// </summary>
        public int ThemeId { get; set; }

        /// <summary>
        /// Get or set TranslationsList.
        /// </summary>
        public List<ThemeTranslationFormData> TranslationsList { get; set; }
    }
}