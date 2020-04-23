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
    /// The NewsletterMail service class.
    /// </summary>
    public class ServiceNewsletterMail : IServiceNewsletterMail
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
        public ServiceNewsletterMail(IUnitOfWork injectedUnitOfWork)
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
        /// Create new NewsletterMail.
        /// </summary>
        /// <param name="request">The NewsletterMail Request Pivot to add.</param>
        /// <returns>NewsletterMail Response Pivot created.</returns>
        public NewsletterMailResponsePivot CreateNewsletterMail(NewsletterMailRequestPivot request)
        {
            if (request?.NewsletterMailPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            NewsletterMail newsletterMail = request.NewsletterMailPivot.ToEntity();
            _unitOfWork.NewsletterMailRepository.Insert(newsletterMail);
            _unitOfWork.Save();
            return new NewsletterMailResponsePivot()
            {
                NewsletterMailPivot = newsletterMail.ToPivot()
            };
        }

        /// <summary>
        /// Change NewsletterMail values.
        /// </summary>
        /// <param name="request">The NewsletterMail Request Pivot to change.</param>
        public void UpdateNewsletterMail(NewsletterMailRequestPivot request)
        {
            if (request?.NewsletterMailPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            NewsletterMail newsletterMail = _unitOfWork.NewsletterMailRepository.GetById(request.NewsletterMailPivot.NewsletterMailId);
            newsletterMail.NewsletterMailId = request.NewsletterMailPivot.NewsletterMailId;
            _unitOfWork.Save();
        }

        /// <summary>
        /// Remove NewsletterMail.
        /// </summary>
        /// <param name="request">The NewsletterMail Request Pivot to remove.</param>
        public void DeleteNewsletterMail(NewsletterMailRequestPivot request)
        {
            if (request?.NewsletterMailPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            NewsletterMail newsletterMail = _unitOfWork.NewsletterMailRepository.GetById(request.NewsletterMailPivot.NewsletterMailId);
            _unitOfWork.NewsletterMailRepository.Delete(newsletterMail);
            _unitOfWork.Save();
        }

        /// <summary>
        /// Get the list of the NewsletterMail.
        /// </summary>
        /// <returns>NewsletterMail Response Pivot response.</returns>
        public NewsletterMailResponsePivot GetAllNewsletterMails()
        {
            return new NewsletterMailResponsePivot()
            {
                NewsletterMailPivotList = _unitOfWork.NewsletterMailRepository.Get().ToList().ToPivotList()
            };
        }

        /// <summary>
        /// Search NewsletterMail by id.
        /// </summary>
        /// <param name="request">The NewsletterMail Request Pivot to retrive.</param>
        /// <returns>NewsletterMail Response Pivot response.</returns>
        public NewsletterMailResponsePivot FindNewsletterMails(NewsletterMailRequestPivot request)
        {
            if (request?.NewsletterMailPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            List<NewsletterMailPivot> results = new List<NewsletterMailPivot>();
            NewsletterMailPivot result = new NewsletterMailPivot();
            switch (request.FindNewsletterMailPivot)
            {
                case FindNewsletterMailPivot.NewsletterMailId:
                    result = _unitOfWork.NewsletterMailRepository.GetById(request.NewsletterMailPivot.NewsletterMailId)?.ToPivot();
                    break;
            }
            return new NewsletterMailResponsePivot
            {
                NewsletterMailPivotList = results,
                NewsletterMailPivot = result
            };
        }
        #endregion
    }
}