namespace Riafco.Service.Dataflex.Pro.Authorizarion.Data
{
    /// <summary>
    /// The User pivot class.
    /// </summary>
    public class UserPivot
    {
        /// <summary>
        /// Gets or Sets The  UserId.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or Sets The  UserName.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or Sets The  UserPicture.
        /// </summary>
        public string UserPicture { get; set; }

        /// <summary>
        /// Gets or Sets The  UserMail.
        /// </summary>
        public string UserMail { get; set; }

        /// <summary>
        /// Gets or Sets The  UserPassword.
        /// </summary>
        public string UserPassword { get; set; }

        /// <summary>
        /// Gets or Sets The  UserStatut.
        /// </summary>
        public bool UserStatut { get; set; }
    }
}