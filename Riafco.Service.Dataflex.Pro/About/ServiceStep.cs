using System;
using System.Collections.Generic;
using System.Linq;
using Riafco.Service.Dataflex.Pro.About.Request;
using Riafco.Service.Dataflex.Pro.About.Response;
using Riafco.Service.Dataflex.Pro.About.Interface;
using Riafco.Service.Dataflex.Pro.UnitOfWork;
using Riafco.Service.Dataflex.Pro.About.Assembler;
using Riafco.Entity.Dataflex.Pro.About;
using Riafco.Service.Dataflex.Pro.About.Data;
using Riafco.Service.Dataflex.Pro.About.Data.Enum;

namespace Riafco.Service.Dataflex.Pro.About
{
    /// <summary>
    /// The ServiceStep class.
    /// </summary>
    public class ServiceStep : IServiceStep
    {
        #region PRIVATE ATRIBUTTES

        /// <summary>
        /// The UnitOfWork instance.
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region contructors
        /// <summary>
        /// Constructor to create instance of the UnitOfWork.
        /// </summary>
        /// <param name="injectedUnitOfWork">the injected UnitOfWork to instance UnitOfWork attribute.</param>
        public ServiceStep(IUnitOfWork injectedUnitOfWork)
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
        /// Create new Step.
        /// </summary>
        /// <param name="request">The Step Request Pivot to add.</param>
        /// <returns>Step Response Pivot created.</returns>
        public StepResponsePivot CreateStep(StepRequestPivot request)
        {
            if (request?.StepPivot == null) { throw new ArgumentNullException(nameof(request)); }
            Step step = request.StepPivot.ToEntity();
            _unitOfWork.StepRepository.Insert(step);
            _unitOfWork.Save();
            return new StepResponsePivot { StepPivot = step.ToPivot() };
        }

        /// <summary>
        /// Change Step values.
        /// </summary>
        /// <param name="request">The Step Request Pivot to change.</param>
        public void UpdateStep(StepRequestPivot request)
        {
            if (request?.StepPivot == null) { throw new ArgumentNullException(nameof(request)); }
            Step step = _unitOfWork.StepRepository.GetById(request.StepPivot.StepId);
            step.StepDate = request.StepPivot.StepDate;
            _unitOfWork.Save();
        }

        /// <summary>
        /// Remove Step.
        /// </summary>
        /// <param name="request">The Step Request Pivot to remove.</param>
        public void DeleteStep(StepRequestPivot request)
        {
            if (request?.StepPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Step step = _unitOfWork.StepRepository.GetById(request.StepPivot.StepId);
            _unitOfWork.StepRepository.Delete(step);
            _unitOfWork.Save();
        }

        /// <summary>
        /// Get the list of the Step.
        /// </summary>
        /// <returns>Step Response Pivot response.</returns>
        public StepResponsePivot GetAllSteps()
        {
            return new StepResponsePivot
            {
                StepPivotList = _unitOfWork.StepRepository.Get().ToList().ToPivotList()
            };
        }

        /// <summary>
        /// Search Step by id.
        /// </summary>
        /// <param name="request">The Step Request Pivot to retrive.</param>
        /// <returns>Step Response Pivot response.</returns>
        public StepResponsePivot FindSteps(StepRequestPivot request)
        {
            if (request?.StepPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            List<StepPivot> results = new List<StepPivot>();
            StepPivot result = new StepPivot();
            switch (request.FindStepPivot)
            {
                case FindStepPivot.StepId:
                    result = _unitOfWork.StepRepository.GetById(request.StepPivot.StepId)?.ToPivot();
                    break;
            }
            return new StepResponsePivot
            {
                StepPivotList = results,
                StepPivot = result
            };
        }
        #endregion
    }
}