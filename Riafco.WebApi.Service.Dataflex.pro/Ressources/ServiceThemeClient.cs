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
    /// The Theme service client class.
    /// </summary>
    public class ServiceThemeClient : IServiceThemeClient
    {
        #region private attributes

        /// <summary>
        /// The Theme service instance.
        /// </summary>
        private readonly IServiceTheme _serviceTheme;

        #endregion

        #region constructor

        /// <summary>
        /// Set the Theme instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceTheme">injected instance</param>
        public ServiceThemeClient(IServiceTheme injectedServiceTheme)
        {
            _serviceTheme = injectedServiceTheme;
        }

        #endregion

        #region public methods

        /// <summary>
        /// Create new Theme.
        /// </summary>
        /// <param name="request">theme request.</param>
        /// <returns>Theme message.</returns>
        public ThemeMessage CreateTheme(ThemeRequest request)
        {
            ThemeMessage message = new ThemeMessage();
            try
            {
                message = _serviceTheme.CreateTheme(request.ToPivot()).ToMessage();
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
        /// Change Theme informations.
        /// </summary>
        /// <param name="request">theme request.</param>
        /// <returns>Theme message.</returns>
        public ThemeMessage UpdateTheme(ThemeRequest request)
        {
            ThemeMessage message = new ThemeMessage();
            try
            {
                _serviceTheme.UpdateTheme(request.ToPivot());
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
        /// Delete Theme.
        /// </summary>
        /// <param name="request">theme request.</param>
        /// <returns>Theme message.</returns>
        public ThemeMessage DeleteTheme(ThemeRequest request)
        {
            ThemeMessage message = new ThemeMessage();
            try
            {
                _serviceTheme.DeleteTheme(request.ToPivot());
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
        /// Get list of Theme
        /// </summary>
        /// <returns>Theme message.</returns>
        public ThemeMessage GetAllThemes()
        {
            ThemeMessage message = new ThemeMessage();
            try
            {
                message = _serviceTheme.GetAllThemes().ToMessage();
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
        /// Search Theme
        /// </summary>
        /// <param name="request">theme request.</param>
        /// <returns>Theme message.</returns>
        public ThemeMessage FindThemes(ThemeRequest request)
        {
            ThemeMessage message = new ThemeMessage();
            try
            {
                message = _serviceTheme.FindThemes(request.ToPivot()).ToMessage();
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