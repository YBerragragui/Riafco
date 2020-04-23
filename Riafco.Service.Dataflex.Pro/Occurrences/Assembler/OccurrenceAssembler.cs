using Riafco.Entity.Dataflex.Pro.Occurrences;
using Riafco.Service.Dataflex.Pro.Occurrences.Data;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.Service.Dataflex.Pro.Occurrences.Assembler
{
    /// <summary>
    /// The Occurrence assembler class.
    /// </summary>
    public static class OccurrenceAssembler
    {
        #region TO PIVOT 
        /// <summary>
        /// From Occurrence To Occurrence Pivot.
        /// </summary>
        /// <param name="occurrence">occurrence TO ASSEMBLE</param>
        /// <returns>OccurrencePivot result.</returns>
        public static OccurrencePivot ToPivot(this Occurrence occurrence)
        {
            if (occurrence == null)
            {
                return null;
            }
            return new OccurrencePivot
            {
                OccurrenceStartDate = occurrence.OccurrenceStartDate,
                OccurrenceEndDate = occurrence.OccurrenceEndDate,
                OccurrenceLink = occurrence.OccurrenceLink,
                OccurrenceId = occurrence.OccurrenceId
            };
        }

        /// <summary>
        /// From Occurrence list to Occurrence pivot list.
        /// </summary>
        /// <param name="occurrenceList">occurrenceList to assemble.</param>
        /// <returns>list of OccurrencePivot result.</returns>
        public static List<OccurrencePivot> ToPivotList(this List<Occurrence> occurrenceList)
        {
            return occurrenceList?.Select(x => x.ToPivot()).ToList();
        }
        #endregion

        #region TO ENTITY 
        /// <summary>
        /// From OccurrencePivot to Occurrence.
        /// </summary>
        /// <param name="occurrencePivot">occurrencePivot to assemble.</param>
        /// <returns>Occurrence result.</returns>
        public static Occurrence ToEntity(this OccurrencePivot occurrencePivot)
        {
            if (occurrencePivot == null)
            {
                return null;
            }
            return new Occurrence
            {
                OccurrenceStartDate = occurrencePivot.OccurrenceStartDate,
                OccurrenceEndDate = occurrencePivot.OccurrenceEndDate,
                OccurrenceLink = occurrencePivot.OccurrenceLink,
                OccurrenceId = occurrencePivot.OccurrenceId
            };
        }

        /// <summary>
        /// From OccurrencePivotList to OccurrenceList .
        /// </summary>
        /// <param name="occurrencePivotList">OccurrencePivotList to assemble.</param>
        /// <returns> list of Occurrence result.</returns>
        public static List<Occurrence> ToEntityList(this List<OccurrencePivot> occurrencePivotList)
        {
            return occurrencePivotList?.Select(x => x.ToEntity()).ToList();
        }
        #endregion
    }
}