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
    /// The CountryTranslation service client class.
    /// </summary>
    public class ServiceCountryTranslationClient : IServiceCountryTranslationClient
    {
        /// <summary>
        /// The CountryTranslation service instance.
        /// </summary>
        private readonly IServiceCountryTranslation _serviceCountryTranslation;

        /// <summary>
        /// Set the CountryTranslation instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceCountryTranslation">injected instance</param>
        public ServiceCountryTranslationClient(IServiceCountryTranslation injectedServiceCountryTranslation)
        {
            _serviceCountryTranslation = injectedServiceCountryTranslation;
        }
        /// <summary>
        /// Add new CountryTranslation
        /// </summary>
        /// <param name="request">countryTranslation request.</param>
        /// <returns>CountryTranslation message.</returns>
        public CountryTranslationMessage CreateCountryTranslation(CountryTranslationRequest request)
        {
            CountryTranslationMessage message = new CountryTranslationMessage();
            try
            {
                message = _serviceCountryTranslation.CreateCountryTranslation(request.ToPivot()).ToMessage();
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
        /// Add new CountryTranslation
        /// </summary>
        /// <param name="request">countryTranslation request.</param>
        /// <returns>CountryTranslation message.</returns>
        public CountryTranslationMessage CreateCountryTranslationRange(CountryTranslationRequest request)
        {
            CountryTranslationMessage message = new CountryTranslationMessage();
            try
            {
                message = _serviceCountryTranslation.CreateCountryTranslationRange(request.ToPivot()).ToMessage();
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
        /// Change CountryTranslation informations.
        /// </summary>
        /// <param name="request">countryTranslation request.</param>
        /// <returns>CountryTranslation message.</returns>
        public CountryTranslationMessage UpdateCountryTranslation(CountryTranslationRequest request)
        {
            CountryTranslationMessage message = new CountryTranslationMessage();
            try
            {
                _serviceCountryTranslation.UpdateCountryTranslation(request.ToPivot());
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
        /// Change CountryTranslation informations.
        /// </summary>
        /// <param name="request">countryTranslation request.</param>
        /// <returns>CountryTranslation message.</returns>
        public CountryTranslationMessage UpdateCountryTranslationRange(CountryTranslationRequest request)
        {
            CountryTranslationMessage message = new CountryTranslationMessage();
            try
            {
                _serviceCountryTranslation.UpdateCountryTranslationRange(request.ToPivot());
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
        /// Delete CountryTranslation
        /// </summary>
        /// <param name="request">countryTranslation request.</param>
        /// <returns>CountryTranslation message.</returns>
        public CountryTranslationMessage DeleteCountryTranslation(CountryTranslationRequest request)
        {
            CountryTranslationMessage message = new CountryTranslationMessage();
            try
            {
                _serviceCountryTranslation.DeleteCountryTranslation(request.ToPivot());
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
        /// Get list of CountryTranslation
        /// </summary>
        /// <returns>CountryTranslation message.</returns>
        public CountryTranslationMessage GetAllCountryTranslations()
        {
            CountryTranslationMessage message = new CountryTranslationMessage();
            try
            {
                message = _serviceCountryTranslation.GetAllCountryTranslations().ToMessage();
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
        /// Search CountryTranslation
        /// </summary>
        /// <param name="request">countryTranslation request.</param>
        /// <returns>CountryTranslation message.</returns>
        public CountryTranslationMessage FindCountryTranslations(CountryTranslationRequest request)
        {
            CountryTranslationMessage message = new CountryTranslationMessage();
            try
            {
                message = _serviceCountryTranslation.FindCountryTranslations(request.ToPivot()).ToMessage();
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