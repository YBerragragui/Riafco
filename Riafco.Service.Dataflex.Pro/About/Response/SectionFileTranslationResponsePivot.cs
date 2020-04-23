using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.About.Data;

namespace Riafco.Service.Dataflex.Pro.About.Response
{
    /// <summary>
    /// The SectionFileTranslation response class.
    /// </summary>
    public class SectionFileTranslationResponsePivot
    {
        /// <summary>
        /// Gets or Sets The  SectionFileTranslationPivotList.
        /// </summary>
        public List<SectionFileTranslationPivot> SectionFileTranslationPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  SectionFileTranslationPivot.
        /// </summary>
        public SectionFileTranslationPivot SectionFileTranslationPivot { get; set; }

    }
}