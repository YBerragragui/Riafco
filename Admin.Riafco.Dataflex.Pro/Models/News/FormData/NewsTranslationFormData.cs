using Admin.Riafco.Dataflex.Pro.GlobalResources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Admin.Riafco.Dataflex.Pro.Models.News.FormData
{
    public class NewsTranslationFormData
    {
        /// <summary>
        /// Gets or sets TranslationId.
        /// </summary>
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or sets NewsId.
        /// </summary>
        public int NewsId { get; set; }

        /// <summary>
        /// Gets or sets LanguageId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(NewsResources), ErrorMessageResourceName = nameof(NewsResources.RequiredField))]
        public int LanguageId { get; set; }

        /// <summary>
        /// Gets or sets NewsTitle.
        /// </summary>
        [Display(ResourceType = typeof(NewsResources), Name = nameof(NewsResources.DisplayNewsTitle))]
        [Required(ErrorMessageResourceType = typeof(NewsResources), ErrorMessageResourceName = nameof(NewsResources.RequiredField))]
        public string NewsTitle { get; set; }

        /// <summary>
        /// Gets or sets NewsSummary.
        /// </summary>
        [Display(ResourceType = typeof(NewsResources), Name = nameof(NewsResources.DisplayNewsSummary))]
        [Required(ErrorMessageResourceType = typeof(NewsResources), ErrorMessageResourceName = nameof(NewsResources.RequiredField))]
        public string NewsSummary { get; set; }

        /// <summary>
        /// Gets or sets NewsDescription.
        /// </summary>
        [Display(ResourceType = typeof(NewsResources), Name = nameof(NewsResources.DisplayNewsDescription))]
        [Required(ErrorMessageResourceType = typeof(NewsResources), ErrorMessageResourceName = nameof(NewsResources.RequiredField))]
        public string NewsDescription { get; set; }

        /// <summary>
        /// Gets or sets LanguagePrefix.
        /// </summary>
        public string LanguagePrefix { get; set; }
    }
}