using Riafco.Framework.Dataflex.pro.Util;
using Riafco.Service.Dataflex.Pro.Ressources.Data;
using Riafco.Service.Dataflex.Pro.Ressources.Data.Enum;
using Riafco.Service.Dataflex.Pro.Ressources.Request;
using Riafco.Service.Dataflex.Pro.Ressources.Response;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Assembler;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Dto.Enum;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Message;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Request;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources.Assembler
{
    /// <summary>
    /// The PublicationTranslation assembler class.
    /// </summary>
    public static class PublicationTranslationAssembler
    {
        #region TO DTO
        /// <summary>
        /// From PublicationTranslation Pivot To PublicationTranslation Dto.
        /// </summary>
        /// <param name="publicationTranslationPivot">publicationTranslation pivot to assemble.</param>
        /// <returns>PublicationTranslationDto result.</returns>
        public static PublicationTranslationDto ToDto(this PublicationTranslationPivot publicationTranslationPivot)
        {
            if (publicationTranslationPivot == null)
            {
                return null;
            }
            return new PublicationTranslationDto
            {
                PublicationTranslationId = publicationTranslationPivot.PublicationTranslationId,
                PublicationSummary = publicationTranslationPivot.PublicationSummary,
                PublicationTitle = publicationTranslationPivot.PublicationTitle,
                Publication = publicationTranslationPivot.Publication.ToDto(),
                PublicationFile = publicationTranslationPivot.PublicationFile,
                PublicationId = publicationTranslationPivot.PublicationId,
                Language = publicationTranslationPivot.Language.ToDto(),
                LanguageId = publicationTranslationPivot.LanguageId
            };
        }

        /// <summary>
        /// From PublicationTranslation pivot list to PublicationTranslation dto list.
        /// </summary>
        /// <param name="publicationTranslationPivotList">publicationTranslation pivot liste to assemble.</param>
        /// <returns>PublicationTranslationdto result.</returns>
        public static List<PublicationTranslationDto> ToDtoList(this List<PublicationTranslationPivot> publicationTranslationPivotList)
        {
            return publicationTranslationPivotList?.Select(x => x.ToDto()).ToList();
        }

        #endregion

        #region TO PIVOT
        /// <summary>
        /// From PublicationTranslation dto To PublicationTranslation pivot.
        /// </summary>
        /// <param name="publicationTranslationDto">publicationTranslation dto to assemble.</param>
        /// <returns>PublicationTranslationpivot result.</returns>
        public static PublicationTranslationPivot ToPivot(this PublicationTranslationDto publicationTranslationDto)
        {
            if (publicationTranslationDto == null)
            {
                return null;
            }
            return new PublicationTranslationPivot
            {
                PublicationTranslationId = publicationTranslationDto.PublicationTranslationId,
                PublicationSummary = publicationTranslationDto.PublicationSummary,
                PublicationTitle = publicationTranslationDto.PublicationTitle,
                Publication = publicationTranslationDto.Publication.ToPivot(),
                PublicationFile = publicationTranslationDto.PublicationFile,
                Language = publicationTranslationDto.Language.ToPivot(),
                PublicationId = publicationTranslationDto.PublicationId,
                LanguageId = publicationTranslationDto.LanguageId
            };
        }

        /// <summary>
        /// From PublicationTranslationpivot list To PublicationTranslation pivot list.
        /// </summary>
        /// <param name="publicationTranslationDtoList">publicationTranslation dto list to assemble.</param>
        /// <returns>PublicationTranslationPivot list result.</returns>
        public static List<PublicationTranslationPivot> ToPivotList(this List<PublicationTranslationDto> publicationTranslationDtoList)
        {
            return publicationTranslationDtoList?.Select(x => x.ToPivot()).ToList();
        }
        #endregion

        #region REQUEST ASSEMBLERT
        /// <summary>
        /// From PublicationTranslation Request to PublicationTranslation Request pivot.
        /// </summary>
        /// <param name="publicationTranslationRequest"></param>
        /// <returns>PublicationTranslation Request pivot result.</returns>
        public static PublicationTranslationRequestPivot ToPivot(this PublicationTranslationRequest publicationTranslationRequest)
        {
            PublicationTranslationRequestPivot publicationTranslationRequestPivot =
                new PublicationTranslationRequestPivot
                {
                    FindPublicationTranslationPivot = Utility
                        .EnumToEnum<FindPublicationTranslationDto, FindPublicationTranslationPivot>(
                            publicationTranslationRequest.FindPublicationTranslationDto),
                    PublicationTranslationPivotList = publicationTranslationRequest.PublicationTranslationDtoList
                        .ToPivotList(),
                    PublicationTranslationPivot = publicationTranslationRequest.PublicationTranslationDto.ToPivot()
                };
            return publicationTranslationRequestPivot;
        }
        #endregion

        #region MESSAGE ASSEMBLER
        /// <summary>
        /// From PublicationTranslation Response pivot to PublicationTranslation Message.
        /// </summary>
        /// <param name="publicationTranslationResponsePivot">PublicationTranslation Response pivot to assemble.</param>
        /// <returns>PublicationTranslation Message result.</returns>
        public static PublicationTranslationMessage ToMessage(this PublicationTranslationResponsePivot publicationTranslationResponsePivot)
        {
            if (publicationTranslationResponsePivot == null)
            {
                return null;
            }
            return new PublicationTranslationMessage
            {
                PublicationTranslationDtoList = publicationTranslationResponsePivot.PublicationTranslationPivotList
                    .ToDtoList(),
                PublicationTranslationDto = publicationTranslationResponsePivot.PublicationTranslationPivot.ToDto()
            };
        }
        #endregion
    }
}