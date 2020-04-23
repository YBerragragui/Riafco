using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.Ressources.Data;
using Riafco.Service.Dataflex.Pro.Ressources.Data.Enum;

namespace Riafco.Service.Dataflex.Pro.Ressources.Request
{
    /// <summary>
    /// Gets or Sets The  ThemeTranslation request class.
    /// </summary>
    public class ThemeTranslationRequestPivot
    {
        /// <summary>
        /// Gets or Sets The  ThemeTranslationPivot requested.
        /// </summary>
        public ThemeTranslationPivot ThemeTranslationPivot { get; set; }

        /// <summary>
        /// Gets or Sets The  ThemeTranslationPivotList requested.
        /// </summary>
        public List<ThemeTranslationPivot> ThemeTranslationPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  Find ThemeTranslationEnum.
        /// </summary>
        public FindThemeTranslationPivot FindThemeTranslationPivot { get; set; }
    }
}