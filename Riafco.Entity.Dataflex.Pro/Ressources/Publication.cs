using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Riafco.Entity.Dataflex.Pro.Ressources
{
    /// <summary>
    /// The Publication class.
    /// </summary>
    [Table("Ressource_Publications")]
    public class Publication
    {
        /// <summary>
        /// Gets or sets PublicationId.
        /// </summary>
        [Key]
        public int PublicationId { get; set; }

        /// <summary>
        /// Gets or sets PublicationImage.
        /// </summary>
        public string PublicationImage { get; set; }

        /// <summary>
        /// Gets or sets PublicationDate.
        /// </summary>
        public DateTime PublicationDate { get; set; }

        #region navigation attributes

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
        /// Gets or sets AuthorId.
        /// </summary>
        [ForeignKey("Author")]
        public int? AuthorId { get; set; }

        /// <summary>
        /// Gets or sets Author
        /// </summary>
        public virtual Author Author { get; set; }

        #endregion
    }
}
