using System;
using System.Collections.Generic;
using System.Linq;
using Riafco.Service.Dataflex.Pro.Ressources.Request;
using Riafco.Service.Dataflex.Pro.Ressources.Response;
using Riafco.Service.Dataflex.Pro.Ressources.Interface;
using Riafco.Service.Dataflex.Pro.UnitOfWork;
using Riafco.Service.Dataflex.Pro.Ressources.Assembler;
using Riafco.Entity.Dataflex.Pro.Ressources;
using Riafco.Service.Dataflex.Pro.Ressources.Data;
using Riafco.Service.Dataflex.Pro.Ressources.Data.Enum;

namespace Riafco.Service.Dataflex.Pro.Ressources
{
    /// <summary>
    /// The Publication service class.
    /// </summary>
    public class ServicePublication : IServicePublication
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
        public ServicePublication(IUnitOfWork injectedUnitOfWork)
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
        /// Create new Publication.
        /// </summary>
        /// <param name="request">The Publication Request Pivot to add.</param>
        /// <returns>Publication Response Pivot created.</returns>
        public PublicationResponsePivot CreatePublication(PublicationRequestPivot request)
        {
            if (request?.PublicationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Publication publication = request.PublicationPivot.ToEntity();
            _unitOfWork.PublicationRepository.Insert(publication);
            _unitOfWork.Save();
            return new PublicationResponsePivot
            {
                PublicationPivot = publication.ToPivot()
            };
        }

        /// <summary>
        /// Change Publication values.
        /// </summary>
        /// <param name="request">The Publication Request Pivot to change.</param>
        public void UpdatePublication(PublicationRequestPivot request)
        {
            if (request?.PublicationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Publication publication = _unitOfWork.PublicationRepository.GetById(request.PublicationPivot.PublicationId);
            publication.PublicationDate = request.PublicationPivot.PublicationDate;
            publication.AuthorId = request.PublicationPivot.AuthorId;
            publication.AreaId = request.PublicationPivot.AreaId;
            if (request.PublicationPivot.PublicationImage != null)
            {
                publication.PublicationImage = request.PublicationPivot.PublicationImage;
            }
            _unitOfWork.Save();
        }

        /// <summary>
        /// Remove Publication.
        /// </summary>
        /// <param name="request">The Publication Request Pivot to remove.</param>
        public void DeletePublication(PublicationRequestPivot request)
        {
            if (request?.PublicationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Publication publication = _unitOfWork.PublicationRepository.Get(p => p.PublicationId == request.PublicationPivot.PublicationId)?.FirstOrDefault();
            _unitOfWork.PublicationRepository.Delete(publication);
            _unitOfWork.Save();
        }

        /// <summary>
        /// Get the list of the Publication.
        /// </summary>
        /// <returns>Publication Response Pivot response.</returns>
        public PublicationResponsePivot GetAllPublications()
        {
            return new PublicationResponsePivot
            {
                PublicationPivotList = _unitOfWork.PublicationRepository.Get(null, null, "Area,Author").ToList().ToPivotList()
            };
        }

        /// <summary>
        /// Search Publication by id.
        /// </summary>
        /// <param name="request">The Publication Request Pivot to retrive.</param>
        /// <returns>Publication Response Pivot response.</returns>
        public PublicationResponsePivot FindPublications(PublicationRequestPivot request)
        {
            if (request?.PublicationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            List<PublicationPivot> results = new List<PublicationPivot>();
            PublicationPivot result = new PublicationPivot();
            switch (request.FindPublicationPivot)
            {
                case FindPublicationPivot.PublicationId:
                    result = _unitOfWork.PublicationRepository.Get(p => p.PublicationId == request.PublicationPivot.PublicationId, null, "Area,Author")?.FirstOrDefault().ToPivot();
                    break;
            }
            return new PublicationResponsePivot
            {
                PublicationPivotList = results,
                PublicationPivot = result
            };
        }
        #endregion
    }
}