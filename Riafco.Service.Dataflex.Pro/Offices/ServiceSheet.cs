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
    /// The Sheet service class.
    /// </summary>
    public class ServiceSheet : IServiceSheet
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
        public ServiceSheet(IUnitOfWork injectedUnitOfWork)
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
        /// Create new Sheet.
        /// </summary>
        /// <param name="request">The Sheet Request Pivot to add.</param>
        /// <returns>Sheet Response Pivot created.</returns>
        public SheetResponsePivot CreateSheet(SheetRequestPivot request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            Sheet sheet = request.SheetPivot.ToEntity();
            _unitOfWork.SheetRepository.Insert(sheet);
            _unitOfWork.Save();
            return new SheetResponsePivot()
            {
                SheetPivot = sheet.ToPivot()
            };
        }

        /// <summary>
        /// Change Sheet values.
        /// </summary>
        /// <param name="request">The Sheet Request Pivot to change.</param>
        public void UpdateSheet(SheetRequestPivot request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            //Sheet sheet = _unitOfWork.SheetRepository.GetById(request.SheetPivot.SheetId);
            //_unitOfWork.Save();
        }

        /// <summary>
        /// Remove Sheet.
        /// </summary>
        /// <param name="request">The Sheet Request Pivot to remove.</param>
        public void DeleteSheet(SheetRequestPivot request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            Sheet sheet = _unitOfWork.SheetRepository.GetById(request.SheetPivot.SheetId);
            _unitOfWork.SheetRepository.Delete(sheet);
            _unitOfWork.Save();

        }

        /// <summary>
        /// Get the list of the Sheet.
        /// </summary>
        /// <returns>Sheet Response Pivot response.</returns>
        public SheetResponsePivot GetAllSheets()
        {
            return new SheetResponsePivot()
            {
                SheetPivotList = _unitOfWork.SheetRepository.Get().ToList().ToPivotList()
            };

        }

        /// <summary>
        /// Search Sheet by id.
        /// </summary>
        /// <param name="request">The Sheet Request Pivot to retrive.</param>
        /// <returns>Sheet Response Pivot response.</returns>
        public SheetResponsePivot FindSheets(SheetRequestPivot request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            List<SheetPivot> results = new List<SheetPivot>();
            SheetPivot result = new SheetPivot();
            switch (request.FindSheetPivot)
            {
                case FindSheetPivot.SheetId:
                    result = _unitOfWork.SheetRepository.Get(s => s.SheetId == request.SheetPivot.SheetId, null, "Country")?.FirstOrDefault().ToPivot();
                    break;
                case FindSheetPivot.CountryId:
                    results = _unitOfWork.SheetRepository.Get(s => s.CountryId == request.SheetPivot.CountryId, null, "Country")?.ToList().ToPivotList();
                    break;
            }
            return new SheetResponsePivot()
            {
                SheetPivotList = results,
                SheetPivot = result
            };
        }
        #endregion

    }
}