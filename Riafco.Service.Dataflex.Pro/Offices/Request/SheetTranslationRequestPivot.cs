using Riafco.Service.Dataflex.Pro.Offices.Data;
using Riafco.Service.Dataflex.Pro.Offices.Data.Enum;
using System.Collections.Generic;

namespace Riafco.Service.Dataflex.Pro.Offices.Request
{
    /// <summary>
    /// Gets or Sets The  SheetTranslation request class.
    /// </summary>
    public class SheetTranslationRequestPivot
    {
        /// <summary>
        /// Gets or Sets The  SheetTranslationPivot requested.
        /// </summary>
        public SheetTranslationPivot SheetTranslationPivot { get; set; }

        /// <summary>
        /// Gets or Sets The  SheetTranslationPivot requested.
        /// </summary>
        public List<SheetTranslationPivot> SheetTranslationPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  Find SheetTranslationEnum.
        /// </summary>
        public FindSheetTranslationPivot FindSheetTranslationPivot { get; set; }
    }
}