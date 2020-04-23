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
    /// The ActivityFileTranslation service class.
    /// </summary>
    public class ServiceActivityFileTranslation : IServiceActivityFileTranslation
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
        public ServiceActivityFileTranslation(IUnitOfWork injectedUnitOfWork)
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
        /// Create new ActivityFileTranslation.
        /// </summary>
        /// <param name="request">The ActivityFileTranslation Request Pivot to add.</param>
        /// <returns>ActivityFileTranslation Response Pivot created.</returns>
        public ActivityFileTranslationResponsePivot CreateActivityFileTranslation(ActivityFileTranslationRequestPivot request)
        {
            if (request?.ActivityFileTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            ActivityFileTranslation activityFileTranslation = request.ActivityFileTranslationPivot.ToEntity();
            _unitOfWork.ActivityFileTranslationRepository.Insert(activityFileTranslation);
            _unitOfWork.Save();
            return new ActivityFileTranslationResponsePivot
            {
                ActivityFileTranslationPivot = activityFileTranslation.ToPivot()
            };
        }


        /// <summary>
        /// Create new ActivityFileTranslation.
        /// </summary>
        /// <param name="request">The ActivityFileTranslation Request Pivot to add.</param>
        /// <returns>ActivityFileTranslation Response Pivot created.</returns>
        public ActivityFileTranslationResponsePivot CreateActivityFileTranslationRange(ActivityFileTranslationRequestPivot request)
        {
            if (request?.ActivityFileTranslationPivotList == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            List<ActivityFileTranslation> activityFileTranslationList = request.ActivityFileTranslationPivotList.ToEntityList();
            _unitOfWork.ActivityFileTranslationRepository.Insert(activityFileTranslationList);
            _unitOfWork.Save();

            return new ActivityFileTranslationResponsePivot
            {
                ActivityFileTranslationPivotList = activityFileTranslationList.ToPivotList()
            };
        }

        /// <summary>
        /// Change ActivityFileTranslation values.
        /// </summary>
        /// <param name="request">The ActivityFileTranslation Request Pivot to change.</param>
        public void UpdateActivityFileTranslation(ActivityFileTranslationRequestPivot request)
        {
            if (request?.ActivityFileTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            ActivityFileTranslation activityFileTranslation = _unitOfWork.ActivityFileTranslationRepository.GetById(request.ActivityFileTranslationPivot.TranslationId);
            if (request.ActivityFileTranslationPivot.ActivityFileSource != null)
            {
                activityFileTranslation.ActivityFileSource = request.ActivityFileTranslationPivot.ActivityFileSource;
            }
            activityFileTranslation.ActivityFileText = request.ActivityFileTranslationPivot.ActivityFileText;
            _unitOfWork.Save();
        }

        /// <summary>
        /// Change ActivityFileTranslation values.
        /// </summary>
        /// <param name="request">The ActivityFileTranslation Request Pivot to change.</param>
        public void UpdateActivityFileTranslationRange(ActivityFileTranslationRequestPivot request)
        {
            if (request?.ActivityFileTranslationPivotList == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            foreach (var translation in request.ActivityFileTranslationPivotList)
            {
                ActivityFileTranslation activityFileTranslation = _unitOfWork.ActivityFileTranslationRepository.GetById(translation.TranslationId);
                if (translation.ActivityFileSource != null)
                {
                    activityFileTranslation.ActivityFileSource = translation.ActivityFileSource;
                }
                activityFileTranslation.ActivityFileText = translation.ActivityFileText;
                _unitOfWork.Save();
            }
        }

        /// <summary>
        /// Remove ActivityFileTranslation.
        /// </summary>
        /// <param name="request">The ActivityFileTranslation Request Pivot to remove.</param>
        public void DeleteActivityFileTranslation(ActivityFileTranslationRequestPivot request)
        {
            if (request?.ActivityFileTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            ActivityFileTranslation activityFileTranslation = _unitOfWork.ActivityFileTranslationRepository.GetById(request.ActivityFileTranslationPivot.TranslationId);
            _unitOfWork.ActivityFileTranslationRepository.Delete(activityFileTranslation);
            _unitOfWork.Save();
        }

        /// <summary>
        /// Get the list of the ActivityFileTranslation.
        /// </summary>
        /// <returns>ActivityFileTranslation Response Pivot response.</returns>
        public ActivityFileTranslationResponsePivot GetAllActivityFileTranslations()
        {
            return new ActivityFileTranslationResponsePivot
            {
                ActivityFileTranslationPivotList = _unitOfWork.ActivityFileTranslationRepository.Get(null, null, "Language,ActivityFile").ToList().ToPivotList()
            };
        }

        /// <summary>
        /// Search ActivityFileTranslation by id.
        /// </summary>
        /// <param name="request">The ActivityFileTranslation Request Pivot to retrive.</param>
        /// <returns>ActivityFileTranslation Response Pivot response.</returns>
        public ActivityFileTranslationResponsePivot FindActivityFileTranslations(ActivityFileTranslationRequestPivot request)
        {
            if (request?.ActivityFileTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            List<ActivityFileTranslationPivot> results = new List<ActivityFileTranslationPivot>();
            ActivityFileTranslationPivot result = new ActivityFileTranslationPivot();
            switch (request.FindActivityFileTranslationPivot)
            {
                case FindActivityFileTranslationPivot.ActivityFileTranslationId:
                    result = _unitOfWork.ActivityFileTranslationRepository.Get(f => f.TranslationId == request.ActivityFileTranslationPivot.TranslationId, null, "Language,ActivityFile")?.FirstOrDefault().ToPivot();
                    break;
                case FindActivityFileTranslationPivot.ActivityFileId:
                    results = _unitOfWork.ActivityFileTranslationRepository.Get(f => f.ActivityFileId == request.ActivityFileTranslationPivot.ActivityFileId, null, "Language,ActivityFile")?.ToList().ToPivotList();
                    break;
            }
            return new ActivityFileTranslationResponsePivot
            {
                ActivityFileTranslationPivotList = results,
                ActivityFileTranslationPivot = result
            };
        }
        #endregion
    }
}