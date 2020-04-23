using Riafco.Entity.Dataflex.Pro.Ressources;
using Riafco.Service.Dataflex.Pro.Languages.Assembler;
using Riafco.Service.Dataflex.Pro.Ressources.Data;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.Service.Dataflex.Pro.Ressources.Assembler
{
    /// <summary>
    /// The PublicationTranslation assembler class.
    /// </summary>
    public static class PublicationTranslationAssembler
    {
        #region TO PIVOT 
        /// <summary>
        /// From PublicationTranslation To PublicationTranslation Pivot.
        /// </summary>
        /// <param name="publicationTranslation">publicationTranslation TO ASSEMBLE</param>
        /// <returns>PublicationTranslationPivot result.</returns>
        public static PublicationTranslationPivot ToPivot(this PublicationTranslation publicationTranslation)
        {
            if (publicationTranslation == null)
            {
                return null;
            }
            return new PublicationTranslationPivot
            {
                PublicationTranslationId = publicationTranslation.PublicationTranslationId,
                PublicationSummary = publicationTranslation.PublicationSummary,
                Publication = publicationTranslation.Publication.ToPivot(),
                PublicationTitle = publicationTranslation.PublicationTitle,
                PublicationFile = publicationTranslation.PublicationFile,
                Language = publicationTranslation.Language.ToPivot(),
                PublicationId = publicationTranslation.PublicationId,
                LanguageId = publicationTranslation.LanguageId
            };
        }

        /// <summary>
        /// From PublicationTranslation list to PublicationTranslation pivot list.
        /// </summary>
        /// <param name="publicationTranslationList">publicationTranslationList to assemble.</param>
        /// <returns>list of PublicationTranslationPivot result.</returns>
        public static List<PublicationTranslationPivot> ToPivotList(
            this List<PublicationTranslation> publicationTranslationList)
        {
            return publicationTranslationList?.Select(x => x.ToPivot()).ToList();
        }

        #endregion

        #region TO ENTITY 
        /// <summary>
        /// From PublicationTranslationPivot to PublicationTranslation.
        /// </summary>
        /// <param name="publicationTranslationPivot">publicationTranslationPivot to assemble.</param>
        /// <returns>PublicationTranslation result.</returns>
        public static PublicationTranslation ToEntity(this PublicationTranslationPivot publicationTranslationPivot)
        {
            if (publicationTranslationPivot == null)
            {
                return null;
            }
            return new PublicationTranslation
            {
                PublicationTranslationId = publicationTranslationPivot.PublicationTranslationId,
                PublicationSummary = publicationTranslationPivot.PublicationSummary,
                Publication = publicationTranslationPivot.Publication.ToEntity(),
                PublicationTitle = publicationTranslationPivot.PublicationTitle,
                PublicationFile = publicationTranslationPivot.PublicationFile,
                Language = publicationTranslationPivot.Language.ToEntity(),
                PublicationId = publicationTranslationPivot.PublicationId,
                LanguageId = publicationTranslationPivot.LanguageId
            };
        }

        /// <summary>
        /// From PublicationTranslationPivotList to PublicationTranslationList .
        /// </summary>
        /// <param name="publicationTranslationPivotList">PublicationTranslationPivotList to assemble.</param>
        /// <returns> list of PublicationTranslation result.</returns>
        public static List<PublicationTranslation> ToEntityList(this List<PublicationTranslationPivot> publicationTranslationPivotList)
        {
            return publicationTranslationPivotList?.Select(x => x.ToEntity()).ToList();
        }
        #endregion
    }
}