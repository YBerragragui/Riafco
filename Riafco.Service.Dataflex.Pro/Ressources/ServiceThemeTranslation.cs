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
    /// The ThemeTranslation service class.
    /// </summary>
    public class ServiceThemeTranslation : IServiceThemeTranslation
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
        public ServiceThemeTranslation(IUnitOfWork injectedUnitOfWork)
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
        /// Create new ThemeTranslation.
        /// </summary>
        /// <param name="request">The ThemeTranslation Request Pivot to add.</param>
        /// <returns>ThemeTranslation Response Pivot created.</returns>
        public ThemeTranslationResponsePivot CreateThemeTranslation(ThemeTranslationRequestPivot request)
        {
            if (request?.ThemeTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            ThemeTranslation themeTranslation = request.ThemeTranslationPivot.ToEntity();
            _unitOfWork.ThemeTranslationRepository.Insert(themeTranslation);
            _unitOfWork.Save();
            return new ThemeTranslationResponsePivot
            {
                ThemeTranslationPivot = themeTranslation.ToPivot()
            };
        }

        public ThemeTranslationResponsePivot CreateThemeTranslationRange(ThemeTranslationRequestPivot request)
        {
            if (request?.ThemeTranslationPivotList == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            List<ThemeTranslation> themeTranslationList = request.ThemeTranslationPivotList.ToEntityList();
            _unitOfWork.ThemeTranslationRepository.Insert(themeTranslationList);
            _unitOfWork.Save();

            return new ThemeTranslationResponsePivot
            {
                ThemeTranslationPivotList = themeTranslationList.ToPivotList()
            };
        }

        /// <summary>
        /// Change ThemeTranslation values.
        /// </summary>
        /// <param name="request">The ThemeTranslation Request Pivot to change.</param>
        public void UpdateThemeTranslation(ThemeTranslationRequestPivot request)
        {
            if (request?.ThemeTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            ThemeTranslation themeTranslation = _unitOfWork.ThemeTranslationRepository.GetById(request.ThemeTranslationPivot.TranslationId);
            themeTranslation.ThemeName = request.ThemeTranslationPivot.ThemeName;
            _unitOfWork.Save();
        }

        /// <summary>
        /// Update ThemeTranslationList values.
        /// </summary>
        /// <param name="request"></param>
        public void UpdateThemeTranslationRange(ThemeTranslationRequestPivot request)
        {
            if (request?.ThemeTranslationPivotList == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            foreach (ThemeTranslationPivot themeTranslationPivot in request.ThemeTranslationPivotList)
            {
                ThemeTranslation themeTranslation = _unitOfWork.ThemeTranslationRepository.GetById(themeTranslationPivot.TranslationId);
                themeTranslation.ThemeName = themeTranslationPivot.ThemeName;
                _unitOfWork.Save();
            }
        }

        /// <summary>
        /// Remove ThemeTranslation.
        /// </summary>
        /// <param name="request">The ThemeTranslation Request Pivot to remove.</param>
        public void DeleteThemeTranslation(ThemeTranslationRequestPivot request)
        {
            if (request?.ThemeTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            ThemeTranslation themeTranslation = _unitOfWork.ThemeTranslationRepository.GetById(request.ThemeTranslationPivot.TranslationId);
            _unitOfWork.ThemeTranslationRepository.Delete(themeTranslation);
            _unitOfWork.Save();
        }

        /// <summary>
        /// Get the list of the ThemeTranslation.
        /// </summary>
        /// <returns>ThemeTranslation Response Pivot response.</returns>
        public ThemeTranslationResponsePivot GetAllThemeTranslations()
        {
            return new ThemeTranslationResponsePivot
            {
                ThemeTranslationPivotList = _unitOfWork.ThemeTranslationRepository.Get(null, null, "Theme,Language").ToList().ToPivotList()
            };
        }

        /// <summary>
        /// Search ThemeTranslation by id.
        /// </summary>
        /// <param name="request">The ThemeTranslation Request Pivot to retrive.</param>
        /// <returns>ThemeTranslation Response Pivot response.</returns>
        public ThemeTranslationResponsePivot FindThemeTranslations(ThemeTranslationRequestPivot request)
        {
            if (request?.ThemeTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            List<ThemeTranslationPivot> results = new List<ThemeTranslationPivot>();
            ThemeTranslationPivot result = new ThemeTranslationPivot();
            switch (request.FindThemeTranslationPivot)
            {
                case FindThemeTranslationPivot.ThemeTranslationId:
                    result = _unitOfWork.ThemeTranslationRepository
                        .Get(t => t.TranslationId == request.ThemeTranslationPivot.TranslationId, null,
                            "Theme,Language")?.FirstOrDefault()
                        ?.ToPivot();
                    break;
                case FindThemeTranslationPivot.ThemeId:
                    results = _unitOfWork.ThemeTranslationRepository
                        .Get(t => t.ThemeId == request.ThemeTranslationPivot.ThemeId, null, "Theme,Language").ToList()
                        .ToPivotList();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return new ThemeTranslationResponsePivot
            {
                ThemeTranslationPivotList = results,
                ThemeTranslationPivot = result
            };
        }
        #endregion
    }
}