using Riafco.Service.Dataflex.Pro.Languages.Data;
using Riafco.Service.Dataflex.Pro.Languages.Data.Enum;

namespace Riafco.Service.Dataflex.Pro.Languages.Request
{
    /// <summary>
    /// Gets or Sets The  Language request class.
    /// </summary>
    public class LanguageRequestPivot
    {
        /// <summary>
        /// Gets or Sets The  LanguagePivot requested.
        /// </summary>
        public LanguagePivot LanguagePivot { get; set; }

        /// <summary>
        /// Gets or Sets The  Find Language.
        /// </summary>
        public FindLanguagePivot FindLanguagePivot { get; set; }
    }
}