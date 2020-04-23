using System.ComponentModel.DataAnnotations;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Ressource;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto
{
    /// <summary>
    /// The Author dto class.
    /// </summary>
    public class AuthorDto
    {
        /// <summary>
        /// Gets or Sets The  AuthorId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(AuthorMessageResource), ErrorMessageResourceName = "RequiredId")]
        public int AuthorId { get; set; }

        /// <summary>
        /// Gets or Sets The  AuthorFirstName.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(AuthorMessageResource), ErrorMessageResourceName = "RequiredFirstName")]
        public string AuthorFirstName { get; set; }

        /// <summary>
        /// Gets or Sets The  AuthorLastName.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(AuthorMessageResource), ErrorMessageResourceName = "RequiredLastName")]
        public string AuthorLastName { get; set; }
    }
}