using System.Collections.Generic;
using System.Linq;
using Riafco.Framework.Dataflex.pro.Util;
using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Dto;
using Riafco.Service.Dataflex.Pro.Newsletters.Data;
using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Request;
using Riafco.Service.Dataflex.Pro.Newsletters.Request;
using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Message;
using Riafco.Service.Dataflex.Pro.Newsletters.Response;
using Riafco.WebApi.Service.Dataflex.pro.Newsletters.Dto.Enum;
using Riafco.Service.Dataflex.Pro.Newsletters.Data.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Newsletters.Assembler
{
    /// <summary>
    /// The Subscriber assembler class.
    /// </summary>
    public static class SubscriberAssembler
    {
        #region TODTO
        /// <summary>
        ///    From Subscriber Pivot To Subscriber Dto.
        /// </summary>
        /// <param name="subscriberPivot">subscriber pivot to assemble.</param>
        /// <returns>SubscriberDto result.</returns>
        public static SubscriberDto ToDto(this SubscriberPivot subscriberPivot)
        {
            if (subscriberPivot == null)
            {
                return null;
            }
            else
            {
                return new SubscriberDto()
                {
                    SubscriberId = subscriberPivot.SubscriberId,
                    SubscriberFirstName = subscriberPivot.SubscriberFirstName,
                    SubscriberLastName = subscriberPivot.SubscriberLastName,
                    SubscriberEmail = subscriberPivot.SubscriberEmail,
                };
            }
        }

        /// <summary>
        ///    From Subscriber pivot list to Subscriber dto list.
        /// </summary>
        /// <param name="subscriberPivotList">subscriber pivot liste to assemble.</param>
        /// <returns>Subscriberdto result.</returns>
        public static List<SubscriberDto> ToDtoList(this List<SubscriberPivot> subscriberPivotList)
        {
            return subscriberPivotList?.Select(x => x?.ToDto()).ToList();

        }

        #endregion

        #region TO PIVOT
        /// <summary>
        ///    From Subscriber dto To Subscriber pivot.
        /// </summary>
        /// <param name="subscriberDto">subscriber dto to assemble.</param>
        /// <returns>Subscriberpivot result.</returns>
        public static SubscriberPivot ToPivot(this SubscriberDto subscriberDto)
        {
            if (subscriberDto == null)
            {
                return null;
            }
            else
            {
                return new SubscriberPivot()
                {
                    SubscriberId = subscriberDto.SubscriberId,
                    SubscriberFirstName = subscriberDto.SubscriberFirstName,
                    SubscriberLastName = subscriberDto.SubscriberLastName,
                    SubscriberEmail = subscriberDto.SubscriberEmail,
                };

            }
        }

        /// <summary>
        ///    From Subscriberpivot list To Subscriber pivot list.
        /// </summary>
        /// <param name="subscriberDtoList">subscriber dto list to assemble.</param>
        /// <returns>SubscriberPivot list result.</returns>
        public static List<SubscriberPivot> ToPivotList(this List<SubscriberDto> subscriberDtoList)
        {
            return subscriberDtoList?.Select(x => x?.ToPivot()).ToList();

        }

        #endregion

        #region REQUEST ASSEMBLERT
        /// <summary>
        ///    From Subscriber Request to Subscriber Request pivot.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Subscriber Request pivot result.</returns>
        public static SubscriberRequestPivot ToPivot(this SubscriberRequest request)
        {
            return new SubscriberRequestPivot()
            {
                SubscriberPivot = request.SubscriberDto?.ToPivot(),
                FindSubscriberPivot = Utility.EnumToEnum<FindSubscriberDto, FindSubscriberPivot>(request.FindSubscriberDto)
            };
        }
        #endregion

        #region MESSAGE ASSEMBLER
        /// <summary>
        /// From Subscriber Response pivot to Subscriber Message.
        /// </summary>
        /// <param name="response">Subscriber Response pivot to assemble.</param>
        /// <returns>Subscriber Message result.</returns>
        public static SubscriberMessage ToMessage(this SubscriberResponsePivot response)
        {
            if (response == null)
            {
                return null;
            }
            else
            {
                return new SubscriberMessage()
                {
                    SubscriberDtoList = response.SubscriberPivotList?.ToDtoList(),
                    SubscriberDto = response.SubscriberPivot?.ToDto(),
                };
            }
        }

        #endregion

    }
}