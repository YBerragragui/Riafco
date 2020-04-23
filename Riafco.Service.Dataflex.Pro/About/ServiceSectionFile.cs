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
    /// The SectionFile service class.
    /// </summary>
    public class ServiceSectionFile : IServiceSectionFile
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
        public ServiceSectionFile(IUnitOfWork injectedUnitOfWork)
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
        /// Create new SectionFile.
        /// </summary>
        /// <param name="request">The SectionFile Request Pivot to add.</param>
        /// <returns>SectionFile Response Pivot created.</returns>
        public SectionFileResponsePivot CreateSectionFile(SectionFileRequestPivot request)
        {
            if (request?.SectionFilePivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            SectionFile sectionFile = request.SectionFilePivot.ToEntity();
            _unitOfWork.SectionFileRepository.Insert(sectionFile);
            _unitOfWork.Save();
            return new SectionFileResponsePivot
            {
                SectionFilePivot = sectionFile.ToPivot()
            };
        }

        /// <summary>
        /// Change SectionFile values.
        /// </summary>
        /// <param name="request">The SectionFile Request Pivot to change.</param>
        public void UpdateSectionFile(SectionFileRequestPivot request)
        {
            if (request?.SectionFilePivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            SectionFile sectionFile = _unitOfWork.SectionFileRepository.GetById(request.SectionFilePivot.SectionFileId);
            sectionFile.SectionId = request.SectionFilePivot.SectionId;
            _unitOfWork.Save();
        }

        /// <summary>
        /// Remove SectionFile.
        /// </summary>
        /// <param name="request">The SectionFile Request Pivot to remove.</param>
        public void DeleteSectionFile(SectionFileRequestPivot request)
        {
            if (request?.SectionFilePivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            SectionFile sectionFile = _unitOfWork.SectionFileRepository.GetById(request.SectionFilePivot.SectionFileId);
            _unitOfWork.SectionFileRepository.Delete(sectionFile);
            _unitOfWork.Save();
        }

        /// <summary>
        /// Get the list of the SectionFile.
        /// </summary>
        /// <returns>SectionFile Response Pivot response.</returns>
        public SectionFileResponsePivot GetAllSectionFiles()
        {
            return new SectionFileResponsePivot
            {
                SectionFilePivotList = _unitOfWork.SectionFileRepository.Get(null, null, "Section").ToList().ToPivotList()
            };
        }

        /// <summary>
        /// Search SectionFile by id.
        /// </summary>
        /// <param name="request">The SectionFile Request Pivot to retrive.</param>
        /// <returns>SectionFile Response Pivot response.</returns>
        public SectionFileResponsePivot FindSectionFiles(SectionFileRequestPivot request)
        {
            if (request?.SectionFilePivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            List<SectionFilePivot> results = new List<SectionFilePivot>();
            SectionFilePivot result = new SectionFilePivot();
            switch (request.FindSectionFilePivot)
            {
                case FindSectionFilePivot.SectionFileId:
                    result = _unitOfWork.SectionFileRepository.Get(f => f.SectionFileId == request.SectionFilePivot.SectionFileId, null, "Section")?.FirstOrDefault().ToPivot();
                    break;
                case FindSectionFilePivot.SectionId:
                    results = _unitOfWork.SectionFileRepository.Get(f => f.SectionId == request.SectionFilePivot.SectionId, null, "Section")?.ToList().ToPivotList();
                    break;
            }
            return new SectionFileResponsePivot
            {
                SectionFilePivotList = results,
                SectionFilePivot = result
            };
        }
        #endregion
    }
}