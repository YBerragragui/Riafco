using Riafco.Entity.Dataflex.Pro.Ressources;
using Riafco.Service.Dataflex.Pro.Ressources.Data;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.Service.Dataflex.Pro.Ressources.Assembler
{
    /// <summary>
    /// The Area assembler class.
    /// </summary>
    public static class AreaAssembler
    {
        #region TO PIVOT 
        /// <summary>
        /// From Area To Area Pivot.
        /// </summary>
        /// <param name="area">area TO ASSEMBLE</param>
        /// <returns>AreaPivot result.</returns>
        public static AreaPivot ToPivot(this Area area)
        {
            if (area == null)
            {
                return null;
            }
            return new AreaPivot
            {
                AreaId = area.AreaId,
            };
        }

        /// <summary>
        /// From Area list to Area pivot list.
        /// </summary>
        /// <param name="areaList">areaList to assemble.</param>
        /// <returns>list of AreaPivot result.</returns>
        public static List<AreaPivot> ToPivotList(this List<Area> areaList)
        {
            return areaList?.Select(x => x.ToPivot()).ToList();
        }
        #endregion

        #region TO ENTITY 
        /// <summary>
        /// From AreaPivot to Area.
        /// </summary>
        /// <param name="areaPivot">areaPivot to assemble.</param>
        /// <returns>Area result.</returns>
        public static Area ToEntity(this AreaPivot areaPivot)
        {
            if (areaPivot == null)
            {
                return null;
            }
            return new Area
            {
                AreaId = areaPivot.AreaId,
            };
        }

        /// <summary>
        /// From AreaPivotList to AreaList .
        /// </summary>
        /// <param name="areaPivotList">AreaPivotList to assemble.</param>
        /// <returns> list of Area result.</returns>
        public static List<Area> ToEntityList(this List<AreaPivot> areaPivotList)
        {
            return areaPivotList?.Select(x => x.ToEntity()).ToList();
        }
        #endregion
    }
}