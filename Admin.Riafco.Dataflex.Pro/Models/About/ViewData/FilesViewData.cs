
using System.Collections.Generic;

namespace Admin.Riafco.Dataflex.Pro.Models.About.ViewData
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
        /// Gets or sets SectionId.
        /// </summary>
        public int SectionId { get; set; }
    }
}