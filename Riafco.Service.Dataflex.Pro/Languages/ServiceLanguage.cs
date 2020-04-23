using Riafco.Entity.Dataflex.Pro.Languages;
using Riafco.Service.Dataflex.Pro.Languages.Assembler;
using Riafco.Service.Dataflex.Pro.Languages.Data;
using Riafco.Service.Dataflex.Pro.Languages.Data.Enum;
using Riafco.Service.Dataflex.Pro.Languages.Interface;
using Riafco.Service.Dataflex.Pro.Languages.Request;
using Riafco.Service.Dataflex.Pro.Languages.Response;
using Riafco.Service.Dataflex.Pro.UnitOfWork;
using System;
using System.Linq;

namespace Riafco.Service.Dataflex.Pro.Languages
{
    /// <summary>
    /// The Language service class.
    /// </summary>
    public class ServiceLanguage : IServiceLanguage
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
        public ServiceLanguage(IUnitOfWork injectedUnitOfWork)
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
        /// Create new Language.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Language Response Pivot added.</returns>
        public LanguageResponsePivot CreateLanguage(LanguageRequestPivot request)
        {
            if (request?.LanguagePivot == null)
            {
                throw new ArgumentNullException($"The request pivot is null.");
            }

            Language language = request.LanguagePivot.ToEntity();
            _unitOfWork.LanguageRepository.Insert(language);
            _unitOfWork.Save();
            return new LanguageResponsePivot()
            {
                LanguagePivot = language.ToPivot()
            };
        }

        /// <summary>
        /// Change Language values.
        /// </summary>
        /// <param name="request">The Language Request Pivot to change.</param>
        public void UpdateLanguage(LanguageRequestPivot request)
        {
            if (request?.LanguagePivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Language language = _unitOfWork.LanguageRepository.GetById(request.LanguagePivot.LanguageId);
            language.LanguagePrefix = request.LanguagePivot.LanguagePrefix;
            if (request.LanguagePivot.LanguagePicture != null) { language.LanguagePicture = request.LanguagePivot.LanguagePicture; }
            _unitOfWork.Save();
        }

        /// <summary>
        /// Remove Language.
        /// </summary>
        /// <param name="request">The Language Request Pivot to remove.</param>
        public void DeleteLanguage(LanguageRequestPivot request)
        {
            if (request?.LanguagePivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Language language = _unitOfWork.LanguageRepository.GetById(request.LanguagePivot.LanguageId);
            _unitOfWork.LanguageRepository.Delete(language);
            _unitOfWork.Save();
        }

        /// <summary>
        /// Get the list of the Language.
        /// </summary>
        /// <returns>Language Response Pivot response.</returns>
        public LanguageResponsePivot GetAllLanguages()
        {
            return new LanguageResponsePivot()
            {
                LanguagePivotList = _unitOfWork.LanguageRepository.Get().ToList().ToPivotList()
            };
        }

        /// <summary>
        /// Search Language by id.
        /// </summary>
        /// <param name="request">The Language Request Pivot to retrive.</param>
        /// <returns>Language Response Pivot response.</returns>
        public LanguageResponsePivot FindLanguages(LanguageRequestPivot request)
        {
            if (request?.LanguagePivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            LanguagePivot result = new LanguagePivot();
            switch (request.FindLanguagePivot)
            {
                case FindLanguagePivot.LanguageId:
                    result = _unitOfWork.LanguageRepository.Get(c => c.LanguageId == request.LanguagePivot.LanguageId)?.FirstOrDefault().ToPivot();
                    break;
            }
            return new LanguageResponsePivot()
            {
                LanguagePivot = result
            };
        }
        #endregion
    }
}