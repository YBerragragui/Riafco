using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.Ressources.Data;

namespace Riafco.Service.Dataflex.Pro.Ressources.Response
{
    /// <summary>
    /// The Theme response class.
    /// </summary>
    public class ThemeResponsePivot
    {
        /// <summary>
        /// Gets or Sets The  ThemePivotList.
        /// </summary>
        public List<ThemePivot> ThemePivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  ThemePivot.
        /// </summary>
        public ThemePivot ThemePivot { get; set; }
    }
}