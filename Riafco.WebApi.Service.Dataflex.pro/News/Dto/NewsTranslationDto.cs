using System.ComponentModel.DataAnnotations;
using Riafco.WebApi.Service.Dataflex.pro.News.Ressource;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Dto;

namespace Riafco.WebApi.Service.Dataflex.pro.News.Dto
{
    /// <summary>
    /// The NewsTranslation dto class.
    /// </summary>
    public class NewsTranslationDto
    {
        /// <summary>
        /// Gets or Sets The  TranslationId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(NewsMessageResource), ErrorMessageResourceName = "RequiredTranslateId")]
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The  NewsTitle.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(NewsMessageResource), ErrorMessageResourceName = "RequiredTitle")]
        public string NewsTitle { get; set; }

        /// <summary>
        /// Gets or Sets The  NewsSummary.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(NewsMessageResource), ErrorMessageResourceName = "RequiredSummary")]
        public string NewsSummary { get; set; }

        /// <summary>
        /// Gets or Sets The  NewsDescription.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(NewsMessageResource), ErrorMessageResourceName = "RequiredDescription")]
        public string NewsDescription { get; set; }

        #region navigation attributes

        /// <summary>
        /// Gets or Sets The  LanguageId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(NewsMessageResource), ErrorMessageResourceName = "RequiredLanguageId")]
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or Sets The  Language.
        /// </summary>
        public LanguageDto Language { get; set; }

        /// <summary>
        /// Gets or Sets The  NewsId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(NewsMessageResource), ErrorMessageResourceName = "RequiredNewsId")]
        public int? NewsId { get; set; }

        /// <summary>
        /// Gets or Sets The  News.
        /// </summary>
        public NewsDto News { get; set; }

        #endregion
    }
}