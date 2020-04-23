using Riafco.Entity.Dataflex.Pro.Offices;
using Riafco.Service.Dataflex.Pro.Offices.Assembler;
using Riafco.Service.Dataflex.Pro.Offices.Data;
using Riafco.Service.Dataflex.Pro.Offices.Data.Enum;
using Riafco.Service.Dataflex.Pro.Offices.Interface;
using Riafco.Service.Dataflex.Pro.Offices.Request;
using Riafco.Service.Dataflex.Pro.Offices.Response;
using Riafco.Service.Dataflex.Pro.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Riafco.Service.Dataflex.Pro.Offices
{
    /// <summary>
    /// The Country service class.
    /// </summary>
    public class ServiceCountry : IServiceCountry
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
        public ServiceCountry(IUnitOfWork injectedUnitOfWork)
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
        /// Create new Country.
        /// </summary>
        /// <param name="request">The Country Request Pivot to add.</param>
        /// <returns>Country Response Pivot created.</returns>
        public CountryResponsePivot CreateCountry(CountryRequestPivot request)
        {
            if (request.CountryPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            Country country = request.CountryPivot.ToEntity();
            _unitOfWork.CountryRepository.Insert(country);
            _unitOfWork.Save();
            return new CountryResponsePivot
            {
                CountryPivot = country.ToPivot()
            };
        }

        /// <summary>
        /// Change Country values.
        /// </summary>
        /// <param name="request">The Country Request Pivot to change.</param>
        public void UpdateCountry(CountryRequestPivot request)
        {
            if (request.CountryPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            Country country = _unitOfWork.CountryRepository.GetById(request.CountryPivot.CountryId);
            if (request.CountryPivot.CountryImage != null)
            {
                country.CountryImage = request.CountryPivot.CountryImage;
            }
            _unitOfWork.Save();

        }

        /// <summary>
        /// Remove Country.
        /// </summary>
        /// <param name="request">The Country Request Pivot to remove.</param>
        public void DeleteCountry(CountryRequestPivot request)
        {
            if (request.CountryPivot == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            Country country = _unitOfWork.CountryRepository.GetById(request.CountryPivot.CountryId);
            _unitOfWork.CountryRepository.Delete(country);
            _unitOfWork.Save();

        }

        /// <summary>
        /// Get the list of the Country.
        /// </summary>
        /// <returns>Country Response Pivot response.</returns>
        public CountryResponsePivot GetAllCountries()
        {
            return new CountryResponsePivot
            {
                CountryPivotList = _unitOfWork.CountryRepository.Get().ToList().ToPivotList()
            };

        }

        /// <summary>
        /// Search Country by id.
        /// </summary>
        /// <param name="request">The Country Request Pivot to retrive.</param>
        /// <returns>Country Response Pivot response.</returns>
        public CountryResponsePivot FindCountries(CountryRequestPivot request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            List<CountryPivot> results = new List<CountryPivot>();
            CountryPivot result = new CountryPivot();
            switch (request.FindCountryPivot)
            {
                case FindCountryPivot.CountryId:
                    result = _unitOfWork.CountryRepository.GetById(request.CountryPivot.CountryId)?.ToPivot();
                    break;
                case FindCountryPivot.CountryCode:
                    result = _unitOfWork.CountryRepository.Get(c=>c.CountryCode == request.CountryPivot.CountryCode).FirstOrDefault().ToPivot();
                    break;
                case FindCountryPivot.CountryShortName:
                    result = _unitOfWork.CountryRepository.Get(c => c.CountryShortName == request.CountryPivot.CountryShortName).FirstOrDefault().ToPivot();
                    break;
            }
            return new CountryResponsePivot
            {
                CountryPivotList = results,
                CountryPivot = result
            };
        }
        #endregion

    }
}