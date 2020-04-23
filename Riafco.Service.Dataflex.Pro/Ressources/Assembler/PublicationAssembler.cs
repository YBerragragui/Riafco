using Riafco.Entity.Dataflex.Pro.Ressources;
using Riafco.Service.Dataflex.Pro.Ressources.Data;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.Service.Dataflex.Pro.Ressources.Assembler
{
    /// <summary>
    /// The Publication assembler class.
    /// </summary>
    public static class PublicationAssembler
    {
        #region TO PIVOT 
        /// <summary>
        /// From Publication To Publication Pivot.
        /// </summary>
        /// <param name="publication">publication TO ASSEMBLE</param>
        /// <returns>PublicationPivot result.</returns>
        public static PublicationPivot ToPivot(this Publication publication)
        {
            if (publication == null)
            {
                return null;
            }
            return new PublicationPivot
            {
                PublicationId = publication.PublicationId,
                PublicationImage = publication.PublicationImage,
                PublicationDate = publication.PublicationDate,
                AreaId = publication.AreaId,
                Area = publication.Area?.ToPivot(),
                AuthorId = publication.AuthorId,
                Author = publication.Author?.ToPivot()
            };
        }

        /// <summary>
        /// From Publication list to Publication pivot list.
        /// </summary>
        /// <param name="publicationList">publicationList to assemble.</param>
        /// <returns>list of PublicationPivot result.</returns>
        public static List<PublicationPivot> ToPivotList(this List<Publication> publicationList)
        {
            return publicationList?.Select(x => x.ToPivot()).ToList();

        }
        #endregion

        #region TO ENTITY 
        /// <summary>
        /// From PublicationPivot to Publication.
        /// </summary>
        /// <param name="publicationPivot">publicationPivot to assemble.</param>
        /// <returns>Publication result.</returns>
        public static Publication ToEntity(this PublicationPivot publicationPivot)
        {
            if (publicationPivot == null)
            {
                return null;
            }
            return new Publication
            {
                PublicationId = publicationPivot.PublicationId,
                PublicationImage = publicationPivot.PublicationImage,
                PublicationDate = publicationPivot.PublicationDate,
                AreaId = publicationPivot.AreaId,
                Area = publicationPivot.Area?.ToEntity(),
                AuthorId = publicationPivot.AuthorId,
                Author = publicationPivot.Author?.ToEntity()
            };
        }

        /// <summary>
        /// From PublicationPivotList to PublicationList .
        /// </summary>
        /// <param name="publicationPivotList">PublicationPivotList to assemble.</param>
        /// <returns> list of Publication result.</returns>
        public static List<Publication> ToEntityList(this List<PublicationPivot> publicationPivotList)
        {
            return publicationPivotList?.Select(x => x.ToEntity()).ToList();
        }
        #endregion
    }
}