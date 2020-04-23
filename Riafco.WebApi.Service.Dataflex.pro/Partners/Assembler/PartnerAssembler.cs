using System.Collections.Generic;
using System.Linq;
using Riafco.Framework.Dataflex.pro.Util;
using Riafco.WebApi.Service.Dataflex.pro.Partners.Dto;
using Riafco.Service.Dataflex.Pro.Partners.Data;
using Riafco.WebApi.Service.Dataflex.pro.Partners.Request;
using Riafco.Service.Dataflex.Pro.Partners.Request;
using Riafco.WebApi.Service.Dataflex.pro.Partners.Message;
using Riafco.Service.Dataflex.Pro.Partners.Response;
using Riafco.WebApi.Service.Dataflex.pro.Partners.Dto.Enum;
using Riafco.Service.Dataflex.Pro.Partners.Data.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Partners.Assembler
{
    /// <summary>
    /// The Partner assembler class.
    /// </summary>
    public static class PartnerAssembler
    {
        #region TODTO
        /// <summary>
        ///    From Partner Pivot To Partner Dto.
        /// </summary>
        /// <param name="partnerPivot">partner pivot to assemble.</param>
        /// <returns>PartnerDto result.</returns>
        public static PartnerDto ToDto(this PartnerPivot partnerPivot)
        {
            if (partnerPivot == null)
            {
                return null;
            }
            return new PartnerDto()
            {
                PartnerId = partnerPivot.PartnerId,
                PartnerImage = partnerPivot.PartnerImage,
                PartnerName = partnerPivot.PartnerName,
                PartnerLink = partnerPivot.PartnerLink,
                PartnerPosition = partnerPivot.PartnerPosition,
            };
        }

        /// <summary>
        ///    From Partner pivot list to Partner dto list.
        /// </summary>
        /// <param name="partnerPivotList">partner pivot liste to assemble.</param>
        /// <returns>Partnerdto result.</returns>
        public static List<PartnerDto> ToDtoList(this List<PartnerPivot> partnerPivotList)
        {
            return partnerPivotList?.Select(x => x?.ToDto()).ToList();

        }

        #endregion

        #region TO PIVOT
        /// <summary>
        ///    From Partner dto To Partner pivot.
        /// </summary>
        /// <param name="partnerDto">partner dto to assemble.</param>
        /// <returns>Partnerpivot result.</returns>
        public static PartnerPivot ToPivot(this PartnerDto partnerDto)
        {
            if (partnerDto == null)
            {
                return null;
            }
            return new PartnerPivot()
            {
                PartnerId = partnerDto.PartnerId,
                PartnerImage = partnerDto.PartnerImage,
                PartnerName = partnerDto.PartnerName,
                PartnerLink = partnerDto.PartnerLink,
                PartnerPosition = partnerDto.PartnerPosition,
            };
        }

        /// <summary>
        ///    From Partnerpivot list To Partner pivot list.
        /// </summary>
        /// <param name="partnerDtoList">partner dto list to assemble.</param>
        /// <returns>PartnerPivot list result.</returns>
        public static List<PartnerPivot> ToPivotList(this List<PartnerDto> partnerDtoList)
        {
            return partnerDtoList?.Select(x => x?.ToPivot()).ToList();

        }

        #endregion

        #region REQUEST ASSEMBLERT
        /// <summary>
        ///    From Partner Request to Partner Request pivot.
        /// </summary>
        /// <param name="partnerRequest"></param>
        /// <returns>Partner Request pivot result.</returns>
        public static PartnerRequestPivot ToPivot(this PartnerRequest partnerRequest)
        {
            return new PartnerRequestPivot()
            {
                PartnerPivot = partnerRequest.PartnerDto?.ToPivot(),
                FindPartnerPivot = Utility.EnumToEnum<FindPartnerDto, FindPartnerPivot>(partnerRequest.FindPartnerDto)
            };
        }
        #endregion

        #region MESSAGE ASSEMBLER
        /// <summary>
        /// From Partner Response pivot to Partner Message.
        /// </summary>
        /// <param name="partnerResponsePivot">Partner Response pivot to assemble.</param>
        /// <returns>Partner Message result.</returns>
        public static PartnerMessage ToMessage(this PartnerResponsePivot partnerResponsePivot)
        {
            if (partnerResponsePivot == null)
            {
                return null;
            }
            return new PartnerMessage()
            {
                PartnerDtoList = partnerResponsePivot.PartnerPivotList?.ToDtoList(),
                PartnerDto = partnerResponsePivot.PartnerPivot?.ToDto(),
            };
        }

        #endregion

    }
}