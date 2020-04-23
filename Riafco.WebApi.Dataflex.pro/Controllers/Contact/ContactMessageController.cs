using Riafco.Framework.Dataflex.pro.Communication.Messages.Enum;
using Riafco.Framework.Dataflex.pro.Web.Validation;
using Riafco.WebApi.Service.Dataflex.pro.Contact.Dto;
using Riafco.WebApi.Service.Dataflex.pro.Contact.Interface;
using Riafco.WebApi.Service.Dataflex.pro.Contact.Message;
using Riafco.WebApi.Service.Dataflex.pro.Contact.Request;
using Riafco.WebApi.Service.Dataflex.pro.Contact.Ressource;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Riafco.WebApi.Dataflex.pro.Controllers.Contact
{
    /// <summary>
    /// The ContactMessage web api controller.
    /// </summary>
    [RoutePrefix("api/Contact")]
    public class ContactMessageController : ApiController
    {
        #region private properties
        /// <summary>
        /// The ContactMessage service client instance.
        /// </summary>
        private readonly IServiceContactMessageClient _serviceContactMessageClient;
        #endregion

        #region constructor
        /// <summary>
        /// Set the IServiceContactMessageClient instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceContactMessageClient">injected instance</param>
        public ContactMessageController(IServiceContactMessageClient injectedServiceContactMessageClient)
        {
            _serviceContactMessageClient = injectedServiceContactMessageClient;
        }
        #endregion

        #region public methods ContactMessages
        /// <summary>
        /// Create new ContactMessage
        /// </summary>
        /// <returns>ContactMessage message.</returns>
        [Route("CreateContactMessage")]
        public IHttpActionResult CreateContactMessage(ContactMessageRequest request)
        {
            List<string> errors = ValidateCreateContactMessage(request);
            ContactMessageMessage message = new ContactMessageMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ContactMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceContactMessageClient.CreateContactMessage(request);
            }
            return Json(message);
        }


        /// <summary>
        /// Delete ContactMessage
        /// </summary>
        /// <returns>ContactMessage message.</returns>
        [Route("RemoveContactMessage")]
        public IHttpActionResult DeleteContactMessage(int partnerId)
        {
            ContactMessageRequest request = new ContactMessageRequest
            {
                ContactMessageDto = new ContactMessageDto { ContactMessageId = partnerId }
            };
            List<string> errors = ValidateDeleteContactMessage(request);
            ContactMessageMessage message = new ContactMessageMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ContactMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceContactMessageClient.DeleteContactMessage(request);
            }
            return Json(message);
        }

        /// <summary>
        /// Get list of ContactMessage
        /// </summary>
        /// <returns>ContactMessage message.</returns>
        [Route("GetContactMessages")]
        public IHttpActionResult GetAllContactMessages()
        {
            ContactMessageMessage message = _serviceContactMessageClient.GetAllContactMessages();
            return Json(message);
        }

        /// <summary>
        /// Find ContactMessage
        /// </summary>
        /// <returns>ContactMessage message.</returns>
        [Route("FindContactMessages")]
        public IHttpActionResult FindContactMessages(ContactMessageRequest request)
        {
            List<string> errors = ValidateFindContactMessages(request);
            ContactMessageMessage message = new ContactMessageMessage();

            if (errors != null && errors.Any())
            {
                message.ErrorMessage = ContactMessageResource.ValidationErrors;
                message.ErrorType = ErrorType.ValidationError;
                message.Errors = new List<string>();
                message.OperationSuccess = false;
                message.Errors.AddRange(errors);
            }
            else
            {
                message = _serviceContactMessageClient.FindContactMessages(request);
            }
            return Json(message);
        }
        #endregion

        #region private validation partner methods
        /// <summary>
        /// Validation creation partner.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateCreateContactMessage(ContactMessageRequest request)
        {
            var errors = new List<string>();
            if (request?.ContactMessageDto == null)
            {
                errors.Add(ContactMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<ContactMessageDto>.ValidateAttributes("ContactMessageFirstName", request.ContactMessageDto.ContactMessageFirstName));
                errors.AddRange(GenericValidationAttribute<ContactMessageDto>.ValidateAttributes("ContactMessageLastName", request.ContactMessageDto.ContactMessageLastName));
                errors.AddRange(GenericValidationAttribute<ContactMessageDto>.ValidateAttributes("ContactMessageMail", request.ContactMessageDto.ContactMessageMail));
                errors.AddRange(GenericValidationAttribute<ContactMessageDto>.ValidateAttributes("ContactMessageSubject", request.ContactMessageDto.ContactMessageSubject));
                errors.AddRange(GenericValidationAttribute<ContactMessageDto>.ValidateAttributes("ContactMessageText", request.ContactMessageDto.ContactMessageText));
                errors.AddRange(GenericValidationAttribute<ContactMessageDto>.ValidateAttributes("LanguageId", request.ContactMessageDto.LanguageId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validation delete partner.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateDeleteContactMessage(ContactMessageRequest request)
        {
            var errors = new List<string>();
            if (request?.ContactMessageDto == null)
            {
                errors.Add(ContactMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<ContactMessageDto>.ValidateAttributes("ContactMessageId", request.ContactMessageDto.ContactMessageId.ToString()));
            }
            return errors;
        }

        /// <summary>
        /// Validation delete partner.
        /// </summary>
        /// <param name="request">the request to validate.</param>
        /// <returns>errors validation</returns>
        private List<string> ValidateFindContactMessages(ContactMessageRequest request)
        {
            var errors = new List<string>();
            if (request?.ContactMessageDto == null)
            {
                errors.Add(ContactMessageResource.NullRequest);
            }
            else
            {
                errors.AddRange(GenericValidationAttribute<ContactMessageDto>.ValidateAttributes("ContactMessageId", request.ContactMessageDto.ContactMessageId.ToString()));
            }
            return errors;
        }
        #endregion
    }
}