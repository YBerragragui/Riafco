using Riafco.Entity.Dataflex.Pro.Authorizarion;
using Riafco.Service.Dataflex.Pro.Authorizarion.Assembler;
using Riafco.Service.Dataflex.Pro.Authorizarion.Data;
using Riafco.Service.Dataflex.Pro.Authorizarion.Data.Enum;
using Riafco.Service.Dataflex.Pro.Authorizarion.Interface;
using Riafco.Service.Dataflex.Pro.Authorizarion.Request;
using Riafco.Service.Dataflex.Pro.Authorizarion.Response;
using Riafco.Service.Dataflex.Pro.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.Service.Dataflex.Pro.Authorizarion
{
    /// <summary>
    /// The UserRule service class.
    /// </summary>
    public class ServiceUserRule : IServiceUserRule
    {
        #region private attributes

        /// <summary>
        /// The UnitOfWork instance.
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region contructors
        /// <summary>
        /// Constructor to create instance of the _unitOfWork.
        /// </summary>
        /// <param name="injectedUnitOfWork">the injected UnitOfWork to instance UnitOfWork attribute.</param>
        public ServiceUserRule(IUnitOfWork injectedUnitOfWork)
        {
            if (injectedUnitOfWork == null)
            {
                throw new ArgumentNullException(nameof(injectedUnitOfWork));
            }
            _unitOfWork = injectedUnitOfWork;
        }
        #endregion

        #region public methods
        /// <summary>
        /// Create new UserRule.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>UserRule Response Pivot added.</returns>
        public UserRuleResponsePivot CreateUserRule(UserRuleRequestPivot request)
        {
            if (request?.UserRulePivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            UserRule userRule = request.UserRulePivot.ToEntity();
            _unitOfWork.UserRuleRepository.Insert(userRule);
            _unitOfWork.Save();

            return new UserRuleResponsePivot
            {
                UserRulePivot = userRule.ToPivot()
            };
        }

        /// <summary>
        /// Change UserRule values.
        /// </summary>
        /// <param name="request">The UserRule Request Pivot to change.</param>
        public void UpdateUserRule(UserRuleRequestPivot request)
        {
            if (request?.UserRulePivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            UserRule userRule = _unitOfWork.UserRuleRepository.GetById(request.UserRulePivot.UserRuleId);
            userRule.UserRuleStatus = request.UserRulePivot.UserRuleStatus;
            _unitOfWork.Save();
        }

        /// <summary>
        /// Change UserRule values.
        /// </summary>
        /// <param name="request">The UserRule Request Pivot to change.</param>
        public void UpdateUserRuleRange(UserRuleRequestPivot request)
        {
            if (request?.UserRulePivotList == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            foreach (var itemUserRule in request.UserRulePivotList.ToList())
            {
                UserRule userRule = _unitOfWork.UserRuleRepository.GetById(itemUserRule.UserRuleId);
                userRule.UserRuleStatus = itemUserRule.UserRuleStatus;
                _unitOfWork.Save();
            }
        }

        /// <summary>
        /// Remove UserRule.
        /// </summary>
        /// <param name="request">The UserRule Request Pivot to remove.</param>
        public void DeleteUserRule(UserRuleRequestPivot request)
        {
            if (request?.UserRulePivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            UserRule userRule = _unitOfWork.UserRuleRepository.GetById(request.UserRulePivot.UserRuleId);
            _unitOfWork.UserRuleRepository.GetById(userRule);
            _unitOfWork.Save();
        }

        /// <summary>
        /// Get the list of the UserRule.
        /// </summary>
        /// <returns>UserRule Response Pivot response.</returns>
        public UserRuleResponsePivot GetAllUserRules()
        {
            return new UserRuleResponsePivot
            {
                UserRulePivotList = _unitOfWork.UserRuleRepository.Get().ToList().ToPivotList()
            };
        }

        /// <summary>
        /// Search UserRule by id.
        /// </summary>
        /// <param name="request">The UserRule Request Pivot to retrive.</param>
        /// <returns>UserRule Response Pivot response.</returns>
        public UserRuleResponsePivot FindUserRules(UserRuleRequestPivot request)
        {
            if (request?.UserRulePivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            List<UserRulePivot> results = new List<UserRulePivot>();
            UserRulePivot result = new UserRulePivot();
            switch (request.FindUserRulePivot)
            {
                case FindUserRulePivot.UserRuleId:
                    result = _unitOfWork.UserRuleRepository.Get(c => c.UserRuleId == request.UserRulePivot.UserRuleId, null, "User,Rule")?.FirstOrDefault().ToPivot();
                    break;
                case FindUserRulePivot.UserId:
                    results = _unitOfWork.UserRuleRepository.Get(c => c.UserId == request.UserRulePivot.UserId, null, "User,Rule")?.ToList().ToPivotList();
                    break;
            }
            return new UserRuleResponsePivot
            {
                UserRulePivotList = results,
                UserRulePivot = result
            };
        }
        #endregion
    }
}