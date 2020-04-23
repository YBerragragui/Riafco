using System.ComponentModel.DataAnnotations;
using System.Web;
using Admin.Riafco.Dataflex.Pro.GlobalResources;

namespace Admin.Riafco.Dataflex.Pro.Models.Newsletters.FormData
{
    /// <summary>
    /// The NewsletterMailTranslationFormData class.
    /// </summary>
    public class NewsletterMailTranslationFormData
    {
        /// <summary>
        /// Gets or Sets The TranslationId.
        /// </summary>
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or Sets The  NewsletterMailSource.
        /// </summary>
        [Display(ResourceType = typeof(NewsletterMailResources), Name = nameof(NewsletterMailResources.DisplayNewsletterMailSource))]
        public HttpPostedFileBase NewsletterMailSource { get; set; }
        public string NewsletterMailSourceName { get; set; }


        /// <summary>
        /// Gets or Sets The  NewsletterMailSubject.
        /// </summary>
        [Display(ResourceType = typeof(NewsletterMailResources), Name = nameof(NewsletterMailResources.DisplayNewsletterMailSubject))]
        [Required(ErrorMessageResourceType = typeof(NewsletterMailResources), ErrorMessageResourceName = nameof(NewsletterMailResources.RequiredNewsletterMailSubject))]
        public string NewsletterMailSubject { get; set; }

        #region navigation attributes

        /// <summary>
        /// Gets or Sets The NewsletterMailId.
        /// </summary>
        public int? NewsletterMailId { get; set; }

        /// <summary>
        /// Gets or Sets The LanguageId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(NewsletterMailResources), ErrorMessageResourceName = "RequiredLanguageId")]
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or sets LanguagePrefix.
        /// </summary>
        public string LanguagePrefix { get; set; }

        #endregion
    }
}