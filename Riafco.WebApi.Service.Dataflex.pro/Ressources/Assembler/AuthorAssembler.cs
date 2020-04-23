using System.Collections.Generic;
using System.Linq;
using Riafco.Framework.Dataflex.pro.Util;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto;
using Riafco.Service.Dataflex.Pro.Ressources.Data;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Request;
using Riafco.Service.Dataflex.Pro.Ressources.Request;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Message;
using Riafco.Service.Dataflex.Pro.Ressources.Response;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto.Enum;
using Riafco.Service.Dataflex.Pro.Ressources.Data.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources.Assembler
{
    /// <summary>
    /// The Author assembler class.
    /// </summary>
    public static class AuthorAssembler
    {
        #region TO DTO
        /// <summary>
        /// From Author Pivot To Author Dto.
        /// </summary>
        /// <param name="authorPivot">author pivot to assemble.</param>
        /// <returns>AuthorDto result.</returns>
        public static AuthorDto ToDto(this AuthorPivot authorPivot)
        {
            if (authorPivot == null)
            {
                return null;
            }
            return new AuthorDto
            {
                AuthorId = authorPivot.AuthorId,
                AuthorFirstName = authorPivot.AuthorFirstName,
                AuthorLastName = authorPivot.AuthorLastName
            };
        }

        /// <summary>
        /// From Author pivot list to Author dto list.
        /// </summary>
        /// <param name="authorPivotList">author pivot liste to assemble.</param>
        /// <returns>Authordto result.</returns>
        public static List<AuthorDto> ToDtoList(this List<AuthorPivot> authorPivotList)
        {
            return authorPivotList?.Select(x => x.ToDto()).ToList();
        }

        #endregion

        #region TO PIVOT
        /// <summary>
        /// From Author dto To Author pivot.
        /// </summary>
        /// <param name="authorDto">author dto to assemble.</param>
        /// <returns>Authorpivot result.</returns>
        public static AuthorPivot ToPivot(this AuthorDto authorDto)
        {
            if (authorDto == null)
            {
                return null;
            }
            return new AuthorPivot
            {
                AuthorId = authorDto.AuthorId,
                AuthorFirstName = authorDto.AuthorFirstName,
                AuthorLastName = authorDto.AuthorLastName
            };
        }

        /// <summary>
        ///    From Authorpivot list To Author pivot list.
        /// </summary>
        /// <param name="authorDtoList">author dto list to assemble.</param>
        /// <returns>AuthorPivot list result.</returns>
        public static List<AuthorPivot> ToPivotList(this List<AuthorDto> authorDtoList)
        {
            return authorDtoList?.Select(x => x.ToPivot()).ToList();
        }

        #endregion

        #region REQUEST ASSEMBLERT
        /// <summary>
        /// From Author Request to Author Request pivot.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Author Request pivot result.</returns>
        public static AuthorRequestPivot ToPivot(this AuthorRequest request)
        {
            return new AuthorRequestPivot
            {
                AuthorPivot = request.AuthorDto?.ToPivot(),
                FindAuthorPivot = Utility.EnumToEnum<FindAuthorDto, FindAuthorPivot>(request.FindAuthorDto)
            };
        }
        #endregion

        #region MESSAGE ASSEMBLER
        /// <summary>
        /// From Author Response pivot to Author Message.
        /// </summary>
        /// <param name="response">Author Response pivot to assemble.</param>
        /// <returns>Author Message result.</returns>
        public static AuthorMessage ToMessage(this AuthorResponsePivot response)
        {
            if (response == null)
            {
                return null;
            }
            return new AuthorMessage
            {
                AuthorDtoList = response.AuthorPivotList.ToDtoList(),
                AuthorDto = response.AuthorPivot?.ToDto()
            };
        }
        #endregion
    }
}