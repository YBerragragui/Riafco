using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.Ressources.Data;

namespace Riafco.Service.Dataflex.Pro.Ressources.Response
{
    /// <summary>
    /// The ThemeTranslation response class.
    /// </summary>
    public class ThemeTranslationResponsePivot
    {
        /// <summary>
        /// Gets or Sets The  ThemeTranslationPivotList.
        /// </summary>
        public List<ThemeTranslationPivot> ThemeTranslationPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  ThemeTranslationPivot.
        /// </summary>
        public ThemeTranslationPivot ThemeTranslationPivot { get; set; }
    }
}