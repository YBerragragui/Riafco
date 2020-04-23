using Riafco.Service.Dataflex.Pro.Activites.Data;
using Riafco.Service.Dataflex.Pro.Activites.Data.Enum;

namespace Riafco.Service.Dataflex.Pro.Activites.Request
{
    /// <summary>
    /// Gets or Sets The  ActivityFile request class.
    /// </summary>
    public class ActivityFileRequestPivot
    {
        /// <summary>
        /// Gets or Sets The  ActivityFilePivot requested.
        /// </summary>
        public ActivityFilePivot ActivityFilePivot { get; set; }

        /// <summary>
        /// Gets or Sets The  Find ActivityFile enum.
        /// </summary>
        public FindActivityFilePivot FindActivityFilePivot { get; set; }
    }
}