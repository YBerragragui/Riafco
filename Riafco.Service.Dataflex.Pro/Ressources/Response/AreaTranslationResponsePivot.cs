using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.Ressources.Data;

namespace Riafco.Service.Dataflex.Pro.Ressources.Response
{
    /// <summary>
    /// The AreaTranslation response class.
    /// </summary>
    public class AreaTranslationResponsePivot
    {
        /// <summary>
        /// Gets or Sets The AreaTranslationPivotList.
        /// </summary>
        public List<AreaTranslationPivot> AreaTranslationPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The AreaTranslationPivot.
        /// </summary>
        public AreaTranslationPivot AreaTranslationPivot { get; set; }
    }
}