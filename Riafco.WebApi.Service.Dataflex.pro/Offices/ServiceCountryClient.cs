using System;
using Riafco.WebApi.Service.Dataflex.pro.Offices.Request;
using Riafco.WebApi.Service.Dataflex.pro.Offices.Message;
using Riafco.WebApi.Service.Dataflex.pro.Offices.Interface;
using Riafco.WebApi.Service.Dataflex.pro.Offices.Assembler;
using Riafco.Service.Dataflex.Pro.Offices.Interface;
using Riafco.Framework.Dataflex.pro.Communication.Messages.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Offices
{
    /// <summary>
    /// The Country service client class.
    /// </summary>
    public class ServiceCountryClient : IServiceCountryClient
    {
        /// <summary>
        /// The Country service instance.
        /// </summary>
        private readonly IServiceCountry _serviceCountry;

        /// <summary>
        /// Set the Country instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceCountry">injected instance</param>
        public ServiceCountryClient(IServiceCountry injectedServiceCountry)
        {
            _serviceCountry = injectedServiceCountry;
        }
        /// <summary>
        /// Add new Country
        /// </summary>
        /// <param name="request">country request.</param>
        /// <returns>Country message.</returns>
        public CountryMessage CreateCountry(CountryRequest request)
        {
            CountryMessage message = new CountryMessage();
            try
            {
                message = _serviceCountry.CreateCountry(request.ToPivot()).ToMessage();
                message.OperationSuccess = true;
            }
            catch (Exception e)
            {
                message.ErrorType = ErrorType.TechnicalError;
                message.ErrorMessage = e.Message;
            }
            return message;
        }

        /// <summary>
        /// Change Country informations.
        /// </summary>
        /// <param name="request">country request.</param>
        /// <returns>Country message.</returns>
        public CountryMessage UpdateCountry(CountryRequest request)
        {
            CountryMessage message = new CountryMessage();
            try
            {
                _serviceCountry.UpdateCountry(request.ToPivot());
                message.OperationSuccess = true;
            }
            catch (Exception e)
            {
                message.ErrorType = ErrorType.TechnicalError;
                message.ErrorMessage = e.Message;
            }
            return message;
        }

        /// <summary>
        /// Delete Country
        /// </summary>
        /// <param name="request">country request.</param>
        /// <returns>Country message.</returns>
        public CountryMessage DeleteCountry(CountryRequest request)
        {
            CountryMessage message = new CountryMessage();
            try
            {
                _serviceCountry.DeleteCountry(request.ToPivot());
                message.OperationSuccess = true;
            }
            catch (Exception e)
            {
                message.ErrorType = ErrorType.TechnicalError;
                message.ErrorMessage = e.Message;
            }
            return message;
        }

        /// <summary>
        /// Get list of Country
        /// </summary>
        /// <returns>Country message.</returns>
        public CountryMessage GetAllCountries()
        {
            CountryMessage message = new CountryMessage();
            try
            {
                message = _serviceCountry.GetAllCountries().ToMessage();
                message.OperationSuccess = true;
            }
            catch (Exception e)
            {
                message.ErrorType = ErrorType.TechnicalError;
                message.ErrorMessage = e.Message;
            }
            return message;
        }

        /// <summary>
        /// Search Country
        /// </summary>
        /// <param name="request">country request.</param>
        /// <returns>Country message.</returns>
        public CountryMessage FindCountries(CountryRequest request)
        {
            CountryMessage message = new CountryMessage();
            try
            {
                message = _serviceCountry.FindCountries(request.ToPivot()).ToMessage();
                message.OperationSuccess = true;
            }
            catch (Exception e)
            {
                message.ErrorType = ErrorType.TechnicalError;
                message.ErrorMessage = e.Message;
            }
            return message;
        }

    }
}