using Riafco.Entity.Dataflex.Pro.Authorizarion;
using Riafco.Service.Dataflex.Pro.Authorizarion.Data;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.Service.Dataflex.Pro.Authorizarion.Assembler
{
    /// <summary>
    /// The User assembler class.
    /// </summary>
    public static class UserAssembler
    {
        #region TO PIVOT 
        /// <summary>
        /// From User To User Pivot.
        /// </summary>
        /// <param name="user">user TO ASSEMBLE</param>
        /// <returns>UserPivot result.</returns>
        public static UserPivot ToPivot(this User user)
        {
            if (user == null)
            {
                return null;
            }
            return new UserPivot
            {
                UserId = user.UserId,
                UserName = user.UserName,
                UserPicture = user.UserPicture,
                UserMail = user.UserMail,
                UserPassword = user.UserPassword,
                UserStatut = user.UserStatut,
            };
        }

        /// <summary>
        /// From User list to User pivot list.
        /// </summary>
        /// <param name="userList">userList to assemble.</param>
        /// <returns>list of UserPivot result.</returns>
        public static List<UserPivot> ToPivotList(this List<User> userList)
        {
            return userList?.Select(x => x.ToPivot()).ToList();
        }
        #endregion

        #region TO ENTITY 
        /// <summary>
        /// From UserPivot to User.
        /// </summary>
        /// <param name="userPivot">userPivot to assemble.</param>
        /// <returns>User result.</returns>
        public static User ToEntity(this UserPivot userPivot)
        {
            if (userPivot == null)
            {
                return null;
            }
            return new User
            {
                UserId = userPivot.UserId,
                UserName = userPivot.UserName,
                UserPicture = userPivot.UserPicture,
                UserMail = userPivot.UserMail,
                UserPassword = userPivot.UserPassword,
                UserStatut = userPivot.UserStatut,
            };
        }

        /// <summary>
        /// From UserPivotList to UserList.
        /// </summary>
        /// <param name="userPivotList">UserPivotList to assemble.</param>
        /// <returns> list of User result.</returns>
        public static List<User> ToEntityList(this List<UserPivot> userPivotList)
        {
            return userPivotList?.Select(x => x.ToEntity()).ToList();
        }
        #endregion
    }
}