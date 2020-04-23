using Riafco.Service.Dataflex.Pro.Authorizarion.Data;
using Riafco.Service.Dataflex.Pro.Authorizarion.Data.Enum;

namespace Riafco.Service.Dataflex.Pro.Authorizarion.Request
{
    /// <summary>
    /// The UserRequestPivot class.
    /// </summary>
    public class UserRequestPivot
    {
        /// <summary>
        /// Gets or sets UserPivot.
        /// </summary>
        public UserPivot UserPivot { get; set; }

        /// <summary>
        /// Gets or sets FindUserPivot.
        /// </summary>
        public FindUserPivot FindUserPivot { get; set; }
    }
}