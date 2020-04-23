using Riafco.Entity.Dataflex.Pro.Ressources;
using Riafco.Service.Dataflex.Pro.Ressources.Assembler;
using Riafco.Service.Dataflex.Pro.Ressources.Data;
using Riafco.Service.Dataflex.Pro.Ressources.Data.Enum;
using Riafco.Service.Dataflex.Pro.Ressources.Interface;
using Riafco.Service.Dataflex.Pro.Ressources.Request;
using Riafco.Service.Dataflex.Pro.Ressources.Response;
using Riafco.Service.Dataflex.Pro.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.Service.Dataflex.Pro.Ressources
{
    /// <summary>
    /// The PublicationTheme service class.
    /// </summary>
    public class ServicePublicationTheme : IServicePublicationTheme
    {
        #region private attribute

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
        public ServicePublicationTheme(IUnitOfWork injectedUnitOfWork)
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
        /// Create new PublicationTheme.
        /// </summary>
        /// <param name="request">The PublicationTheme Request Pivot to add.</param>
        /// <returns>PublicationTheme Response Pivot created.</returns>
        public PublicationThemeResponsePivot CreatePublicationTheme(PublicationThemeRequestPivot request)
        {
            if (request?.PublicationThemePivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            PublicationTheme publicationTheme = request.PublicationThemePivot.ToEntity();
            _unitOfWork.PublicationThemeRepository.Insert(publicationTheme);
            _unitOfWork.Save();
            return new PublicationThemeResponsePivot
            {
                PublicationThemePivot = publicationTheme.ToPivot()
            };
        }

        /// <summary>
        /// Create new PublicationTheme.
        /// </summary>
        /// <param name="request">The PublicationTheme Request Pivot to add.</param>
        /// <returns>PublicationTheme Response Pivot created.</returns>
        public PublicationThemeResponsePivot CreatePublicationThemeRange(PublicationThemeRequestPivot request)
        {
            if (request?.PublicationThemePivotList == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            List<PublicationTheme> publicationThemeList = request.PublicationThemePivotList.ToEntityList();
            _unitOfWork.PublicationThemeRepository.Insert(publicationThemeList);
            _unitOfWork.Save();
            return new PublicationThemeResponsePivot
            {
                PublicationThemePivotList = publicationThemeList.ToPivotList()
            };
        }

        /// <summary>
        /// Change PublicationTheme values.
        /// </summary>
        /// <param name="request">The PublicationTheme Request Pivot to change.</param>
        public void UpdatePublicationTheme(PublicationThemeRequestPivot request)
        {
            if (request?.PublicationThemePivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            PublicationTheme publicationTheme = _unitOfWork.PublicationThemeRepository.GetById(request.PublicationThemePivot.PublicationThemeId);
            publicationTheme.PublicationId = request.PublicationThemePivot.PublicationId;
            publicationTheme.ThemeId = request.PublicationThemePivot.ThemeId;
            _unitOfWork.Save();
        }

        /// <summary>
        /// Change PublicationTheme values Range.
        /// </summary>
        /// <param name="request">The PublicationTheme Request Pivot to change.</param>
        public void UpdatePublicationThemeRange(PublicationThemeRequestPivot request)
        {
            if (request?.PublicationThemePivotList == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            foreach (PublicationThemePivot publicationThemePivot in request.PublicationThemePivotList)
            {
                PublicationTheme publicationTheme = _unitOfWork.PublicationThemeRepository.GetById(publicationThemePivot.PublicationThemeId);
                publicationTheme.PublicationId = publicationThemePivot.PublicationId;
                publicationTheme.ThemeId = publicationThemePivot.ThemeId;
                _unitOfWork.Save();
            }
        }

        /// <summary>
        /// Remove PublicationTheme.
        /// </summary>
        /// <param name="request">The PublicationTheme Request Pivot to remove.</param>
        public void DeletePublicationTheme(PublicationThemeRequestPivot request)
        {
            if (request?.PublicationThemePivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            PublicationTheme publicationTheme = _unitOfWork.PublicationThemeRepository.GetById(request.PublicationThemePivot.PublicationThemeId);
            _unitOfWork.PublicationThemeRepository.Delete(publicationTheme);
            _unitOfWork.Save();
        }

        /// <summary>
        /// Get the list of the PublicationTheme.
        /// </summary>
        /// <returns>PublicationTheme Response Pivot response.</returns>
        public PublicationThemeResponsePivot GetAllPublicationThemes()
        {
            return new PublicationThemeResponsePivot
            {
                PublicationThemePivotList = _unitOfWork.PublicationThemeRepository.Get().ToList().ToPivotList()
            };
        }

        /// <summary>
        /// Search PublicationTheme.
        /// </summary>
        /// <param name="request">The PublicationTheme Request Pivot to retrive.</param>
        /// <returns>PublicationTheme Response Pivot response.</returns>
        public PublicationThemeResponsePivot FindPublicationThemes(PublicationThemeRequestPivot request)
        {
            if (request?.PublicationThemePivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            List<PublicationThemePivot> results = new List<PublicationThemePivot>();
            PublicationThemePivot result = new PublicationThemePivot();

            List<PublicationTranslationPivot> publicationTranslationPivotList = new List<PublicationTranslationPivot>();
            PublicationTranslationPivot publicationTranslationPivot = new PublicationTranslationPivot();

            List<ThemeTranslationPivot> themeTranslationPivotList = new List<ThemeTranslationPivot>();
            ThemeTranslationPivot themeTranslationPivot = new ThemeTranslationPivot();

            switch (request.FindPublicationThemePivot)
            {
                case FindPublicationThemePivot.PublicationThemeId:
                    result = _unitOfWork.PublicationThemeRepository
                        .Get(p => p.PublicationThemeId == request.PublicationThemePivot.PublicationThemeId)
                        ?.FirstOrDefault().ToPivot();

                    themeTranslationPivot = _unitOfWork.ThemeTranslationRepository
                        .Get(t => t.ThemeId == request.PublicationThemePivot.ThemeId).FirstOrDefault().ToPivot();

                    publicationTranslationPivot = _unitOfWork.PublicationTranslationRepository
                        .Get(p => p.PublicationId == request.PublicationThemePivot.PublicationId).FirstOrDefault()
                        .ToPivot();
                    break;
                case FindPublicationThemePivot.PublicationId:
                    results = _unitOfWork.PublicationThemeRepository
                        .Get(p => p.PublicationId == request.PublicationThemePivot.PublicationId)?.ToList()
                        .ToPivotList();

                    if (results != null)
                    {
                        foreach (PublicationThemePivot publicationThemePivot in results)
                        {
                            publicationTranslationPivotList.AddRange(_unitOfWork.PublicationTranslationRepository
                                .Get(p => p.PublicationId == publicationThemePivot.PublicationId).ToList()
                                .ToPivotList());

                            themeTranslationPivotList.AddRange(_unitOfWork.ThemeTranslationRepository
                                .Get(t => t.ThemeId == publicationThemePivot.ThemeId).ToList()
                                .ToPivotList());
                        }
                    }
                    break;
                case FindPublicationThemePivot.ThemeId:
                    results = _unitOfWork.PublicationThemeRepository
                        .Get(p => p.ThemeId == request.PublicationThemePivot.ThemeId)?.ToList().ToPivotList();

                    if (results != null)
                    {
                        foreach (PublicationThemePivot publicationThemePivot in results)
                        {
                            publicationTranslationPivotList.AddRange(_unitOfWork.PublicationTranslationRepository
                                .Get(p => p.PublicationId == publicationThemePivot.PublicationId).ToList()
                                .ToPivotList());

                            themeTranslationPivotList.AddRange(_unitOfWork.ThemeTranslationRepository
                                .Get(t => t.ThemeId == publicationThemePivot.ThemeId).ToList()
                                .ToPivotList());
                        }
                    }
                    break;
                case FindPublicationThemePivot.PublicationIdAndThemeId:
                    result = _unitOfWork.PublicationThemeRepository
                        .Get(
                            p => p.ThemeId == request.PublicationThemePivot.ThemeId &&
                                 p.PublicationId == request.PublicationThemePivot.PublicationId
                        )?.FirstOrDefault().ToPivot();

                    themeTranslationPivot = _unitOfWork.ThemeTranslationRepository
                        .Get(t => t.ThemeId == request.PublicationThemePivot.ThemeId).FirstOrDefault().ToPivot();

                    publicationTranslationPivot = _unitOfWork.PublicationTranslationRepository
                        .Get(p => p.PublicationId == request.PublicationThemePivot.PublicationId).FirstOrDefault()
                        .ToPivot();
                    break;
            }
            return new PublicationThemeResponsePivot
            {
                PublicationTranslationPivotList = publicationTranslationPivotList,
                PublicationTranslationPivot = publicationTranslationPivot,

                ThemeTranslationPivotList = themeTranslationPivotList,
                ThemeTranslationPivot = themeTranslationPivot,

                PublicationThemePivotList = results,
                PublicationThemePivot = result
            };
        }
        #endregion
    }
}