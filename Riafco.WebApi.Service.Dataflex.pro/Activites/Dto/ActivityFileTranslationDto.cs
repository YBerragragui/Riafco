using System.ComponentModel.DataAnnotations;
using Riafco.WebApi.Service.Dataflex.pro.Activites.Ressource;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.Activites.Dto
{
    /// <summary>
    /// The ActivityFileTranslation dto class.
    /// </summary>
    public class ActivityFileTranslationDto
    {
        /// <summary>
        /// Gets or Sets The TranslationId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(FileMessageResource), ErrorMessageResourceName = "RequiredTranslationId")]
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The  ActivityFileSource.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(FileMessageResource), ErrorMessageResourceName = "RequiredActivityFileSource")]
        public string ActivityFileSource { get; set; }

        /// <summary>
        /// Gets or Sets The  ActivityFileText.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(FileMessageResource), ErrorMessageResourceName = "RequiredActivityFileText")]
        public string ActivityFileText { get; set; }

        #region navigation attributes

        /// <summary>
        /// Gets or Sets The  ActivityFileId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(FileMessageResource), ErrorMessageResourceName = "RequiredFileActivityId")]
        public int? ActivityFileId { get; set; }

        /// <summary>
        /// Gets or Sets The  ActivityFile.
        /// </summary>
        public ActivityFileDto ActivityFile { get; set; }

        /// <summary>
        /// Gets or Sets The  LanguageId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(FileMessageResource), ErrorMessageResourceName = "RequiredLanguageId")]
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or Sets The  Language.
        /// </summary>
        public LanguageDto Language { get; set; }
        #endregion
    }
}