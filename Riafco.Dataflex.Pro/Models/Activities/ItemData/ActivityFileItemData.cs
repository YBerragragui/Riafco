namespace Riafco.Dataflex.Pro.Models.Activities.ItemData
{
    /// <summary>
    /// The ActivityFileItemData class.
    /// </summary>
    public class ActivityFileItemData
    {
        /// <summary>
        /// Gets or Sets The ActivityFileId.
        /// </summary>
        public int ActivityFileId { get; set; }

        #region navigation attributes

        /// <summary>
        /// Gets or Sets The  ActivityId.
        /// </summary>
        public int? ActivityId { get; set; }

        /// <summary>
        /// Gets or Sets The  Activity.
        /// </summary>
        public ActivityItemData Activity { get; set; }

        #endregion
    }
}