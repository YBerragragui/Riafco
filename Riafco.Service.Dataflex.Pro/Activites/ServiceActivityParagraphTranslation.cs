using System;
using System.Collections.Generic;
using System.Linq;
using Riafco.Service.Dataflex.Pro.Activites.Request;
using Riafco.Service.Dataflex.Pro.Activites.Response;
using Riafco.Service.Dataflex.Pro.Activites.Interface;
using Riafco.Service.Dataflex.Pro.UnitOfWork;
using Riafco.Service.Dataflex.Pro.Activites.Assembler;
using Riafco.Entity.Dataflex.Pro.Activites;
using Riafco.Service.Dataflex.Pro.Activites.Data;
using Riafco.Service.Dataflex.Pro.Activites.Data.Enum;

namespace Riafco.Service.Dataflex.Pro.Activites
{
    /// <summary>
    /// The ActivityParagraphTraslation service class.
    /// </summary>
    public class ServiceActivityParagraphTranslation : IServiceActivityParagraphTranslation
    {
        #region private attributes

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
        public ServiceActivityParagraphTranslation(IUnitOfWork injectedUnitOfWork)
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
        /// Create new ActivityParagraphTraslation.
        /// </summary>
        /// <param name="request">The ActivityParagraphTraslation Request Pivot to add.</param>
        /// <returns>ActivityParagraphTraslation Response Pivot added.</returns>
        public ActivityParagraphTranslationResponsePivot CreateActivityParagraphTranslation(ActivityParagraphTranslationRequestPivot request)
        {
            if (request?.ActivityParagraphTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            ActivityParagraphTranslation activityParagraphTraslation = request.ActivityParagraphTranslationPivot.ToEntity();
            _unitOfWork.ActivityParagraphTraslationRepository.Insert(activityParagraphTraslation);
            _unitOfWork.Save();

            return new ActivityParagraphTranslationResponsePivot
            {
                ActivityParagraphTranslationPivot = activityParagraphTraslation.ToPivot()
            };
        }

        /// <summary>
        /// Create new ActivityParagraphTraslation.
        /// </summary>
        /// <param name="request">The ActivityParagraphTraslation Request Pivot to add.</param>
        /// <returns>ActivityParagraphTraslation Response Pivot added.</returns>
        public ActivityParagraphTranslationResponsePivot CreateActivityParagraphTranslationRange(ActivityParagraphTranslationRequestPivot request)
        {
            if (request?.ActivityParagraphTranslationPivotList == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            List<ActivityParagraphTranslation> activityParagraphTraslationList = request.ActivityParagraphTranslationPivotList.ToEntityList();
            _unitOfWork.ActivityParagraphTraslationRepository.Insert(activityParagraphTraslationList);
            _unitOfWork.Save();
            return new ActivityParagraphTranslationResponsePivot
            {
                ActivityParagraphTranslationPivotList = activityParagraphTraslationList.ToPivotList()
            };
        }

        /// <summary>
        /// Change ActivityParagraphTraslation values.
        /// </summary>
        /// <param name="request">The ActivityParagraphTraslation Request Pivot to change.</param>
        public void UpdateActivityParagraphTranslation(ActivityParagraphTranslationRequestPivot request)
        {
            if (request?.ActivityParagraphTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            ActivityParagraphTranslation activityTranslation = _unitOfWork.ActivityParagraphTraslationRepository.GetById(request.ActivityParagraphTranslationPivot.TranslationId);
            activityTranslation.ParagraphDescription = request.ActivityParagraphTranslationPivot.ParagraphDescription;
            activityTranslation.ParagraphTitle = request.ActivityParagraphTranslationPivot.ParagraphTitle;
            _unitOfWork.Save();
        }

        /// <summary>
        /// Change ActivityParagraphTraslation values Range.
        /// </summary>
        /// <param name="request">The ActivityParagraphTraslation Request Pivot to change.</param>
        public void UpdateActivityParagraphTranslationRange(ActivityParagraphTranslationRequestPivot request)
        {
            if (request?.ActivityParagraphTranslationPivotList == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            foreach (var translation in request.ActivityParagraphTranslationPivotList.ToList())
            {
                ActivityParagraphTranslation activityTranslation = _unitOfWork.ActivityParagraphTraslationRepository.GetById(translation.TranslationId);
                activityTranslation.ParagraphDescription = translation.ParagraphDescription;
                activityTranslation.ParagraphTitle = translation.ParagraphTitle;
                _unitOfWork.Save();
            }
        }

        /// <summary>
        /// Remove ActivityParagraphTraslation.
        /// </summary>
        /// <param name="request">The ActivityParagraphTraslation Request Pivot to remove.</param>
        public void DeleteActivityParagraphTranslation(ActivityParagraphTranslationRequestPivot request)
        {
            if (request?.ActivityParagraphTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            ActivityParagraphTranslation activityParagraphTraslation = _unitOfWork.ActivityParagraphTraslationRepository.GetById(request.ActivityParagraphTranslationPivot.TranslationId);
            _unitOfWork.ActivityParagraphTraslationRepository.Delete(activityParagraphTraslation);
            _unitOfWork.Save();
        }

        /// <summary>
        /// Get the list of the ActivityParagraphTraslation.
        /// </summary>
        /// <returns>ActivityParagraphTraslation Response Pivot response.</returns>
        public ActivityParagraphTranslationResponsePivot GetAllActivityParagraphTraslations()
        {
            return new ActivityParagraphTranslationResponsePivot
            {
                ActivityParagraphTranslationPivotList = _unitOfWork.ActivityParagraphTraslationRepository.Get().ToList().ToPivotList()
            };
        }

        /// <summary>
        /// Search ActivityParagraphTraslation by id.
        /// </summary>
        /// <param name="request">The ActivityParagraphTraslation Request Pivot to retrive.</param>
        /// <returns>ActivityParagraphTraslation Response Pivot response.</returns>
        public ActivityParagraphTranslationResponsePivot FindActivityParagraphTranslations(ActivityParagraphTranslationRequestPivot request)
        {
            if (request?.ActivityParagraphTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            List<ActivityParagraphTranslationPivot> results = new List<ActivityParagraphTranslationPivot>();
            ActivityParagraphTranslationPivot result = new ActivityParagraphTranslationPivot();
            switch (request.FindActivityParagraphTranslationPivot)
            {
                case FindActivityParagraphTranslationPivot.ActivityParagraphTranslationId:
                    result = _unitOfWork.ActivityParagraphTraslationRepository.Get(p => p.ParagraphId == request.ActivityParagraphTranslationPivot.TranslationId, null, "ActivityParagraph,Language")?.FirstOrDefault()?.ToPivot();
                    break;
                case FindActivityParagraphTranslationPivot.ActivityParagraphId:
                    results = _unitOfWork.ActivityParagraphTraslationRepository.Get(p => p.ParagraphId == request.ActivityParagraphTranslationPivot.ParagraphId, null, "ActivityParagraph,Language")?.ToList().ToPivotList();
                    break;
            }
            return new ActivityParagraphTranslationResponsePivot
            {
                ActivityParagraphTranslationPivotList = results,
                ActivityParagraphTranslationPivot = result
            };
        }
        #endregion
    }
}