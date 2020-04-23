using Riafco.WebApi.Service.Dataflex.pro.News.Ressource;
using System;
using System.ComponentModel.DataAnnotations;

namespace Riafco.WebApi.Service.Dataflex.pro.News.Dto
{
    /// <summary>
    /// The News dto class.
    /// </summary>
    public class NewsDto
    {
        /// <summary>
        /// Gets or Sets The  NewsId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(NewsMessageResource), ErrorMessageResourceName = "RequiredId")]
        public int NewsId { get; set; }

        /// <summary>
        /// Gets or Sets The  NewsImage.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(NewsMessageResource), ErrorMessageResourceName = "RequiredImage")]
        public string NewsImage { get; set; }

        /// <summary>
        /// Gets or Sets The  NewsDate.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(NewsMessageResource), ErrorMessageResourceName = "RequiredDate")]
        public DateTime NewsDate { get; set; }
    }
}