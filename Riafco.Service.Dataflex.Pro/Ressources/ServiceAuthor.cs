using System;
using System.Collections.Generic;
using System.Linq;
using Riafco.Service.Dataflex.Pro.Ressources.Request;
using Riafco.Service.Dataflex.Pro.Ressources.Response;
using Riafco.Service.Dataflex.Pro.Ressources.Interface;
using Riafco.Service.Dataflex.Pro.UnitOfWork;
using Riafco.Service.Dataflex.Pro.Ressources.Assembler;
using Riafco.Entity.Dataflex.Pro.Ressources;
using Riafco.Service.Dataflex.Pro.Ressources.Data;
using Riafco.Service.Dataflex.Pro.Ressources.Data.Enum;

namespace Riafco.Service.Dataflex.Pro.Ressources
{
    /// <summary>
    /// The Author service class.
    /// </summary>
    public class ServiceAuthor : IServiceAuthor
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
        public ServiceAuthor(IUnitOfWork injectedUnitOfWork)
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
        /// Create new Author.
        /// </summary>
        /// <param name="request">The Author Request Pivot to add.</param>
        /// <returns>Author Response Pivot created.</returns>
        public AuthorResponsePivot CreateAuthor(AuthorRequestPivot request)
        {
            if (request?.AuthorPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Author author = request.AuthorPivot.ToEntity();
            _unitOfWork.AuthorRepository.Insert(author);
            _unitOfWork.Save();
            return new AuthorResponsePivot
            {
                AuthorPivot = author.ToPivot()
            };
        }

        /// <summary>
        /// Change Author values.
        /// </summary>
        /// <param name="request">The Author Request Pivot to change.</param>
        public void UpdateAuthor(AuthorRequestPivot request)
        {
            if (request?.AuthorPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Author author = _unitOfWork.AuthorRepository.GetById(request.AuthorPivot.AuthorId);
            author.AuthorFirstName = request.AuthorPivot.AuthorFirstName;
            author.AuthorLastName = request.AuthorPivot.AuthorLastName;
            _unitOfWork.Save();
        }

        /// <summary>
        /// Remove Author.
        /// </summary>
        /// <param name="request">The Author Request Pivot to remove.</param>
        public void DeleteAuthor(AuthorRequestPivot request)
        {
            if (request?.AuthorPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Author author = _unitOfWork.AuthorRepository.GetById(request.AuthorPivot.AuthorId);
            _unitOfWork.AuthorRepository.Delete(author);
            _unitOfWork.Save();
        }

        /// <summary>
        /// Get the list of the Author.
        /// </summary>
        /// <returns>Author Response Pivot response.</returns>
        public AuthorResponsePivot GetAllAuthors()
        {
            return new AuthorResponsePivot
            {
                AuthorPivotList = _unitOfWork.AuthorRepository.Get().ToList().ToPivotList()
            };
        }

        /// <summary>
        /// Search Author by id.
        /// </summary>
        /// <param name="request">The Author Request Pivot to retrive.</param>
        /// <returns>Author Response Pivot response.</returns>
        public AuthorResponsePivot FindAuthors(AuthorRequestPivot request)
        {
            if (request?.AuthorPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            List<AuthorPivot> results = new List<AuthorPivot>();
            AuthorPivot result = new AuthorPivot();
            switch (request.FindAuthorPivot)
            {
                case FindAuthorPivot.AuthorId:
                    result = _unitOfWork.AuthorRepository.GetById(request.AuthorPivot.AuthorId)?.ToPivot();
                    break;
            }
            return new AuthorResponsePivot
            {
                AuthorPivotList = results,
                AuthorPivot = result
            };
        }
        #endregion
    }
}