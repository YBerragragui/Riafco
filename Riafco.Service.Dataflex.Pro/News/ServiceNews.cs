using System;
using System.Collections.Generic;
using System.Linq;
using Riafco.Service.Dataflex.Pro.News.Request;
using Riafco.Service.Dataflex.Pro.News.Response;
using Riafco.Service.Dataflex.Pro.News.Interface;
using Riafco.Service.Dataflex.Pro.UnitOfWork;
using Riafco.Service.Dataflex.Pro.News.Assembler;
using Riafco.Service.Dataflex.Pro.News.Data;
using Riafco.Service.Dataflex.Pro.News.Data.Enum;

namespace Riafco.Service.Dataflex.Pro.News
{
    /// <summary>
    /// The News service class.
    /// </summary>
    public class ServiceNews : IServiceNews
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
        public ServiceNews(IUnitOfWork injectedUnitOfWork)
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
        /// Create new News.
        /// </summary>
        /// <param name="request">The News Request Pivot to add.</param>
        /// <returns>News Response Pivot created.</returns>
        public NewsResponsePivot CreateNews(NewsRequestPivot request)
        {
            if (request?.NewsPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Entity.Dataflex.Pro.News.News news = request.NewsPivot.ToEntity();
            _unitOfWork.NewsRepository.Insert(news);
            _unitOfWork.Save();
            return new NewsResponsePivot()
            {
                NewsPivot = news.ToPivot()
            };
        }

        /// <summary>
        /// Change News values.
        /// </summary>
        /// <param name="request">The News Request Pivot to change.</param>
        public void UpdateNews(NewsRequestPivot request)
        {
            if (request?.NewsPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Entity.Dataflex.Pro.News.News news = _unitOfWork.NewsRepository.GetById(request.NewsPivot.NewsId);
            news.NewsDate = request.NewsPivot.NewsDate;
            if (request.NewsPivot.NewsImage != null)
            {
                news.NewsImage = request.NewsPivot.NewsImage;
            }
            _unitOfWork.Save();
        }

        /// <summary>
        /// Remove News.
        /// </summary>
        /// <param name="request">The News Request Pivot to remove.</param>
        public void DeleteNews(NewsRequestPivot request)
        {
            if (request?.NewsPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            Entity.Dataflex.Pro.News.News news = _unitOfWork.NewsRepository.GetById(request.NewsPivot.NewsId);
            _unitOfWork.NewsRepository.Delete(news);
            _unitOfWork.Save();
        }

        /// <summary>
        /// Get the list of the News.
        /// </summary>
        /// <returns>News Response Pivot response.</returns>
        public NewsResponsePivot GetAllNews()
        {
            return new NewsResponsePivot()
            {
                NewsPivotList = _unitOfWork.NewsRepository.Get().ToList().ToPivotList()
            };

        }

        /// <summary>
        /// Search News by id.
        /// </summary>
        /// <param name="request">The News Request Pivot to retrive.</param>
        /// <returns>News Response Pivot response.</returns>
        public NewsResponsePivot FindNews(NewsRequestPivot request)
        {
            if (request?.NewsPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            List<NewsPivot> results = new List<NewsPivot>();
            NewsPivot result = new NewsPivot();
            switch (request.FindNewsPivot)
            {
                case FindNewsPivot.NewsId:
                    result = _unitOfWork.NewsRepository.GetById(request.NewsPivot.NewsId)?.ToPivot();
                    break;
            }
            return new NewsResponsePivot()
            {
                NewsPivotList = results,
                NewsPivot = result
            };
        }
        #endregion
    }
}