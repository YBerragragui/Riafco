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
    /// The Sheet service client class.
    /// </summary>
    public class ServiceSheetClient : IServiceSheetClient
    {
        /// <summary>
        /// The Sheet service instance.
        /// </summary>
        private readonly IServiceSheet _serviceSheet;

        /// <summary>
        /// Set the Sheet instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceSheet">injected instance</param>
        public ServiceSheetClient(IServiceSheet injectedServiceSheet)
        {
            _serviceSheet = injectedServiceSheet;
        }

        /// <summary>
        /// Add new Sheet
        /// </summary>
        /// <param name="request">sheet request.</param>
        /// <returns>Sheet message.</returns>
        public SheetMessage CreateSheet(SheetRequest request)
        {
            SheetMessage message = new SheetMessage();
            try
            {
                message = _serviceSheet.CreateSheet(request.ToPivot()).ToMessage();
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
        /// Change Sheet informations.
        /// </summary>
        /// <param name="request">sheet request.</param>
        /// <returns>Sheet message.</returns>
        public SheetMessage UpdateSheet(SheetRequest request)
        {
            SheetMessage message = new SheetMessage();
            try
            {
                _serviceSheet.UpdateSheet(request.ToPivot());
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
        /// Delete Sheet
        /// </summary>
        /// <param name="request">sheet request.</param>
        /// <returns>Sheet message.</returns>
        public SheetMessage DeleteSheet(SheetRequest request)
        {
            SheetMessage message = new SheetMessage();
            try
            {
                _serviceSheet.DeleteSheet(request.ToPivot());
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
        /// Get list of Sheet
        /// </summary>
        /// <returns>Sheet message.</returns>
        public SheetMessage GetAllSheets()
        {
            SheetMessage message = new SheetMessage();
            try
            {
                message = _serviceSheet.GetAllSheets().ToMessage();
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
        /// Search Sheet
        /// </summary>
        /// <param name="request">sheet request.</param>
        /// <returns>Sheet message.</returns>
        public SheetMessage FindSheets(SheetRequest request)
        {
            SheetMessage message = new SheetMessage();
            try
            {
                message = _serviceSheet.FindSheets(request.ToPivot()).ToMessage();
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