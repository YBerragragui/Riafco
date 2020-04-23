using Riafco.Service.Dataflex.Pro.Authorizarion.Data;
using System.Collections.Generic;

namespace Riafco.Service.Dataflex.Pro.Authorizarion.Response
{
    /// <summary>
    /// The UserResponsePivot class.
    /// </summary>
    public class UserResponsePivot
    {
        /// <summary>
        /// Gets or sets the UserPivotList
        /// </summary>
        public List<UserPivot> UserPivotList { get; set; }

        /// <summary>
        /// Gets or sets the UserPivot.
        /// </summary>
        public UserPivot UserPivot { get; set; }

    }
}