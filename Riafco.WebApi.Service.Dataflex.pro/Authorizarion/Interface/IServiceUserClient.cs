using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Message;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Request;

namespace Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Interface
{
    /// <summary>
    /// The User client interface.
    /// </summary>
    public interface IServiceUserClient
    {
        /// <summary>
        /// Create User dto.
        /// </summary>
        /// <param name="request"> The UserRequest that content Userdto to add.</param>
        /// <returns>The UserMessagePivot result with the UserPivot to add.</returns>
        UserMessage CreateUser(UserRequest request);

        /// <summary>
        /// Update User dto.
        /// </summary>
        /// <param name="request"> The UserRequest that content Userdto to update.</param>
        UserMessage UpdateUser(UserRequest request);

        /// <summary>
        /// Delete User dto.
        /// </summary>
        /// <param name="request"> The UserRequest that content Userdto to remove.</param>
        /// <returns>The UserMessagePivot result with the UserPivot removed.</returns>
        UserMessage DeleteUser(UserRequest request);

        /// <summary>
        /// Get the list of User.
        /// </summary>
        /// <returns>The UserMessagePivot result with the UserPivot list.</returns>
        UserMessage GetAllUsers();

        /// <summary>
        /// Find User.
        /// </summary>
        /// <returns>The UserMessagePivot result with the UserPivot list.</returns>
        UserMessage FindUsers(UserRequest request);
    }
}