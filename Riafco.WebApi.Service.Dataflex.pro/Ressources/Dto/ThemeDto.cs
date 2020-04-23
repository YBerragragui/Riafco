using System.ComponentModel.DataAnnotations;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Ressource;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto
{
    /// <summary>
    /// The Theme dto class.
    /// </summary>
    public class ThemeDto
    {
        /// <summary>
        /// Gets or Sets The  ThemeId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ThemeMessageResource), ErrorMessageResourceName = "RequiredId")]
        public int ThemeId { get; set; }
    }
}