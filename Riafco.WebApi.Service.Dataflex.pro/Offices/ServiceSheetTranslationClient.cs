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
    /// The SheetTranslation service client class.
    /// </summary>
    public class ServiceSheetTranslationClient : IServiceSheetTranslationClient
    {
        /// <summary>
        /// The SheetTranslation service instance.
        /// </summary>
        private readonly IServiceSheetTranslation _serviceSheetTranslation;

        /// <summary>
        /// Set the SheetTranslation instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceSheetTranslation">injected instance</param>
        public ServiceSheetTranslationClient(IServiceSheetTranslation injectedServiceSheetTranslation)
        {
            _serviceSheetTranslation = injectedServiceSheetTranslation;
        }
        /// <summary>
        /// Add new SheetTranslation
        /// </summary>
        /// <param name="request">sheetTranslation request.</param>
        /// <returns>SheetTranslation message.</returns>
        public SheetTranslationMessage CreateSheetTranslation(SheetTranslationRequest request)
        {
            SheetTranslationMessage message = new SheetTranslationMessage();
            try
            {
                message = _serviceSheetTranslation.CreateSheetTranslation(request.ToPivot()).ToMessage();
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
        /// Add new SheetTranslation
        /// </summary>
        /// <param name="request">sheetTranslation request.</param>
        /// <returns>SheetTranslation message.</returns>
        public SheetTranslationMessage CreateSheetTranslationRange(SheetTranslationRequest request)
        {
            SheetTranslationMessage message = new SheetTranslationMessage();
            try
            {
                message = _serviceSheetTranslation.CreateSheetTranslationRange(request.ToPivot()).ToMessage();
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
        /// Change SheetTranslation informations.
        /// </summary>
        /// <param name="request">sheetTranslation request.</param>
        /// <returns>SheetTranslation message.</returns>
        public SheetTranslationMessage UpdateSheetTranslation(SheetTranslationRequest request)
        {
            SheetTranslationMessage message = new SheetTranslationMessage();
            try
            {
                _serviceSheetTranslation.UpdateSheetTranslation(request.ToPivot());
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
        /// Change SheetTranslation informations.
        /// </summary>
        /// <param name="request">sheetTranslation request.</param>
        /// <returns>SheetTranslation message.</returns>
        public SheetTranslationMessage UpdateSheetTranslationRange(SheetTranslationRequest request)
        {
            SheetTranslationMessage message = new SheetTranslationMessage();
            try
            {
                _serviceSheetTranslation.UpdateSheetTranslationRange(request.ToPivot());
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
        /// Delete SheetTranslation
        /// </summary>
        /// <param name="request">sheetTranslation request.</param>
        /// <returns>SheetTranslation message.</returns>
        public SheetTranslationMessage DeleteSheetTranslation(SheetTranslationRequest request)
        {
            SheetTranslationMessage message = new SheetTranslationMessage();
            try
            {
                _serviceSheetTranslation.DeleteSheetTranslation(request.ToPivot());
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
        /// Get list of SheetTranslation
        /// </summary>
        /// <returns>SheetTranslation message.</returns>
        public SheetTranslationMessage GetAllSheetTranslations()
        {
            SheetTranslationMessage message = new SheetTranslationMessage();
            try
            {
                message = _serviceSheetTranslation.GetAllSheetTranslations().ToMessage();
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
        /// Search SheetTranslation
        /// </summary>
        /// <param name="request">sheetTranslation request.</param>
        /// <returns>SheetTranslation message.</returns>
        public SheetTranslationMessage FindSheetTranslations(SheetTranslationRequest request)
        {
            SheetTranslationMessage message = new SheetTranslationMessage();
            try
            {
                message = _serviceSheetTranslation.FindSheetTranslations(request.ToPivot()).ToMessage();
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