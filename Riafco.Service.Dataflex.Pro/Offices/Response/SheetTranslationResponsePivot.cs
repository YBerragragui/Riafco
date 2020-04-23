using System;
using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.Offices.Data;

namespace Riafco.Service.Dataflex.Pro.Offices.Response
{
    /// <summary>
    /// The SheetTranslation response class.
    /// </summary>
    public class SheetTranslationResponsePivot
    {
        /// <summary>
        /// Gets or Sets The  SheetTranslationPivotList.
        /// </summary>
        public List<SheetTranslationPivot> SheetTranslationPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  SheetTranslationPivot.
        /// </summary>
        public SheetTranslationPivot SheetTranslationPivot { get; set; }

    }
}