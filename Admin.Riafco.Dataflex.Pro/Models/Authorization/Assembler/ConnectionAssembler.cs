using Admin.Riafco.Dataflex.Pro.Models.Authorization.FormData;
using Admin.Riafco.Dataflex.Pro.Models.Authorization.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Authorization.RequestData;
using Admin.Riafco.Dataflex.Pro.Models.Authorization.ResultData;

namespace Admin.Riafco.Dataflex.Pro.Models.Authorization.Assembler
{
    /// <summary>
    /// The ConnectionAssembler class
    /// </summary>
    public static class ConnectionAssembler
    {
        /// <summary>
        /// From user result data to connection form data
        /// </summary>
        /// <param name="resultData">the user result data from web api.</param>
        /// <returns>the form data.</returns>
        public static ConnectionFormData ToFormData(this UserResultData resultData)
        {
            ConnectionFormData formData = new ConnectionFormData();
            if (resultData?.UserDto != null)
            {
                formData.Password = resultData.UserDto.UserPassword;
                formData.Username = resultData.UserDto.UserMail;
            }
            return formData;
        }

        /// <summary>
        /// From Form data to request data.
        /// </summary>
        /// <param name="formData">the form data to convert.</param>
        /// <returns>the request data.</returns>
        public static UserRequestData ToRequestData(this ConnectionFormData formData)
        {
            UserRequestData request = new UserRequestData();
            if (formData != null)
            {
                request.UserDto = new UserItemData
                {
                    UserPassword = formData.Password,
                    UserMail = formData.Username
                };
            }
            return request;
        }
    }
}