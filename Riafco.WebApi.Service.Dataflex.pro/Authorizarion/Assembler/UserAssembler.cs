using Riafco.Framework.Dataflex.pro.Util;
using Riafco.Service.Dataflex.Pro.Authorizarion.Data;
using Riafco.Service.Dataflex.Pro.Authorizarion.Data.Enum;
using Riafco.Service.Dataflex.Pro.Authorizarion.Request;
using Riafco.Service.Dataflex.Pro.Authorizarion.Response;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Dto.Enum;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Message;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Request;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Assembler
{
    /// <summary>
    /// The User assembler class.
    /// </summary>
    public static class UserAssembler
    {
        #region TO DTO
        /// <summary>
        /// From User Pivot To User Dto.
        /// </summary>
        /// <param name="userPivot">user pivot to assemble.</param>
        /// <returns>UserDto result.</returns>
        public static UserDto ToDto(this UserPivot userPivot)
        {
            if (userPivot == null)
            {
                return null;
            }
            return new UserDto
            {
                UserPicture = userPivot.UserPicture,
                UserPassword = userPivot.UserPassword,
                UserStatut = userPivot.UserStatut,
                UserMail = userPivot.UserMail,
                UserName = userPivot.UserName,
                UserId = userPivot.UserId
            };
        }

        /// <summary>
        /// From User pivot list to User dto list.
        /// </summary>
        /// <param name="userPivotList">user pivot liste to assemble.</param>
        /// <returns>Userdto result.</returns>
        public static List<UserDto> ToDtoList(this List<UserPivot> userPivotList)
        {
            return userPivotList?.Select(x => x.ToDto()).ToList();
        }

        #endregion

        #region TO PIVOT
        /// <summary>
        /// From User dto To User pivot.
        /// </summary>
        /// <param name="userDto">user dto to assemble.</param>
        /// <returns>Userpivot result.</returns>
        public static UserPivot ToPivot(this UserDto userDto)
        {
            if (userDto == null)
            {
                return null;
            }
            return new UserPivot
            {
                UserId = userDto.UserId,
                UserName = userDto.UserName,
                UserPicture = userDto.UserPicture,
                UserMail = userDto.UserMail,
                UserPassword = userDto.UserPassword,
                UserStatut = userDto.UserStatut
            };
        }

        /// <summary>
        /// From Userpivot list To User pivot list.
        /// </summary>
        /// <param name="userDtoList">user dto list to assemble.</param>
        /// <returns>UserPivot list result.</returns>
        public static List<UserPivot> ToPivotList(this List<UserDto> userDtoList)
        {
            return userDtoList?.Select(x => x.ToPivot()).ToList();
        }

        #endregion

        #region REQUEST ASSEMBLERT
        /// <summary>
        /// From User Request to User Request pivot.
        /// </summary>
        /// <param name="userRequest">the request to assemble.</param>
        /// <returns>User Request pivot result.</returns>
        public static UserRequestPivot ToPivot(this UserRequest userRequest)
        {
            return new UserRequestPivot
            {
                FindUserPivot = Utility.EnumToEnum<FindUserDto, FindUserPivot>(userRequest.FindUserDto),
                UserPivot = userRequest.UserDto.ToPivot()
            };
        }
        #endregion

        #region MESSAGE ASSEMBLER
        /// <summary>
        /// From User Response pivot to User Message.
        /// </summary>
        /// <param name="userResponsePivot">user Response pivot to assemble.</param>
        /// <returns>User Message result.</returns>
        public static UserMessage ToMessage(this UserResponsePivot userResponsePivot)
        {
            return new UserMessage
            {
                UserDtoList = userResponsePivot?.UserPivotList.ToDtoList(),
                UserDto = userResponsePivot?.UserPivot.ToDto()
            };
        }
        #endregion
    }
}