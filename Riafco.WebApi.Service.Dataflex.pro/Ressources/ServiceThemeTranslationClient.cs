using System;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Request;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Message;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Interface;
using Riafco.WebApi.Service.Dataflex.pro.Ressources.Assembler;
using Riafco.Service.Dataflex.Pro.Ressources.Interface;
using Riafco.Framework.Dataflex.pro.Communication.Messages.Enum;

namespace Riafco.WebApi.Service.Dataflex.pro.Ressources
{
    /// <summary>
    /// The ThemeTranslation service client class.
    /// </summary>
    public class ServiceThemeTranslationClient : IServiceThemeTranslationClient
    {
        #region private attributes

        /// <summary>
        /// The ThemeTranslation service instance.
        /// </summary>
        private readonly IServiceThemeTranslation _serviceThemeTranslation;

        #endregion

        #region constructor

        /// <summary>
        /// Set the ThemeTranslation instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceThemeTranslation">injected instance</param>
        public ServiceThemeTranslationClient(IServiceThemeTranslation injectedServiceThemeTranslation)
        {
            _serviceThemeTranslation = injectedServiceThemeTranslation;
        }

        #endregion

        #region public methods

        /// <summary>
        /// Create new ThemeTranslation
        /// </summary>
        /// <param name="request">themeTranslation request.</param>
        /// <returns>ThemeTranslation message.</returns>
        public ThemeTranslationMessage CreateThemeTranslation(ThemeTranslationRequest request)
        {
            ThemeTranslationMessage message = new ThemeTranslationMessage();
            try
            {
                message = _serviceThemeTranslation.CreateThemeTranslation(request.ToPivot()).ToMessage();
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
        /// Create new ThemeTranslation range.
        /// </summary>
        /// <param name="request">themeTranslation request.</param>
        /// <returns>ThemeTranslation message.</returns>
        public ThemeTranslationMessage CreateThemeTranslationRange(ThemeTranslationRequest request)
        {
            ThemeTranslationMessage message = new ThemeTranslationMessage();
            try
            {
                message = _serviceThemeTranslation.CreateThemeTranslationRange(request.ToPivot()).ToMessage();
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
        /// Change ThemeTranslation informations.
        /// </summary>
        /// <param name="request">themeTranslation request.</param>
        /// <returns>ThemeTranslation message.</returns>
        public ThemeTranslationMessage UpdateThemeTranslation(ThemeTranslationRequest request)
        {
            ThemeTranslationMessage message = new ThemeTranslationMessage();
            try
            {
                _serviceThemeTranslation.UpdateThemeTranslation(request.ToPivot());
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
        /// Change ThemeTranslation informations Range.
        /// </summary>
        /// <param name="request">themeTranslation request.</param>
        /// <returns>ThemeTranslation message.</returns>
        public ThemeTranslationMessage UpdateThemeTranslationRange(ThemeTranslationRequest request)
        {
            ThemeTranslationMessage message = new ThemeTranslationMessage();
            try
            {
                _serviceThemeTranslation.UpdateThemeTranslationRange(request.ToPivot());
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
        /// Delete ThemeTranslation
        /// </summary>
        /// <param name="request">themeTranslation request.</param>
        /// <returns>ThemeTranslation message.</returns>
        public ThemeTranslationMessage DeleteThemeTranslation(ThemeTranslationRequest request)
        {
            ThemeTranslationMessage message = new ThemeTranslationMessage();
            try
            {
                _serviceThemeTranslation.DeleteThemeTranslation(request.ToPivot());
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
        /// Get list of ThemeTranslation
        /// </summary>
        /// <returns>ThemeTranslation message.</returns>
        public ThemeTranslationMessage GetAllThemeTranslations()
        {
            ThemeTranslationMessage message = new ThemeTranslationMessage();
            try
            {
                message = _serviceThemeTranslation.GetAllThemeTranslations().ToMessage();
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
        /// Search ThemeTranslation
        /// </summary>
        /// <param name="request">themeTranslation request.</param>
        /// <returns>ThemeTranslation message.</returns>
        public ThemeTranslationMessage FindThemeTranslations(ThemeTranslationRequest request)
        {
            ThemeTranslationMessage message = new ThemeTranslationMessage();
            try
            {
                message = _serviceThemeTranslation.FindThemeTranslations(request.ToPivot()).ToMessage();
                message.OperationSuccess = true;
            }
            catch (Exception e)
            {
                message.ErrorType = ErrorType.TechnicalError;
                message.ErrorMessage = e.Message;
            }
            return message;
        }
        #endregion
    }
}