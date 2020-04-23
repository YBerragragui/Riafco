using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Riafco.Entity.Dataflex.Pro.Ressources
{
    /// <summary>
    /// The theme class.
    /// </summary>
    [Table("Ressource_Themes")]
    public class Theme
    {
        /// <summary>
        /// Gets or sets ThemeId.
        /// </summary>
        [Key]
        public int ThemeId { get; set; }
    }
}
