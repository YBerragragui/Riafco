using System.Collections.Generic;
using Riafco.Service.Dataflex.Pro.News.Data;

namespace Riafco.Service.Dataflex.Pro.News.Response
{
    /// <summary>
    /// The News response class.
    /// </summary>
    public class NewsResponsePivot
    {
        /// <summary>
        /// Gets or Sets The  NewsPivotList.
        /// </summary>
        public List<NewsPivot> NewsPivotList { get; set; }

        /// <summary>
        /// Gets or Sets The  NewsPivot.
        /// </summary>
        public NewsPivot NewsPivot { get; set; }

    }
}