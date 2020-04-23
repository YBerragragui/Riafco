using System.ComponentModel.DataAnnotations;
using Riafco.WebApi.Service.Dataflex.pro.About.Ressource;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Dto
{
    /// <summary>
    /// The SectionFileTranslation dto class.
    /// </summary>
    public class SectionFileTranslationDto
    {
        /// <summary>
        /// Gets or Sets The TranslationId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(FileMessageResource), ErrorMessageResourceName = "RequiredTranslationId")]
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The  SectionFileSource.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(FileMessageResource), ErrorMessageResourceName = "RequiredSectionFileSource")]
        public string SectionFileSource { get; set; }

        /// <summary>
        /// Gets or Sets The  SectionFileText.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(FileMessageResource), ErrorMessageResourceName = "RequiredSectionFileText")]
        public string SectionFileText { get; set; }

        #region navigation attributes

        /// <summary>
        /// Gets or Sets The  SectionFileId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(FileMessageResource), ErrorMessageResourceName = "RequiredFileSectionId")]
        public int? SectionFileId { get; set; }

        /// <summary>
        /// Gets or Sets The  SectionFile.
        /// </summary>
        public SectionFileDto SectionFile { get; set; }

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