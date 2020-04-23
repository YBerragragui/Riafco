using System.ComponentModel.DataAnnotations;
using Admin.Riafco.Dataflex.Pro.GlobalResources;

namespace Admin.Riafco.Dataflex.Pro.Models.Offices.FormData
{
    /// <summary>
    /// The SheetTranslationFormData class.
    /// </summary>
    public class SheetTranslationFormData
    {
        /// <summary>
        /// Gets or Sets The TraslationId.
        /// </summary>
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The  SheetTitle.
        /// </summary>
        [Display(ResourceType = typeof(CountryResources), Name = nameof(CountryResources.DisplaySheetTitle))]
        [Required(ErrorMessageResourceType = typeof(CountryResources), ErrorMessageResourceName = "RequiredSheetTitle")]
        public string SheetTitle { get; set; }

        /// <summary>
        /// Gets or Sets The SheetDescription.
        /// </summary>
        [Display(ResourceType = typeof(CountryResources), Name = nameof(CountryResources.DisplaySheetValue))]
        [Required(ErrorMessageResourceType = typeof(CountryResources), ErrorMessageResourceName = "RequiredSheetValue")]
        public string SheetValue { get; set; }

        /// <summary>
        /// Gets or Sets The LanguageId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(CountryResources), ErrorMessageResourceName = "RequiredLanguageId")]
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or Sets The  SheetId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(CountryResources), ErrorMessageResourceName = "RequiredSheetId")]
        public int? SheetId { get; set; }

        /// <summary>
        /// Gets or sets LanguagePrefix.
        /// </summary>
        public string LanguagePrefix { get; set; }
    }
}