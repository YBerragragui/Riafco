using Riafco.Entity.Dataflex.Pro.Languages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Riafco.Entity.Dataflex.Pro.Offices
{
    /// <summary>
    /// The CountryTraduction class
    /// </summary>
    [Table("office_CountryTranslations")]
    public class CountryTranslation
    {
        /// <summary>
        /// Gets or sets TraductionId
        /// </summary>
        [Key]
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or sets CountryName
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        /// Gets or sets CountryTitle
        /// </summary>
        public string CountryTitle { get; set; }

        /// <summary>
        /// Gets or sets CountryDescription
        /// </summary>
        public string CountryDescription { get; set; }

        /// <summary>
        /// Gets or sets CountrySummary
        /// </summary>
        public string CountrySummary { get; set; }

        #region navigation properties
        /// <summary>
        /// Gets or sets CountryId
        /// </summary>
        [ForeignKey("Country")]
        public int? CountryId { get; set; }

        /// <summary>
        /// Gets or sets Evenet
        /// </summary>
        public virtual Country Country { get; set; }

        /// <summary>
        /// Gets or sets LangueId
        /// </summary>
        [ForeignKey("Language")]
        public int? LanguageId { get; set; }

        /// <summary>
        /// Gets or sets Language
        /// </summary>
        public virtual Language Language { get; set; }
        #endregion
    }
}
