using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.About.Data;

namespace Riafco.Service.Dataflex.Pro.About.Response
{
    /// <summary>
    /// The SectionFile response class.
    /// </summary>
    public class SectionFileResponsePivot
    {
        /// <summary>
        /// Gets or Sets The SectionFilePivotList.
        /// </summary>
        public List<SectionFilePivot> SectionFilePivotList { get; set; }

        /// <summary>
        /// Gets or Sets The SectionFilePivot.
        /// </summary>
        public SectionFilePivot SectionFilePivot { get; set; }

    }
}