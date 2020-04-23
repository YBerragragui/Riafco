using Admin.Riafco.Dataflex.Pro.GlobalResources;
using System.ComponentModel.DataAnnotations;

namespace Admin.Riafco.Dataflex.Pro.Models.Authorization.FormData
{
    /// <summary>
    /// The ConnectionFormData class
    /// </summary>
    public class ConnectionFormData
    {
        /// <summary>
        /// Gets or sets Username
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(ConnectionResources), ErrorMessageResourceName = nameof(ConnectionResources.RequiredLogin))]
        [Display(ResourceType = typeof(ConnectionResources), Name = nameof(ConnectionResources.DisplayLogin))]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets Password
        /// </summary>
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(ConnectionResources), Name = nameof(ConnectionResources.DisplayPasse))]
        [Required(ErrorMessageResourceType = typeof(ConnectionResources), ErrorMessageResourceName = nameof(ConnectionResources.RequiredPasse))]
        public string Password { get; set; }
    }
}