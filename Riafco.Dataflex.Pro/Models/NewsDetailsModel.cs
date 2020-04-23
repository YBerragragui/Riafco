using Riafco.Dataflex.Pro.Models.News.ViewData;
using Riafco.Dataflex.Pro.Models.Newsletters.FormData;
using Riafco.Dataflex.Pro.Models.Occurrences.ViewData;
using Riafco.Dataflex.Pro.Models.Partners.ViewData;

namespace Riafco.Dataflex.Pro.Models
{
    /// <summary>
    /// The NewsDetailsModel class.
    /// </summary>
    public class NewsDetailsModel
    {
        /// <summary>
        /// Gets or sets NewsViewData
        /// </summary>
        public NewsViewData NewsViewData { get; set; }

        /// <summary>
        /// Get or  sets NewsViewDatas 
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
        /// Gets or sets SubscriberFormData.
        /// </summary>
        public SubscriberFormData SubscriberFormData { get; set; }
    }
}