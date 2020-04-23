using Riafco.Framework.Dataflex.pro.Communication.Messages.Enum;
using Riafco.Framework.Dataflex.pro.Web.Validation;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Dto.Enum;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Interface;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Message;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Request;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Ressource;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Riafco.WebApi.Dataflex.pro.Controllers.Authorizarion
{
    /// <summary>
    /// The User web api controller.
    /// </summary>
    [RoutePrefix("api/Users")]
    public class UserController : ApiController
    {
        #region private attributes

        /// <summary>
        /// The User service client instance.
        /// </summary>
        private readonly IServiceUserClient _serviceUserClient;

        /// <summary>
        /// The UserRule service client instance.
        /// </summary>
        private readonly IServiceUserRuleClient _serviceUserRuleClient;

        #endregion

        #region constructor

        /// <summary>
        /// Set the IServiceUserClient instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceUserClient">injected instance</param>
        /// <param name="injectedServiceUserRuleClient">injected instance</param>
        public UserController(IServiceUserClient injectedServiceUserClient, IServiceUserRuleClient injectedServiceUserRuleClient)
        {
            _serviceUserRuleClient = injectedServiceUserRuleClient;
            _serviceUserClient = injectedServiceUserClient;
        }

        #endregion

        #region public user methods

        /// <summary>
        /// Create new User
        /// </summary>
        /// <returns>User message.</returns>
        [Route("CreateUser")]
        public IHttpActionResult CreateUser(UserRequest request)
        {
            List<string> errors = ValidateCreateUser(request);
            UserMessage message = new UserMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = UserMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceUserClient.CreateUser(request);
                return Json(message);
            }
            return Json(message);
        }

        /// <summary>
        /// Change User informations.
        /// </summary>
        /// <returns>User message.</returns>
        [Route("UpdateUser")]
        public IHttpActionResult UpdateUser(UserRequest request)
        {
            List<string> errors = ValidateUpdateUser(request);
            UserMessage message = new UserMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = UserMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceUserClient.UpdateUser(request);
                return Json(message);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <returns>User message.</returns>
        [Route("RemoveUser")]
        public IHttpActionResult DeleteUser(int userId)
        {
            UserRequest request = new UserRequest { UserDto = new UserDto { UserId = userId } };
            List<string> errors = ValidateDeleteUser(request);
            UserMessage message = new UserMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = UserMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceUserClient.DeleteUser(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of User
        /// </summary>
        /// <returns>User message.</returns>
        [Route("GetUsers")]
        public IHttpActionResult GetAllUsers()
        {
            UserMessage message = _serviceUserClient.GetAllUsers();
            return Json(message);
        }

        /// <summary>
        /// Find User
        /// </summary>
        /// <returns>User message.</returns>
        [Route("FindUsers")]
        public IHttpActionResult FindUsers(UserRequest request)
        {
            List<string> errors = ValidateFindUsers(request);
            UserMessage message = new UserMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = UserMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceUserClient.FindUsers(request);
            }
            return Json(message);
        }

        #endregion

        #region public user rule methods
        /// <summary>
        /// Create new UserRule
        /// </summary>
        /// <returns>UserRule message.</returns>
        [Route("CreateUserRule")]
        public IHttpActionResult CreateUserRule(UserRuleRequest request)
        {
            List<string> errors = ValidateCreateUserRule(request);
            UserRuleMessage message = new UserRuleMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = UserMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceUserRuleClient.CreateUserRule(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change UserRule informations.
        /// </summary>
        /// <returns>UserRule message.</returns>
        [Route("UpdateUserRule")]
        public IHttpActionResult UpdateUserRule(UserRuleRequest request)
        {
            List<string> errors = ValidateUpdateUserRule(request);
            UserRuleMessage message = new UserRuleMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = UserMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceUserRuleClient.UpdateUserRule(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Change UserRule informations.
        /// </summary>
        /// <returns>UserRule message.</returns>
        [Route("UpdateUserRuleRange")]
        public IHttpActionResult UpdateUserRuleRange(UserRuleRequest request)
        {
            List<string> errors = ValidateUpdateUserRuleRangeRange(request);
            UserRuleMessage message = new UserRuleMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = UserMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceUserRuleClient.UpdateUserRuleRange(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Delete UserRule
        /// </summary>
        /// <returns>UserRule message.</returns>
        [Route("RemoveUserRule")]
        public IHttpActionResult DeleteUserRule(int userRuleId)
        {
            UserRuleRequest request = new UserRuleRequest { UserRuleDto = new UserRuleDto() { UserRuleId = userRuleId } };
            List<string> errors = ValidateDeleteUserRule(request);
            UserRuleMessage message = new UserRuleMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = UserMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceUserRuleClient.DeleteUserRule(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of UserRule
        /// </summary>
        /// <returns>UserRule message.</returns>
        [Route("GetUserRules")]
        public IHttpActionResult GetAllUserRule()
        {
            UserRuleMessage message = _serviceUserRuleClient.GetAllUserRules();
            return Json(message);
        }

        /// <summary>
        /// Find UserRule
        /// </summary>
        /// <returns>UserRule message.</returns>
        [Route("FindUserRules")]
        public IHttpActionResult FindUserRules(UserRuleRequest request)
        {
            List<string> errors = ValidateFindUserRule(request);
            UserRuleMessage message = new UserRuleMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = UserMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceUserRuleClient.FindUserRules(request);
            }
            return Json(message);
        }


        #endregion

        #region validate user methodes

        /// <summary>
        /// Validate create user.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validaton list</returns>
        private List<string> ValidateCreateUser(UserRequest request)
        {
            var errors = new List<string>();
            if (request?.UserDto == null)
            {
                errors.Add(UserMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<UserDto>.ValidateAttributes("UserName", request.UserDto.UserName));
                errors.AddRange(GenericValidationAttribute<UserDto>.ValidateAttributes("UserPicture", request.UserDto.UserPicture.ToString()));
                errors.AddRange(GenericValidationAttribute<UserDto>.ValidateAttributes("UserMail", request.UserDto.UserMail));
            }
            return errors;
        }

        /// <summary>
        /// Validate create user.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validaton list</returns>
        private List<string> ValidateUpdateUser(UserRequest request)
        {
            var errors = new List<string>();
            if (request?.UserDto == null)
            {
                errors.Add(UserMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<UserDto>.ValidateAttributes("UserId", request.UserDto.UserId.ToString()));
                errors.AddRange(GenericValidationAttribute<UserDto>.ValidateAttributes("UserName", request.UserDto.UserName));
                errors.AddRange(GenericValidationAttribute<UserDto>.ValidateAttributes("UserMail", request.UserDto.UserMail));
            }
            return errors;
        }

        /// <summary>
        /// errors validation list.
        /// </summary>
        /// <param name="request">request to validate.</param>
        /// <returns></returns>
        private List<string> ValidateDeleteUser(UserRequest request)
        {
            var errors = new List<string>();
            if (request?.UserDto == null)
            {
                errors.Add(UserMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<UserDto>.ValidateAttributes("UserId", request.UserDto.UserId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validate finding user.
        /// </summary>
        /// <param name="request">t-he request to validate.</param>
        /// <returns>validation errors.</returns>
        private List<string> ValidateFindUsers(UserRequest request)
        {
            var errors = new List<string>();
            if (request?.UserDto == null)
            {
                errors.Add(UserMessageResource.NullRequest);
            }
            return errors;
        }
        #endregion

        #region private validation user rule methods

        /// <summary>
        /// create user rule validation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateUserRule(UserRuleRequest request)
        {
            var errors = new List<string>();
            if (request?.UserRuleDto == null)
            {
                errors.Add(UserRuleMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<UserRuleDto>.ValidateAttributes("UserRuleStatus", request.UserRuleDto.UserRuleStatus.ToString()));
                errors.AddRange(GenericValidationAttribute<UserRuleDto>.ValidateAttributes("UserId", request.UserRuleDto.UserId.ToString()));
                errors.AddRange(GenericValidationAttribute<UserRuleDto>.ValidateAttributes("RuleId", request.UserRuleDto.RuleId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// create user rule validation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateUserRule(UserRuleRequest request)
        {
            var errors = new List<string>();
            if (request?.UserRuleDto == null)
            {
                errors.Add(UserRuleMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<UserRuleDto>.ValidateAttributes("UserRuleStatus", request.UserRuleDto.UserRuleStatus.ToString()));
                errors.AddRange(GenericValidationAttribute<UserRuleDto>.ValidateAttributes("UserRuleId", request.UserRuleDto.UserRuleId.ToString()));
                errors.AddRange(GenericValidationAttribute<UserRuleDto>.ValidateAttributes("UserId", request.UserRuleDto.UserId.ToString()));
                errors.AddRange(GenericValidationAttribute<UserRuleDto>.ValidateAttributes("RuleId", request.UserRuleDto.RuleId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// create user rule validation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateUpdateUserRuleRangeRange(UserRuleRequest request)
        {
            var errors = new List<string>();
            if (request?.UserRuleDtoList == null)
            {
                errors.Add(UserRuleMessageResource.NullRequest);
            }
            else
            {
                foreach (var userRule in request.UserRuleDtoList.ToList())
                {
                    errors.AddRange(GenericValidationAttribute<UserRuleDto>.ValidateAttributes("UserRuleStatus", userRule.UserRuleStatus.ToString()));
                    errors.AddRange(GenericValidationAttribute<UserRuleDto>.ValidateAttributes("UserRuleId", userRule.UserRuleId.ToString()));
                    errors.AddRange(GenericValidationAttribute<UserRuleDto>.ValidateAttributes("UserId", userRule.UserId.ToString()));
                    errors.AddRange(GenericValidationAttribute<UserRuleDto>.ValidateAttributes("RuleId", userRule.RuleId.ToString()));
                }
            }
            return errors;
        }

        /// <summary>
        /// create user rule validation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateDeleteUserRule(UserRuleRequest request)
        {
            var errors = new List<string>();
            if (request?.UserRuleDto == null)
            {
                errors.Add(UserRuleMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<UserRuleDto>.ValidateAttributes("UserRuleId", request.UserRuleDto.UserRuleId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// create user rule validation.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateFindUserRule(UserRuleRequest request)
        {
            var errors = new List<string>();
            if (request?.UserRuleDto == null)
            {
                errors.Add(UserRuleMessageResource.NullRequest);
            }
            else
            {
                switch (request.FindUserRuleDto)
                {
                    case FindUserRuleDto.UserRuleId:
                        errors.AddRange(GenericValidationAttribute<UserRuleDto>.ValidateAttributes("UserRuleId", request.UserRuleDto.UserRuleId.ToString()));
                        break;
                    case FindUserRuleDto.UserId:
                        errors.AddRange(GenericValidationAttribute<UserRuleDto>.ValidateAttributes("UserId", request.UserRuleDto.UserId.ToString()));
                        break;
                }
            }
            return errors;
        }
        #endregion
    }
}