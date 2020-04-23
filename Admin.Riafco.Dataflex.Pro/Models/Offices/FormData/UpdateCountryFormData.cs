using Admin.Riafco.Dataflex.Pro.GlobalResources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Admin.Riafco.Dataflex.Pro.Models.Offices.FormData
{
    /// <summary>
    /// The CountryFormData class
    /// </summary>
    public class UpdateCountryFormData
    {
        /// <summary>
        /// Get or sets CountryId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(CountryResources), ErrorMessageResourceName = "RequiredCountryId")]
        public int CountryId { get; set; }

        /// <summary>
        /// Gets or sets CountryCode.
        /// </summary>
        [Display(ResourceType = typeof(CountryResources), Name = nameof(CountryResources.DisplayCountryCode))]
        [Required(ErrorMessageResourceType = typeof(CountryResources), ErrorMessageResourceName = nameof(CountryResources.RequiredCountryCode))]
        public int CountryCode { get; set; }

        /// <summary>
        /// Gets or sets CountryShortName.
        /// </summary>
        [MaxLength(2)]
        [Required(ErrorMessageResourceType = typeof(CountryResources), ErrorMessageResourceName = nameof(CountryResources.RequiredShortName))]
        public string CountryShortName { get; set; }

        /// <summary>
        /// Gets or sets CountryImage.
        /// </summary>
        [Display(ResourceType = typeof(CountryResources), Name = nameof(CountryResources.DisplayCountryImage))]
        public HttpPostedFileBase CountryImage { get; set; }

        /// <summary>
        /// Gets or sets TranslationsList.
        /// </summary>
        public List<CountryTranslationFormData> TranslationsList { get; set; }
    }
}
