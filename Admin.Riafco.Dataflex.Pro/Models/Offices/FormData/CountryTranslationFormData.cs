using Admin.Riafco.Dataflex.Pro.GlobalResources;
using System.ComponentModel.DataAnnotations;

namespace Admin.Riafco.Dataflex.Pro.Models.Offices.FormData
{
    /// <summary>
    /// The CountryTranslationFormData class.
    /// </summary>
    public class CountryTranslationFormData
    {
        /// <summary>
        /// Gets or sets TranslationId.
        /// </summary>
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or sets CountryId.
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// Gets or sets LanguageId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(CountryResources), ErrorMessageResourceName = nameof(CountryResources.RequiredField))]
        public int LanguageId { get; set; }

        /// <summary>
        /// Gets or sets CountryTitle.
        /// </summary>
        [Display(ResourceType = typeof(CountryResources), Name = nameof(CountryResources.DisplayCountryName))]
        [Required(ErrorMessageResourceType = typeof(CountryResources), ErrorMessageResourceName = nameof(CountryResources.RequiredCountryName))]
        public string CountryName { get; set; }

        /// <summary>
        /// Gets or sets CountryTitle.
        /// </summary>
        [Display(ResourceType = typeof(CountryResources), Name = nameof(CountryResources.DisplayCountryTitle))]
        [Required(ErrorMessageResourceType = typeof(CountryResources), ErrorMessageResourceName = nameof(CountryResources.RequiredCountryTitle))]
        public string CountryTitle { get; set; }

        /// <summary>
        /// Gets or sets CountryIntroduction.
        /// </summary>
        [Display(ResourceType = typeof(CountryResources), Name = nameof(CountryResources.DisplayCountrySummary))]
        [Required(ErrorMessageResourceType = typeof(CountryResources), ErrorMessageResourceName = nameof(CountryResources.RequiredCountrySummary))]
        public string CountrySummary { get; set; }

        /// <summary>
        /// Gets or sets CountryDescription.
        /// </summary>
        [Display(ResourceType = typeof(CountryResources), Name = nameof(CountryResources.DisplayCountryDescription))]
        [Required(ErrorMessageResourceType = typeof(CountryResources), ErrorMessageResourceName = nameof(CountryResources.RequiredCountryDescription))]
        public string CountryDescription { get; set; }

        /// <summary>
        /// Gets or sets LanguagePrefix.
        /// </summary>
        public string LanguagePrefix { get; set; }
    }
}
