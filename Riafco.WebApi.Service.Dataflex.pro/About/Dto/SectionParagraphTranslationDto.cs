using System.ComponentModel.DataAnnotations;
using Riafco.WebApi.Service.Dataflex.pro.About.Ressource;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.About.Dto
{
    /// <summary>
    /// The SectionParagraphTraslation dto class.
    /// </summary>
    public class SectionParagraphTranslationDto
    {
        /// <summary>
        /// Gets or Sets The TranslationId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ParagraphMessageResource), ErrorMessageResourceName = "RequiredTranslationId")]
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The ParagraphTitle.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(ParagraphMessageResource), ErrorMessageResourceName = "RequiredParagraphTitle")]
        public string ParagraphTitle { get; set; }

        /// <summary>
        /// Gets or Sets The ParagraphDescription.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(ParagraphMessageResource), ErrorMessageResourceName = "RequiredParagraphDescription")]
        public string ParagraphDescription { get; set; }

        #region navigation propertises

        /// <summary>
        /// Gets or Sets The  LanguageId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ParagraphMessageResource), ErrorMessageResourceName = "RequiredLanguageId")]
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or Sets The  Language.
        /// </summary>
        public LanguageDto Language { get; set; }

        /// <summary>
        /// Gets or Sets The  ParagraphId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ParagraphMessageResource), ErrorMessageResourceName = "RequiredParagraphId")]
        public int? ParagraphId { get; set; }

        /// <summary>
        /// Gets or Sets The  SectionParagraph.
        /// </summary>
        public SectionParagraphDto SectionParagraph { get; set; }

        #endregion
    }
}