
using System.Collections.Generic;

namespace Admin.Riafco.Dataflex.Pro.Models.Offices.ViewData
{
    /// <summary>
    /// The SheetsViewData class.
    /// </summary>
    public class SheetsViewData
    {
        /// <summary>
        /// Gets or sets Sheets
        /// </summary>
        public List<SheetViewData> Sheets { get; set; }

        /// <summary>
        /// Gets or sets CountryId.
        /// </summary>
        public int CountryId { get; set; }
    }
}