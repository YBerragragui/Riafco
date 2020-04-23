using Riafco.Entity.Dataflex.Pro.About;
using Riafco.Service.Dataflex.Pro.About.Assembler;
using Riafco.Service.Dataflex.Pro.About.Data;
using Riafco.Service.Dataflex.Pro.About.Data.Enum;
using Riafco.Service.Dataflex.Pro.About.Interface;
using Riafco.Service.Dataflex.Pro.About.Request;
using Riafco.Service.Dataflex.Pro.About.Response;
using Riafco.Service.Dataflex.Pro.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.Service.Dataflex.Pro.About
{
    /// <summary>
    /// The StepParagraph service class.
    /// </summary>
    public class ServiceStepParagraph : IServiceStepParagraph
    {
        #region PRIVATE ATTRIBUTEs

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
        public ServiceStepParagraph(IUnitOfWork injectedUnitOfWork)
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
        /// Create new StepParagraph.
        /// </summary>
        /// <param name="request">The StepParagraph Request Pivot to add.</param>
        /// <returns>StepParagraph Response Pivot created.</returns>
        public StepParagraphResponsePivot CreateStepParagraph(StepParagraphRequestPivot request)
        {
            if (request?.StepParagraphPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            StepParagraph stepParagraph = request.StepParagraphPivot.ToEntity();
            _unitOfWork.StepParagraphRepository.Insert(stepParagraph);
            _unitOfWork.Save();
            return new StepParagraphResponsePivot
            {
                StepParagraphPivot = stepParagraph.ToPivot()
            };
        }

        /// <summary>
        /// Change StepParagraph values.
        /// </summary>
        /// <param name="request">The StepParagraph Request Pivot to change.</param>
        public void UpdateStepParagraph(StepParagraphRequestPivot request)
        {
            if (request?.StepParagraphPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            StepParagraph stepParagraph = _unitOfWork.StepParagraphRepository.GetById(request.StepParagraphPivot.ParagraphId);
            stepParagraph.StepId = request.StepParagraphPivot.StepId;
            _unitOfWork.Save();
        }

        /// <summary>
        /// Remove StepParagraph.
        /// </summary>
        /// <param name="request">The StepParagraph Request Pivot to remove.</param>
        public void DeleteStepParagraph(StepParagraphRequestPivot request)
        {
            if (request?.StepParagraphPivot == null) { throw new ArgumentNullException(nameof(request)); }
            StepParagraph stepParagraph = _unitOfWork.StepParagraphRepository.GetById(request.StepParagraphPivot.ParagraphId);
            _unitOfWork.StepParagraphRepository.Delete(stepParagraph);
            _unitOfWork.Save();
        }

        /// <summary>
        /// Get the list of the StepParagraph.
        /// </summary>
        /// <returns>StepParagraph Response Pivot response.</returns>
        public StepParagraphResponsePivot GetAllStepParagraphs()
        {
            return new StepParagraphResponsePivot
            {
                StepParagraphPivotList =
                    _unitOfWork.StepParagraphRepository.Get(null, null, "Step").ToList().ToPivotList()
            };
        }

        /// <summary>
        /// Search StepParagraph by id.
        /// </summary>
        /// <param name="request">The StepParagraph Request Pivot to retrive.</param>
        /// <returns>StepParagraph Response Pivot response.</returns>
        public StepParagraphResponsePivot FindStepParagraphs(StepParagraphRequestPivot request)
        {
            if (request?.StepParagraphPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            List<StepParagraphPivot> results = new List<StepParagraphPivot>();
            StepParagraphPivot result = new StepParagraphPivot();
            switch (request.FindStepParagraphPivot)
            {
                case FindStepParagraphPivot.StepParagraphId:
                    result = _unitOfWork.StepParagraphRepository.GetById(request.StepParagraphPivot.ParagraphId)?.ToPivot();
                    break;
                case FindStepParagraphPivot.StepId:
                    results = _unitOfWork.StepParagraphRepository.Get(p => p.StepId == request.StepParagraphPivot.StepId)?.ToList().ToPivotList();
                    break;
            }
            return new StepParagraphResponsePivot
            {
                StepParagraphPivotList = results,
                StepParagraphPivot = result
            };
        }
        #endregion

    }
}