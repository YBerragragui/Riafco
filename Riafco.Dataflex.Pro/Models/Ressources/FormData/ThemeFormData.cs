using Riafco.Dataflex.Pro.GlobalResources;
using System.ComponentModel.DataAnnotations;

namespace Riafco.Dataflex.Pro.Models.Ressources.FormData
{
    /// <summary>
    /// The ThemeFormData class.
    /// </summary>
    public class ThemeFormData
    {
        /// <summary>
        /// Gets or Sets The ThemeId.
        /// </summary>
        [Display(ResourceType = typeof(ThemeResources), Name = nameof(ThemeResources.DisplayThemeName))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ThemeResources), ErrorMessageResourceName = "RequiredId")]
        public int ThemeId { get; set; }
    }
}