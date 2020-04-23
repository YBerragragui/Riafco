using Riafco.Dataflex.Pro.Models.News.ItemData;
using Riafco.Dataflex.Pro.Models.News.ItemData.Enum;
using System.Runtime.Serialization;

namespace Riafco.Dataflex.Pro.Models.News.RequestData
{
    /// <summary>
    /// The News request class.
    /// </summary>
    [DataContract]
    public class NewsRequestData
    {
        /// <summary>
        /// Gets or Sets The NewsDto requested.
        /// </summary>
        [DataMember]
        public NewsItemData NewsDto { get; set; }

        /// <summary>
        /// Gets or sets The Find NewsDto.
        /// </summary>
        [DataMember]
        public FindNewsItemData FindNewsDto { get; set; }
    }
}