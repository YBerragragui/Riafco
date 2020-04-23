using Riafco.Dataflex.Pro.Models.Ressources.FormData;
using Riafco.Dataflex.Pro.Models.Ressources.ItemData;
using Riafco.Dataflex.Pro.Models.Ressources.RequestData;

namespace Riafco.Dataflex.Pro.Models.Ressources.Assembler
{
    /// <summary>
    /// The AuthorAssembler class.
    /// </summary>
    public static class AuthorAssembler
    {
        #region TO ITEM DATA
        /// <summary>
        /// FROM FROMDATA TO ITEMDATA.
        /// </summary>
        /// <param name="formData">the formdata to convert</param>
        /// <returns>the item data.</returns>
        public static AuthorItemData ToItemData(this AuthorFormData formData)
        {
            if (formData == null)
            {
                return new AuthorItemData();
            }

            AuthorItemData itemData = new AuthorItemData
            {
                AuthorFirstName = formData.AuthorFullName,
                AuthorLastName = formData.AuthorFullName,
                AuthorId = formData.AuthorId
            };
            return itemData;
        }
        #endregion

        #region TO FORM DATA
        /// <summary>
        /// FROM ITEM DATA TO FORM DATA.
        /// </summary>
        /// <param name="itemData">the itemData to convert</param>
        /// <returns>the formdata result</returns>
        public static AuthorFormData ToFormData(this AuthorItemData itemData)
        {
            if (itemData == null)
            {
                return new AuthorFormData();
            }

            AuthorFormData formData = new AuthorFormData
            {
                AuthorFullName = itemData.AuthorFirstName + " " + itemData.AuthorLastName,
                AuthorId = itemData.AuthorId
            };
            return formData;
        }
        #endregion

        #region REQUEST DATA

        /// <summary>
        /// From FORMDATA To REQUESTDATA
        /// </summary>
        /// <param name="authorFormData"></param>
        /// <returns></returns>
        public static AuthorRequestData ToRequestData(this AuthorFormData authorFormData)
        {
            if (authorFormData == null)
            {
                return new AuthorRequestData();
            }
            return new AuthorRequestData
            {
                AuthorDto = authorFormData.ToItemData()
            };
        }

        /// <summary>
        /// From REQUESTDATA To FORMDATA
        /// </summary>
        /// <param name="authorRequestData"></param>
        /// <returns></returns>
        public static AuthorFormData ToFormData(this AuthorRequestData authorRequestData)
        {
            if (authorRequestData?.AuthorDto == null)
            {
                return new AuthorFormData();
            }
            return new AuthorFormData
            {
                AuthorFullName = authorRequestData.AuthorDto.AuthorFirstName + " " +
                                 authorRequestData.AuthorDto.AuthorLastName,
                AuthorId = authorRequestData.AuthorDto.AuthorId
            };
        }
        #endregion
    }
}