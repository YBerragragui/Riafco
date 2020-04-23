using System;

namespace Riafco.Service.Dataflex.Pro.News.Data
{
    /// <summary>
    /// The News pivot class.
    /// </summary>
    public class NewsPivot
    {
        /// <summary>
        /// Gets or Sets The  NewsId.
        /// </summary>
        public int NewsId { get; set; }

        /// <summary>
        /// Gets or Sets The  NewsImage.
        /// </summary>
        public string NewsImage { get; set; }

        /// <summary>
        /// Gets or Sets The  NewsDate.
        /// </summary>
        public DateTime NewsDate { get; set; }
    }
}