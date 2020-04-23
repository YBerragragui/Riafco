using Riafco.Entity.Dataflex.Pro.Partners;
using Riafco.Service.Dataflex.Pro.Partners.Data;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.Service.Dataflex.Pro.Partners.Assembler
{
    /// <summary>
    /// The Partner assembler class.
    /// </summary>
    public static class PartnerAssembler
    {
        #region TO PIVOT 
        /// <summary>
        /// From Partner To Partner Pivot.
        /// </summary>
        /// <param name="partner">partner TO ASSEMBLE</param>
        /// <returns>PartnerPivot result.</returns>
        public static PartnerPivot ToPivot(this Partner partner)
        {
            if (partner == null)
            {
                return null;
            }
            return new PartnerPivot()
            {
                PartnerId = partner.PartnerId,
                PartnerImage = partner.PartnerImage,
                PartnerName = partner.PartnerName,
                PartnerLink = partner.PartnerLink,
                PartnerPosition = partner.PartnerPosition,
            };
        }

        /// <summary>
        /// From Partner list to Partner pivot list.
        /// </summary>
        /// <param name="partnerList">partnerList to assemble.</param>
        /// <returns>list of PartnerPivot result.</returns>
        public static List<PartnerPivot> ToPivotList(this List<Partner> partnerList)
        {
            return partnerList?.Select(x => x.ToPivot()).ToList();

        }
        #endregion

        #region TO ENTITY 
        /// <summary>
        /// From PartnerPivot to Partner.
        /// </summary>
        /// <param name="partnerPivot">partnerPivot to assemble.</param>
        /// <returns>Partner result.</returns>
        public static Partner ToEntity(this PartnerPivot partnerPivot)
        {
            if (partnerPivot == null)
            {
                return null;
            }
            return new Partner()
            {
                PartnerId = partnerPivot.PartnerId,
                PartnerImage = partnerPivot.PartnerImage,
                PartnerName = partnerPivot.PartnerName,
                PartnerLink = partnerPivot.PartnerLink,
                PartnerPosition = partnerPivot.PartnerPosition,
            };
        }

        /// <summary>
        /// From PartnerPivotList to PartnerList .
        /// </summary>
        /// <param name="partnerPivotList">PartnerPivotList to assemble.</param>
        /// <returns> list of Partner result.</returns>
        public static List<Partner> ToEntityList(this List<PartnerPivot> partnerPivotList)
        {
            return partnerPivotList?.Select(x => x?.ToEntity()).ToList();

        }
        #endregion
    }
}