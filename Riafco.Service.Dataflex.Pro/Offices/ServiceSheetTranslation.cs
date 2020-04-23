using System;
using System.Collections.Generic;
using System.Linq;
using Riafco.Service.Dataflex.Pro.Offices.Request;
using Riafco.Service.Dataflex.Pro.Offices.Response;
using Riafco.Service.Dataflex.Pro.Offices.Interface;
using Riafco.Service.Dataflex.Pro.UnitOfWork;
using Riafco.Service.Dataflex.Pro.Offices.Assembler;
using Riafco.Entity.Dataflex.Pro.Offices;
using Riafco.Service.Dataflex.Pro.Offices.Data;
using Riafco.Service.Dataflex.Pro.Offices.Data.Enum;

namespace Riafco.Service.Dataflex.Pro.Offices
{
    /// <summary>
    /// The SheetTranslation service class.
    /// </summary>
    public class ServiceSheetTranslation : IServiceSheetTranslation
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
        public ServiceSheetTranslation(IUnitOfWork injectedUnitOfWork)
        {
            if (injectedUnitOfWork == null)
            {
                throw new ArgumentNullException(nameof(injectedUnitOfWork));
            }
            else
            {
                _unitOfWork = injectedUnitOfWork;
            }
        }
        #endregion

        #region public methods
        /// <summary>
        /// Create new SheetTranslation.
        /// </summary>
        /// <param name="request">The SheetTranslation Request Pivot to add.</param>
        /// <returns>SheetTranslation Response Pivot created.</returns>
        public SheetTranslationResponsePivot CreateSheetTranslation(SheetTranslationRequestPivot request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            SheetTranslation sheetTranslation = request.SheetTranslationPivot.ToEntity();
            _unitOfWork.SheetTranslationRepository.Insert(sheetTranslation);
            _unitOfWork.Save();
            return new SheetTranslationResponsePivot()
            {
                SheetTranslationPivot = sheetTranslation.ToPivot()
            };
        }

        /// <summary>
        /// Create new SheetTranslationRange.
        /// </summary>
        /// <param name="request">The SheetTranslationRange Request Pivot to add.</param>
        /// <returns>SheetTranslation Response Pivot created.</returns>
        public SheetTranslationResponsePivot CreateSheetTranslationRange(SheetTranslationRequestPivot request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            List<SheetTranslation> sheetTranslationList = request.SheetTranslationPivotList.ToEntityList();
            _unitOfWork.SheetTranslationRepository.Insert(sheetTranslationList);
            _unitOfWork.Save();
            return new SheetTranslationResponsePivot()
            {
                SheetTranslationPivotList = sheetTranslationList.ToPivotList()
            };
        }

        /// <summary>
        /// Change SheetTranslation values.
        /// </summary>
        /// <param name="request">The SheetTranslation Request Pivot to change.</param>
        public void UpdateSheetTranslation(SheetTranslationRequestPivot request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            SheetTranslation sheetTranslation = _unitOfWork.SheetTranslationRepository.GetById(request.SheetTranslationPivot.TranslationId);
            sheetTranslation.SheetTitle = request.SheetTranslationPivot.SheetTitle;
            sheetTranslation.SheetValue = request.SheetTranslationPivot.SheetValue;
            _unitOfWork.Save();

        }

        /// <summary>
        /// Change SheetTranslationRange values.
        /// </summary>
        /// <param name="request">The SheetTranslation Request SheetTranslationRange to change.</param>
        public void UpdateSheetTranslationRange(SheetTranslationRequestPivot request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            foreach (var item in request.SheetTranslationPivotList)
            {
                SheetTranslation sheetTranslation = _unitOfWork.SheetTranslationRepository.GetById(item.TranslationId);
                sheetTranslation.SheetTitle = item.SheetTitle;
                sheetTranslation.SheetValue = item.SheetValue;
                _unitOfWork.Save();
            }
        }

        /// <summary>
        /// Remove SheetTranslation.
        /// </summary>
        /// <param name="request">The SheetTranslation Request Pivot to remove.</param>
        public void DeleteSheetTranslation(SheetTranslationRequestPivot request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            SheetTranslation sheetTranslation = _unitOfWork.SheetTranslationRepository.GetById(request.SheetTranslationPivot.TranslationId);
            _unitOfWork.SheetTranslationRepository.Delete(sheetTranslation);
            _unitOfWork.Save();

        }

        /// <summary>
        /// Get the list of the SheetTranslation.
        /// </summary>
        /// <returns>SheetTranslation Response Pivot response.</returns>
        public SheetTranslationResponsePivot GetAllSheetTranslations()
        {
            return new SheetTranslationResponsePivot
            {
                SheetTranslationPivotList = _unitOfWork.SheetTranslationRepository.Get().ToList().ToPivotList()
            };

        }

        /// <summary>
        /// Search SheetTranslation by id.
        /// </summary>
        /// <param name="request">The SheetTranslation Request Pivot to retrive.</param>
        /// <returns>SheetTranslation Response Pivot response.</returns>
        public SheetTranslationResponsePivot FindSheetTranslations(SheetTranslationRequestPivot request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            List<SheetTranslationPivot> results = new List<SheetTranslationPivot>();
            SheetTranslationPivot result = new SheetTranslationPivot();
            switch (request.FindSheetTranslationPivot)
            {
                case FindSheetTranslationPivot.SheetTranslationId:
                    result = _unitOfWork.SheetTranslationRepository.GetById(request.SheetTranslationPivot.TranslationId)?.ToPivot();
                    break;
                case FindSheetTranslationPivot.SheetId:
                    results = _unitOfWork.SheetTranslationRepository.Get(s => s.SheetId == request.SheetTranslationPivot.SheetId, null, "Language,Sheet")?.ToList().ToPivotList();
                    break;
            }
            return new SheetTranslationResponsePivot()
            {
                SheetTranslationPivotList = results,
                SheetTranslationPivot = result
            };
        }
        #endregion

    }
}