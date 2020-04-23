using Riafco.Entity.Dataflex.Pro.Ressources;
using Riafco.Service.Dataflex.Pro.Ressources.Assembler;
using Riafco.Service.Dataflex.Pro.Ressources.Data;
using Riafco.Service.Dataflex.Pro.Ressources.Data.Enum;
using Riafco.Service.Dataflex.Pro.Ressources.Interface;
using Riafco.Service.Dataflex.Pro.Ressources.Request;
using Riafco.Service.Dataflex.Pro.Ressources.Response;
using Riafco.Service.Dataflex.Pro.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.Service.Dataflex.Pro.Ressources
{
    /// <summary>
    /// The PublicationTranslation service class.
    /// </summary>
    public class ServicePublicationTranslation : IServicePublicationTranslation
    {
        #region private attribes

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
        public ServicePublicationTranslation(IUnitOfWork injectedUnitOfWork)
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
        /// Create new PublicationTranslation.
        /// </summary>
        /// <param name="request">The PublicationTranslation Request Pivot to add.</param>
        /// <returns>PublicationTranslation Response Pivot created.</returns>
        public PublicationTranslationResponsePivot CreatePublicationTranslation(
            PublicationTranslationRequestPivot request)
        {
            if (request?.PublicationTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            PublicationTranslation publicationTranslation = request.PublicationTranslationPivot.ToEntity();
            _unitOfWork.PublicationTranslationRepository.Insert(publicationTranslation);
            _unitOfWork.Save();
            return new PublicationTranslationResponsePivot
            {
                PublicationTranslationPivot = publicationTranslation.ToPivot()
            };
        }

        /// <summary>
        /// Create new PublicationTranslation.
        /// </summary>
        /// <param name="request">The PublicationTranslation Request Pivot to add.</param>
        /// <returns>PublicationTranslation Response Pivot created.</returns>
        public PublicationTranslationResponsePivot CreatePublicationTranslationRange(
            PublicationTranslationRequestPivot request)
        {
            if (request?.PublicationTranslationPivotList == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            List<PublicationTranslation> publicationTranslationList =
                request.PublicationTranslationPivotList.ToEntityList();
            _unitOfWork.PublicationTranslationRepository.Insert(publicationTranslationList);
            _unitOfWork.Save();
            return new PublicationTranslationResponsePivot
            {
                PublicationTranslationPivotList = publicationTranslationList.ToPivotList()
            };
        }

        /// <summary>
        /// Change PublicationTranslation values.
        /// </summary>
        /// <param name="request">The PublicationTranslation Request Pivot to change.</param>
        public void UpdatePublicationTranslation(PublicationTranslationRequestPivot request)
        {
            if (request?.PublicationTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            PublicationTranslation publicationTranslation =
                _unitOfWork.PublicationTranslationRepository.GetById(request.PublicationTranslationPivot
                    .PublicationTranslationId);
            publicationTranslation.PublicationSummary = request.PublicationTranslationPivot.PublicationSummary;
            publicationTranslation.PublicationTitle = request.PublicationTranslationPivot.PublicationTitle;
            if (!string.IsNullOrEmpty(request.PublicationTranslationPivot.PublicationFile))
            {
                publicationTranslation.PublicationFile = request.PublicationTranslationPivot.PublicationFile;
            }
            _unitOfWork.Save();
        }

        /// <summary>
        /// Change PublicationTranslation values.
        /// </summary>
        /// <param name="request">The PublicationTranslation Request Pivot to change.</param>
        public void UpdatePublicationTranslationRange(PublicationTranslationRequestPivot request)
        {
            if (request?.PublicationTranslationPivotList == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            foreach (var publicationTranslationPivot in request.PublicationTranslationPivotList)
            {
                PublicationTranslation publicationTranslation =
                    _unitOfWork.PublicationTranslationRepository.GetById(publicationTranslationPivot
                        .PublicationTranslationId);

                if (!string.IsNullOrEmpty(publicationTranslationPivot.PublicationFile))
                {
                    publicationTranslation.PublicationFile = publicationTranslationPivot.PublicationFile;
                }

                publicationTranslation.PublicationSummary = publicationTranslationPivot.PublicationSummary;
                publicationTranslation.PublicationTitle = publicationTranslationPivot.PublicationTitle;
                _unitOfWork.Save();
            }
        }

        /// <summary>
        /// Remove PublicationTranslation.
        /// </summary>
        /// <param name="request">The PublicationTranslation Request Pivot to remove.</param>
        public void DeletePublicationTranslation(PublicationTranslationRequestPivot request)
        {
            if (request?.PublicationTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            PublicationTranslation publicationTranslation =
                _unitOfWork.PublicationTranslationRepository.GetById(request.PublicationTranslationPivot
                    .PublicationTranslationId);
            _unitOfWork.PublicationTranslationRepository.Delete(publicationTranslation);
            _unitOfWork.Save();
        }

        /// <summary>
        /// Get the list of the PublicationTranslation.
        /// </summary>
        /// <returns>PublicationTranslation Response Pivot response.</returns>
        public PublicationTranslationResponsePivot GetAllPublicationTranslations()
        {
            return new PublicationTranslationResponsePivot
            {
                PublicationTranslationPivotList = _unitOfWork.PublicationTranslationRepository
                    .Get(null, null, "Publication,Language").ToList().ToPivotList()
            };
        }

        /// <summary>
        /// Search PublicationTranslation by id.
        /// </summary>
        /// <param name="request">The PublicationTranslation Request Pivot to retrive.</param>
        /// <returns>PublicationTranslation Response Pivot response.</returns>
        public PublicationTranslationResponsePivot FindPublicationTranslations(PublicationTranslationRequestPivot request)
        {
            if (request?.PublicationTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            List<PublicationTranslationPivot> results = new List<PublicationTranslationPivot>();
            PublicationTranslationPivot result = new PublicationTranslationPivot();
            switch (request.FindPublicationTranslationPivot)
            {
                case FindPublicationTranslationPivot.PublicationTranslationId:
                    result = _unitOfWork.PublicationTranslationRepository
                        .Get(
                            p => p.PublicationTranslationId ==
                                 request.PublicationTranslationPivot.PublicationTranslationId, null,
                            "Publication,Language")?.FirstOrDefault().ToPivot();
                    break;
                case FindPublicationTranslationPivot.PublicationId:
                    results = _unitOfWork.PublicationTranslationRepository
                        .Get(p => p.PublicationId == request.PublicationTranslationPivot.PublicationId, null,
                            "Publication,Language")?.ToList().ToPivotList();
                    break;
            }
            return new PublicationTranslationResponsePivot
            {
                PublicationTranslationPivotList = results,
                PublicationTranslationPivot = result
            };
        }
        #endregion
    }
}