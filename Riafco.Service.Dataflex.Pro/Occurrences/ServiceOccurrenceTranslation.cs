using System;
using System.Collections.Generic;
using System.Linq;
using Riafco.Service.Dataflex.Pro.Occurrences.Request;
using Riafco.Service.Dataflex.Pro.Occurrences.Response;
using Riafco.Service.Dataflex.Pro.Occurrences.Interface;
using Riafco.Service.Dataflex.Pro.UnitOfWork;
using Riafco.Service.Dataflex.Pro.Occurrences.Assembler;
using Riafco.Entity.Dataflex.Pro.Occurrences;
using Riafco.Service.Dataflex.Pro.Occurrences.Data;
using Riafco.Service.Dataflex.Pro.Occurrences.Data.Enum;

namespace Riafco.Service.Dataflex.Pro.Occurrences
{
    /// <summary>
    /// The OccurrenceTranslation service class.
    /// </summary>
    public class ServiceOccurrenceTranslation : IServiceOccurrenceTranslation
    {
        #region private properties
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
        public ServiceOccurrenceTranslation(IUnitOfWork injectedUnitOfWork)
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
        /// Create new OccurrenceTranslation.
        /// </summary>
        /// <param name="request">The OccurrenceTranslation Request Pivot to add.</param>
        /// <returns>OccurrenceTranslation Response Pivot created.</returns>
        public OccurrenceTranslationResponsePivot CreateOccurrenceTranslation(OccurrenceTranslationRequestPivot request)
        {
            if (request?.OccurrenceTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            OccurrenceTranslation occurrenceTranslation = request.OccurrenceTranslationPivot.ToEntity();
            _unitOfWork.OccurrenceTranslationRepository.Insert(occurrenceTranslation);
            _unitOfWork.Save();
            return new OccurrenceTranslationResponsePivot
            {
                OccurrenceTranslationPivot = occurrenceTranslation.ToPivot()
            };
        }

        /// <summary>
        /// Create new OccurrenceTranslation.
        /// </summary>
        /// <param name="request">The OccurrenceTranslation Request Pivot to add.</param>
        /// <returns>OccurrenceTranslation Response Pivot created.</returns>
        public OccurrenceTranslationResponsePivot CreateOccurrenceTranslationRange(OccurrenceTranslationRequestPivot request)
        {
            if (request?.OccurrenceTranslationPivotList == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            List<OccurrenceTranslation> occurrenceTranslationList = request.OccurrenceTranslationPivotList.ToEntityList();
            _unitOfWork.OccurrenceTranslationRepository.Insert(occurrenceTranslationList);
            _unitOfWork.Save();
            return new OccurrenceTranslationResponsePivot()
            {
                OccurrenceTranslationPivotList = occurrenceTranslationList.ToPivotList()
            };
        }

        /// <summary>
        /// Change OccurrenceTranslation values.
        /// </summary>
        /// <param name="request">The OccurrenceTranslation Request Pivot to change.</param>
        public void UpdateOccurrenceTranslation(OccurrenceTranslationRequestPivot request)
        {
            if (request?.OccurrenceTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            OccurrenceTranslation occurrenceTranslation = _unitOfWork.OccurrenceTranslationRepository.GetById(request.OccurrenceTranslationPivot.TranslationId);
            occurrenceTranslation.OccurrenceTitle = request.OccurrenceTranslationPivot.OccurrenceTitle;
            occurrenceTranslation.OccurrenceDescription = request.OccurrenceTranslationPivot.OccurrenceDescription;
            _unitOfWork.Save();

        }


        /// <summary>
        /// Change OccurrenceTranslation values.
        /// </summary>
        /// <param name="request">The OccurrenceTranslation Request Pivot to change.</param>
        public void UpdateOccurrenceTranslationRange(OccurrenceTranslationRequestPivot request)
        {
            if (request?.OccurrenceTranslationPivotList == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            foreach (var item in request.OccurrenceTranslationPivotList)
            {
                OccurrenceTranslation occurrenceTranslation = _unitOfWork.OccurrenceTranslationRepository.GetById(item.TranslationId);
                occurrenceTranslation.OccurrenceTitle = item.OccurrenceTitle;
                occurrenceTranslation.OccurrenceDescription = item.OccurrenceDescription;
                _unitOfWork.Save();
            }
        }

        /// <summary>
        /// Remove OccurrenceTranslation.
        /// </summary>
        /// <param name="request">The OccurrenceTranslation Request Pivot to remove.</param>
        public void DeleteOccurrenceTranslation(OccurrenceTranslationRequestPivot request)
        {
            if (request?.OccurrenceTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            OccurrenceTranslation occurrenceTranslation = _unitOfWork.OccurrenceTranslationRepository.GetById(request.OccurrenceTranslationPivot.TranslationId);
            _unitOfWork.OccurrenceTranslationRepository.Delete(occurrenceTranslation);
            _unitOfWork.Save();

        }

        /// <summary>
        /// Get the list of the OccurrenceTranslation.
        /// </summary>
        /// <returns>OccurrenceTranslation Response Pivot response.</returns>
        public OccurrenceTranslationResponsePivot GetAllOccurrenceTranslations()
        {
            return new OccurrenceTranslationResponsePivot()
            {
                OccurrenceTranslationPivotList = _unitOfWork.OccurrenceTranslationRepository.Get().ToList().ToPivotList()
            };

        }

        /// <summary>
        /// Search OccurrenceTranslation by id.
        /// </summary>
        /// <param name="request">The OccurrenceTranslation Request Pivot to retrive.</param>
        /// <returns>OccurrenceTranslation Response Pivot response.</returns>
        public OccurrenceTranslationResponsePivot FindOccurrenceTranslations(OccurrenceTranslationRequestPivot request)
        {
            if (request?.OccurrenceTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            List<OccurrenceTranslationPivot> results = new List<OccurrenceTranslationPivot>();
            OccurrenceTranslationPivot result = new OccurrenceTranslationPivot();
            switch (request.FindOccurrenceTranslationPivot)
            {
                case FindOccurrenceTranslationPivot.OccurrenceTranslationId:
                    result = _unitOfWork.OccurrenceTranslationRepository.GetById(request.OccurrenceTranslationPivot.TranslationId)?.ToPivot();
                    break;
                case FindOccurrenceTranslationPivot.OccurrenceId:
                    results = _unitOfWork.OccurrenceTranslationRepository.Get(o => o.OccurrenceId == request.OccurrenceTranslationPivot.OccurrenceId, null, "Occurrence,Language")?.ToList().ToPivotList();
                    break;
            }
            return new OccurrenceTranslationResponsePivot()
            {
                OccurrenceTranslationPivotList = results,
                OccurrenceTranslationPivot = result
            };
        }
        #endregion

    }
}