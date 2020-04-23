using System.ComponentModel.DataAnnotations;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Occurrences.Ressource;

namespace Riafco.WebApi.Service.Dataflex.pro.Occurrences.Dto
{
    /// <summary>
    /// The OccurrenceTranslation dto class.
    /// </summary>
    public class OccurrenceTranslationDto
    {
        /// <summary>
        /// Gets or Sets The  TranslationId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(OccurrenceMessageResource), ErrorMessageResourceName = "RequiredTranslateId")]
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The  OccurrenceTitle.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(OccurrenceMessageResource), ErrorMessageResourceName = "RequiredTitle")]
        public string OccurrenceTitle { get; set; }

        /// <summary>
        /// Gets or Sets The  OccurrenceDescription.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(OccurrenceMessageResource), ErrorMessageResourceName = "RequiredDescription")]
        public string OccurrenceDescription { get; set; }
        #region navigation properties
        /// <summary>
        /// Gets or Sets The  OccurrenceId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(OccurrenceMessageResource), ErrorMessageResourceName = "RequiredOccurrenceId")]
        public int? OccurrenceId { get; set; }

        /// <summary>
        /// Gets or Sets The  Occurrence.
        /// </summary>
        public OccurrenceDto Occurrence { get; set; }
        /// <summary>
        /// Gets or Sets The  LanguageId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(OccurrenceMessageResource), ErrorMessageResourceName = "RequiredLanguageId")]
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or Sets The  Language.
        /// </summary>
        public LanguageDto Language { get; set; }
        #endregion
    }
}