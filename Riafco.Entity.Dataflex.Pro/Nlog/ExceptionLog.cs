using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Riafco.Entity.Dataflex.Pro.Nlog
{
    /// <summary>
    /// The ExceptionLog class.
    /// </summary>
    [Table("ExceptionLog")]
    public class ExceptionLog
    {
        /// <summary>
        /// Gets or sets ExceptionId.
        /// </summary>
        [Key]
        public int ExceptionId { get; set; }

        /// <summary>
        /// Gets or sets ExceptionDate.
        /// </summary>
        public DateTime ExceptionDate { get; set; }

        /// <summary>
        /// Gets or sets ExceptionLevel.
        /// </summary>
        public string ExceptionLevel { get; set; }

        /// <summary>
        /// Gets or sets ExceptionLogger.
        /// </summary>
        public string ExceptionLogger { get; set; }

        /// <summary>
        /// Gets or sets ExceptionMessage.
        /// </summary>
        public string ExceptionMessage { get; set; }

        /// <summary>
        /// Gets or sets ExceptionUserId
        /// </summary>
        public int ExceptionUserId { get; set; }

        /// <summary>
        /// Gets or sets TechniqueException.
        /// </summary>
        public string TechniqueException { get; set; }

        /// <summary>
        /// Gets or sets StacktraceException.
        /// </summary>
        public string StacktraceException { get; set; }

    }
}
