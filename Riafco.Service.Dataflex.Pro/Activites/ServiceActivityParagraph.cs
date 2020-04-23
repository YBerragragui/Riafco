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
    /// The ActivityParagraph service class.
    /// </summary>
    public class ServiceActivityParagraph : IServiceActivityParagraph
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
        public ServiceActivityParagraph(IUnitOfWork injectedUnitOfWork)
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
        /// Create new ActivityParagraph.
        /// </summary>
        /// <param name="request">The ActivityParagraph Request Pivot to add.</param>
        /// <returns>ActivityParagraph Response Pivot added.</returns>
        public ActivityParagraphResponsePivot CreateActivityParagraph(ActivityParagraphRequestPivot request)
        {
            if (request?.ActivityParagraphPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            ActivityParagraph activityParagraph = request.ActivityParagraphPivot.ToEntity();
            _unitOfWork.ActivityParagraphRepository.Insert(activityParagraph);
            _unitOfWork.Save();
            return new ActivityParagraphResponsePivot
            {
                ActivityParagraphPivot = activityParagraph.ToPivot()
            };
        }

        /// <summary>
        /// Change ActivityParagraph values.
        /// </summary>
        /// <param name="request">The ActivityParagraph Request Pivot to change.</param>
        public void UpdateActivityParagraph(ActivityParagraphRequestPivot request)
        {
            if (request?.ActivityParagraphPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            ActivityParagraph activityParagraph = _unitOfWork.ActivityParagraphRepository.GetById(request.ActivityParagraphPivot.ParagraphId);
            if (request.ActivityParagraphPivot.ParagraphImage != null) { activityParagraph.ParagraphImage = request.ActivityParagraphPivot.ParagraphImage; }
            _unitOfWork.Save();
        }

        /// <summary>
        /// Remove ActivityParagraph.
        /// </summary>
        /// <param name="request">The ActivityParagraph Request Pivot to remove.</param>
        public void DeleteActivityParagraph(ActivityParagraphRequestPivot request)
        {
            if (request?.ActivityParagraphPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            ActivityParagraph activityParagraph = _unitOfWork.ActivityParagraphRepository.GetById(request.ActivityParagraphPivot.ParagraphId);
            _unitOfWork.ActivityParagraphRepository.Delete(activityParagraph);
            _unitOfWork.Save();
        }

        /// <summary>
        /// Get the list of the ActivityParagraph.
        /// </summary>
        /// <returns>ActivityParagraph Response Pivot response.</returns>
        public ActivityParagraphResponsePivot GetAllActivityParagraphs()
        {
            return new ActivityParagraphResponsePivot
            {
                ActivityParagraphPivotList = _unitOfWork.ActivityParagraphRepository.Get(null, null, "Activity").ToList().ToPivotList()
            };
        }

        /// <summary>
        /// Search ActivityParagraph by id.
        /// </summary>
        /// <param name="request">The ActivityParagraph Request Pivot to retrive.</param>
        /// <returns>ActivityParagraph Response Pivot response.</returns>
        public ActivityParagraphResponsePivot FindActivityParagraphs(ActivityParagraphRequestPivot request)
        {
            if (request?.ActivityParagraphPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            List<ActivityParagraphPivot> results = new List<ActivityParagraphPivot>();
            ActivityParagraphPivot result = new ActivityParagraphPivot();
            switch (request.FindActivityParagraphPivot)
            {
                case FindActivityParagraphPivot.ActivityParagraphId:
                    result = _unitOfWork.ActivityParagraphRepository.Get(p => p.ParagraphId == request.ActivityParagraphPivot.ParagraphId, null, "Activity")?.FirstOrDefault().ToPivot();
                    break;
                case FindActivityParagraphPivot.ActivityId:
                    results = _unitOfWork.ActivityParagraphRepository.Get(p => p.ActivityId == request.ActivityParagraphPivot.ActivityId, null, "Activity")?.ToList().ToPivotList();
                    break;
            }

            return new ActivityParagraphResponsePivot
            {
                ActivityParagraphPivotList = results,
                ActivityParagraphPivot = result 
            };
        }
        #endregion
    }
}