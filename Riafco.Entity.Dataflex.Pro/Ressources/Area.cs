using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Riafco.Entity.Dataflex.Pro.Ressources
{
    /// <summary>
    /// The Area class.
    /// </summary>
    [Table("Ressource_Areas")]
    public class Area
    {
        /// <summary>
        /// Gets or sets AreaId.
        /// </summary>
        [Key]
        public int AreaId { get; set; }
    }
}
