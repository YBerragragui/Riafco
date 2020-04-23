
using System.Collections.Generic;

namespace Riafco.Dataflex.Pro.Models.Activities.ViewData
{
    /// <summary>
    /// The FilesViewData class.
    /// </summary>
    public class FilesViewData
    {
        /// <summary>
        /// Gets or sets Files
        /// </summary>
        public List<FileViewData> Files { get; set; }

        /// <summary>
        /// Gets or sets ActivityId.
        /// </summary>
        public int ActivityId { get; set; }
    }
}