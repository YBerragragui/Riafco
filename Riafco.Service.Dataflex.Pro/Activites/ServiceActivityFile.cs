using System;
using System.Collections.Generic;
using System.Linq;
using Riafco.Service.Dataflex.Pro.Activites.Request;
using Riafco.Service.Dataflex.Pro.Activites.Response;
using Riafco.Service.Dataflex.Pro.Activites.Interface;
using Riafco.Service.Dataflex.Pro.UnitOfWork;
using Riafco.Service.Dataflex.Pro.Activites.Assembler;
using Riafco.Entity.Dataflex.Pro.Activites;
using Riafco.Service.Dataflex.Pro.Activites.Data;
using Riafco.Service.Dataflex.Pro.Activites.Data.Enum;

namespace Riafco.Service.Dataflex.Pro.Activites
{
    /// <summary>
    /// The ActivityFile service class.
    /// </summary>
    public class ServiceActivityFile : IServiceActivityFile
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
        public ServiceActivityFile(IUnitOfWork injectedUnitOfWork)
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
        /// Create new ActivityFile.
        /// </summary>
        /// <param name="request">The ActivityFile Request Pivot to add.</param>
        /// <returns>ActivityFile Response Pivot created.</returns>
        public ActivityFileResponsePivot CreateActivityFile(ActivityFileRequestPivot request)
        {
            if (request?.ActivityFilePivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            ActivityFile activityFile = request.ActivityFilePivot.ToEntity();
            _unitOfWork.ActivityFileRepository.Insert(activityFile);
            _unitOfWork.Save();
            return new ActivityFileResponsePivot
            {
                ActivityFilePivot = activityFile.ToPivot()
            };
        }

        /// <summary>
        /// Change ActivityFile values.
        /// </summary>
        /// <param name="request">The ActivityFile Request Pivot to change.</param>
        public void UpdateActivityFile(ActivityFileRequestPivot request)
        {
            if (request?.ActivityFilePivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            ActivityFile activityFile = _unitOfWork.ActivityFileRepository.GetById(request.ActivityFilePivot.ActivityFileId);
            activityFile.ActivityId = request.ActivityFilePivot.ActivityId;
            _unitOfWork.Save();
        }

        /// <summary>
        /// Remove ActivityFile.
        /// </summary>
        /// <param name="request">The ActivityFile Request Pivot to remove.</param>
        public void DeleteActivityFile(ActivityFileRequestPivot request)
        {
            if (request?.ActivityFilePivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            ActivityFile activityFile = _unitOfWork.ActivityFileRepository.GetById(request.ActivityFilePivot.ActivityFileId);
            _unitOfWork.ActivityFileRepository.Delete(activityFile);
            _unitOfWork.Save();
        }

        /// <summary>
        /// Get the list of the ActivityFile.
        /// </summary>
        /// <returns>ActivityFile Response Pivot response.</returns>
        public ActivityFileResponsePivot GetAllActivityFiles()
        {
            return new ActivityFileResponsePivot
            {
                ActivityFilePivotList = _unitOfWork.ActivityFileRepository.Get(null, null, "Activity").ToList().ToPivotList()
            };
        }

        /// <summary>
        /// Search ActivityFile by id.
        /// </summary>
        /// <param name="request">The ActivityFile Request Pivot to retrive.</param>
        /// <returns>ActivityFile Response Pivot response.</returns>
        public ActivityFileResponsePivot FindActivityFiles(ActivityFileRequestPivot request)
        {
            if (request?.ActivityFilePivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            List<ActivityFilePivot> results = new List<ActivityFilePivot>();
            ActivityFilePivot result = new ActivityFilePivot();
            switch (request.FindActivityFilePivot)
            {
                case FindActivityFilePivot.ActivityFileId:
                    result = _unitOfWork.ActivityFileRepository.Get(f => f.ActivityFileId == request.ActivityFilePivot.ActivityFileId, null, "Activity")?.FirstOrDefault().ToPivot();
                    break;
                case FindActivityFilePivot.ActivityId:
                    results = _unitOfWork.ActivityFileRepository.Get(f => f.ActivityId == request.ActivityFilePivot.ActivityId, null, "Activity")?.ToList().ToPivotList();
                    break;
            }
            return new ActivityFileResponsePivot
            {
                ActivityFilePivotList = results,
                ActivityFilePivot = result
            };
        }
        #endregion
    }
}