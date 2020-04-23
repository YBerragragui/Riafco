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
    /// The Publication assembler class.
    /// </summary>
    public static class PublicationAssembler
    {
        #region TODTO
        /// <summary>
        ///    From Publication Pivot To Publication Dto.
        /// </summary>
        /// <param name="publicationPivot">publication pivot to assemble.</param>
        /// <returns>PublicationDto result.</returns>
        public static PublicationDto ToDto(this PublicationPivot publicationPivot)
        {
            if (publicationPivot == null)
            {
                return null;
            }
            return new PublicationDto
            {
                PublicationId = publicationPivot.PublicationId,
                PublicationImage = publicationPivot.PublicationImage,
                PublicationDate = publicationPivot.PublicationDate,
                AreaId = publicationPivot.AreaId,
                Area = publicationPivot.Area.ToDto(),
                AuthorId = publicationPivot.AuthorId,
                Author = publicationPivot.Author.ToDto(),
            };
        }

        /// <summary>
        ///    From Publication pivot list to Publication dto list.
        /// </summary>
        /// <param name="publicationPivotList">publication pivot liste to assemble.</param>
        /// <returns>Publicationdto result.</returns>
        public static List<PublicationDto> ToDtoList(this List<PublicationPivot> publicationPivotList)
        {
            return publicationPivotList?.Select(x => x.ToDto()).ToList();
        }

        #endregion

        #region TO PIVOT
        /// <summary>
        ///    From Publication dto To Publication pivot.
        /// </summary>
        /// <param name="publicationDto">publication dto to assemble.</param>
        /// <returns>Publicationpivot result.</returns>
        public static PublicationPivot ToPivot(this PublicationDto publicationDto)
        {
            if (publicationDto == null)
            {
                return null;
            }
            return new PublicationPivot
            {
                PublicationId = publicationDto.PublicationId,
                PublicationImage = publicationDto.PublicationImage,
                PublicationDate = publicationDto.PublicationDate,
                AreaId = publicationDto.AreaId,
                Area = publicationDto.Area.ToPivot(),
                AuthorId = publicationDto.AuthorId,
                Author = publicationDto.Author.ToPivot(),
            };
        }

        /// <summary>
        /// From Publicationpivot list To Publication pivot list.
        /// </summary>
        /// <param name="publicationDtoList">publication dto list to assemble.</param>
        /// <returns>PublicationPivot list result.</returns>
        public static List<PublicationPivot> ToPivotList(this List<PublicationDto> publicationDtoList)
        {
            return publicationDtoList?.Select(x => x.ToPivot()).ToList();
        }

        #endregion

        #region REQUEST ASSEMBLERT
        /// <summary>
        /// From Publication Request to Publication Request pivot.
        /// </summary>
        /// <param name="publicationRequest"></param>
        /// <returns>Publication Request pivot result.</returns>
        public static PublicationRequestPivot ToPivot(this PublicationRequest publicationRequest)
        {
            return new PublicationRequestPivot
            {
                PublicationPivot = publicationRequest.PublicationDto.ToPivot(),
                FindPublicationPivot = Utility.EnumToEnum<FindPublicationDto, FindPublicationPivot>(publicationRequest.FindPublicationDto)
            };
        }
        #endregion

        #region MESSAGE ASSEMBLER
        /// <summary>
        /// From Publication Response pivot to Publication Message.
        /// </summary>
        /// <param name="publicationResponsePivot">Publication Response pivot to assemble.</param>
        /// <returns>Publication Message result.</returns>
        public static PublicationMessage ToMessage(this PublicationResponsePivot publicationResponsePivot)
        {
            if (publicationResponsePivot == null)
            {
                return null;
            }
            return new PublicationMessage
            {
                PublicationDtoList = publicationResponsePivot.PublicationPivotList.ToDtoList(),
                PublicationDto = publicationResponsePivot.PublicationPivot.ToDto(),
            };
        }
        #endregion
    }
}