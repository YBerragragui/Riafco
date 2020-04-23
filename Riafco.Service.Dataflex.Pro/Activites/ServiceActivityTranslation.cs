using Riafco.Entity.Dataflex.Pro.Activites;
using Riafco.Service.Dataflex.Pro.Activites.Assembler;
using Riafco.Service.Dataflex.Pro.Activites.Data;
using Riafco.Service.Dataflex.Pro.Activites.Data.Enum;
using Riafco.Service.Dataflex.Pro.Activites.Interface;
using Riafco.Service.Dataflex.Pro.Activites.Request;
using Riafco.Service.Dataflex.Pro.Activites.Response;
using Riafco.Service.Dataflex.Pro.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.Service.Dataflex.Pro.Activites
{
    /// <summary>
    /// The ActivityTranslation service class.
    /// </summary>
    public class ServiceActivityTranslation : IServiceActivityTranslation
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
        public ServiceActivityTranslation(IUnitOfWork injectedUnitOfWork)
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
        /// Create new ActivityTranslation.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>ActivityTranslation Response Pivot added.</returns>
        public ActivityTranslationResponsePivot CreateActivityTranslation(ActivityTranslationRequestPivot request)
        {
            if (request?.ActivityTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            ActivityTranslation activityTranslation = request.ActivityTranslationPivot.ToEntity();
            _unitOfWork.ActivityTranslationRepository.Insert(activityTranslation);
            _unitOfWork.Save();
            return new ActivityTranslationResponsePivot
            {
                ActivityTranslationPivot = activityTranslation.ToPivot()
            };
        }

        /// <summary>
        ///  Create new ActivityTranslation.
        /// </summary>
        /// <param name="request">the request to add</param>
        /// <returns>the items added</returns>
        public ActivityTranslationResponsePivot CreateActivityTranslationRange(ActivityTranslationRequestPivot request)
        {
            if (request?.ActivityTranslationPivotList == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            List<ActivityTranslation> activityTranslationList = request.ActivityTranslationPivotList.ToEntityList();
            _unitOfWork.ActivityTranslationRepository.Insert(activityTranslationList);
            _unitOfWork.Save();

            return new ActivityTranslationResponsePivot
            {
                ActivityTranslationPivotList = activityTranslationList.ToPivotList()
            };
        }

        /// <summary>
        /// Change ActivityTranslation values.
        /// </summary>
        /// <param name="request">The ActivityTranslation Request Pivot to change.</param>
        public void UpdateActivityTranslation(ActivityTranslationRequestPivot request)
        {
            if (request?.ActivityTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            ActivityTranslation activityTranslation = _unitOfWork.ActivityTranslationRepository.GetById(request.ActivityTranslationPivot.TranslationId);
            activityTranslation.ActivityIntroduction = request.ActivityTranslationPivot.ActivityIntroduction;
            activityTranslation.ActivityDescription = request.ActivityTranslationPivot.ActivityDescription;
            activityTranslation.ActivityTitle = request.ActivityTranslationPivot.ActivityTitle;
            _unitOfWork.Save();
        }

        /// <summary>
        /// update list of activity translation
        /// </summary>
        /// <param name="request">the request update</param>
        public void UpdateActivityTranslationRange(ActivityTranslationRequestPivot request)
        {
            if (request?.ActivityTranslationPivotList == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            foreach (var translationPivot in request.ActivityTranslationPivotList.ToList())
            {
                ActivityTranslation activityTranslation = _unitOfWork.ActivityTranslationRepository.GetById(translationPivot.TranslationId);
                activityTranslation.ActivityIntroduction = translationPivot.ActivityIntroduction;
                activityTranslation.ActivityDescription = translationPivot.ActivityDescription;
                activityTranslation.ActivityTitle = translationPivot.ActivityTitle;
                _unitOfWork.Save();
            }
        }

        /// <summary>
        /// Remove ActivityTranslation.
        /// </summary>
        /// <param name="request">The ActivityTranslation Request Pivot to remove.</param>
        public void DeleteActivityTranslation(ActivityTranslationRequestPivot request)
        {
            if (request?.ActivityTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            ActivityTranslation activityTranslation = _unitOfWork.ActivityTranslationRepository.GetById(request.ActivityTranslationPivot.TranslationId);
            _unitOfWork.ActivityTranslationRepository.Delete(activityTranslation);
            _unitOfWork.Save();
        }

        /// <summary>
        /// Get the list of the ActivityTranslation.
        /// </summary>
        /// <returns>ActivityTranslation Response Pivot response.</returns>
        public ActivityTranslationResponsePivot GetAllActivityTranslations()
        {
            return new ActivityTranslationResponsePivot
            {
                ActivityTranslationPivotList = _unitOfWork.ActivityTranslationRepository.Get(null, null, "Activity,Language").ToList().ToPivotList()
            };
        }

        /// <summary>
        /// Search ActivityTranslation by id.
        /// </summary>
        /// <param name="request">The ActivityTranslation Request Pivot to retrive.</param>
        /// <returns>ActivityTranslation Response Pivot response.</returns>
        public ActivityTranslationResponsePivot FindActivityTranslations(ActivityTranslationRequestPivot request)
        {
            if (request?.ActivityTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            List<ActivityTranslationPivot> results = new List<ActivityTranslationPivot>();
            ActivityTranslationPivot result = new ActivityTranslationPivot();
            switch (request.FindActivityTranslationPivot)
            {
                case FindActivityTranslationPivot.ActivityTranslationId:
                    result = _unitOfWork.ActivityTranslationRepository.Get(c => c.TranslationId == request.ActivityTranslationPivot.TranslationId, null, "Activity,Language")?.FirstOrDefault().ToPivot();
                    break;
                case FindActivityTranslationPivot.ActivityId:
                    results = _unitOfWork.ActivityTranslationRepository.Get(c => c.ActivityId == request.ActivityTranslationPivot.ActivityId, null, "Activity,Language")?.ToList().ToPivotList();
                    break;
            }
            return new ActivityTranslationResponsePivot
            {
                ActivityTranslationPivotList = results,
                ActivityTranslationPivot = result
            };
        }
        #endregion
    }
}