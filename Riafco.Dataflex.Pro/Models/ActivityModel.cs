using Riafco.Dataflex.Pro.Models.Activities.ViewData;
using Riafco.Dataflex.Pro.Models.News.ViewData;
using Riafco.Dataflex.Pro.Models.Newsletters.FormData;
using Riafco.Dataflex.Pro.Models.Occurrences.ViewData;
using Riafco.Dataflex.Pro.Models.Partners.ViewData;

namespace Riafco.Dataflex.Pro.Models
{
    /// <summary>
    /// The ActivityModel class.
    /// </summary>
    public class ActivityModel
    {
        /// <summary>
        /// Gets or sets ActivityViewData.
        /// </summary>
        public ActivityViewData ActivityViewData { get; set; }

        /// <summary>
        /// Gets or sets ParagraphsViewData.
        /// </summary>
        public ParagraphsViewData ParagraphsViewData { get; set; }

        /// <summary>
        /// Gets or sets FilesViewData.
        /// </summary>
        public FilesViewData FilesViewData { get; set; }

        #region SHARED OBJECTS

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

        #endregion
    }
}