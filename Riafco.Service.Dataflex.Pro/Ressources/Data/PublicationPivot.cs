using System;

namespace Riafco.Service.Dataflex.Pro.Ressources.Data
{
    /// <summary>
    /// The Publication pivot class.
    /// </summary>
    public class PublicationPivot
    {
        /// <summary>
        /// Gets or Sets The  PublicationId.
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

        #region navigation attributes

        /// <summary>
        /// Gets or Sets The  AreaId.
        /// </summary>
        public int? AreaId { get; set; }

        /// <summary>
        /// Gets or Sets The  Area.
        /// </summary>
        public AreaPivot Area { get; set; }

        /// <summary>
        /// Gets or Sets The  AuthorId.
        /// </summary>
        public int? AuthorId { get; set; }

        /// <summary>
        /// Gets or Sets The  Author.
        /// </summary>
        public AuthorPivot Author { get; set; }


        #endregion
    }
}