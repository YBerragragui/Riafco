using Riafco.WebApi.Service.Dataflex.pro.Languages.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Ressource;
using System.ComponentModel.DataAnnotations;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto
{
    /// <summary>
    /// The PublicationTranslation dto class.
    /// </summary>
    public class PublicationTranslationDto
    {
        /// <summary>
        /// Gets or Sets The  PublicationTranslationId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(PublicationMessageResource), ErrorMessageResourceName = "RequiredTranslationId")]
        public int PublicationTranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The PublicationTitle.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(PublicationMessageResource), ErrorMessageResourceName = "RequiredPublicationTitle")]
        public string PublicationTitle { get; set; }

        /// <summary>
        /// Gets or Sets The PublicationSummary.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(PublicationMessageResource), ErrorMessageResourceName = "RequiredPublicationSummary")]
        public string PublicationSummary { get; set; }

        /// <summary>
        /// Gets or sets PublicationFile.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(PublicationMessageResource), ErrorMessageResourceName = "RequiredPublicationFile")]
        public string PublicationFile { get; set; }

        #region PRIVATE ATTRIBUTES

        /// <summary>
        /// Gets or Sets The  LanguageId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(PublicationMessageResource), ErrorMessageResourceName = "RequiredLanguageId")]
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or Sets The  Language.
        /// </summary>
        public LanguageDto Language { get; set; }

        /// <summary>
        /// Gets or Sets The  PublicationId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(PublicationMessageResource), ErrorMessageResourceName = "RequiredPublicationId")]
        public int? PublicationId { get; set; }

        /// <summary>
        /// Gets or Sets The  Publication.
        /// </summary>
        public PublicationDto Publication { get; set; }

        #endregion
    }
}