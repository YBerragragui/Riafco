using Riafco.Entity.Dataflex.Pro.Languages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Riafco.Entity.Dataflex.Pro.Ressources
{
    /// <summary>
    /// The AreaTranslation class.
    /// </summary>
    [Table("Ressource_AreaTranslations")]
    public class AreaTranslation
    {
        /// <summary>
        /// Gets or sets TranslationId.
        /// </summary>
        [Key]
        public int TranslationId { get; set; }

        /// <summary>
        /// Gets or sets AreaName.
        /// </summary>
        public string AreaName { get; set; }

        #region navigation properties
        /// <summary>
        /// Gets or sets Area.
        /// </summary>
        [ForeignKey("Area")]
        public int? AreaId { get; set; }

        /// <summary>
        /// Gets or sets Area
        /// </summary>
        public virtual Area Area { get; set; }

        /// <summary>
        /// Gets or sets LanguageId.
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
