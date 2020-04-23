using Riafco.Entity.Dataflex.Pro.Ressources;
using Riafco.Service.Dataflex.Pro.Ressources.Data;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.Service.Dataflex.Pro.Ressources.Assembler
{
    /// <summary>
    /// The PublicationTheme assembler class.
    /// </summary>
    public static class PublicationThemeAssembler
    {
        #region TO PIVOT 
        /// <summary>
        /// From PublicationTheme To PublicationTheme Pivot.
        /// </summary>
        /// <param name="publicationTheme">publicationTheme TO ASSEMBLE</param>
        /// <returns>PublicationThemePivot result.</returns>
        public static PublicationThemePivot ToPivot(this PublicationTheme publicationTheme)
        {
            if (publicationTheme == null)
            {
                return null;
            }
            return new PublicationThemePivot
            {
                PublicationThemeId = publicationTheme.PublicationThemeId,
                Publication = publicationTheme.Publication?.ToPivot(),
                PublicationId = publicationTheme.PublicationId,
                Theme = publicationTheme.Theme?.ToPivot(),
                ThemeId = publicationTheme.ThemeId
            };
        }

        /// <summary>
        /// From PublicationTheme list to PublicationTheme pivot list.
        /// </summary>
        /// <param name="publicationThemeList">publicationThemeList to assemble.</param>
        /// <returns>list of PublicationThemePivot result.</returns>
        public static List<PublicationThemePivot> ToPivotList(this List<PublicationTheme> publicationThemeList)
        {
            return publicationThemeList?.Select(x => x.ToPivot()).ToList();
        }
        #endregion

        #region TO ENTITY 
        /// <summary>
        /// From PublicationThemePivot to PublicationTheme.
        /// </summary>
        /// <param name="publicationThemePivot">publicationThemePivot to assemble.</param>
        /// <returns>PublicationTheme result.</returns>
        public static PublicationTheme ToEntity(this PublicationThemePivot publicationThemePivot)
        {
            if (publicationThemePivot == null)
            {
                return null;
            }
            return new PublicationTheme
            {
                PublicationThemeId = publicationThemePivot.PublicationThemeId,
                Publication = publicationThemePivot.Publication.ToEntity(),
                PublicationId = publicationThemePivot.PublicationId,
                Theme = publicationThemePivot.Theme.ToEntity(),
                ThemeId = publicationThemePivot.ThemeId
            };
        }

        /// <summary>
        /// From PublicationThemePivotList to PublicationThemeList .
        /// </summary>
        /// <param name="publicationThemePivotList">PublicationThemePivotList to assemble.</param>
        /// <returns> list of PublicationTheme result.</returns>
        public static List<PublicationTheme> ToEntityList(this List<PublicationThemePivot> publicationThemePivotList)
        {
            return publicationThemePivotList?.Select(x => x.ToEntity()).ToList();
        }
        #endregion
    }
}