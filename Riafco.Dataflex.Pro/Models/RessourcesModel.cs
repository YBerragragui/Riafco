using Riafco.Dataflex.Pro.Models.News.ViewData;
using Riafco.Dataflex.Pro.Models.Occurrences.ViewData;
using Riafco.Dataflex.Pro.Models.Partners.ViewData;
using Riafco.Dataflex.Pro.Models.Ressources.FormData;
using Riafco.Dataflex.Pro.Models.Ressources.ViewData;

namespace Riafco.Dataflex.Pro.Models
{
    /// <summary>
    /// The RessourcesModel class.
    /// </summary>
    public class RessourcesModel
    {
        /// <summary>
        /// Gets or sets FilterFormData.
        /// </summary>
        public FilterFormData FilterFormData { get; set; }

        /// <summary>
        /// Gets or sets PublicationsViewData.
        /// </summary>
        public PublicationsViewData PublicationsViewData { get; set; }

        #region SHARED VEIW DATA

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

        #endregion
    }
}