using System;

namespace Riafco.Dataflex.Pro.Models.Ressources.ItemData
{
    /// <summary>
    /// The Publication dto class.
    /// </summary>
    public class PublicationItemData
    {
        /// <summary>
        /// Gets or Sets The PublicationId.
        /// </summary>
        public int PublicationId { get; set; }

        /// <summary>
        /// Gets or Sets The  PublicationImage.
        /// </summary>
        public string PublicationImage { get; set; }

        /// <summary>
        /// Gets or Sets The  PublicationDate.
        /// </summary>
        public DateTime PublicationDate { get; set; }

        #region private attributes

        /// <summary>
        /// Gets or Sets The  AreaId.
        /// </summary>
        public int? AreaId { get; set; }

        /// <summary>
        /// Gets or Sets The  Area.
        /// </summary>
        public AreaItemData Area { get; set; }

        /// <summary>
        /// Gets or Sets The  AuthorId.
        /// </summary>
        public int? AuthorId { get; set; }

        /// <summary>
        /// Gets or Sets The  Author.
        /// </summary>
        public AuthorItemData Author { get; set; }

        #endregion
    }
}