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
    /// The SectionTranslation service class.
    /// </summary>
    public class ServiceSectionTranslation : IServiceSectionTranslation
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
        public ServiceSectionTranslation(IUnitOfWork injectedUnitOfWork)
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
        /// Create new SectionTranslation.
        /// </summary>
        /// <param name="request">The SectionTranslation Request Pivot to add.</param>
        /// <returns>SectionTranslation Response Pivot created.</returns>
        public SectionTranslationResponsePivot CreateSectionTranslation(SectionTranslationRequestPivot request)
        {
            if (request?.SectionTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            SectionTranslation sectionTranslation = request.SectionTranslationPivot.ToEntity();
            _unitOfWork.SectionTranslationRepository.Insert(sectionTranslation);
            _unitOfWork.Save();
            return new SectionTranslationResponsePivot
            {
                SectionTranslationPivot = sectionTranslation.ToPivot()
            };
        }

        /// <summary>
        /// Create new SectionTranslation.
        /// </summary>
        /// <param name="request">The SectionTranslation Request Pivot to add.</param>
        /// <returns>SectionTranslation Response Pivot created.</returns>
        public SectionTranslationResponsePivot CreateSectionTranslationRange(SectionTranslationRequestPivot request)
        {
            if (request?.SectionTranslationPivotList == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            List<SectionTranslation> sectionTranslationList = request.SectionTranslationPivotList.ToEntityList();
            _unitOfWork.SectionTranslationRepository.Insert(sectionTranslationList);
            _unitOfWork.Save();
            return new SectionTranslationResponsePivot
            {
                SectionTranslationPivotList = sectionTranslationList.ToPivotList()
            };
        }

        /// <summary>
        /// Change SectionTranslation values.
        /// </summary>
        /// <param name="request">The SectionTranslation Request Pivot to change.</param>
        public void UpdateSectionTranslation(SectionTranslationRequestPivot request)
        {
            if (request?.SectionTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            SectionTranslation sectionTranslation = _unitOfWork.SectionTranslationRepository.GetById(request.SectionTranslationPivot.TranslationId);
            sectionTranslation.SectionDesciption = request.SectionTranslationPivot.SectionDesciption;
            sectionTranslation.SectionTitle = request.SectionTranslationPivot.SectionTitle;
            _unitOfWork.Save();

        }


        /// <summary>
        /// Change SectionTranslation values.
        /// </summary>
        /// <param name="request">The SectionTranslation Request Pivot to change.</param>
        public void UpdateSectionTranslationRange(SectionTranslationRequestPivot request)
        {
            if (request?.SectionTranslationPivotList == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            foreach (var item in request.SectionTranslationPivotList)
            {
                SectionTranslation sectionTranslation = _unitOfWork.SectionTranslationRepository.GetById(item.TranslationId);
                sectionTranslation.SectionDesciption = item.SectionDesciption;
                sectionTranslation.SectionTitle = item.SectionTitle;
                _unitOfWork.Save();
            }
        }

        /// <summary>
        /// Remove SectionTranslation.
        /// </summary>
        /// <param name="request">The SectionTranslation Request Pivot to remove.</param>
        public void DeleteSectionTranslation(SectionTranslationRequestPivot request)
        {
            if (request?.SectionTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            SectionTranslation sectionTranslation = _unitOfWork.SectionTranslationRepository.GetById(request.SectionTranslationPivot.TranslationId);
            _unitOfWork.SectionTranslationRepository.Delete(sectionTranslation);
            _unitOfWork.Save();

        }

        /// <summary>
        /// Get the list of the SectionTranslation.
        /// </summary>
        /// <returns>SectionTranslation Response Pivot response.</returns>
        public SectionTranslationResponsePivot GetAllSectionTranslations()
        {
            return new SectionTranslationResponsePivot()
            {
                SectionTranslationPivotList = _unitOfWork.SectionTranslationRepository.Get().ToList().ToPivotList()
            };

        }

        /// <summary>
        /// Search SectionTranslation by id.
        /// </summary>
        /// <param name="request">The SectionTranslation Request Pivot to retrive.</param>
        /// <returns>SectionTranslation Response Pivot response.</returns>
        public SectionTranslationResponsePivot FindSectionTranslations(SectionTranslationRequestPivot request)
        {
            if (request?.SectionTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            List<SectionTranslationPivot> results = new List<SectionTranslationPivot>();
            SectionTranslationPivot result = new SectionTranslationPivot();
            switch (request.FindSectionTranslationPivot)
            {
                case FindSectionTranslationPivot.SectionTranslationId:
                    result = _unitOfWork.SectionTranslationRepository.GetById(request.SectionTranslationPivot.TranslationId)?.ToPivot();
                    break;
                case FindSectionTranslationPivot.SectionId:
                    results = _unitOfWork.SectionTranslationRepository.Get(o => o.SectionId == request.SectionTranslationPivot.SectionId, null, "Section,Language")?.ToList().ToPivotList();
                    break;
            }
            return new SectionTranslationResponsePivot()
            {
                SectionTranslationPivotList = results,
                SectionTranslationPivot = result
            };
        }
        #endregion

    }
}