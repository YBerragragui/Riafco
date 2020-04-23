using Riafco.Service.Dataflex.Pro.Ressources.Data;
using Riafco.Service.Dataflex.Pro.Ressources.Data.Enum;
using System.Collections.Generic;

namespace Riafco.Service.Dataflex.Pro.Ressources.Request
{
    /// <summary>
    /// Gets or Sets The  AreaTranslation request class.
    /// </summary>
    public class AreaTranslationRequestPivot
    {
        /// <summary>
        /// Gets or Sets The  AreaTranslationPivot requested.
        /// </summary>
        public AreaTranslationPivot AreaTranslationPivot { get; set; }

        /// <summary>
        /// Gets or Sets The  AreaTranslationPivot requested.
        /// </summary>
        public List<AreaTranslationPivot> AreaTranslationPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  Find AreaTranslationEnum.
        /// </summary>
        public FindAreaTranslationPivot FindAreaTranslationPivot { get; set; }
    }
}