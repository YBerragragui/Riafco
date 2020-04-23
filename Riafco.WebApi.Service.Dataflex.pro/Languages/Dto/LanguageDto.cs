using Riafco.WebApi.Service.Dataflex.pro.Languages.Ressource;
using System.ComponentModel.DataAnnotations;

namespace Riafco.WebApi.Service.Dataflex.pro.Languages.Dto
{
    /// <summary>
    /// The Language dto class.
    /// </summary>
    public class LanguageDto
    {
        /// <summary>
        /// Gets or Sets The  LanguageId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(LanguageMessageResource), ErrorMessageResourceName = "RequiredId")]
        public int LanguageId { get; set; }

        /// <summary>
        /// Gets or Sets The  LanguePrefix.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(LanguageMessageResource), ErrorMessageResourceName = "RequiredPrefix")]
        public string LanguagePrefix { get; set; }

        /// <summary>
        /// Gets or Sets The  LanguePicture.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(LanguageMessageResource), ErrorMessageResourceName = "RequiredPicture")]
        public string LanguagePicture { get; set; }
    }
}