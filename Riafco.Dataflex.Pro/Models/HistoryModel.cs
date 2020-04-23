using Riafco.Dataflex.Pro.Models.About.ViewData;
using Riafco.Dataflex.Pro.Models.News.ViewData;
using Riafco.Dataflex.Pro.Models.Newsletters.FormData;
using Riafco.Dataflex.Pro.Models.Partners.ViewData;

namespace Riafco.Dataflex.Pro.Models
{
    /// <summary>
    /// The HistoryModel class.
    /// </summary>
    public class HistoryModel
    {
        /// <summary>
        /// Get or sets NewsViewDatas. 
        /// </summary>
        public NewsViewDatas NewsViewDatas { get; set; }

        /// <summary>
        /// Gets or sets PartnersViewData.
        /// </summary>
        public PartnersViewData PartnersViewData { get; set; }

        /// <summary>
        /// gets or sets SubscriberFormData.
        /// </summary>
        public SubscriberFormData SubscriberFormData { get; set; }

        /// <summary>
        /// Gets or sets StepsViewData.
        /// </summary>
        public StepsViewData StepsViewData { get; set; }
    }
}