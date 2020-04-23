using Admin.Riafco.Dataflex.Pro.Models.Authorization.ItemData;
using Admin.Riafco.Dataflex.Pro.Models.Authorization.ItemData.Enum;
using Admin.Riafco.Dataflex.Pro.Models.Authorization.RequestData;
using Admin.Riafco.Dataflex.Pro.Models.Authorization.ResultData;
using Riafco.Framework.Dataflex.pro.Web.WebApi;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Admin.Riafco.Dataflex.Pro.Authorization
{
    /// <summary>
    /// The AuthorizeUserAttribute class.
    /// </summary>
    public static class AuthorizeUserAttribute
    {
        /// <summary>
        /// Authorize user.
        /// </summary>
        /// <returns>true if the user connected</returns>
        public static async Task<bool> Authorize(string role)
        {
            bool isAuthorized = HttpContext.Current.User.Identity.IsAuthenticated;
            if (!isAuthorized) return false;
            bool existUser = await IsUserExiste();
            if (!existUser) return false;
            List<UserRuleItemData> userRules = await GetUserRules();
            if (userRules != null)
            {
                return userRules.Any(r => r?.Rule?.RulePrefix == role) && userRules.First(r => r?.Rule?.RulePrefix == role).UserRuleStatus;
            }
            return false;
        }

        /// <summary>
        /// Authorize user.
        /// </summary>
        /// <returns>true if the user connected</returns>
        public static async Task<bool> AuthorizeSettings()
        {
            bool isAuthorized = HttpContext.Current.User.Identity.IsAuthenticated;
            if (!isAuthorized) return false;
            int userId = int.Parse(HttpContext.Current.User.Identity.Name);
            bool existUser = await IsActiveUserExiste(userId);
            return existUser;
        }

        /// <summary>
        /// Return true if the user exist.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        private static async Task<bool> IsActiveUserExiste(int userId)
        {
            UserRequestData findRequest = new UserRequestData
            {
                UserDto = new UserItemData { UserId = userId },
                FindUserDto = FindUserItemData.UserId
            };

            UserResultData result = await WebApiClient.PostFormJsonAsync<UserRequestData, UserResultData>(Constant.WebApiControllerUser, Constant.WebApiFindUser, findRequest);
            return (result != null && result.OperationSuccess && result.UserDto != null && result.UserDto.UserStatut);
        }

        /// <summary>
        /// Return true if the user exist.
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> IsUserExiste()
        {
            int userId = int.Parse(HttpContext.Current.User.Identity.Name);
            UserRequestData findRequest = new UserRequestData
            {
                UserDto = new UserItemData { UserId = userId },
                FindUserDto = FindUserItemData.UserId
            };

            UserResultData result = await WebApiClient.PostFormJsonAsync<UserRequestData, UserResultData>(Constant.WebApiControllerUser, Constant.WebApiFindUser, findRequest);
            return (result != null && result.OperationSuccess && result.UserDto != null);
        }

        /// <summary>
        /// Get the userRule of the user.
        /// </summary>
        /// <returns></returns>
        private static async Task<List<UserRuleItemData>> GetUserRules()
        {
            int userId = int.Parse(HttpContext.Current.User.Identity.Name);
            UserRuleRequestData findUserRuleRequest = new UserRuleRequestData
            {
                UserRuleDto = new UserRuleItemData { UserId = userId },
                FindUserRuleDto = FindUserRuleItemData.UserId
            };

            UserRuleResultData userRuleResultData = await WebApiClient.PostFormJsonAsync<UserRuleRequestData, UserRuleResultData>(Constant.WebApiControllerUser, Constant.WebApiFindUserRules, findUserRuleRequest);

            if (userRuleResultData != null && userRuleResultData.OperationSuccess && userRuleResultData.UserRuleDtoList != null)
            {
                return userRuleResultData.UserRuleDtoList;
            }
            return new List<UserRuleItemData>();
        }
    }
}