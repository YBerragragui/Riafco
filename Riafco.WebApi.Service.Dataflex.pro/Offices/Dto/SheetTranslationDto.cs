using System.ComponentModel.DataAnnotations;
using Riafco.WebApi.Service.Dataflex.pro.Offices.Ressource;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.Offices.Dto
{
    /// <summary>
    /// The SheetTranslation dto class.
    /// </summary>
    public class SheetTranslationDto
    {
        /// <summary>
        /// Gets or Sets The  TranslationId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(CountryMessageResource), ErrorMessageResourceName = "RequiredTranslateId")]
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The  SheetTitle.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(CountryMessageResource), ErrorMessageResourceName = "RequiredTitle")]
        public string SheetTitle { get; set; }

        /// <summary>
        /// Gets or Sets The  SheetValue.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(CountryMessageResource), ErrorMessageResourceName = "RequiredValue")]
        public string SheetValue { get; set; }

        #region navigation properties
        /// <summary>
        /// Gets or Sets The  LanguageId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(CountryMessageResource), ErrorMessageResourceName = "RequiredLanguageId")]
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or Sets The  Language.
        /// </summary>
        public LanguageDto Language { get; set; }
        /// <summary>
        /// Gets or Sets The  SheetId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(CountryMessageResource), ErrorMessageResourceName = "RequiredSheetId")]
        public int? SheetId { get; set; }

        /// <summary>
        /// Gets or Sets The  Sheet.
        /// </summary>
        public SheetDto Sheet { get; set; }
        #endregion
    }
}