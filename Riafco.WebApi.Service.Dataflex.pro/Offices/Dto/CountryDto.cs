using System.ComponentModel.DataAnnotations;
using Riafco.WebApi.Service.Dataflex.pro.Offices.Ressource;

namespace Riafco.WebApi.Service.Dataflex.pro.Offices.Dto
{
    /// <summary>
    /// The Country dto class.
    /// </summary>
    public class CountryDto
    {
        /// <summary>
        /// Gets or Sets The  CountryId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(CountryMessageResource), ErrorMessageResourceName = "RequiredId")]
        public int CountryId { get; set; }

        /// <summary>
        /// Gets or Sets The  CountryImage.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(CountryMessageResource), ErrorMessageResourceName = "RequiredImage")]
        public string CountryImage { get; set; }

        /// <summary>
        /// Gots or sets CountryCode.
        /// </summary>
        public int CountryCode { get; set; }

        /// <summary>
        /// Gets or sets CountryShortName.
        /// </summary>
        public string CountryShortName { get; set; }
    }
}