using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Ressource;

namespace Riafco.WebApi.Service.Dataflex.pro.Newsletters.Dto
{
    /// <summary>
    /// The NewsletterMailTranslation dto class.
    /// </summary>
    public class NewsletterMailTranslationDto
    {
        /// <summary>
        /// Gets or Sets The  TranslationId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(NewsletterMailMessageResource), ErrorMessageResourceName = "RequiredTranslationId")]
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The  NewsletterMailSource.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(NewsletterMailMessageResource), ErrorMessageResourceName = "RequiredNewsletterMailSource")]
        public string NewsletterMailSource { get; set; }

        /// <summary>
        /// Gets or Sets The  NewsletterMailSubject.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(NewsletterMailMessageResource), ErrorMessageResourceName = "RequiredNewsletterMailSubject")]
        public string NewsletterMailSubject { get; set; }

        #region navigation properties
        /// <summary>
        /// Gets or Sets The  NewsletterMailId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(NewsletterMailMessageResource), ErrorMessageResourceName = "RequiredNewsletterMailId")]
        public int? NewsletterMailId { get; set; }

        /// <summary>
        /// Gets or Sets The  NewsletterMail.
        /// </summary>
        public NewsletterMailDto NewsletterMail { get; set; }
        /// <summary>
        /// Gets or Sets The  LanguageId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(NewsletterMailMessageResource), ErrorMessageResourceName = "RequiredLanguageId")]
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or Sets The  Language.
        /// </summary>
        public LanguageDto Language { get; set; }
        #endregion
    }
}