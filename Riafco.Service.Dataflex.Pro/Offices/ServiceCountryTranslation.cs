using System;
using System.Collections.Generic;
using System.Linq;
using Riafco.Service.Dataflex.Pro.Offices.Request;
using Riafco.Service.Dataflex.Pro.Offices.Response;
using Riafco.Service.Dataflex.Pro.Offices.Interface;
using Riafco.Service.Dataflex.Pro.UnitOfWork;
using Riafco.Service.Dataflex.Pro.Offices.Assembler;
using Riafco.Entity.Dataflex.Pro.Offices;
using Riafco.Service.Dataflex.Pro.Offices.Data;
using Riafco.Service.Dataflex.Pro.Offices.Data.Enum;

namespace Riafco.Service.Dataflex.Pro.Offices
{
    /// <summary>
    /// The CountryTranslation service class.
    /// </summary>
    public class ServiceCountryTranslation : IServiceCountryTranslation
    {
        /// <summary>
        /// The UnitOfWork instance.
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        #region contructors
        /// <summary>
        /// Constructor to create instance of the UnitOfWork.
        /// </summary>
        /// <param name="injectedUnitOfWork">the injected UnitOfWork to instance UnitOfWork attribute.</param>
        public ServiceCountryTranslation(IUnitOfWork injectedUnitOfWork)
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
        /// Create new CountryTranslation.
        /// </summary>
        /// <param name="request">The CountryTranslation Request Pivot to add.</param>
        /// <returns>CountryTranslation Response Pivot created.</returns>
        public CountryTranslationResponsePivot CreateCountryTranslation(CountryTranslationRequestPivot request)
        {
            if (request.CountryTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            CountryTranslation countryTranslation = request.CountryTranslationPivot.ToEntity();
            _unitOfWork.CountryTranslationRepository.Insert(countryTranslation);
            _unitOfWork.Save();
            return new CountryTranslationResponsePivot()
            {
                CountryTranslationPivot = countryTranslation.ToPivot()
            };
        }

        /// <summary>
        /// Create new CreateCountryTranslationRange.
        /// </summary>
        /// <param name="request">The CreateCountryTranslationRange Request Pivot to add.</param>
        /// <returns>CountryTranslation Response Pivot created.</returns>
        public CountryTranslationResponsePivot CreateCountryTranslationRange(CountryTranslationRequestPivot request)
        {
            if (request.CountryTranslationPivotList == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            List<CountryTranslation> countryTranslationList = request.CountryTranslationPivotList.ToEntityList();
            _unitOfWork.CountryTranslationRepository.Insert(countryTranslationList);
            _unitOfWork.Save();
            return new CountryTranslationResponsePivot()
            {
                CountryTranslationPivotList = countryTranslationList.ToPivotList()
            };
        }

        /// <summary>
        /// Change CountryTranslation values.
        /// </summary>
        /// <param name="request">The CountryTranslation Request Pivot to change.</param>
        public void UpdateCountryTranslation(CountryTranslationRequestPivot request)
        {
            if (request.CountryTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            CountryTranslation countryTranslation = _unitOfWork.CountryTranslationRepository.GetById(request.CountryTranslationPivot.TranslationId);
            countryTranslation.CountryName = request.CountryTranslationPivot.CountryName;
            countryTranslation.CountryTitle = request.CountryTranslationPivot.CountryTitle;
            countryTranslation.CountryDescription = request.CountryTranslationPivot.CountryDescription;
            countryTranslation.CountrySummary = request.CountryTranslationPivot.CountrySummary;
            _unitOfWork.Save();
        }

        /// <summary>
        /// Change UpdateCountryTranslationRange values.
        /// </summary>
        /// <param name="request">The CountryTranslation Request Pivot to change.</param>
        public void UpdateCountryTranslationRange(CountryTranslationRequestPivot request)
        {
            if (request.CountryTranslationPivotList == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            foreach (var item in request.CountryTranslationPivotList)
            {
                CountryTranslation countryTranslation = _unitOfWork.CountryTranslationRepository.GetById(item.TranslationId);
                countryTranslation.CountryName = item.CountryName;
                countryTranslation.CountryTitle = item.CountryTitle;
                countryTranslation.CountryDescription = item.CountryDescription;
                countryTranslation.CountrySummary = item.CountrySummary;
                _unitOfWork.Save();
            }
        }

        /// <summary>
        /// Remove CountryTranslation.
        /// </summary>
        /// <param name="request">The CountryTranslation Request Pivot to remove.</param>
        public void DeleteCountryTranslation(CountryTranslationRequestPivot request)
        {
            if (request.CountryTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            CountryTranslation countryTranslation = _unitOfWork.CountryTranslationRepository.GetById(request.CountryTranslationPivot.TranslationId);
            _unitOfWork.CountryTranslationRepository.Delete(countryTranslation);
            _unitOfWork.Save();

        }

        /// <summary>
        /// Get the list of the CountryTranslation.
        /// </summary>
        /// <returns>CountryTranslation Response Pivot response.</returns>
        public CountryTranslationResponsePivot GetAllCountryTranslations()
        {
            return new CountryTranslationResponsePivot()
            {
                CountryTranslationPivotList = _unitOfWork.CountryTranslationRepository.Get(null, null, "Country,Language").ToList().ToPivotList()
            };

        }

        /// <summary>
        /// Search CountryTranslation by id.
        /// </summary>
        /// <param name="request">The CountryTranslation Request Pivot to retrive.</param>
        /// <returns>CountryTranslation Response Pivot response.</returns>
        public CountryTranslationResponsePivot FindCountryTranslations(CountryTranslationRequestPivot request)
        {
            if (request.CountryTranslationPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            List<CountryTranslationPivot> results = new List<CountryTranslationPivot>();
            CountryTranslationPivot result = new CountryTranslationPivot();
            switch (request.FindCountryTranslationPivot)
            {
                case FindCountryTranslationPivot.CountryTranslationId:
                    result = _unitOfWork.CountryTranslationRepository.Get(c => c.TranslationId == request.CountryTranslationPivot.TranslationId, null, "Country,Language")?.FirstOrDefault().ToPivot();
                    break;
                case FindCountryTranslationPivot.CountryId:
                    results = _unitOfWork.CountryTranslationRepository.Get(c => c.CountryId == request.CountryTranslationPivot.CountryId, null, "Country,Language")?.ToList().ToPivotList();
                    break;
            }
            return new CountryTranslationResponsePivot()
            {
                CountryTranslationPivotList = results,
                CountryTranslationPivot = result
            };
        }
        #endregion

    }
}