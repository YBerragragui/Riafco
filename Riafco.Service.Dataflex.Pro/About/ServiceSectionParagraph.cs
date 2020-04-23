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
    /// The SectionParagraph service class.
    /// </summary>
    public class ServiceSectionParagraph : IServiceSectionParagraph
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
        public ServiceSectionParagraph(IUnitOfWork injectedUnitOfWork)
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
        /// Create new SectionParagraph.
        /// </summary>
        /// <param name="request">The SectionParagraph Request Pivot to add.</param>
        /// <returns>SectionParagraph Response Pivot added.</returns>
        public SectionParagraphResponsePivot CreateSectionParagraph(SectionParagraphRequestPivot request)
        {
            if (request?.SectionParagraphPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            SectionParagraph sectionParagraph = request.SectionParagraphPivot.ToEntity();
            _unitOfWork.SectionParagraphRepository.Insert(sectionParagraph);
            _unitOfWork.Save();
            return new SectionParagraphResponsePivot
            {
                SectionParagraphPivot = sectionParagraph.ToPivot()
            };
        }

        /// <summary>
        /// Change SectionParagraph values.
        /// </summary>
        /// <param name="request">The SectionParagraph Request Pivot to change.</param>
        public void UpdateSectionParagraph(SectionParagraphRequestPivot request)
        {
            if (request?.SectionParagraphPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
        }

        /// <summary>
        /// Remove SectionParagraph.
        /// </summary>
        /// <param name="request">The SectionParagraph Request Pivot to remove.</param>
        public void DeleteSectionParagraph(SectionParagraphRequestPivot request)
        {
            if (request?.SectionParagraphPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            SectionParagraph sectionParagraph = _unitOfWork.SectionParagraphRepository.GetById(request.SectionParagraphPivot.ParagraphId);
            _unitOfWork.SectionParagraphRepository.Delete(sectionParagraph);
            _unitOfWork.Save();
        }

        /// <summary>
        /// Get the list of the SectionParagraph.
        /// </summary>
        /// <returns>SectionParagraph Response Pivot response.</returns>
        public SectionParagraphResponsePivot GetAllSectionParagraphs()
        {
            return new SectionParagraphResponsePivot
            {
                SectionParagraphPivotList = _unitOfWork.SectionParagraphRepository.Get(null, null, "Section").ToList().ToPivotList()
            };
        }

        /// <summary>
        /// Search SectionParagraph by id.
        /// </summary>
        /// <param name="request">The SectionParagraph Request Pivot to retrive.</param>
        /// <returns>SectionParagraph Response Pivot response.</returns>
        public SectionParagraphResponsePivot FindSectionParagraphs(SectionParagraphRequestPivot request)
        {
            if (request?.SectionParagraphPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            List<SectionParagraphPivot> results = new List<SectionParagraphPivot>();
            SectionParagraphPivot result = new SectionParagraphPivot();
            switch (request.FindSectionParagraphPivot)
            {
                case FindSectionParagraphPivot.SectionParagraphId:
                    result = _unitOfWork.SectionParagraphRepository.Get(p => p.ParagraphId == request.SectionParagraphPivot.ParagraphId, null, "Section")?.FirstOrDefault().ToPivot();
                    break;
                case FindSectionParagraphPivot.SectionId:
                    results = _unitOfWork.SectionParagraphRepository.Get(p => p.SectionId == request.SectionParagraphPivot.SectionId, null, "Section")?.ToList().ToPivotList();
                    break;
            }

            return new SectionParagraphResponsePivot
            {
                SectionParagraphPivotList = results,
                SectionParagraphPivot = result
            };
        }
        #endregion
    }
}