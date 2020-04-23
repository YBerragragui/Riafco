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
    /// The AreaTranslation service class.
    /// </summary>
    public class ServiceAreaTranslation : IServiceAreaTranslation
    {
        #region private attributes

        /// <summary>
        /// The UnitOfWork instance.
        /// </summary>
        private IUnitOfWork UnitOfWork;

        #endregion

        #region contructors
        /// <summary>
        /// Constructor to create instance of the UnitOfWork.
        /// </summary>
        /// <param name="injectedUnitOfWork">the injected UnitOfWork to instance UnitOfWork attribute.</param>
        public ServiceAreaTranslation(IUnitOfWork injectedUnitOfWork)
        {
            if (injectedUnitOfWork == null)
            {
                throw new ArgumentNullException(nameof(injectedUnitOfWork));
            }
            UnitOfWork = injectedUnitOfWork;
        }
        #endregion

        #region public methods
        /// <summary>
        /// Create new AreaTranslation.
        /// </summary>
        /// <param name="request">The AreaTranslation Request Pivot to add.</param>
        /// <returns>AreaTranslation Response Pivot created.</returns>
        public AreaTranslationResponsePivot CreateAreaTranslation(AreaTranslationRequestPivot request)
        {
            if (request?.AreaTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            AreaTranslation areaTranslation = request.AreaTranslationPivot.ToEntity();
            UnitOfWork.AreaTranslationRepository.Insert(areaTranslation);
            UnitOfWork.Save();
            return new AreaTranslationResponsePivot
            {
                AreaTranslationPivot = areaTranslation.ToPivot()
            };
        }

        /// <summary>
        /// Create new AreaTranslation.
        /// </summary>
        /// <param name="request">The AreaTranslation Request Pivot to add.</param>
        /// <returns>AreaTranslation Response Pivot created.</returns>
        public AreaTranslationResponsePivot CreateAreaTranslationRange(AreaTranslationRequestPivot request)
        {
            if (request?.AreaTranslationPivotList == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            List<AreaTranslation> areaTranslationList = request.AreaTranslationPivotList.ToEntityList();
            UnitOfWork.AreaTranslationRepository.Insert(areaTranslationList);
            UnitOfWork.Save();

            return new AreaTranslationResponsePivot
            {
                AreaTranslationPivotList = areaTranslationList.ToPivotList()
            };
        }

        /// <summary>
        /// Change AreaTranslation values.
        /// </summary>
        /// <param name="request">The AreaTranslation Request Pivot to change.</param>
        public void UpdateAreaTranslation(AreaTranslationRequestPivot request)
        {
            if (request?.AreaTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            AreaTranslation areaTranslation = UnitOfWork.AreaTranslationRepository.GetById(request.AreaTranslationPivot.TranslationId);
            areaTranslation.AreaName = request.AreaTranslationPivot.AreaName;
            UnitOfWork.Save();
        }

        /// <summary>
        /// Change AreaTranslation values.
        /// </summary>
        /// <param name="request">The AreaTranslation Request Pivot to change.</param>
        public void UpdateAreaTranslationRange(AreaTranslationRequestPivot request)
        {
            if (request?.AreaTranslationPivotList == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            foreach (var areaTranslationPivot in request.AreaTranslationPivotList)
            {
                AreaTranslation areaTranslation = UnitOfWork.AreaTranslationRepository.GetById(areaTranslationPivot.TranslationId);
                areaTranslation.AreaName = areaTranslationPivot.AreaName;
                UnitOfWork.Save();
            }
        }

        /// <summary>
        /// Remove AreaTranslation.
        /// </summary>
        /// <param name="request">The AreaTranslation Request Pivot to remove.</param>
        public void DeleteAreaTranslation(AreaTranslationRequestPivot request)
        {
            if (request?.AreaTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            AreaTranslation areaTranslation = UnitOfWork.AreaTranslationRepository.GetById(request.AreaTranslationPivot.TranslationId);
            UnitOfWork.AreaTranslationRepository.Delete(areaTranslation);
            UnitOfWork.Save();
        }

        /// <summary>
        /// Get the list of the AreaTranslation.
        /// </summary>
        /// <returns>AreaTranslation Response Pivot response.</returns>
        public AreaTranslationResponsePivot GetAllAreaTranslations()
        {
            return new AreaTranslationResponsePivot
            {
                AreaTranslationPivotList = UnitOfWork.AreaTranslationRepository.Get(null, null, "Area,Language").ToList().ToPivotList()
            };
        }

        /// <summary>
        /// Search AreaTranslation by id.
        /// </summary>
        /// <param name="request">The AreaTranslation Request Pivot to retrive.</param>
        /// <returns>AreaTranslation Response Pivot response.</returns>
        public AreaTranslationResponsePivot FindAreaTranslations(AreaTranslationRequestPivot request)
        {
            if (request?.AreaTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            List<AreaTranslationPivot> results = new List<AreaTranslationPivot>();
            AreaTranslationPivot result = new AreaTranslationPivot();
            switch (request.FindAreaTranslationPivot)
            {
                case FindAreaTranslationPivot.AreaTranslationId:
                    result = UnitOfWork.AreaTranslationRepository.Get(t => t.TranslationId == request.AreaTranslationPivot.TranslationId, null, "Area,Language")?.FirstOrDefault().ToPivot();
                    break;
                case FindAreaTranslationPivot.AreaId:
                    results = UnitOfWork.AreaTranslationRepository.Get(t => t.AreaId == request.AreaTranslationPivot.AreaId, null, "Area,Language")?.ToList().ToPivotList();
                    break;
            }
            return new AreaTranslationResponsePivot
            {
                AreaTranslationPivotList = results,
                AreaTranslationPivot = result
            };
        }
        #endregion
    }
}