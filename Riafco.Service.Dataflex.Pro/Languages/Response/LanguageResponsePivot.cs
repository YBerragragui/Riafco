using Riafco.Service.Dataflex.Pro.Languages.Data;
using System.Collections.Generic;

namespace Riafco.Service.Dataflex.Pro.Languages.Response
{
    /// <summary>
    /// The Language response class.
    /// </summary>
    public class LanguageResponsePivot
    {
        /// <summary>
        /// Gets or Sets The  LanguagePivotList.
        /// </summary>
        public List<LanguagePivot> LanguagePivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  LanguagePivot.
        /// </summary>
        public LanguagePivot LanguagePivot { get; set; }
    }
}