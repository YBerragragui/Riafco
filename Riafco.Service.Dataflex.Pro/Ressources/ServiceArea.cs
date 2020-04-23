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
    /// The Area service class.
    /// </summary>
    public class ServiceArea : IServiceArea
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
        public ServiceArea(IUnitOfWork injectedUnitOfWork)
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
        /// Create new Area.
        /// </summary>
        /// <param name="request">The Area Request Pivot to add.</param>
        /// <returns>Area Response Pivot created.</returns>
        public AreaResponsePivot CreateArea(AreaRequestPivot request)
        {
            if (request?.AreaPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Area area = request.AreaPivot.ToEntity();
            _unitOfWork.AreaRepository.Insert(area);
            _unitOfWork.Save();
            return new AreaResponsePivot
            {
                AreaPivot = area.ToPivot()
            };
        }

        /// <summary>
        /// Change Area values.
        /// </summary>
        /// <param name="request">The Area Request Pivot to change.</param>
        public void UpdateArea(AreaRequestPivot request)
        {
            if (request?.AreaPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Area area = _unitOfWork.AreaRepository.GetById(request.AreaPivot.AreaId);
            area.AreaId = request.AreaPivot.AreaId;
            _unitOfWork.Save();
        }

        /// <summary>
        /// Remove Area.
        /// </summary>
        /// <param name="request">The Area Request Pivot to remove.</param>
        public void DeleteArea(AreaRequestPivot request)
        {
            if (request?.AreaPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Area area = _unitOfWork.AreaRepository.GetById(request.AreaPivot.AreaId);
            _unitOfWork.AreaRepository.Delete(area);
            _unitOfWork.Save();
        }

        /// <summary>
        /// Get the list of the Area.
        /// </summary>
        /// <returns>Area Response Pivot response.</returns>
        public AreaResponsePivot GetAllAreas()
        {
            return new AreaResponsePivot
            {
                AreaPivotList = _unitOfWork.AreaRepository.Get().ToList().ToPivotList()
            };
        }

        /// <summary>
        /// Search Area by id.
        /// </summary>
        /// <param name="request">The Area Request Pivot to retrive.</param>
        /// <returns>Area Response Pivot response.</returns>
        public AreaResponsePivot FindAreas(AreaRequestPivot request)
        {
            if (request?.AreaPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            List<AreaPivot> results = new List<AreaPivot>();
            AreaPivot result = new AreaPivot();
            switch (request.FindAreaPivot)
            {
                case FindAreaPivot.AreaId:
                    result = _unitOfWork.AreaRepository.GetById(request.AreaPivot.AreaId)?.ToPivot();
                    break;
            }
            return new AreaResponsePivot
            {
                AreaPivotList = results,
                AreaPivot = result
            };
        }
        #endregion
    }
}