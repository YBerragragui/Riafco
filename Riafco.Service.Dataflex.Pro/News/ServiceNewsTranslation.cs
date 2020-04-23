using Riafco.Entity.Dataflex.Pro.News;
using Riafco.Service.Dataflex.Pro.News.Assembler;
using Riafco.Service.Dataflex.Pro.News.Data;
using Riafco.Service.Dataflex.Pro.News.Data.Enum;
using Riafco.Service.Dataflex.Pro.News.Interface;
using Riafco.Service.Dataflex.Pro.News.Request;
using Riafco.Service.Dataflex.Pro.News.Response;
using Riafco.Service.Dataflex.Pro.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.Service.Dataflex.Pro.News
{
    /// <summary>
    /// The NewsTranslation service class.
    /// </summary>
    public class ServiceNewsTranslation : IServiceNewsTranslation
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
        public ServiceNewsTranslation(IUnitOfWork injectedUnitOfWork)
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
        /// Create new NewsTranslation.
        /// </summary>
        /// <param name="request">The NewsTranslation Request Pivot to add.</param>
        /// <returns>NewsTranslation Response Pivot created.</returns>
        public NewsTranslationResponsePivot CreateNewsTranslation(NewsTranslationRequestPivot request)
        {
            if (request.NewsTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            NewsTranslation newsTranslation = request.NewsTranslationPivot.ToEntity();
            _unitOfWork.NewsTranslationRepository.Insert(newsTranslation);
            _unitOfWork.Save();
            return new NewsTranslationResponsePivot()
            {
                NewsTranslationPivot = newsTranslation.ToPivot()
            };
        }

        /// <summary>
        /// Create new NewsTranslation.
        /// </summary>
        /// <param name="request">The NewsTranslation Request Pivot to add.</param>
        /// <returns>NewsTranslation Response Pivot created.</returns>
        public NewsTranslationResponsePivot CreateNewsTranslationRange(NewsTranslationRequestPivot request)
        {
            if (request.NewsTranslationPivotList == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            List<NewsTranslation> newsTranslationList = request.NewsTranslationPivotList.ToEntityList();
            _unitOfWork.NewsTranslationRepository.Insert(newsTranslationList);
            _unitOfWork.Save();
            return new NewsTranslationResponsePivot
            {
                NewsTranslationPivotList = newsTranslationList.ToPivotList()
            };
        }

        /// <summary>
        /// Change NewsTranslation values.
        /// </summary>
        /// <param name="request">The NewsTranslation Request Pivot to change.</param>
        public void UpdateNewsTranslation(NewsTranslationRequestPivot request)
        {
            if (request.NewsTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            NewsTranslation newsTranslation = _unitOfWork.NewsTranslationRepository.GetById(request.NewsTranslationPivot.TranslationId);
            newsTranslation.NewsSummary = request.NewsTranslationPivot.NewsSummary;
            newsTranslation.NewsTitle = request.NewsTranslationPivot.NewsTitle;
            newsTranslation.NewsDescription = request.NewsTranslationPivot.NewsDescription;
            _unitOfWork.Save();
        }

        /// <summary>
        /// Change NewsTranslation values.
        /// </summary>
        /// <param name="request">The NewsTranslation Request Pivot to change.</param>
        public void UpdateNewsTranslationRange(NewsTranslationRequestPivot request)
        {
            if (request.NewsTranslationPivotList == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            foreach (var item in request.NewsTranslationPivotList)
            {
                NewsTranslation newsTranslation = _unitOfWork.NewsTranslationRepository.GetById(item.TranslationId);
                newsTranslation.NewsSummary = item.NewsSummary;
                newsTranslation.NewsTitle = item.NewsTitle;
                newsTranslation.NewsDescription = item.NewsDescription;
                _unitOfWork.Save();
            }
        }

        /// <summary>
        /// Remove NewsTranslation.
        /// </summary>
        /// <param name="request">The NewsTranslation Request Pivot to remove.</param>
        public void DeleteNewsTranslation(NewsTranslationRequestPivot request)
        {
            if (request.NewsTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            NewsTranslation newsTranslation = _unitOfWork.NewsTranslationRepository.GetById(request.NewsTranslationPivot.TranslationId);
            _unitOfWork.NewsTranslationRepository.Delete(newsTranslation);
            _unitOfWork.Save();
        }

        /// <summary>
        /// Get the list of the NewsTranslation.
        /// </summary>
        /// <returns>NewsTranslation Response Pivot response.</returns>
        public NewsTranslationResponsePivot GetAllNewsTranslation()
        {
            return new NewsTranslationResponsePivot()
            {
                NewsTranslationPivotList = _unitOfWork.NewsTranslationRepository.Get(null, null, "News,Language").ToList().ToPivotList()
            };

        }

        /// <summary>
        /// Search NewsTranslation by id.
        /// </summary>
        /// <param name="request">The NewsTranslation Request Pivot to retrive.</param>
        /// <returns>NewsTranslation Response Pivot response.</returns>
        public NewsTranslationResponsePivot FindNewsTranslation(NewsTranslationRequestPivot request)
        {
            if (request.NewsTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            List<NewsTranslationPivot> results = new List<NewsTranslationPivot>();
            NewsTranslationPivot result = new NewsTranslationPivot();
            switch (request.FindNewsTranslationPivot)
            {
                case FindNewsTranslationPivot.NewsTranslationId:
                    result = _unitOfWork.NewsTranslationRepository.GetById(request.NewsTranslationPivot.TranslationId)?.ToPivot();
                    break;
                case FindNewsTranslationPivot.NewsId:
                    results = _unitOfWork.NewsTranslationRepository
                        .Get(t => t.NewsId == request.NewsTranslationPivot.NewsId, null, "News,Language")?.ToList()
                        .ToPivotList();
                    break;
                case FindNewsTranslationPivot.LanguageId:
                    results = _unitOfWork.NewsTranslationRepository
                        .Get(t => t.LanguageId == request.NewsTranslationPivot.LanguageId, null, "News,Language")
                        ?.ToList().ToPivotList();
                    break;
            }
            return new NewsTranslationResponsePivot()
            {
                NewsTranslationPivotList = results,
                NewsTranslationPivot = result
            };
        }
        #endregion
    }
}