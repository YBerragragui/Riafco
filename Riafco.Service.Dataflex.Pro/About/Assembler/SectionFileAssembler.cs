using Riafco.Entity.Dataflex.Pro.About;
using Riafco.Service.Dataflex.Pro.About.Data;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.Service.Dataflex.Pro.About.Assembler
{
    /// <summary>
    /// The SectionFile assembler class.
    /// </summary>
    public static class SectionFileAssembler
    {
        #region TO PIVOT 
        /// <summary>
        /// From SectionFile To SectionFile Pivot.
        /// </summary>
        /// <param name="sectionFile">sectionFile TO ASSEMBLE</param>
        /// <returns>SectionFilePivot result.</returns>
        public static SectionFilePivot ToPivot(this SectionFile sectionFile)
        {
            if (sectionFile == null)
            {
                return null;
            }
            return new SectionFilePivot
            {
                SectionFileId = sectionFile.SectionFileId,
                Section = sectionFile.Section.ToPivot(),
                SectionId = sectionFile.SectionId
            };
        }

        /// <summary>
        /// From SectionFile list to SectionFile pivot list.
        /// </summary>
        /// <param name="sectionFileList">sectionFileList to assemble.</param>
        /// <returns>list of SectionFilePivot result.</returns>
        public static List<SectionFilePivot> ToPivotList(this List<SectionFile> sectionFileList)
        {
            return sectionFileList?.Select(x => x.ToPivot()).ToList();
        }
        #endregion

        #region TO ENTITY 
        /// <summary>
        /// From SectionFilePivot to SectionFile.
        /// </summary>
        /// <param name="sectionFilePivot">sectionFilePivot to assemble.</param>
        /// <returns>SectionFile result.</returns>
        public static SectionFile ToEntity(this SectionFilePivot sectionFilePivot)
        {
            if (sectionFilePivot == null)
            {
                return null;
            }
            return new SectionFile
            {
                SectionFileId = sectionFilePivot.SectionFileId,
                Section = sectionFilePivot.Section?.ToEntity(),
                SectionId = sectionFilePivot.SectionId
            };
        }

        /// <summary>
        /// From SectionFilePivotList to SectionFileList .
        /// </summary>
        /// <param name="sectionFilePivotList">SectionFilePivotList to assemble.</param>
        /// <returns>List of SectionFile result.</returns>
        public static List<SectionFile> ToEntityList(this List<SectionFilePivot> sectionFilePivotList)
        {
            return sectionFilePivotList?.Select(x => x.ToEntity()).ToList();
        }
        #endregion
    }
}