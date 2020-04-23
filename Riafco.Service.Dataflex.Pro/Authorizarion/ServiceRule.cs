using Riafco.Entity.Dataflex.Pro.Authorizarion;
using Riafco.Service.Dataflex.Pro.Authorizarion.Assembler;
using Riafco.Service.Dataflex.Pro.Authorizarion.Data;
using Riafco.Service.Dataflex.Pro.Authorizarion.Data.Enum;
using Riafco.Service.Dataflex.Pro.Authorizarion.Interface;
using Riafco.Service.Dataflex.Pro.Authorizarion.Request;
using Riafco.Service.Dataflex.Pro.Authorizarion.Response;
using Riafco.Service.Dataflex.Pro.UnitOfWork;
using System;
using System.Linq;

namespace Riafco.Service.Dataflex.Pro.Authorizarion
{
    /// <summary>
    /// The Rule service class.
    /// </summary>
    public class ServiceRule : IServiceRule
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
        public ServiceRule(IUnitOfWork injectedUnitOfWork)
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
        /// Create new Rule.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Rule Response Pivot added.</returns>
        public RuleResponsePivot CreateRule(RuleRequestPivot request)
        {
            if (request?.RulePivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Rule rule = request.RulePivot.ToEntity();
            _unitOfWork.RuleRepository.Insert(rule);
            _unitOfWork.Save();

            return new RuleResponsePivot
            {
                RulePivot = rule.ToPivot()
            };
        }

        /// <summary>
        /// Change Rule values.
        /// </summary>
        /// <param name="request">The Rule Request Pivot to change.</param>
        public void UpdateRule(RuleRequestPivot request)
        {
            if (request?.RulePivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Rule rule = _unitOfWork.RuleRepository.GetById(request.RulePivot.RuleId);
            rule.RulePrefix = request.RulePivot.RulePrefix;
            rule.RuleName = request.RulePivot.RuleName;
            _unitOfWork.Save();
        }

        /// <summary>
        /// Remove Rule.
        /// </summary>
        /// <param name="request">The Rule Request Pivot to remove.</param>
        public void DeleteRule(RuleRequestPivot request)
        {
            if (request?.RulePivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Rule rule = _unitOfWork.RuleRepository.GetById(request.RulePivot.RuleId);
            _unitOfWork.RuleRepository.Delete(rule);
            _unitOfWork.Save();
        }

        /// <summary>
        /// Get the list of the Rule.
        /// </summary>
        /// <returns>Rule Response Pivot response.</returns>
        public RuleResponsePivot GetAllRules()
        {
            return new RuleResponsePivot
            {
                RulePivotList = _unitOfWork.RuleRepository.Get().ToList().ToPivotList()
            };
        }

        /// <summary>
        /// Search Rule by id.
        /// </summary>
        /// <param name="request">The Rule Request Pivot to retrive.</param>
        /// <returns>Rule Response Pivot response.</returns>
        public RuleResponsePivot FindRules(RuleRequestPivot request)
        {
            if (request?.RulePivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            RulePivot result = new RulePivot();
            switch (request.FindRulePivot)
            {
                case FindRulePivot.RuleId:
                    result = _unitOfWork.RuleRepository.Get(c => c.RuleId == request.RulePivot.RuleId)?.FirstOrDefault().ToPivot();
                    break;
            }
            return new RuleResponsePivot
            {
                RulePivot = result
            };
        }
        #endregion
    }
}