using Admin.Riafco.Dataflex.Pro.Models.Authorization.FormData;
using Admin.Riafco.Dataflex.Pro.Models.Authorization.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Authorization.RequestData;
using Admin.Riafco.Dataflex.Pro.Models.Authorization.ResultData;

namespace Admin.Riafco.Dataflex.Pro.Models.Authorization.Assembler
{
    /// <summary>
    /// The UserAssembler class. 
    /// </summary>
    public static class UserAssembler
    {
        /// <summary>
        /// From user result data to connection form data
        /// </summary>
        /// <param name="resultData">the user result data from web api.</param>
        /// <returns>the form data.</returns>
        public static ManageUserFormData ToUserFormData(this UserResultData resultData)
        {
            ManageUserFormData formData = new ManageUserFormData();
            if (resultData?.UserDto != null)
            {
                formData = new ManageUserFormData
                {
                    UserStatus = resultData.UserDto.UserStatut,
                    UserName = resultData.UserDto.UserName,
                    UserMail = resultData.UserDto.UserMail,
                    UserId = resultData.UserDto.UserId
                };
            }
            return formData;
        }

        /// <summary>
        /// From Form data to request data.
        /// </summary>
        /// <param name="formData">the form data to convert.</param>
        /// <returns>the request data.</returns>
        public static UserRequestData ToRequestData(this ManageUserFormData formData)
        {
            UserRequestData request = new UserRequestData();
            if (formData != null)
            {
                request.UserDto = new UserItemData
                {
                    UserPicture = formData.UserPicture?.FileName,
                    UserPassword = formData.UserPassword,
                    UserStatut = formData.UserStatus,
                    UserMail = formData.UserMail,
                    UserName = formData.UserName,
                    UserId = formData.UserId
                };
            }
            return request;
        }

        /// <summary>
        /// From user result data to connection form data
        /// </summary>
        /// <param name="resultData">the user result data from web api.</param>
        /// <returns>the form data.</returns>
        public static UserRequestData ToUserRequestData(this UserResultData resultData)
        {
            UserRequestData userRequestData = new UserRequestData();
            if (resultData?.UserDto != null)
            {
                userRequestData = new UserRequestData
                {
                    UserDto = new UserItemData
                    {
                        UserPassword = resultData.UserDto.UserPassword,
                        UserPicture = resultData.UserDto.UserPicture,
                        UserStatut = resultData.UserDto.UserStatut,
                        UserName = resultData.UserDto.UserName,
                        UserMail = resultData.UserDto.UserMail,
                        UserId = resultData.UserDto.UserId
                    }
                };
            }
            return userRequestData;
        }

        /// <summary>
        /// from item data to form data
        /// </summary>
        /// <param name="itemData">the item data to convert</param>
        /// <returns>the form data result</returns>
        public static ManageUserRuleFormData ToUserRuleFormData(this UserRuleItemData itemData)
        {
            ManageUserRuleFormData formData = new ManageUserRuleFormData();
            if (itemData?.RuleId != null)
                formData = new ManageUserRuleFormData
                {
                    RuleStatus = itemData.UserRuleStatus,
                    RulePrefix = itemData.Rule.RuleName,
                    RuleName = itemData.Rule.RuleName,
                    UserRuleId = itemData.UserRuleId,
                    RuleId = itemData.RuleId.Value
                };
            return formData;
        }

        /// <summary>
        /// From form data to item data.
        /// </summary>
        /// <param name="formData"></param>
        /// <returns></returns>
        public static UserRuleItemData ToUserRuleItemData(this ManageUserRuleFormData formData)
        {
            UserRuleItemData itemData = new UserRuleItemData();
            if (formData != null)
            {
                itemData = new UserRuleItemData
                {
                    UserRuleStatus = formData.RuleStatus,
                    UserRuleId = formData.UserRuleId,
                    RuleId = formData.RuleId
                };
            }
            return itemData;
        }
    }
}