using Riafco.Service.Dataflex.Pro.Offices.Data;
using Riafco.Service.Dataflex.Pro.Offices.Data.Enum;

namespace Riafco.Service.Dataflex.Pro.Offices.Request
{
    /// <summary>
    /// Gets or Sets The  Sheet request class.
    /// </summary>
    public class SheetRequestPivot
    {
        /// <summary>
        /// Gets or Sets The  SheetPivot requested.
        /// </summary>
        public SheetPivot SheetPivot { get; set; }

        /// <summary>
        /// Gets or Sets The  Find SheetEnum.
        /// </summary>
        public FindSheetPivot FindSheetPivot { get; set; }
    }
}