using System;
using System.Collections.Generic;
using System.Linq;
using Riafco.Service.Dataflex.Pro.About.Request;
using Riafco.Service.Dataflex.Pro.About.Response;
using Riafco.Service.Dataflex.Pro.About.Interface;
using Riafco.Service.Dataflex.Pro.UnitOfWork;
using Riafco.Service.Dataflex.Pro.About.Assembler;
using Riafco.Entity.Dataflex.Pro.About;
using Riafco.Service.Dataflex.Pro.About.Data;
using Riafco.Service.Dataflex.Pro.About.Data.Enum;

namespace Riafco.Service.Dataflex.Pro.About
{
    /// <summary>
    /// The SectionParagraphTraslation service class.
    /// </summary>
    public class ServiceSectionParagraphTranslation : IServiceSectionParagraphTranslation
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
        public ServiceSectionParagraphTranslation(IUnitOfWork injectedUnitOfWork)
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
        /// Create new SectionParagraphTraslation.
        /// </summary>
        /// <param name="request">The SectionParagraphTraslation Request Pivot to add.</param>
        /// <returns>SectionParagraphTraslation Response Pivot added.</returns>
        public SectionParagraphTranslationResponsePivot CreateSectionParagraphTranslation(SectionParagraphTranslationRequestPivot request)
        {
            if (request?.SectionParagraphTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            SectionParagraphTranslation sectionParagraphTraslation = request.SectionParagraphTranslationPivot.ToEntity();
            _unitOfWork.SectionParagraphTraslationRepository.Insert(sectionParagraphTraslation);
            _unitOfWork.Save();

            return new SectionParagraphTranslationResponsePivot
            {
                SectionParagraphTranslationPivot = sectionParagraphTraslation.ToPivot()
            };
        }

        /// <summary>
        /// Create new SectionParagraphTraslation.
        /// </summary>
        /// <param name="request">The SectionParagraphTraslation Request Pivot to add.</param>
        /// <returns>SectionParagraphTraslation Response Pivot added.</returns>
        public SectionParagraphTranslationResponsePivot CreateSectionParagraphTranslationRange(SectionParagraphTranslationRequestPivot request)
        {
            if (request?.SectionParagraphTranslationPivotList == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            List<SectionParagraphTranslation> sectionParagraphTraslationList = request.SectionParagraphTranslationPivotList.ToEntityList();
            _unitOfWork.SectionParagraphTraslationRepository.Insert(sectionParagraphTraslationList);
            _unitOfWork.Save();
            return new SectionParagraphTranslationResponsePivot
            {
                SectionParagraphTranslationPivotList = sectionParagraphTraslationList.ToPivotList()
            };
        }

        /// <summary>
        /// Change SectionParagraphTraslation values.
        /// </summary>
        /// <param name="request">The SectionParagraphTraslation Request Pivot to change.</param>
        public void UpdateSectionParagraphTranslation(SectionParagraphTranslationRequestPivot request)
        {
            if (request?.SectionParagraphTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            SectionParagraphTranslation sectionTranslation = _unitOfWork.SectionParagraphTraslationRepository.GetById(request.SectionParagraphTranslationPivot.TranslationId);
            sectionTranslation.ParagraphDescription = request.SectionParagraphTranslationPivot.ParagraphDescription;
            sectionTranslation.ParagraphTitle = request.SectionParagraphTranslationPivot.ParagraphTitle;
            _unitOfWork.Save();
        }

        /// <summary>
        /// Change SectionParagraphTraslation values Range.
        /// </summary>
        /// <param name="request">The SectionParagraphTraslation Request Pivot to change.</param>
        public void UpdateSectionParagraphTranslationRange(SectionParagraphTranslationRequestPivot request)
        {
            if (request?.SectionParagraphTranslationPivotList == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            foreach (var translation in request.SectionParagraphTranslationPivotList.ToList())
            {
                SectionParagraphTranslation sectionTranslation = _unitOfWork.SectionParagraphTraslationRepository.GetById(translation.TranslationId);
                sectionTranslation.ParagraphDescription = translation.ParagraphDescription;
                sectionTranslation.ParagraphTitle = translation.ParagraphTitle;
                _unitOfWork.Save();
            }
        }

        /// <summary>
        /// Remove SectionParagraphTraslation.
        /// </summary>
        /// <param name="request">The SectionParagraphTraslation Request Pivot to remove.</param>
        public void DeleteSectionParagraphTranslation(SectionParagraphTranslationRequestPivot request)
        {
            if (request?.SectionParagraphTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            SectionParagraphTranslation sectionParagraphTraslation = _unitOfWork.SectionParagraphTraslationRepository.GetById(request.SectionParagraphTranslationPivot.TranslationId);
            _unitOfWork.SectionParagraphTraslationRepository.Delete(sectionParagraphTraslation);
            _unitOfWork.Save();
        }

        /// <summary>
        /// Get the list of the SectionParagraphTraslation.
        /// </summary>
        /// <returns>SectionParagraphTraslation Response Pivot response.</returns>
        public SectionParagraphTranslationResponsePivot GetAllSectionParagraphTraslations()
        {
            return new SectionParagraphTranslationResponsePivot
            {
                SectionParagraphTranslationPivotList = _unitOfWork.SectionParagraphTraslationRepository.Get().ToList().ToPivotList()
            };
        }

        /// <summary>
        /// Search SectionParagraphTraslation by id.
        /// </summary>
        /// <param name="request">The SectionParagraphTraslation Request Pivot to retrive.</param>
        /// <returns>SectionParagraphTraslation Response Pivot response.</returns>
        public SectionParagraphTranslationResponsePivot FindSectionParagraphTranslations(SectionParagraphTranslationRequestPivot request)
        {
            if (request?.SectionParagraphTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            List<SectionParagraphTranslationPivot> results = new List<SectionParagraphTranslationPivot>();
            SectionParagraphTranslationPivot result = new SectionParagraphTranslationPivot();
            switch (request.FindSectionParagraphTranslationPivot)
            {
                case FindSectionParagraphTranslationPivot.SectionParagraphTranslationId:
                    result = _unitOfWork.SectionParagraphTraslationRepository.Get(p => p.ParagraphId == request.SectionParagraphTranslationPivot.TranslationId, null, "SectionParagraph,Language")?.FirstOrDefault()?.ToPivot();
                    break;
                case FindSectionParagraphTranslationPivot.SectionParagraphId:
                    results = _unitOfWork.SectionParagraphTraslationRepository.Get(p => p.ParagraphId == request.SectionParagraphTranslationPivot.ParagraphId, null, "SectionParagraph,Language")?.ToList().ToPivotList();
                    break;
            }
            return new SectionParagraphTranslationResponsePivot
            {
                SectionParagraphTranslationPivotList = results,
                SectionParagraphTranslationPivot = result
            };
        }
        #endregion
    }
}