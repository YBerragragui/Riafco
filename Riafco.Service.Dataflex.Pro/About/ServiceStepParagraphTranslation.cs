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
    /// The StepParagraphTranslation service class.
    /// </summary>
    public class ServiceStepParagraphTranslation : IServiceStepParagraphTranslation
    {
        #region private Atribute

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
        public ServiceStepParagraphTranslation(IUnitOfWork injectedUnitOfWork)
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
        /// Create new StepParagraphTranslation.
        /// </summary>
        /// <param name="request">The StepParagraphTranslation Request Pivot to add.</param>
        /// <returns>StepParagraphTranslation Response Pivot created.</returns>
        public StepParagraphTranslationResponsePivot CreateStepParagraphTranslation(
            StepParagraphTranslationRequestPivot request)
        {
            if (request?.StepParagraphTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            StepParagraphTranslation stepParagraphTranslation = request.StepParagraphTranslationPivot.ToEntity();
            _unitOfWork.StepParagraphTranslationRepository.Insert(stepParagraphTranslation);
            _unitOfWork.Save();
            return new StepParagraphTranslationResponsePivot
            {
                StepParagraphTranslationPivot = stepParagraphTranslation.ToPivot()
            };
        }

        /// <summary>
        /// Adding StepParagraphTranslation list
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public StepParagraphTranslationResponsePivot CreateStepParagraphTranslationRange(StepParagraphTranslationRequestPivot request)
        {
            if (request?.StepParagraphTranslationPivotList == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            List<StepParagraphTranslation> stepParagraphTranslationList = request.StepParagraphTranslationPivotList.ToEntityList();
            _unitOfWork.StepParagraphTranslationRepository.Insert(stepParagraphTranslationList);
            _unitOfWork.Save();
            return new StepParagraphTranslationResponsePivot
            {
                StepParagraphTranslationPivotList = stepParagraphTranslationList.ToPivotList()
            };
        }

        /// <summary>
        /// Change StepParagraphTranslation values.
        /// </summary>
        /// <param name="request">The StepParagraphTranslation Request Pivot to change.</param>
        public void UpdateStepParagraphTranslation(StepParagraphTranslationRequestPivot request)
        {
            if (request?.StepParagraphTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            StepParagraphTranslation stepParagraphTranslation =
                _unitOfWork.StepParagraphTranslationRepository.GetById(request.StepParagraphTranslationPivot
                    .TranslationId);
            stepParagraphTranslation.ParagraphTitle = request.StepParagraphTranslationPivot.ParagraphTitle;
            stepParagraphTranslation.ParagraphDescription = request.StepParagraphTranslationPivot.ParagraphDescription;
            _unitOfWork.Save();
        }

        /// <summary>
        /// Update step paragraph translation list.
        /// </summary>
        /// <param name="request"></param>
        public void UpdateStepParagraphTranslationRange(StepParagraphTranslationRequestPivot request)
        {
            if (request?.StepParagraphTranslationPivotList == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            foreach (var translationPivot in request.StepParagraphTranslationPivotList)
            {
                StepParagraphTranslation stepParagraphTranslation =
                    _unitOfWork.StepParagraphTranslationRepository.GetById(translationPivot
                        .TranslationId);
                stepParagraphTranslation.ParagraphTitle = translationPivot.ParagraphTitle;
                stepParagraphTranslation.ParagraphDescription = translationPivot.ParagraphDescription;
                _unitOfWork.Save();
            }
        }

        /// <summary>
        /// Remove StepParagraphTranslation.
        /// </summary>
        /// <param name="request">The StepParagraphTranslation Request Pivot to remove.</param>
        public void DeleteStepParagraphTranslation(StepParagraphTranslationRequestPivot request)
        {
            if (request?.StepParagraphTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            StepParagraphTranslation stepParagraphTranslation =
                _unitOfWork.StepParagraphTranslationRepository.GetById(request.StepParagraphTranslationPivot
                    .TranslationId);
            _unitOfWork.StepParagraphTranslationRepository.Delete(stepParagraphTranslation);
            _unitOfWork.Save();
        }

        /// <summary>
        /// Get the list of the StepParagraphTranslation.
        /// </summary>
        /// <returns>StepParagraphTranslation Response Pivot response.</returns>
        public StepParagraphTranslationResponsePivot GetAllStepParagraphTranslations()
        {
            return new StepParagraphTranslationResponsePivot
            {
                StepParagraphTranslationPivotList = _unitOfWork.StepParagraphTranslationRepository.Get().ToList()
                    .ToPivotList()
            };
        }

        /// <summary>
        /// Search StepParagraphTranslation by id.
        /// </summary>
        /// <param name="request">The StepParagraphTranslation Request Pivot to retrive.</param>
        /// <returns>StepParagraphTranslation Response Pivot response.</returns>
        public StepParagraphTranslationResponsePivot FindStepParagraphTranslations(
            StepParagraphTranslationRequestPivot request)
        {
            if (request?.StepParagraphTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            List<StepParagraphTranslationPivot> results = new List<StepParagraphTranslationPivot>();
            StepParagraphTranslationPivot result = new StepParagraphTranslationPivot();
            switch (request.FindStepParagraphTranslationPivot)
            {
                case FindStepParagraphTranslationPivot.StepParagraphTranslationId:
                    result = _unitOfWork.StepParagraphTranslationRepository
                        .GetById(request.StepParagraphTranslationPivot.TranslationId)?.ToPivot();
                    break;
                case FindStepParagraphTranslationPivot.StepParagraphId:
                    results = _unitOfWork.StepParagraphTranslationRepository.Get(t=>t.ParagraphId == request.StepParagraphTranslationPivot.ParagraphId)?.ToList().ToPivotList();
                    break;
            }
            return new StepParagraphTranslationResponsePivot
            {
                StepParagraphTranslationPivotList = results,
                StepParagraphTranslationPivot = result
            };
        }

        #endregion
    }
}