using Riafco.Entity.Dataflex.Pro.About;
using Riafco.Service.Dataflex.Pro.About.Data;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.Service.Dataflex.Pro.About.Assembler
{
    /// <summary>
    /// The SectionParagraph assembler class.
    /// </summary>
    public static class SectionParagraphAssembler
    {
        #region TO PIVOT 
        /// <summary>
        /// From SectionParagraph To SectionParagraph Pivot.
        /// </summary>
        /// <param name="sectionParagraph">sectionParagraph TO ASSEMBLE</param>
        /// <returns>SectionParagraphPivot result.</returns>
        public static SectionParagraphPivot ToPivot(this SectionParagraph sectionParagraph)
        {
            if (sectionParagraph == null)
            {
                return null;
            }
            return new SectionParagraphPivot
            {
                Section = sectionParagraph.Section?.ToPivot(),
                ParagraphId = sectionParagraph.ParagraphId,
                SectionId = sectionParagraph.SectionId
            };
        }

        /// <summary>
        /// From SectionParagraph list to SectionParagraph pivot list.
        /// </summary>
        /// <param name="sectionParagraphList">sectionParagraphList to assemble.</param>
        /// <returns>list of SectionParagraphPivot result.</returns>
        public static List<SectionParagraphPivot> ToPivotList(this List<SectionParagraph> sectionParagraphList)
        {
            return sectionParagraphList?.Select(x => x?.ToPivot()).ToList();

        }
        #endregion

        #region TO ENTITY 
        /// <summary>
        /// From SectionParagraphPivot to SectionParagraph.
        /// </summary>
        /// <param name="sectionParagraphPivot">sectionParagraphPivot to assemble.</param>
        /// <returns>SectionParagraph result.</returns>
        public static SectionParagraph ToEntity(this SectionParagraphPivot sectionParagraphPivot)
        {
            if (sectionParagraphPivot == null)
            {
                return null;
            }
            return new SectionParagraph
            {
                Section = sectionParagraphPivot.Section?.ToEntity(),
                ParagraphId = sectionParagraphPivot.ParagraphId,
                SectionId = sectionParagraphPivot.SectionId
            };
        }

        /// <summary>
        /// From SectionParagraphPivotList to SectionParagraphList .
        /// </summary>
        /// <param name="sectionParagraphPivotList">SectionParagraphPivotList to assemble.</param>
        /// <returns> list of SectionParagraph result.</returns>
        public static List<SectionParagraph> ToEntityList(this List<SectionParagraphPivot> sectionParagraphPivotList)
        {
            return sectionParagraphPivotList?.Select(x => x?.ToEntity()).ToList();
        }
        #endregion
    }
}