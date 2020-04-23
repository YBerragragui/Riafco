using Riafco.Service.Dataflex.Pro.About.Data;
using Riafco.Service.Dataflex.Pro.About.Data.Enum;

namespace Riafco.Service.Dataflex.Pro.About.Request
{
    /// <summary>
    /// Gets or Sets The  SectionFile request class.
    /// </summary>
    public class SectionFileRequestPivot
    {
        /// <summary>
        /// Gets or Sets The  SectionFilePivot requested.
        /// </summary>
        public SectionFilePivot SectionFilePivot { get; set; }

        /// <summary>
        /// Gets or Sets The  Find SectionFile enum.
        /// </summary>
        public FindSectionFilePivot FindSectionFilePivot { get; set; }
    }
}