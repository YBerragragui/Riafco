using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Ressource;
using System.ComponentModel.DataAnnotations;

namespace Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Dto
{
    /// <summary>
    /// The User dto class.
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Gets or Sets The  UserId.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(UserMessageResource), ErrorMessageResourceName = "RequiredId")]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or Sets The  UserName.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(UserMessageResource), ErrorMessageResourceName = "RequiredUserName")]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or Sets The  UserPicture.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(UserMessageResource), ErrorMessageResourceName = "RequiredUserPicture")]
        public string UserPicture { get; set; }

        /// <summary>
        /// Gets or Sets The  UserMail.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(UserMessageResource), ErrorMessageResourceName = "RequiredUserMail")]
        public string UserMail { get; set; }

        /// <summary>
        /// Gets or Sets The  UserPassword.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(UserMessageResource), ErrorMessageResourceName = "RequiredUserUserPassword")]
        public string UserPassword { get; set; }

        /// <summary>
        /// Gets or Sets The  UserStatut.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(UserMessageResource), ErrorMessageResourceName = "RequiredUserUserStatut")]
        public bool UserStatut { get; set; }
    }
}