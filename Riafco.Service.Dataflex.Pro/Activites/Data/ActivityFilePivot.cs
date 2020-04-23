
namespace Riafco.Service.Dataflex.Pro.Activites.Data
{
    /// <summary>
    /// The ActivityFile pivot class.
    /// </summary>
    public class ActivityFilePivot
    {
        /// <summary>
        /// Gets or Sets The ActivityFileId.
        /// </summary>
        public int ActivityFileId { get; set; }

        #region NAVIGATION ATTRIBUTES

        /// <summary>
        /// Gets or Sets The ActivityId.
        /// </summary>
        public int? ActivityId { get; set; }

        /// <summary>
        /// Gets or Sets The  Activity.
        /// </summary>
        public ActivityPivot Activity { get; set; }
        #endregion
    }
}