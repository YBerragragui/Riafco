using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Riafco.Entity.Dataflex.Pro.Authorizarion
{
    /// <summary>
    /// The user class.
    /// </summary>
    [Table("auth_Users")]
    public class User
    {
        /// <summary>
        /// Gets or sets User Id.
        /// </summary>
        [Key]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets UserPicture
        /// </summary>
        public string UserPicture { get; set; }

        /// <summary>
        /// Gets or sets UserMail
        /// </summary>
        public string UserMail { get; set; }

        /// <summary>
        /// Gets or sets User password.
        /// </summary>
        public string UserPassword { get; set; }

        /// <summary>
        /// Gets or sets user statut.
        /// </summary>
        public bool UserStatut { get; set; }
    }
}
