using System;
using System.ComponentModel.DataAnnotations;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Ressource;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto
{
    /// <summary>
    /// The Publication dto class.
    /// </summary>
    public class PublicationDto
    {
        /// <summary>
        /// Gets or Sets The PublicationId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(PublicationMessageResource), ErrorMessageResourceName = "RequiredTranslationId")]
        public int PublicationId { get; set; }

        /// <summary>
        /// Gets or Sets The  PublicationImage.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(PublicationMessageResource), ErrorMessageResourceName = "RequiredPublicationImage")]
        public string  PublicationImage { get; set; }

        /// <summary>
        /// Gets or Sets The  PublicationDate.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(PublicationMessageResource), ErrorMessageResourceName = "RequiredPublicationDate")]
        public DateTime PublicationDate { get; set; }

        #region private attributes

        /// <summary>
        /// Gets or Sets The  AreaId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(PublicationMessageResource), ErrorMessageResourceName = "RequiredPublicationArea")]
        public int? AreaId { get; set; }

        /// <summary>
        /// Gets or Sets The  Area.
        /// </summary>
        public AreaDto Area { get; set; }

        /// <summary>
        /// Gets or Sets The  AuthorId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(PublicationMessageResource), ErrorMessageResourceName = "RequiredPublicationAuthor")]
        public int? AuthorId { get; set; }

        /// <summary>
        /// Gets or Sets The  Author.
        /// </summary>
        public AuthorDto Author { get; set; }

        #endregion
    }
}