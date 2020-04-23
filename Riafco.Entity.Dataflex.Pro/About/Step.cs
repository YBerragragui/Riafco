using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Riafco.Entity.Dataflex.Pro.About
{
    /// <summary>
    /// The step class.
    /// </summary>
    [Table("about_Steps")]
    public class Step
    {
        /// <summary>
        /// Gets or sets StepId
        /// </summary>
        [Key]
        public int StepId { get; set; }

        /// <summary>
        /// Gets or sets StepDate.
        /// </summary>
        public DateTime StepDate { get; set; }
    }
}
