using Riafco.Service.Dataflex.Pro.News.Data;
using Riafco.Service.Dataflex.Pro.News.Data.Enum;

namespace Riafco.Service.Dataflex.Pro.News.Request
{
    /// <summary>
    /// Gets or Sets The  News request class.
    /// </summary>
    public class NewsRequestPivot
    {
        /// <summary>
        /// Gets or Sets The  NewsPivot requested.
        /// </summary>
        public NewsPivot NewsPivot { get; set; }

        /// <summary>
        /// Gets or Sets The  Find NewsEnum.
        /// </summary>
        public FindNewsPivot FindNewsPivot { get; set; }
    }
}