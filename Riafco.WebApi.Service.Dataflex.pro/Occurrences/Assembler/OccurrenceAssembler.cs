using Riafco.Framework.Dataflex.pro.Util;
using Riafco.Service.Dataflex.Pro.Occurrences.Data;
using Riafco.Service.Dataflex.Pro.Occurrences.Data.Enum;
using Riafco.Service.Dataflex.Pro.Occurrences.Request;
using Riafco.Service.Dataflex.Pro.Occurrences.Response;
using Riafco.WebApi.Service.Dataflex.pro.Occurrences.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Occurrences.Dto.Enum;
using Riafco.WebApi.Service.Dataflex.pro.Occurrences.Message;
using Riafco.WebApi.Service.Dataflex.pro.Occurrences.Request;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.WebApi.Service.Dataflex.pro.Occurrences.Assembler
{
    /// <summary>
    /// The Occurrence assembler class.
    /// </summary>
    public static class OccurrenceAssembler
    {
        #region TO DTO
        /// <summary>
        /// From Occurrence Pivot To Occurrence Dto.
        /// </summary>
        /// <param name="occurrencePivot">occurrence pivot to assemble.</param>
        /// <returns>OccurrenceDto result.</returns>
        public static OccurrenceDto ToDto(this OccurrencePivot occurrencePivot)
        {
            if (occurrencePivot == null)
            {
                return null;
            }

            return new OccurrenceDto
            {
                OccurrenceStartDate = occurrencePivot.OccurrenceStartDate,
                OccurrenceEndDate = occurrencePivot.OccurrenceEndDate,
                OccurrenceLink = occurrencePivot.OccurrenceLink,
                OccurrenceId = occurrencePivot.OccurrenceId
            };
        }

        /// <summary>
        /// From Occurrence pivot list to Occurrence dto list.
        /// </summary>
        /// <param name="occurrencePivotList">occurrence pivot liste to assemble.</param>
        /// <returns>Occurrencedto result.</returns>
        public static List<OccurrenceDto> ToDtoList(this List<OccurrencePivot> occurrencePivotList)
        {
            return occurrencePivotList?.Select(x => x.ToDto()).ToList();
        }

        #endregion

        #region TO PIVOT
        /// <summary>
        /// From Occurrence dto To Occurrence pivot.
        /// </summary>
        /// <param name="occurrenceDto">occurrence dto to assemble.</param>
        /// <returns>Occurrencepivot result.</returns>
        public static OccurrencePivot ToPivot(this OccurrenceDto occurrenceDto)
        {
            if (occurrenceDto == null)
            {
                return null;
            }
            return new OccurrencePivot
            {
                OccurrenceStartDate = occurrenceDto.OccurrenceStartDate,
                OccurrenceEndDate = occurrenceDto.OccurrenceEndDate,
                OccurrenceLink = occurrenceDto.OccurrenceLink,
                OccurrenceId = occurrenceDto.OccurrenceId
            };
        }

        /// <summary>
        /// From Occurrencepivot list To Occurrence pivot list.
        /// </summary>
        /// <param name="occurrenceDtoList">occurrence dto list to assemble.</param>
        /// <returns>OccurrencePivot list result.</returns>
        public static List<OccurrencePivot> ToPivotList(this List<OccurrenceDto> occurrenceDtoList)
        {
            return occurrenceDtoList?.Select(x => x.ToPivot()).ToList();
        }

        #endregion

        #region REQUEST ASSEMBLERT
        /// <summary>
        /// From Occurrence Request to Occurrence Request pivot.
        /// </summary>
        /// <param name="occurrenceRequest"></param>
        /// <returns>Occurrence Request pivot result.</returns>
        public static OccurrenceRequestPivot ToPivot(this OccurrenceRequest occurrenceRequest)
        {
            return new OccurrenceRequestPivot
            {
                FindOccurrencePivot = Utility.EnumToEnum<FindOccurrenceDto, FindOccurrencePivot>(occurrenceRequest.FindOccurrenceDto),
                OccurrencePivot = occurrenceRequest.OccurrenceDto.ToPivot()
            };
        }
        #endregion

        #region MESSAGE ASSEMBLER
        /// <summary>
        /// From Occurrence Response pivot to Occurrence Message.
        /// </summary>
        /// <param name="occurrenceResponsePivot">Occurrence Response pivot to assemble.</param>
        /// <returns>Occurrence Message result.</returns>
        public static OccurrenceMessage ToMessage(this OccurrenceResponsePivot occurrenceResponsePivot)
        {
            if (occurrenceResponsePivot == null)
            {
                return null;
            }
            return new OccurrenceMessage
            {
                OccurrenceDtoList = occurrenceResponsePivot.OccurrencePivotList.ToDtoList(),
                OccurrenceDto = occurrenceResponsePivot.OccurrencePivot.ToDto()
            };
        }
        #endregion
    }
}