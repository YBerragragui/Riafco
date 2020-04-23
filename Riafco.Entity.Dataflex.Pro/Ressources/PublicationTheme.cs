using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Riafco.Entity.Dataflex.Pro.Ressources
{
    /// <summary>
    /// The PublicationTheme class.
    /// </summary>
    [Table("Ressource_PublicationThemes")]
    public class PublicationTheme
    {
        /// <summary>
        /// Gets or sets PublicationThemId.
        /// </summary>
        [Key]
        public int PublicationThemeId { get; set; }

        #region navigation attributes

        /// <summary>
        /// Gets or sets ThemeId.
        /// </summary>
        [ForeignKey("Theme")]
        public int? ThemeId { get; set; }

        /// <summary>
        /// Gets or sets Theme.
        /// </summary>
        public virtual Theme Theme { get; set; }

        /// <summary>
        /// Gets or sets PublicationId.
        /// </summary>
        [ForeignKey("Publication")]
        public int? PublicationId { get; set; }

        /// <summary>
        /// Gets or sets Publication.
        /// </summary>
        public virtual Publication Publication { get; set; }

        #endregion
    }
}
