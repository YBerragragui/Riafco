using Riafco.Entity.Dataflex.Pro.About;
using Riafco.Service.Dataflex.Pro.About.Data;
using Riafco.Entity.Dataflex.Pro;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.Service.Dataflex.Pro.About.Assembler
{
    /// <summary>
    /// The Section assembler class.
    /// </summary>
    public static class SectionAssembler
    {
        #region TO PIVOT 
        /// <summary>
        /// From Section To Section Pivot.
        /// </summary>
        /// <param name="section">section TO ASSEMBLE</param>
        /// <returns>SectionPivot result.</returns>
        public static SectionPivot ToPivot(this Section section)
        {
            if (section == null)
            {
                return null;
            }
            return new SectionPivot()
            {
                SectionId = section.SectionId,
                SectionImage = section.SectionImage,
            };
        }

        /// <summary>
        /// From Section list to Section pivot list.
        /// </summary>
        /// <param name="sectionList">sectionList to assemble.</param>
        /// <returns>list of SectionPivot result.</returns>
        public static List<SectionPivot> ToPivotList(this List<Section> sectionList)
        {
            return sectionList?.Select(x => x.ToPivot()).ToList();

        }
        #endregion

        #region TO ENTITY 
        /// <summary>
        /// From SectionPivot to Section.
        /// </summary>
        /// <param name="sectionPivot">sectionPivot to assemble.</param>
        /// <returns>Section result.</returns>
        public static Section ToEntity(this SectionPivot sectionPivot)
        {
            if (sectionPivot == null)
            {
                return null;
            }
            return new Section()
            {
                SectionId = sectionPivot.SectionId,
                SectionImage = sectionPivot.SectionImage,
            };
        }

        /// <summary>
        /// From SectionPivotList to SectionList .
        /// </summary>
        /// <param name="sectionPivotList">SectionPivotList to assemble.</param>
        /// <returns> list of Section result.</returns>
        public static List<Section> ToEntityList(this List<SectionPivot> sectionPivotList)
        {
            return sectionPivotList?.Select(x => x?.ToEntity()).ToList();

        }
        #endregion
    }
}