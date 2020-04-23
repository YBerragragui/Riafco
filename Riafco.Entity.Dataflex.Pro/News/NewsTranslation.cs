using Riafco.Entity.Dataflex.Pro.Languages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Riafco.Entity.Dataflex.Pro.News
{
    /// <summary>
    /// The TraductionNews class.
    /// </summary>
    [Table("news_NewsTranslations")]
    public class NewsTranslation
    {
        /// <summary>
        /// Gets or gets TraductionId.
        /// </summary>
        [Key]
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or sets NewsTitle.
        /// </summary>
        public string NewsTitle { get; set; }

        /// <summary>
        /// Gets or sets NewsSammury.
        /// </summary>
        public string NewsSummary { get; set; }

        /// <summary>
        /// Gets or sets NewsDescription.
        /// </summary>
        public string NewsDescription { get; set; }

        #region Navigation properties
        /// <summary>
        /// Gets sets LangueId.
        /// </summary>
        [ForeignKey("Language")]
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or sets Langue.
        /// </summary>
        public virtual Language Language { get; set; }

        /// <summary>
        /// Gets or sets NewsId.
        /// </summary>
        [ForeignKey("News")]
        public int? NewsId { get; set; }

        /// <summary>
        /// Gets sets or News.
        /// </summary>
        public virtual News News { get; set; }
        #endregion
    }
}
