using Riafco.Entity.Dataflex.Pro.Newsletters;
using Riafco.Service.Dataflex.Pro.Newsletters.Data;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.Service.Dataflex.Pro.Newsletters.Assembler
{
    /// <summary>
    /// The Subscriber assembler class.
    /// </summary>
    public static class SubscriberAssembler
    {
        #region TO PIVOT 
        /// <summary>
        /// From Subscriber To Subscriber Pivot.
        /// </summary>
        /// <param name="subscriber">subscriber TO ASSEMBLE</param>
        /// <returns>SubscriberPivot result.</returns>
        public static SubscriberPivot ToPivot(this Subscriber subscriber)
        {
            if (subscriber == null)
            {
                return null;
            }
            return new SubscriberPivot()
            {
                SubscriberId = subscriber.SubscriberId,
                SubscriberFirstName = subscriber.SubscriberFirstName,
                SubscriberLastName = subscriber.SubscriberLastName,
                SubscriberEmail = subscriber.SubscriberEmail,
            };
        }

        /// <summary>
        /// From Subscriber list to Subscriber pivot list.
        /// </summary>
        /// <param name="subscriberList">subscriberList to assemble.</param>
        /// <returns>list of SubscriberPivot result.</returns>
        public static List<SubscriberPivot> ToPivotList(this List<Subscriber> subscriberList)
        {
            return subscriberList?.Select(x => x.ToPivot()).ToList();

        }
        #endregion

        #region TO ENTITY 
        /// <summary>
        /// From SubscriberPivot to Subscriber.
        /// </summary>
        /// <param name="subscriberPivot">subscriberPivot to assemble.</param>
        /// <returns>Subscriber result.</returns>
        public static Subscriber ToEntity(this SubscriberPivot subscriberPivot)
        {
            if (subscriberPivot == null)
            {
                return null;
            }
            return new Subscriber()
            {
                SubscriberId = subscriberPivot.SubscriberId,
                SubscriberFirstName = subscriberPivot.SubscriberFirstName,
                SubscriberLastName = subscriberPivot.SubscriberLastName,
                SubscriberEmail = subscriberPivot.SubscriberEmail,
            };
        }

        /// <summary>
        /// From SubscriberPivotList to SubscriberList .
        /// </summary>
        /// <param name="subscriberPivotList">SubscriberPivotList to assemble.</param>
        /// <returns> list of Subscriber result.</returns>
        public static List<Subscriber> ToEntityList(this List<SubscriberPivot> subscriberPivotList)
        {
            return subscriberPivotList?.Select(x => x?.ToEntity()).ToList();

        }
        #endregion
    }
}