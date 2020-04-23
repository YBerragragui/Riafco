using System.ComponentModel.DataAnnotations;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Ressource;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto
{
    /// <summary>
    /// The Area dto class.
    /// </summary>
    public class AreaDto
    {
        /// <summary>
        /// Gets or Sets The  AreaId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(AreaMessageResource), ErrorMessageResourceName = "RequiredId")]
        public int AreaId { get; set; }
    }
}