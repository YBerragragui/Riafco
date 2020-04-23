using Riafco.Service.Dataflex.Pro.Activites.Data;
using Riafco.Service.Dataflex.Pro.Activites.Data.Enum;

namespace Riafco.Service.Dataflex.Pro.Activites.Request
{
    /// <summary>
    /// Gets or Sets The  Activity request class.
    /// </summary>
    public class ActivityRequestPivot
    {
        /// <summary>
        /// Gets or Sets The  ActivityPivot requested.
        /// </summary>
        public ActivityPivot ActivityPivot { get; set; }

        /// <summary>
        /// Gets or Sets The  Find Activity.
        /// </summary>
        public FindActivityPivot FindActivityPivot { get; set; }
    }
}