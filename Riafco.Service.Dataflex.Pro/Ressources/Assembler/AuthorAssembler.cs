using Riafco.Entity.Dataflex.Pro.Ressources;
using Riafco.Service.Dataflex.Pro.Ressources.Data;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.Service.Dataflex.Pro.Ressources.Assembler
{
    /// <summary>
    /// The Author assembler class.
    /// </summary>
    public static class AuthorAssembler
    {
        #region TO PIVOT 
        /// <summary>
        /// From Author To Author Pivot.
        /// </summary>
        /// <param name="author">author TO ASSEMBLE</param>
        /// <returns>AuthorPivot result.</returns>
        public static AuthorPivot ToPivot(this Author author)
        {
            if (author == null)
            {
                return null;
            }
            return new AuthorPivot
            {
                AuthorId = author.AuthorId,
                AuthorFirstName = author.AuthorFirstName,
                AuthorLastName = author.AuthorLastName
            };
        }

        /// <summary>
        /// From Author list to Author pivot list.
        /// </summary>
        /// <param name="authorList">authorList to assemble.</param>
        /// <returns>list of AuthorPivot result.</returns>
        public static List<AuthorPivot> ToPivotList(this List<Author> authorList)
        {
            return authorList?.Select(x => x.ToPivot()).ToList();
        }
        #endregion

        #region TO ENTITY 
        /// <summary>
        /// From AuthorPivot to Author.
        /// </summary>
        /// <param name="authorPivot">authorPivot to assemble.</param>
        /// <returns>Author result.</returns>
        public static Author ToEntity(this AuthorPivot authorPivot)
        {
            if (authorPivot == null)
            {
                return null;
            }
            return new Author
            {
                AuthorFirstName = authorPivot.AuthorFirstName,
                AuthorLastName = authorPivot.AuthorLastName,
                AuthorId = authorPivot.AuthorId
            };
        }

        /// <summary>
        /// From AuthorPivotList to AuthorList.
        /// </summary>
        /// <param name="authorPivotList">AuthorPivotList to assemble.</param>
        /// <returns> list of Author result.</returns>
        public static List<Author> ToEntityList(this List<AuthorPivot> authorPivotList)
        {
            return authorPivotList?.Select(x => x.ToEntity()).ToList();
        }
        #endregion
    }
}