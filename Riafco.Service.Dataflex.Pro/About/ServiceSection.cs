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
    /// The Section service class.
    /// </summary>
    public class ServiceSection : IServiceSection
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
        public ServiceSection(IUnitOfWork injectedUnitOfWork)
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
        /// Create new Section.
        /// </summary>
        /// <param name="request">The Section Request Pivot to add.</param>
        /// <returns>Section Response Pivot created.</returns>
        public SectionResponsePivot CreateSection(SectionRequestPivot request)
        {
            if (request?.SectionPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            Section section = request.SectionPivot.ToEntity();
            _unitOfWork.SectionRepository.Insert(section);
            _unitOfWork.Save();
            return new SectionResponsePivot
            {
                SectionPivot = section.ToPivot()
            };
        }

        /// <summary>
        /// Change Section values.
        /// </summary>
        /// <param name="request">The Section Request Pivot to change.</param>
        public void UpdateSection(SectionRequestPivot request)
        {
            if (request?.SectionPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            Section section = _unitOfWork.SectionRepository.GetById(request.SectionPivot.SectionId);
            if (string.IsNullOrEmpty(request.SectionPivot.SectionImage) == false)
            {
                section.SectionImage = request.SectionPivot.SectionImage;
            }
            _unitOfWork.Save();
        }

        /// <summary>
        /// Remove Section.
        /// </summary>
        /// <param name="request">The Section Request Pivot to remove.</param>
        public void DeleteSection(SectionRequestPivot request)
        {
            if (request?.SectionPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            Section section = _unitOfWork.SectionRepository.GetById(request.SectionPivot.SectionId);
            _unitOfWork.SectionRepository.Delete(section);
            _unitOfWork.Save();
        }

        /// <summary>
        /// Get the list of the Section.
        /// </summary>
        /// <returns>Section Response Pivot response.</returns>
        public SectionResponsePivot GetAllSections()
        {
            return new SectionResponsePivot()
            {
                SectionPivotList = _unitOfWork.SectionRepository.Get().ToList().ToPivotList()
            };
        }

        /// <summary>
        /// Search Section by id.
        /// </summary>
        /// <param name="request">The Section Request Pivot to retrive.</param>
        /// <returns>Section Response Pivot response.</returns>
        public SectionResponsePivot FindSections(SectionRequestPivot request)
        {
            if (request?.SectionPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            List<SectionPivot> results = new List<SectionPivot>();
            SectionPivot result = new SectionPivot();
            switch (request.FindSectionPivot)
            {
                case FindSectionPivot.SectionId:
                    result = _unitOfWork.SectionRepository.GetById(request.SectionPivot.SectionId)?.ToPivot();
                    break;
            }
            return new SectionResponsePivot
            {
                SectionPivotList = results,
                SectionPivot = result
            };
        }
        #endregion
    }
}