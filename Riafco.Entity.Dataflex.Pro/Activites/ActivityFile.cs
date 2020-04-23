using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Riafco.Entity.Dataflex.Pro.Activites
{
    /// <summary>
    /// The ActiviteFile class
    /// </summary>
    [Table("act_ActivityFiles")]
    public class ActivityFile
    {
        /// <summary>
        /// Gets or sets FileId.
        /// </summary>
        [Key]
        public int ActivityFileId { get; set; }

        #region NAVIGATION ATTRIBUTES

        /// <summary>
        /// Gets or sets ActiviteId
        /// </summary>
        [ForeignKey("Activity")]
        public int? ActivityId { get; set; }

        /// <summary>
        /// Gets or sets activity
        /// </summary>
        public virtual Activity Activity { get; set; }

        #endregion
    }
}
