using Riafco.Dataflex.Pro.Models.News.ViewData;
using Riafco.Dataflex.Pro.Models.Newsletters.FormData;
using Riafco.Dataflex.Pro.Models.Occurrences.ViewData;
using Riafco.Dataflex.Pro.Models.Partners.ViewData;

namespace Riafco.Dataflex.Pro.Models
{
    /// <summary>
    /// The HomeModel class.
    /// </summary>
    public class HomeModel
    {
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
        /// gets or sets SubscriberFormData.
        /// </summary>
        public SubscriberFormData SubscriberFormData { get; set; }
    }
}