using System.ComponentModel.DataAnnotations;
using Riafco.WebApi.Service.Dataflex.pro.Offices.Ressource;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.Offices.Dto
{
    /// <summary>
    /// The CountryTranslation dto class.
    /// </summary>
    public class CountryTranslationDto
    {
        /// <summary>
        /// Gets or Sets The  TranslationId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(CountryMessageResource), ErrorMessageResourceName = "RequiredTranslateId")]
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The  CountryName.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(CountryMessageResource), ErrorMessageResourceName = "RequiredName")]
        public string CountryName { get; set; }

        /// <summary>
        /// Gets or Sets The  CountryTitle.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(CountryMessageResource), ErrorMessageResourceName = "RequiredTitle")]
        public string CountryTitle { get; set; }

        /// <summary>
        /// Gets or Sets The  CountryDescription.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(CountryMessageResource), ErrorMessageResourceName = "RequiredDescription")]
        public string CountryDescription { get; set; }

        /// <summary>
        /// Gets or Sets The  CountrySummary.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(CountryMessageResource), ErrorMessageResourceName = "RequiredSummary")]
        public string CountrySummary { get; set; }

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
        /// <summary>
        /// Gets or Sets The  LanguageId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(CountryMessageResource), ErrorMessageResourceName = "RequiredLanguageId")]
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or Sets The  Language.
        /// </summary>
        public LanguageDto Language { get; set; }
        #endregion
    }
}