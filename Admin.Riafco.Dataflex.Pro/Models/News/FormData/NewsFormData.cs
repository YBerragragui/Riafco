using System;
using Admin.Riafco.Dataflex.Pro.GlobalResources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Admin.Riafco.Dataflex.Pro.Models.News.FormData
{
    /// <summary>
    /// The NewsFormData class
    /// </summary>
    public class NewsFormData
    {

        /// <summary>
        /// Gets or Sets The  NewsId.
        /// </summary>
        public int NewsId { get; set; }

        /// <summary>
        /// Gets or Sets The  NewsImage.
        /// </summary>
        [DataType(DataType.Upload)]
        [Display(ResourceType = typeof(NewsResources), Name = nameof(NewsResources.DisplayNewsImage))]
        public HttpPostedFileBase NewsImage { get; set; }

        /// <summary>
        /// Gets or Sets The  NewsDate.
        /// </summary>
        /// [DisplayName("Date : ")]
        [Display(ResourceType = typeof(NewsResources), Name = nameof(NewsResources.DisplayNewsDate))]
        [Required(ErrorMessageResourceType = typeof(NewsResources), ErrorMessageResourceName = nameof(NewsResources.RequiredField))]
        [RegularExpression(@"((0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/([0-9])*)", ErrorMessageResourceType = typeof(NewsResources), ErrorMessageResourceName = nameof(NewsResources.InvalideDate))]
        public string NewsDate { get; set; }

        /// <summary>
        /// Gets or sets TranslationsList.
        /// </summary>
        public List<NewsTranslationFormData> TranslationsList { get; set; }

    }
}
