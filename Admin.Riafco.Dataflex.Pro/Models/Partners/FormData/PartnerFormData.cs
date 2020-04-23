using Admin.Riafco.Dataflex.Pro.GlobalResources;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Admin.Riafco.Dataflex.Pro.Models.Partners.FormData
{
    /// <summary>
    /// The PartnerFormData class
    /// </summary>
    public class PartnerFormData
    {
        /// <summary>
        /// Get or sets PartnerId.
        /// </summary>
        public int PartnerId { get; set; }

        /// <summary>
        /// Gets or sets PartnerImage.
        /// </summary>
        [Display(ResourceType = typeof(PartnerResources), Name = nameof(PartnerResources.DisplayPartnerImage))]
        public HttpPostedFileBase PartnerImage { get; set; }

        /// <summary>
        /// Gets or sets PartnerName.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(PartnerResources), ErrorMessageResourceName = nameof(PartnerResources.RequiredPartnerName))]
        [Display(ResourceType = typeof(PartnerResources), Name = nameof(PartnerResources.DisplayPartnerName))]
        public string PartnerName { get; set; }

        /// <summary>
        /// Gets or sets PartnerLink.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(PartnerResources), ErrorMessageResourceName = nameof(PartnerResources.RequiredPartnerLink))]
        [Display(ResourceType = typeof(PartnerResources), Name = nameof(PartnerResources.DisplayPartnerLink))]
        public string PartnerLink { get; set; }

        /// <summary>
        /// Gets or sets PartnerLink.
        /// </summary>
        [Display(ResourceType = typeof(PartnerResources), Name = nameof(PartnerResources.DisplayPartnerPosition))]
        public int PartnerPosition { get; set; }
    }
}
