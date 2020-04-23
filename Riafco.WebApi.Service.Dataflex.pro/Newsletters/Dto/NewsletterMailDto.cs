using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Ressource;

namespace Riafco.WebApi.Service.Dataflex.pro.Newsletters.Dto
{
    /// <summary>
    /// The NewsletterMail dto class.
    /// </summary>
    public class NewsletterMailDto
    {
        /// <summary>
        /// Gets or Sets The  NewsletterMailId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(NewsletterMailMessageResource), ErrorMessageResourceName = "RequiredNewsletterMailId")]
        public int NewsletterMailId { get; set; }
    }
}