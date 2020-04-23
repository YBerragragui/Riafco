using System.Collections.Generic;
using System.Linq;
using Riafco.Framework.Dataflex.pro.Util;
using Riafco.WebApi.Service.Dataflex.pro.Occurrences.Dto;
using Riafco.Service.Dataflex.Pro.Occurrences.Data;
using Riafco.WebApi.Service.Dataflex.pro.Occurrences.Request;
using Riafco.Service.Dataflex.Pro.Occurrences.Request;
using Riafco.WebApi.Service.Dataflex.pro.Occurrences.Message;
using Riafco.Service.Dataflex.Pro.Occurrences.Response;
using Riafco.WebApi.Service.Dataflex.pro.Occurrences.Dto.Enum;
using Riafco.Service.Dataflex.Pro.Occurrences.Data.Enum;
using Riafco.WebApi.Service.Dataflex.pro.Languages.Assembler;

namespace Riafco.WebApi.Service.Dataflex.pro.Occurrences.Assembler
{
    /// <summary>
    /// The OccurrenceTranslation assembler class.
    /// </summary>
    public static class OccurrenceTranslationAssembler
    {
        #region TODTO
        /// <summary>
        ///    From OccurrenceTranslation Pivot To OccurrenceTranslation Dto.
        /// </summary>
        /// <param name="occurrenceTranslationPivot">occurrenceTranslation pivot to assemble.</param>
        /// <returns>OccurrenceTranslationDto result.</returns>
        public static OccurrenceTranslationDto ToDto(this OccurrenceTranslationPivot occurrenceTranslationPivot)
        {
            if (occurrenceTranslationPivot == null)
            {
                return null;
            }
            return new OccurrenceTranslationDto()
            {
                TranslationId = occurrenceTranslationPivot.TranslationId,
                OccurrenceTitle = occurrenceTranslationPivot.OccurrenceTitle,
                OccurrenceDescription = occurrenceTranslationPivot.OccurrenceDescription,
                OccurrenceId = occurrenceTranslationPivot.OccurrenceId,
                Occurrence = occurrenceTranslationPivot.Occurrence.ToDto(),
                LanguageId = occurrenceTranslationPivot.LanguageId,
                Language = occurrenceTranslationPivot.Language.ToDto()
            };
        }

        /// <summary>
        ///    From OccurrenceTranslation pivot list to OccurrenceTranslation dto list.
        /// </summary>
        /// <param name="occurrenceTranslationPivotList">occurrenceTranslation pivot liste to assemble.</param>
        /// <returns>OccurrenceTranslationdto result.</returns>
        public static List<OccurrenceTranslationDto> ToDtoList(this List<OccurrenceTranslationPivot> occurrenceTranslationPivotList)
        {
            return occurrenceTranslationPivotList?.Select(x => x?.ToDto()).ToList();

        }

        #endregion

        #region TO PIVOT
        /// <summary>
        ///    From OccurrenceTranslation dto To OccurrenceTranslation pivot.
        /// </summary>
        /// <param name="occurrenceTranslationDto">occurrenceTranslation dto to assemble.</param>
        /// <returns>OccurrenceTranslationpivot result.</returns>
        public static OccurrenceTranslationPivot ToPivot(this OccurrenceTranslationDto occurrenceTranslationDto)
        {
            if (occurrenceTranslationDto == null)
            {
                return null;
            }
            return new OccurrenceTranslationPivot()
            {
                TranslationId = occurrenceTranslationDto.TranslationId,
                OccurrenceTitle = occurrenceTranslationDto.OccurrenceTitle,
                OccurrenceDescription = occurrenceTranslationDto.OccurrenceDescription,
                OccurrenceId = occurrenceTranslationDto.OccurrenceId,
                Occurrence = occurrenceTranslationDto.Occurrence.ToPivot(),
                LanguageId = occurrenceTranslationDto.LanguageId,
                Language = occurrenceTranslationDto.Language.ToPivot()
            };
        }

        /// <summary>
        ///    From OccurrenceTranslationpivot list To OccurrenceTranslation pivot list.
        /// </summary>
        /// <param name="occurrenceTranslationDtoList">occurrenceTranslation dto list to assemble.</param>
        /// <returns>OccurrenceTranslationPivot list result.</returns>
        public static List<OccurrenceTranslationPivot> ToPivotList(this List<OccurrenceTranslationDto> occurrenceTranslationDtoList)
        {
            return occurrenceTranslationDtoList?.Select(x => x?.ToPivot()).ToList();

        }

        #endregion

        #region REQUEST ASSEMBLERT
        /// <summary>
        ///    From OccurrenceTranslation Request to OccurrenceTranslation Request pivot.
        /// </summary>
        /// <param name="occurrenceTranslationRequest"></param>
        /// <returns>OccurrenceTranslation Request pivot result.</returns>
        public static OccurrenceTranslationRequestPivot ToPivot(this OccurrenceTranslationRequest occurrenceTranslationRequest)
        {
            return new OccurrenceTranslationRequestPivot()
            {
                OccurrenceTranslationPivot = occurrenceTranslationRequest.OccurrenceTranslationDto?.ToPivot(),
                OccurrenceTranslationPivotList = occurrenceTranslationRequest.OccurrenceTranslationDtoList.ToPivotList(),
                FindOccurrenceTranslationPivot = Utility.EnumToEnum<FindOccurrenceTranslationDto, FindOccurrenceTranslationPivot>(occurrenceTranslationRequest.FindOccurrenceTranslationDto)
            };
        }
        #endregion

        #region MESSAGE ASSEMBLER
        /// <summary>
        /// From OccurrenceTranslation Response pivot to OccurrenceTranslation Message.
        /// </summary>
        /// <param name="occurrenceTranslationResponsePivot">OccurrenceTranslation Response pivot to assemble.</param>
        /// <returns>OccurrenceTranslation Message result.</returns>
        public static OccurrenceTranslationMessage ToMessage(this OccurrenceTranslationResponsePivot occurrenceTranslationResponsePivot)
        {
            if (occurrenceTranslationResponsePivot == null)
            {
                return null;
            }
            return new OccurrenceTranslationMessage()
            {
                OccurrenceTranslationDtoList = occurrenceTranslationResponsePivot.OccurrenceTranslationPivotList?.ToDtoList(),
                OccurrenceTranslationDto = occurrenceTranslationResponsePivot.OccurrenceTranslationPivot?.ToDto()
            };
        }

        #endregion
    }
}