using Riafco.Service.Dataflex.Pro.Ressources.Data;
using Riafco.Service.Dataflex.Pro.Ressources.Data.Enum;

namespace Riafco.Service.Dataflex.Pro.Ressources.Request
{
    /// <summary>
    /// Gets or Sets The  Theme request class.
    /// </summary>
    public class ThemeRequestPivot
    {
        /// <summary>
        /// Gets or Sets The  ThemePivot requested.
        /// </summary>
        public ThemePivot ThemePivot { get; set; }

        /// <summary>
        /// Gets or Sets The  Find ThemeEnum.
        /// </summary>
        public FindThemePivot FindThemePivot { get; set; }
    }
}