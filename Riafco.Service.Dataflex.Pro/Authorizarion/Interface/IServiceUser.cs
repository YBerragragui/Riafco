using Riafco.Service.Dataflex.Pro.Authorizarion.Request;
using Riafco.Service.Dataflex.Pro.Authorizarion.Response;

namespace Riafco.Service.Dataflex.Pro.Authorizarion.Interface
{
    /// <summary>
    /// The User interface.
    /// </summary>
    public interface IServiceUser
    {
        /// <summary>
        /// Create UserPivot.
        /// </summary>
        /// <param name="request"> The UserRequest Pivot that content UserPivot to add.</param>
        /// <returns>The UserResponsePivot result with the UserPivot added.</returns>
        UserResponsePivot CreateUser(UserRequestPivot request);

        /// <summary>
        /// Update UserPivot.
        /// </summary>
        /// <param name="request"> The UserRequest Pivot that content UserPivot to update.</param>
        void UpdateUser(UserRequestPivot request);

        /// <summary>
        /// Delete UserPivot.
        /// </summary>
        /// <param name="request"> The UserRequest Pivot that content UserPivot to remove.</param>
        void DeleteUser(UserRequestPivot request);

        /// <summary>
        /// Get User list
        /// </summary>
        /// <returns>Response result.</returns>
        UserResponsePivot GetAllUsers();

        /// <summary>
        /// Search User.
        /// </summary>
        /// <param name="request"> The UserRequest Pivot that content UserPivot to remove.</param>
        /// <returns>Response Result.</returns>
        UserResponsePivot FindUsers(UserRequestPivot request);

    }
}