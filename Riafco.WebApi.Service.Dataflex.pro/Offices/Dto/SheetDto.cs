using System.ComponentModel.DataAnnotations;
using Riafco.WebApi.Service.Dataflex.pro.Offices.Ressource;

namespace Riafco.WebApi.Service.Dataflex.pro.Offices.Dto
{
    /// <summary>
    /// The Sheet dto class.
    /// </summary>
    public class SheetDto
    {
        /// <summary>
        /// Gets or Sets The  SheetId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(CountryMessageResource), ErrorMessageResourceName = "RequiredId")]
        public int SheetId { get; set; }

        #region navigation properties
        /// <summary>
        /// Gets or Sets The  CountryId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(CountryMessageResource), ErrorMessageResourceName = "RequiredCountryId")]
        public int? CountryId { get; set; }

        /// <summary>
        /// Gets or Sets The  Country.
        /// </summary>
        public CountryDto Country { get; set; }
        #endregion
    }
}