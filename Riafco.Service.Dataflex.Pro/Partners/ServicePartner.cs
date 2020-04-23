using System;
using System.Collections.Generic;
using System.Linq;
using Riafco.Service.Dataflex.Pro.Partners.Request;
using Riafco.Service.Dataflex.Pro.Partners.Response;
using Riafco.Service.Dataflex.Pro.Partners.Interface;
using Riafco.Service.Dataflex.Pro.UnitOfWork;
using Riafco.Service.Dataflex.Pro.Partners.Assembler;
using Riafco.Entity.Dataflex.Pro.Partners;
using Riafco.Service.Dataflex.Pro.Partners.Data;
using Riafco.Service.Dataflex.Pro.Partners.Data.Enum;

namespace Riafco.Service.Dataflex.Pro.Partners
{
    /// <summary>
    /// The Partner service class.
    /// </summary>
    public class ServicePartner : IServicePartner
    {
        /// <summary>
        /// The UnitOfWork instance.
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        #region contructors
        /// <summary>
        /// Constructor to create instance of the UnitOfWork.
        /// </summary>
        /// <param name="injectedUnitOfWork">the injected UnitOfWork to instance UnitOfWork attribute.</param>
        public ServicePartner(IUnitOfWork injectedUnitOfWork)
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
        /// Create new Partner.
        /// </summary>
        /// <param name="request">The Partner Request Pivot to add.</param>
        /// <returns>Partner Response Pivot created.</returns>
        public PartnerResponsePivot CreatePartner(PartnerRequestPivot request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            Partner partner = request.PartnerPivot.ToEntity();
            List<Partner> partnersList = _unitOfWork.PartnerRepository.Get().ToList();
            partner.PartnerPosition = partnersList.Count + 1;
            _unitOfWork.PartnerRepository.Insert(partner);
            _unitOfWork.Save();
            return new PartnerResponsePivot()
            {
                PartnerPivot = partner.ToPivot()
            };
        }

        /// <summary>
        /// Change Partner values.
        /// </summary>
        /// <param name="request">The Partner Request Pivot to change.</param>
        public void UpdatePartner(PartnerRequestPivot request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            Partner partner = _unitOfWork.PartnerRepository.GetById(request.PartnerPivot.PartnerId);
            if (request.PartnerPivot.PartnerImage != null)
            {
                partner.PartnerImage = request.PartnerPivot.PartnerImage;
            }
            partner.PartnerLink = request.PartnerPivot.PartnerLink;
            partner.PartnerName = request.PartnerPivot.PartnerName;
            partner.PartnerPosition = request.PartnerPivot.PartnerPosition;
            _unitOfWork.Save();
            UpdatePartnersPositions(partner.PartnerId);
        }

        /// <summary>
        /// Remove Partner.
        /// </summary>
        /// <param name="request">The Partner Request Pivot to remove.</param>
        public void DeletePartner(PartnerRequestPivot request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            Partner partner = _unitOfWork.PartnerRepository.GetById(request.PartnerPivot.PartnerId);

            _unitOfWork.PartnerRepository.Delete(partner);
            _unitOfWork.Save();

            UpdatePartnersPositions();
        }

        /// <summary>
        /// Get the list of the Partner.
        /// </summary>
        /// <returns>Partner Response Pivot response.</returns>
        public PartnerResponsePivot GetAllPartners()
        {
            return new PartnerResponsePivot()
            {
                PartnerPivotList = _unitOfWork.PartnerRepository.Get().ToList().ToPivotList()
            };
        }

        /// <summary>
        /// Search Partner by id.
        /// </summary>
        /// <param name="request">The Partner Request Pivot to retrive.</param>
        /// <returns>Partner Response Pivot response.</returns>
        public PartnerResponsePivot FindPartners(PartnerRequestPivot request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            List<PartnerPivot> results = new List<PartnerPivot>();
            PartnerPivot result = new PartnerPivot();
            switch (request.FindPartnerPivot)
            {
                case FindPartnerPivot.PartnerId:
                    result = _unitOfWork.PartnerRepository.GetById(request.PartnerPivot.PartnerId)?.ToPivot();
                    break;
            }
            return new PartnerResponsePivot()
            {
                PartnerPivotList = results,
                PartnerPivot = result
            };
        }

        private void UpdatePartnersPositions(int partnerId)
        {
            List<Partner> partnersList = _unitOfWork.PartnerRepository.Get(p => p.PartnerId != partnerId).OrderBy(p=>p.PartnerPosition).ToList();
            Partner partner = _unitOfWork.PartnerRepository.GetById(partnerId);

            partnersList.Insert(partner.PartnerPosition - 1, partner);

            for (int i = 0; i < partnersList.Count; i++)
            {
                partnersList[i].PartnerPosition = i + 1;
            }
            _unitOfWork.Save();
        }

        private void UpdatePartnersPositions()
        {
            List<Partner> partnersList = _unitOfWork.PartnerRepository.Get().OrderBy(p => p.PartnerPosition).ToList();

            for (int i = 0; i < partnersList.Count; i++)
            {
                partnersList[i].PartnerPosition = i + 1;
            }
            _unitOfWork.Save();
        }

        #endregion

        }
}