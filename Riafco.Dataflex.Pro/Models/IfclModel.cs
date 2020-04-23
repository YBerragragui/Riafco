using Riafco.Dataflex.Pro.Models.News.ViewData;
using Riafco.Dataflex.Pro.Models.Occurrences.ViewData;
using Riafco.Dataflex.Pro.Models.Offices.ViewData;
using Riafco.Dataflex.Pro.Models.Partners.ViewData;

namespace Riafco.Dataflex.Pro.Models
{
    /// <summary>
    /// The IfclModel class.
    /// </summary>
    public class IfclModel
    {
        /// <summary>
        /// Gets or sets NewsViewDatas.
        /// </summary>
        public NewsViewDatas NewsViewDatas { get; set; }

        /// <summary>
        /// Gets or sets OccurrencesViewData.
        /// </summary>
        public OccurrencesViewData OccurrencesViewData { get; set; }

        /// <summary>
        /// Gets or sets PartnersViewData.
        /// </summary>
        public PartnersViewData PartnersViewData { get; set; }

        /// <summary>
        /// Gets or sets CountryViewData
        /// </summary>
        public CountryViewData CountryViewData { get; set; }

        /// <summary>
        /// Gets or sets SheetsViewData
        /// </summary>
        public SheetsViewData SheetsViewData { get; set; }
    }
}