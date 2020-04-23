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
    /// The Theme service class.
    /// </summary>
    public class ServiceTheme : IServiceTheme
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
        public ServiceTheme(IUnitOfWork injectedUnitOfWork)
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
        /// Create new Theme.
        /// </summary>
        /// <param name="request">The Theme Request Pivot to add.</param>
        /// <returns>Theme Response Pivot created.</returns>
        public ThemeResponsePivot CreateTheme(ThemeRequestPivot request)
        {
            if (request?.ThemePivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Theme theme = request.ThemePivot.ToEntity();
            _unitOfWork.ThemeRepository.Insert(theme);
            _unitOfWork.Save();
            return new ThemeResponsePivot()
            {
                ThemePivot = theme.ToPivot()
            };
        }

        /// <summary>
        /// Change Theme values.
        /// </summary>
        /// <param name="request">The Theme Request Pivot to change.</param>
        public void UpdateTheme(ThemeRequestPivot request)
        {
            if (request?.ThemePivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Theme theme = _unitOfWork.ThemeRepository.GetById(request.ThemePivot.ThemeId);
            _unitOfWork.ThemeRepository.DetachObject(theme);
            _unitOfWork.ThemeRepository.Update(request.ThemePivot.ToEntity());
            _unitOfWork.Save();
        }

        /// <summary>
        /// Remove Theme.
        /// </summary>
        /// <param name="request">The Theme Request Pivot to remove.</param>
        public void DeleteTheme(ThemeRequestPivot request)
        {
            if (request?.ThemePivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Theme theme = _unitOfWork.ThemeRepository.GetById(request.ThemePivot.ThemeId);
            _unitOfWork.ThemeRepository.Delete(theme);
            _unitOfWork.Save();
        }

        /// <summary>
        /// Get the list of the Theme.
        /// </summary>
        /// <returns>Theme Response Pivot response.</returns>
        public ThemeResponsePivot GetAllThemes()
        {
            return new ThemeResponsePivot
            {
                ThemePivotList = _unitOfWork.ThemeRepository.Get().ToList().ToPivotList()
            };
        }

        /// <summary>
        /// Search Theme by id.
        /// </summary>
        /// <param name="request">The Theme Request Pivot to retrive.</param>
        /// <returns>Theme Response Pivot response.</returns>
        public ThemeResponsePivot FindThemes(ThemeRequestPivot request)
        {
            if (request?.ThemePivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            List<ThemePivot> results = new List<ThemePivot>();
            ThemePivot result = new ThemePivot();
            switch (request.FindThemePivot)
            {
                case FindThemePivot.ThemeId:
                    result = _unitOfWork.ThemeRepository.GetById(request.ThemePivot.ThemeId)?.ToPivot();
                    break;
            }
            return new ThemeResponsePivot
            {
                ThemePivotList = results,
                ThemePivot = result
            };
        }
        #endregion
    }
}