using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Riafco.Entity.Dataflex.Pro.Ressources
{
    /// <summary>
    /// The Author class.
    /// </summary>
    [Table("Ressource_Authors")]
    public class Author
    {
        /// <summary>
        /// Gets or sets AuthorId.
        /// </summary>
        [Key]
        public int AuthorId { get; set; }

        /// <summary>
        /// Gets or sets AuthorName.
        /// </summary>
        public string AuthorFirstName { get; set; }

        /// <summary>
        /// Gets or sets AuthorLastName.
        /// </summary>
        public string AuthorLastName { get; set; }
    }
}
