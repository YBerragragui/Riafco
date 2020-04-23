using Riafco.Dataflex.Pro.GlobalResources;
using System.ComponentModel.DataAnnotations;

namespace Riafco.Dataflex.Pro.Models.Ressources.FormData
{
    /// <summary>
    /// The AreaFormData class.
    /// </summary>
    public class AreaFormData
    {
        /// <summary>
        /// Gets or Sets The AreaId.
        /// </summary>
        [Display(ResourceType = typeof(AreaResources), Name = nameof(AreaResources.DisplayAreaName))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(AreaResources), ErrorMessageResourceName = "RequiredId")]
        public int AreaId { get; set; }
    }
}