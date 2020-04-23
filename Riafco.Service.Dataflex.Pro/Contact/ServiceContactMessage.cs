using System;
using System.Collections.Generic;
using System.Linq;
using Riafco.Service.Dataflex.Pro.Contact.Request;
using Riafco.Service.Dataflex.Pro.Contact.Response;
using Riafco.Service.Dataflex.Pro.Contact.Interface;
using Riafco.Service.Dataflex.Pro.UnitOfWork;
using Riafco.Service.Dataflex.Pro.Contact.Assembler;
using Riafco.Entity.Dataflex.Pro.Contact;
using Riafco.Service.Dataflex.Pro.Contact.Data;
using Riafco.Service.Dataflex.Pro.Contact.Data.Enum;

namespace Riafco.Service.Dataflex.Pro.Contact
{
    /// <summary>
    /// The ContactMessage service class.
    /// </summary>
    public class ServiceContactMessage : IServiceContactMessage
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
        public ServiceContactMessage(IUnitOfWork injectedUnitOfWork)
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
        /// Create new ContactMessage.
        /// </summary>
        /// <param name="request">The ContactMessage Request Pivot to add.</param>
        /// <returns>ContactMessage Response Pivot created.</returns>
        public ContactMessageResponsePivot CreateContactMessage(ContactMessageRequestPivot request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            ContactMessage contactMessage = request.ContactMessagePivot.ToEntity();
            _unitOfWork.ContactMessageRepository.Insert(contactMessage);
            _unitOfWork.Save();
            return new ContactMessageResponsePivot()
            {
                ContactMessagePivot = contactMessage.ToPivot()
            };
        }

        
        /// <summary>
        /// Remove ContactMessage.
        /// </summary>
        /// <param name="request">The ContactMessage Request Pivot to remove.</param>
        public void DeleteContactMessage(ContactMessageRequestPivot request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            ContactMessage contactMessage = _unitOfWork.ContactMessageRepository.GetById(request.ContactMessagePivot.ContactMessageId);
            _unitOfWork.ContactMessageRepository.Delete(contactMessage);
            _unitOfWork.Save();

        }

        /// <summary>
        /// Get the list of the ContactMessage.
        /// </summary>
        /// <returns>ContactMessage Response Pivot response.</returns>
        public ContactMessageResponsePivot GetAllContactMessages()
        {
            return new ContactMessageResponsePivot()
            {
                ContactMessagePivotList = _unitOfWork.ContactMessageRepository.Get().ToList().ToPivotList()
            };

        }

        /// <summary>
        /// Search ContactMessage by id.
        /// </summary>
        /// <param name="request">The ContactMessage Request Pivot to retrive.</param>
        /// <returns>ContactMessage Response Pivot response.</returns>
        public ContactMessageResponsePivot FindContactMessages(ContactMessageRequestPivot request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            List<ContactMessagePivot> results = new List<ContactMessagePivot>();
            ContactMessagePivot result = new ContactMessagePivot();
            switch (request.FindContactMessagePivot)
            {
                case FindContactMessagePivot.ContactMessageId:
                    result = _unitOfWork.ContactMessageRepository.GetById(request.ContactMessagePivot.ContactMessageId)?.ToPivot();
                    break;
            }
            return new ContactMessageResponsePivot()
            {
                ContactMessagePivotList = results,
                ContactMessagePivot = result
            };
        }
        #endregion

    }
}