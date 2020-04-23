using Riafco.Entity.Dataflex.Pro.Occurrences;
using Riafco.Service.Dataflex.Pro.Occurrences.Assembler;
using Riafco.Service.Dataflex.Pro.Occurrences.Data;
using Riafco.Service.Dataflex.Pro.Occurrences.Data.Enum;
using Riafco.Service.Dataflex.Pro.Occurrences.Interface;
using Riafco.Service.Dataflex.Pro.Occurrences.Request;
using Riafco.Service.Dataflex.Pro.Occurrences.Response;
using Riafco.Service.Dataflex.Pro.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.Service.Dataflex.Pro.Occurrences
{
    /// <summary>
    /// The Occurrence service class.
    /// </summary>
    public class ServiceOccurrence : IServiceOccurrence
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
        public ServiceOccurrence(IUnitOfWork injectedUnitOfWork)
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
        /// Create new Occurrence.
        /// </summary>
        /// <param name="request">The Occurrence Request Pivot to add.</param>
        /// <returns>Occurrence Response Pivot created.</returns>
        public OccurrenceResponsePivot CreateOccurrence(OccurrenceRequestPivot request)
        {
            if (request?.OccurrencePivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            Occurrence occurrence = request.OccurrencePivot.ToEntity();
            _unitOfWork.OccurrenceRepository.Insert(occurrence);
            _unitOfWork.Save();
            return new OccurrenceResponsePivot
            {
                OccurrencePivot = occurrence.ToPivot()
            };
        }

        /// <summary>
        /// Change Occurrence values.
        /// </summary>
        /// <param name="request">The Occurrence Request Pivot to change.</param>
        public void UpdateOccurrence(OccurrenceRequestPivot request)
        {
            if (request?.OccurrencePivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Occurrence occurrence = _unitOfWork.OccurrenceRepository.GetById(request.OccurrencePivot.OccurrenceId);
            occurrence.OccurrenceStartDate = request.OccurrencePivot.OccurrenceStartDate;
            occurrence.OccurrenceEndDate = request.OccurrencePivot.OccurrenceEndDate;
            occurrence.OccurrenceLink = request.OccurrencePivot.OccurrenceLink;
            _unitOfWork.Save();
        }

        /// <summary>
        /// Remove Occurrence.
        /// </summary>
        /// <param name="request">The Occurrence Request Pivot to remove.</param>
        public void DeleteOccurrence(OccurrenceRequestPivot request)
        {
            if (request?.OccurrencePivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            Occurrence occurrence = _unitOfWork.OccurrenceRepository.GetById(request.OccurrencePivot.OccurrenceId);
            _unitOfWork.OccurrenceRepository.Delete(occurrence);
            _unitOfWork.Save();
        }

        /// <summary>
        /// Get the list of the Occurrence.
        /// </summary>
        /// <returns>Occurrence Response Pivot response.</returns>
        public OccurrenceResponsePivot GetAllOccurrences()
        {
            return new OccurrenceResponsePivot
            {
                OccurrencePivotList = _unitOfWork.OccurrenceRepository.Get().ToList().ToPivotList()
            };
        }

        /// <summary>
        /// Search Occurrence by id.
        /// </summary>
        /// <param name="request">The Occurrence Request Pivot to retrive.</param>
        /// <returns>Occurrence Response Pivot response.</returns>
        public OccurrenceResponsePivot FindOccurrences(OccurrenceRequestPivot request)
        {
            if (request?.OccurrencePivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            List<OccurrencePivot> results = new List<OccurrencePivot>();
            OccurrencePivot result = new OccurrencePivot();
            switch (request.FindOccurrencePivot)
            {
                case FindOccurrencePivot.OccurrenceId:
                    result = _unitOfWork.OccurrenceRepository.GetById(request.OccurrencePivot.OccurrenceId).ToPivot();
                    break;
            }
            return new OccurrenceResponsePivot
            {
                OccurrencePivotList = results,
                OccurrencePivot = result
            };
        }
        #endregion
    }
}