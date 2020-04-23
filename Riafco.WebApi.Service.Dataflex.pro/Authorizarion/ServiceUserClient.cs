using Riafco.Framework.Dataflex.pro.Communication.Messages.Enum;
using Riafco.Framework.Dataflex.pro.Web.Security;
using Riafco.Service.Dataflex.Pro.Authorizarion.Interface;
using Riafco.Service.Dataflex.Pro.Authorizarion.Response;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Assembler;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Dto.Enum;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Interface;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Message;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Request;
using Riafco.WebApi.Service.Dataflex.pro.Authorizarion.Ressource;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.WebApi.Service.Dataflex.pro.Authorizarion
{
    /// <summary>
    /// The User service client class.
    /// </summary>
    public class ServiceUserClient : IServiceUserClient
    {
        #region private attributes

        /// <summary>
        /// The Rule service instance.
        /// </summary>
        private readonly IServiceRule _serviceRule;

        /// <summary>
        /// The User service instance.
        /// </summary>
        private readonly IServiceUser _serviceUser;

        /// <summary>
        /// The UserRule service instance.
        /// </summary>
        private readonly IServiceUserRule _serviceUserRule;

        #endregion

        #region contructor

        /// <summary>
        /// Set the User instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceUser">injected instance</param>
        /// <param name="injectedServiceUserRule">injected instance</param>
        /// <param name="injectedServiceRule">injected instance</param>
        public ServiceUserClient(IServiceUser injectedServiceUser, IServiceUserRule injectedServiceUserRule, IServiceRule injectedServiceRule)
        {
            _serviceUserRule = injectedServiceUserRule;
            _serviceUser = injectedServiceUser;
            _serviceRule = injectedServiceRule;
        }

        #endregion

        #region user methods

        /// <summary>
        /// Create new User
        /// </summary>
        /// <param name="request">user request.</param>
        /// <returns>User message.</returns>
        public UserMessage CreateUser(UserRequest request)
        {
            UserMessage message = new UserMessage();
            try
            {
                //search user by adress mail.
                request.FindUserDto = FindUserDto.UserMail;
                UserResponsePivot response = _serviceUser.FindUsers(request.ToPivot());

                if (response?.UserPivot == null)
                {
                    //generate and set password:
                    string password = ManagePassword.GeneratePassword(5);
                    request.UserDto.UserPassword = password;
                    message = _serviceUser.CreateUser(request.ToPivot()).ToMessage();

                    //add user rule.
                    RuleMessage ruleMessage = _serviceRule.GetAllRules().ToMessage();
                    if (ruleMessage?.RuleDtoList != null)
                    {
                        foreach (var rule in ruleMessage.RuleDtoList.ToList())
                        {
                            UserRuleRequest userRuleRequest = new UserRuleRequest
                            {
                                UserRuleDto = new UserRuleDto
                                {
                                    UserId = message.UserDto.UserId,
                                    UserRuleStatus = false,
                                    RuleId = rule.RuleId
                                }
                            };
                            _serviceUserRule.CreateUserRule(userRuleRequest.ToPivot()).ToMessage();
                        }
                    }
                    else
                    {
                        message.Errors = new List<string> { UserRuleMessageResource.UserRuleNotAdded };
                        message.ErrorMessage = UserRuleMessageResource.UserRuleNotAdded;
                        message.ErrorType = ErrorType.FunctionalError;
                        message.OperationSuccess = false;
                    }
                    message.OperationSuccess = true;
                }
                else
                {
                    message.Errors = new List<string> { UserMessageResource.AlreadyExist };
                    message.ErrorMessage = UserMessageResource.AlreadyExist;
                    message.ErrorType = ErrorType.FunctionalError;
                    message.OperationSuccess = false;
                }
            }
            catch (Exception e)
            {
                message.ErrorType = ErrorType.TechnicalError;
                message.ErrorMessage = e.Message;
            }
            return message;
        }

        /// <summary>
        /// Change User informations.
        /// </summary>
        /// <param name="request">user request.</param>
        /// <returns>User message.</returns>
        public UserMessage UpdateUser(UserRequest request)
        {
            UserMessage message = new UserMessage();
            try
            {
                request.FindUserDto = FindUserDto.UserId;
                UserResponsePivot response = _serviceUser.FindUsers(request.ToPivot());
                if (response?.UserPivot != null)
                {
                    _serviceUser.UpdateUser(request.ToPivot());
                    message.OperationSuccess = true;
                }
                else
                {
                    message.ErrorMessage = UserMessageResource.NotFound;
                    message.OperationSuccess = false;
                }
            }
            catch (Exception e)
            {
                message.ErrorType = ErrorType.TechnicalError;
                message.ErrorMessage = e.Message;
            }
            return message;
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="request">user request.</param>
        /// <returns>User message.</returns>
        public UserMessage DeleteUser(UserRequest request)
        {
            UserMessage message = new UserMessage();
            try
            {
                request.FindUserDto = FindUserDto.UserId;
                UserResponsePivot response = _serviceUser.FindUsers(request.ToPivot());
                if (response?.UserPivot != null)
                {
                    _serviceUser.DeleteUser(request.ToPivot());
                    message.OperationSuccess = true;
                }
                else
                {
                    message.ErrorMessage = UserMessageResource.NotFound;
                    message.OperationSuccess = false;
                }
            }
            catch (Exception e)
            {
                message.ErrorType = ErrorType.TechnicalError;
                message.ErrorMessage = e.Message;
            }
            return message;
        }

        /// <summary>
        /// Get list of User
        /// </summary>
        /// <returns>User message.</returns>
        public UserMessage GetAllUsers()
        {
            UserMessage message = new UserMessage();
            try
            {
                message = _serviceUser.GetAllUsers().ToMessage();
                message.OperationSuccess = true;
            }
            catch (Exception e)
            {
                message.ErrorType = ErrorType.TechnicalError;
                message.ErrorMessage = e.Message;
            }
            return message;
        }

        /// <summary>
        /// Search User
        /// </summary>
        /// <param name="request">user request.</param>
        /// <returns>User message.</returns>
        public UserMessage FindUsers(UserRequest request)
        {
            UserMessage message = new UserMessage();
            try
            {
                message = _serviceUser.FindUsers(request.ToPivot()).ToMessage();
                message.OperationSuccess = true;
            }
            catch (Exception e)
            {
                message.ErrorType = ErrorType.TechnicalError;
                message.ErrorMessage = e.Message;
            }
            return message;
        }
        #endregion
    }
}