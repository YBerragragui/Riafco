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
    /// The NewsletterMailTranslation service class.
    /// </summary>
    public class ServiceNewsletterMailTranslation : IServiceNewsletterMailTranslation
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
        public ServiceNewsletterMailTranslation(IUnitOfWork injectedUnitOfWork)
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
        /// Create new NewsletterMailTranslation.
        /// </summary>
        /// <param name="request">The NewsletterMailTranslation Request Pivot to add.</param>
        /// <returns>NewsletterMailTranslation Response Pivot created.</returns>
        public NewsletterMailTranslationResponsePivot CreateNewsletterMailTranslation(NewsletterMailTranslationRequestPivot request)
        {
            if (request?.NewsletterMailTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            NewsletterMailTranslation newsletterMailTranslation = request.NewsletterMailTranslationPivot.ToEntity();
            _unitOfWork.NewsletterMailTranslationRepository.Insert(newsletterMailTranslation);
            _unitOfWork.Save();
            return new NewsletterMailTranslationResponsePivot
            {
                NewsletterMailTranslationPivot = newsletterMailTranslation.ToPivot()
            };
        }


        /// <summary>
        /// Create new NewsletterMailTranslation.
        /// </summary>
        /// <param name="request">The NewsletterMailTranslation Request Pivot to add.</param>
        /// <returns>NewsletterMailTranslation Response Pivot created.</returns>
        public NewsletterMailTranslationResponsePivot CreateNewsletterMailTranslationRange(NewsletterMailTranslationRequestPivot request)
        {
            if (request?.NewsletterMailTranslationPivotList == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            List<NewsletterMailTranslation> newsletterMailTranslationList = request.NewsletterMailTranslationPivotList.ToEntityList();
            _unitOfWork.NewsletterMailTranslationRepository.Insert(newsletterMailTranslationList);
            _unitOfWork.Save();

            return new NewsletterMailTranslationResponsePivot
            {
                NewsletterMailTranslationPivotList = newsletterMailTranslationList.ToPivotList()
            };
        }

        /// <summary>
        /// Change NewsletterMailTranslation values.
        /// </summary>
        /// <param name="request">The NewsletterMailTranslation Request Pivot to change.</param>
        public void UpdateNewsletterMailTranslation(NewsletterMailTranslationRequestPivot request)
        {
            if (request?.NewsletterMailTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            NewsletterMailTranslation newsletterMailTranslation = _unitOfWork.NewsletterMailTranslationRepository.GetById(request.NewsletterMailTranslationPivot.TranslationId);
            if (request.NewsletterMailTranslationPivot.NewsletterMailSource != null)
            {
                newsletterMailTranslation.NewsletterMailSource = request.NewsletterMailTranslationPivot.NewsletterMailSource;
            }
            newsletterMailTranslation.NewsletterMailSubject = request.NewsletterMailTranslationPivot.NewsletterMailSubject;
            _unitOfWork.Save();
        }

        /// <summary>
        /// Change NewsletterMailTranslation values.
        /// </summary>
        /// <param name="request">The NewsletterMailTranslation Request Pivot to change.</param>
        public void UpdateNewsletterMailTranslationRange(NewsletterMailTranslationRequestPivot request)
        {
            if (request?.NewsletterMailTranslationPivotList == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            foreach (var translation in request.NewsletterMailTranslationPivotList)
            {
                NewsletterMailTranslation newsletterMailTranslation = _unitOfWork.NewsletterMailTranslationRepository.GetById(translation.TranslationId);
                if (translation.NewsletterMailSource != null)
                {
                    newsletterMailTranslation.NewsletterMailSource = translation.NewsletterMailSource;
                }
                newsletterMailTranslation.NewsletterMailSubject = translation.NewsletterMailSubject;
                _unitOfWork.Save();
            }
        }

        /// <summary>
        /// Remove NewsletterMailTranslation.
        /// </summary>
        /// <param name="request">The NewsletterMailTranslation Request Pivot to remove.</param>
        public void DeleteNewsletterMailTranslation(NewsletterMailTranslationRequestPivot request)
        {
            if (request?.NewsletterMailTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            NewsletterMailTranslation newsletterMailTranslation = _unitOfWork.NewsletterMailTranslationRepository.GetById(request.NewsletterMailTranslationPivot.TranslationId);
            _unitOfWork.NewsletterMailTranslationRepository.Delete(newsletterMailTranslation);
            _unitOfWork.Save();
        }

        /// <summary>
        /// Get the list of the NewsletterMailTranslation.
        /// </summary>
        /// <returns>NewsletterMailTranslation Response Pivot response.</returns>
        public NewsletterMailTranslationResponsePivot GetAllNewsletterMailTranslations()
        {
            return new NewsletterMailTranslationResponsePivot
            {
                NewsletterMailTranslationPivotList = _unitOfWork.NewsletterMailTranslationRepository.Get(null, null, "Language,NewsletterMail").ToList().ToPivotList()
            };
        }

        /// <summary>
        /// Search NewsletterMailTranslation by id.
        /// </summary>
        /// <param name="request">The NewsletterMailTranslation Request Pivot to retrive.</param>
        /// <returns>NewsletterMailTranslation Response Pivot response.</returns>
        public NewsletterMailTranslationResponsePivot FindNewsletterMailTranslations(NewsletterMailTranslationRequestPivot request)
        {
            if (request?.NewsletterMailTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            List<NewsletterMailTranslationPivot> results = new List<NewsletterMailTranslationPivot>();
            NewsletterMailTranslationPivot result = new NewsletterMailTranslationPivot();
            switch (request.FindNewsletterMailTranslationPivot)
            {
                case FindNewsletterMailTranslationPivot.NewsletterMailTranslationId:
                    result = _unitOfWork.NewsletterMailTranslationRepository.Get(f => f.TranslationId == request.NewsletterMailTranslationPivot.TranslationId, null, "Language,NewsletterMail")?.FirstOrDefault().ToPivot();
                    break;
                case FindNewsletterMailTranslationPivot.NewsletterMailId:
                    results = _unitOfWork.NewsletterMailTranslationRepository.Get(f => f.NewsletterMailId == request.NewsletterMailTranslationPivot.NewsletterMailId, null, "Language,NewsletterMail")?.ToList().ToPivotList();
                    break;
            }
            return new NewsletterMailTranslationResponsePivot
            {
                NewsletterMailTranslationPivotList = results,
                NewsletterMailTranslationPivot = result
            };
        }
        #endregion
    }
}