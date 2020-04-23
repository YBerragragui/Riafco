using Riafco.Entity.Dataflex.Pro.Activites;
using Riafco.Service.Dataflex.Pro.Activites.Assembler;
using Riafco.Service.Dataflex.Pro.Activites.Data;
using Riafco.Service.Dataflex.Pro.Activites.Data.Enum;
using Riafco.Service.Dataflex.Pro.Activites.Interface;
using Riafco.Service.Dataflex.Pro.Activites.Request;
using Riafco.Service.Dataflex.Pro.Activites.Response;
using Riafco.Service.Dataflex.Pro.UnitOfWork;
using System;
using System.Linq;

namespace Riafco.Service.Dataflex.Pro.Activites
{
    /// <summary>
    /// The Activity service class.
    /// </summary>
    public class ServiceActivity : IServiceActivity
    {
        #region private attributes

        /// <summary>
        /// The UnitOfWork instance.
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region contructors
        /// <summary>
        /// Constructor to create instance of the _unitOfWork.
        /// </summary>
        /// <param name="injectedUnitOfWork">the injected UnitOfWork to instance UnitOfWork attribute.</param>
        public ServiceActivity(IUnitOfWork injectedUnitOfWork)
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
        /// Create new Activity.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Activity Response Pivot added.</returns>
        public ActivityResponsePivot CreateActivity(ActivityRequestPivot request)
        {
            if (request?.ActivityPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Activity activity = request.ActivityPivot.ToEntity();
            _unitOfWork.ActivityRepository.Insert(activity);
            _unitOfWork.Save();
            return new ActivityResponsePivot
            {
                ActivityPivot = activity.ToPivot()
            };
        }

        /// <summary>
        /// Change Activity values.
        /// </summary>
        /// <param name="request">The Activity Request Pivot to change.</param>
        public void UpdateActivity(ActivityRequestPivot request)
        {
            if (request?.ActivityPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Activity activity = _unitOfWork.ActivityRepository.GetById(request.ActivityPivot.ActivityId);
            if (request.ActivityPivot.ActivityIcon != null)
            {
                activity.ActivityIcon = request.ActivityPivot.ActivityIcon;
            }
            if (request.ActivityPivot.ActivityImage != null)
            {
                activity.ActivityImage = request.ActivityPivot.ActivityImage;
            }
            _unitOfWork.Save();
        }

        /// <summary>
        /// Remove Activity.
        /// </summary>
        /// <param name="request">The Activity Request Pivot to remove.</param>
        public void DeleteActivity(ActivityRequestPivot request)
        {
            if (request?.ActivityPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Activity activity = _unitOfWork.ActivityRepository.GetById(request.ActivityPivot.ActivityId);
            _unitOfWork.ActivityRepository.Delete(activity);
            _unitOfWork.Save();
        }

        /// <summary>
        /// Get the list of the Activity.
        /// </summary>
        /// <returns>Activity Response Pivot response.</returns>
        public ActivityResponsePivot GetAllActivities()
        {
            return new ActivityResponsePivot
            {
                ActivityPivotList = _unitOfWork.ActivityRepository.Get().ToList().ToPivotList()
            };
        }

        /// <summary>
        /// Search Activity by id.
        /// </summary>
        /// <param name="request">The Activity Request Pivot to retrive.</param>
        /// <returns>Activity Response Pivot response.</returns>
        public ActivityResponsePivot FindActivities(ActivityRequestPivot request)
        {
            if (request?.ActivityPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            ActivityPivot result = new ActivityPivot();
            switch (request.FindActivityPivot)
            {
                case FindActivityPivot.ActivityId:
                    result = _unitOfWork.ActivityRepository.Get(c => c.ActivityId == request.ActivityPivot.ActivityId)?.FirstOrDefault().ToPivot();
                    break;
            }
            return new ActivityResponsePivot
            {
                ActivityPivot = result
            };
        }
        #endregion
    }
}