using Admin.Riafco.Dataflex.Pro.GlobalResources;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Admin.Riafco.Dataflex.Pro.Models.Authorization.FormData
{
    /// <summary>
    /// The ManageUserFormData class.
    /// </summary>
    public class ManageUserFormData
    {
        /// <summary>
        /// Gets or sets UserId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(UserResources), ErrorMessageResourceName = nameof(UserResources.RequiredUserId))]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets UserPicture.
        /// </summary>
        [DataType(DataType.Upload)]
        [Display(ResourceType = typeof(UserResources), Name = nameof(UserResources.DisplayUserPicture))]
        public HttpPostedFileBase UserPicture { get; set; }

        /// <summary>
        /// Gets or sets UserName.
        /// </summary>
        [Display(ResourceType = typeof(UserResources), Name = nameof(UserResources.DisplayUserName))]
        [Required(ErrorMessageResourceType = typeof(UserResources), ErrorMessageResourceName = nameof(UserResources.RequiredUserName))]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets UserMail.
        /// </summary>
        [Display(ResourceType = typeof(UserResources), Name = nameof(UserResources.DisplayUserMail))]
        [Required(ErrorMessageResourceType = typeof(UserResources), ErrorMessageResourceName = nameof(UserResources.RequiredMail))]
        [EmailAddress(ErrorMessageResourceType = typeof(UserResources), ErrorMessageResourceName = nameof(UserResources.InvalideMail))]
        public string UserMail { get; set; }

        [Display(ResourceType = typeof(UserResources), Name = nameof(UserResources.DisplayUserPasse))]
        [Required(ErrorMessageResourceType = typeof(UserResources), ErrorMessageResourceName = nameof(UserResources.RequiredPasse))]
        public string UserPassword { get; set; }

        /// <summary>
        /// Gets or sets UserStatus.
        /// </summary>
        public bool UserStatus { get; set; }
    }
}