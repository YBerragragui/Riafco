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
    /// The SectionFileTranslation service class.
    /// </summary>
    public class ServiceSectionFileTranslation : IServiceSectionFileTranslation
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
        public ServiceSectionFileTranslation(IUnitOfWork injectedUnitOfWork)
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
        /// Create new SectionFileTranslation.
        /// </summary>
        /// <param name="request">The SectionFileTranslation Request Pivot to add.</param>
        /// <returns>SectionFileTranslation Response Pivot created.</returns>
        public SectionFileTranslationResponsePivot CreateSectionFileTranslation(SectionFileTranslationRequestPivot request)
        {
            if (request?.SectionFileTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            SectionFileTranslation sectionFileTranslation = request.SectionFileTranslationPivot.ToEntity();
            _unitOfWork.SectionFileTranslationRepository.Insert(sectionFileTranslation);
            _unitOfWork.Save();
            return new SectionFileTranslationResponsePivot
            {
                SectionFileTranslationPivot = sectionFileTranslation.ToPivot()
            };
        }


        /// <summary>
        /// Create new SectionFileTranslation.
        /// </summary>
        /// <param name="request">The SectionFileTranslation Request Pivot to add.</param>
        /// <returns>SectionFileTranslation Response Pivot created.</returns>
        public SectionFileTranslationResponsePivot CreateSectionFileTranslationRange(SectionFileTranslationRequestPivot request)
        {
            if (request?.SectionFileTranslationPivotList == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            List<SectionFileTranslation> sectionFileTranslationList = request.SectionFileTranslationPivotList.ToEntityList();
            _unitOfWork.SectionFileTranslationRepository.Insert(sectionFileTranslationList);
            _unitOfWork.Save();

            return new SectionFileTranslationResponsePivot
            {
                SectionFileTranslationPivotList = sectionFileTranslationList.ToPivotList()
            };
        }

        /// <summary>
        /// Change SectionFileTranslation values.
        /// </summary>
        /// <param name="request">The SectionFileTranslation Request Pivot to change.</param>
        public void UpdateSectionFileTranslation(SectionFileTranslationRequestPivot request)
        {
            if (request?.SectionFileTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            SectionFileTranslation sectionFileTranslation = _unitOfWork.SectionFileTranslationRepository.GetById(request.SectionFileTranslationPivot.TranslationId);
            if (request.SectionFileTranslationPivot.SectionFileSource != null)
            {
                sectionFileTranslation.SectionFileSource = request.SectionFileTranslationPivot.SectionFileSource;
            }
            sectionFileTranslation.SectionFileText = request.SectionFileTranslationPivot.SectionFileText;
            _unitOfWork.Save();
        }

        /// <summary>
        /// Change SectionFileTranslation values.
        /// </summary>
        /// <param name="request">The SectionFileTranslation Request Pivot to change.</param>
        public void UpdateSectionFileTranslationRange(SectionFileTranslationRequestPivot request)
        {
            if (request?.SectionFileTranslationPivotList == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            foreach (var translation in request.SectionFileTranslationPivotList)
            {
                SectionFileTranslation sectionFileTranslation = _unitOfWork.SectionFileTranslationRepository.GetById(translation.TranslationId);
                if (translation.SectionFileSource != null)
                {
                    sectionFileTranslation.SectionFileSource = translation.SectionFileSource;
                }
                sectionFileTranslation.SectionFileText = translation.SectionFileText;
                _unitOfWork.Save();
            }
        }

        /// <summary>
        /// Remove SectionFileTranslation.
        /// </summary>
        /// <param name="request">The SectionFileTranslation Request Pivot to remove.</param>
        public void DeleteSectionFileTranslation(SectionFileTranslationRequestPivot request)
        {
            if (request?.SectionFileTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            SectionFileTranslation sectionFileTranslation = _unitOfWork.SectionFileTranslationRepository.GetById(request.SectionFileTranslationPivot.TranslationId);
            _unitOfWork.SectionFileTranslationRepository.Delete(sectionFileTranslation);
            _unitOfWork.Save();
        }

        /// <summary>
        /// Get the list of the SectionFileTranslation.
        /// </summary>
        /// <returns>SectionFileTranslation Response Pivot response.</returns>
        public SectionFileTranslationResponsePivot GetAllSectionFileTranslations()
        {
            return new SectionFileTranslationResponsePivot
            {
                SectionFileTranslationPivotList = _unitOfWork.SectionFileTranslationRepository.Get(null, null, "Language,SectionFile").ToList().ToPivotList()
            };
        }

        /// <summary>
        /// Search SectionFileTranslation by id.
        /// </summary>
        /// <param name="request">The SectionFileTranslation Request Pivot to retrive.</param>
        /// <returns>SectionFileTranslation Response Pivot response.</returns>
        public SectionFileTranslationResponsePivot FindSectionFileTranslations(SectionFileTranslationRequestPivot request)
        {
            if (request?.SectionFileTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            List<SectionFileTranslationPivot> results = new List<SectionFileTranslationPivot>();
            SectionFileTranslationPivot result = new SectionFileTranslationPivot();
            switch (request.FindSectionFileTranslationPivot)
            {
                case FindSectionFileTranslationPivot.SectionFileTranslationId:
                    result = _unitOfWork.SectionFileTranslationRepository.Get(f => f.TranslationId == request.SectionFileTranslationPivot.TranslationId, null, "Language,SectionFile")?.FirstOrDefault().ToPivot();
                    break;
                case FindSectionFileTranslationPivot.SectionFileId:
                    results = _unitOfWork.SectionFileTranslationRepository.Get(f => f.SectionFileId == request.SectionFileTranslationPivot.SectionFileId, null, "Language,SectionFile")?.ToList().ToPivotList();
                    break;
            }
            return new SectionFileTranslationResponsePivot
            {
                SectionFileTranslationPivotList = results,
                SectionFileTranslationPivot = result
            };
        }
        #endregion
    }
}