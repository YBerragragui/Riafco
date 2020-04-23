using Riafco.Service.Dataflex.Pro.Ressources.Data;
using Riafco.Service.Dataflex.Pro.Ressources.Data.Enum;

namespace Riafco.Service.Dataflex.Pro.Ressources.Request
{
    /// <summary>
    /// Gets or Sets The  Area request class.
    /// </summary>
    public class AreaRequestPivot
    {
        /// <summary>
        /// Gets or Sets The  AreaPivot requested.
        /// </summary>
        public AreaPivot AreaPivot { get; set; }

        /// <summary>
        /// Gets or Sets The  Find AreaEnum.
        /// </summary>
        public FindAreaPivot FindAreaPivot { get; set; }
    }
}