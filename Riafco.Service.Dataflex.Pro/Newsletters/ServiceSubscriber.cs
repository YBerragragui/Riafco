using System;
using System.Collections.Generic;
using System.Linq;
using Riafco.Service.Dataflex.Pro.Newsletters.Request;
using Riafco.Service.Dataflex.Pro.Newsletters.Response;
using Riafco.Service.Dataflex.Pro.Newsletters.Interface;
using Riafco.Service.Dataflex.Pro.UnitOfWork;
using Riafco.Service.Dataflex.Pro.Newsletters.Assembler;
using Riafco.Entity.Dataflex.Pro.Newsletters;
using Riafco.Service.Dataflex.Pro.Newsletters.Data;
using Riafco.Service.Dataflex.Pro.Newsletters.Data.Enum;

namespace Riafco.Service.Dataflex.Pro.Newsletters
{
    /// <summary>
    /// The Subscriber service class.
    /// </summary>
    public class ServiceSubscriber : IServiceSubscriber
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
        public ServiceSubscriber(IUnitOfWork injectedUnitOfWork)
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
        /// Create new Subscriber.
        /// </summary>
        /// <param name="request">The Subscriber Request Pivot to add.</param>
        /// <returns>Subscriber Response Pivot created.</returns>
        public SubscriberResponsePivot CreateSubscriber(SubscriberRequestPivot request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            Subscriber subscriber = request.SubscriberPivot.ToEntity();
            _unitOfWork.SubscriberRepository.Insert(subscriber);
            _unitOfWork.Save();
            return new SubscriberResponsePivot()
            {
                SubscriberPivot = subscriber.ToPivot()
            };
        }

        /// <summary>
        /// Change Subscriber values.
        /// </summary>
        /// <param name="request">The Subscriber Request Pivot to change.</param>
        public void UpdateSubscriber(SubscriberRequestPivot request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            Subscriber subscriber = _unitOfWork.SubscriberRepository.GetById(request.SubscriberPivot.SubscriberId);
            subscriber.SubscriberFirstName = request.SubscriberPivot.SubscriberFirstName;
            subscriber.SubscriberLastName = request.SubscriberPivot.SubscriberLastName;
            subscriber.SubscriberEmail = request.SubscriberPivot.SubscriberEmail;
            _unitOfWork.Save();

        }

        /// <summary>
        /// Remove Subscriber.
        /// </summary>
        /// <param name="request">The Subscriber Request Pivot to remove.</param>
        public void DeleteSubscriber(SubscriberRequestPivot request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            Subscriber subscriber = _unitOfWork.SubscriberRepository.GetById(request.SubscriberPivot.SubscriberId);
            _unitOfWork.SubscriberRepository.Delete(subscriber);
            _unitOfWork.Save();
        }

        /// <summary>
        /// Get the list of the Subscriber.
        /// </summary>
        /// <returns>Subscriber Response Pivot response.</returns>
        public SubscriberResponsePivot GetAllSubscribers()
        {
            return new SubscriberResponsePivot()
            {
                SubscriberPivotList = _unitOfWork.SubscriberRepository.Get().ToList().ToPivotList()
            };

        }

        /// <summary>
        /// Search Subscriber by id.
        /// </summary>
        /// <param name="request">The Subscriber Request Pivot to retrive.</param>
        /// <returns>Subscriber Response Pivot response.</returns>
        public SubscriberResponsePivot FindSubscribers(SubscriberRequestPivot request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            List<SubscriberPivot> results = new List<SubscriberPivot>();
            SubscriberPivot result = new SubscriberPivot();
            switch (request.FindSubscriberPivot)
            {
                case FindSubscriberPivot.SubscriberId:
                    result = _unitOfWork.SubscriberRepository.GetById(request.SubscriberPivot.SubscriberId)?.ToPivot();
                    break;
            }
            return new SubscriberResponsePivot()
            {
                SubscriberPivotList = results,
                SubscriberPivot = result
            };
        }
        #endregion

    }
}