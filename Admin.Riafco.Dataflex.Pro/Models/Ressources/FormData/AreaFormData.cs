using System.Collections.Generic;

namespace Admin.Riafco.Dataflex.Pro.Models.Ressources.FormData
{
    /// <summary>
    /// The AreaFormData class.
    /// </summary>
    public class AreaFormData
    {
        /// <summary>
        /// Gets or Sets The AreaId.
        /// </summary>
        public int AreaId { get; set; }

        /// <summary>
        /// Get or set TranslationsList.
        /// </summary>
        public List<AreaTranslationFormData> TranslationsList { get; set; }
    }
}