using System.ComponentModel.DataAnnotations;
using Admin.Riafco.Dataflex.Pro.GlobalResources;

namespace Admin.Riafco.Dataflex.Pro.Models.Ressources.FormData
{
    /// <summary>
    /// The PublicationThemeFormData class.
    /// </summary>
    public class PublicationThemeFormData
    {
        /// <summary>
        /// Gets or Sets The  PublicationThemeId.
        /// </summary>
        public int PublicationThemeId { get; set; }

        #region navigation attributes

        /// <summary>
        /// Gets or Sets The  ThemeId.
        /// </summary>
        [Display(ResourceType = typeof(PublicationThemeResources), Name = nameof(PublicationThemeResources.DisplayTheme))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(PublicationThemeResources), ErrorMessageResourceName = "RequiredThemeId")]
        [Required(ErrorMessageResourceType = typeof(PublicationThemeResources), AllowEmptyStrings = false, ErrorMessageResourceName = "RequiredThemeId")]
        public int? ThemeId { get; set; }

        /// <summary>
        /// Gets or Sets The PublicationId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(PublicationThemeResources), ErrorMessageResourceName = "RequiredPublicationId")]
        [Required(ErrorMessageResourceType = typeof(PublicationThemeResources), AllowEmptyStrings = false, ErrorMessageResourceName = "RequiredPublicationId")]
        public int? PublicationId { get; set; }

        #endregion
    }
}