using System.ComponentModel.DataAnnotations;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Ressource;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto
{
    /// <summary>
    /// The PublicationTheme dto class.
    /// </summary>
    public class PublicationThemeDto
    {
        /// <summary>
        /// Gets or Sets The  PublicationThemeId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(PublicationThemeMessageResource), ErrorMessageResourceName = "RequiredId")]
        public int PublicationThemeId { get; set; }

        #region navigation attributes

        /// <summary>
        /// Gets or Sets The  ThemeId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(PublicationThemeMessageResource), ErrorMessageResourceName = "RequiredThemeId")]
        public int? ThemeId { get; set; }

        /// <summary>
        /// Gets or Sets The  Theme.
        /// </summary>
        public ThemeDto Theme { get; set; }

        /// <summary>
        /// Gets or Sets The  PublicationId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(PublicationThemeMessageResource), ErrorMessageResourceName = "RequiredPublicationId")]
        public int? PublicationId { get; set; }

        /// <summary>
        /// Gets or Sets The  Publication.
        /// </summary>
        public PublicationDto Publication { get; set; }

        #endregion
    }
}