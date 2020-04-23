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
    /// The Area service client class.
    /// </summary>
    public class ServiceAreaClient : IServiceAreaClient
    {
        #region private attributes

        /// <summary>
        /// The Area service instance.
        /// </summary>
        private readonly IServiceArea _serviceArea;

        #endregion

        #region constructor

        /// <summary>
        /// Set the Area instane with injected instance.
        /// </summary>
        /// <param name="injectedServiceArea">injected instance</param>
        public ServiceAreaClient(IServiceArea injectedServiceArea)
        {
            _serviceArea = injectedServiceArea;
        }

        #endregion

        #region publics methods

        /// <summary>
        /// Create new Area
        /// </summary>
        /// <param name="request">area request.</param>
        /// <returns>Area message.</returns>
        public AreaMessage CreateArea(AreaRequest request)
        {
            AreaMessage message = new AreaMessage();
            try
            {
                message = _serviceArea.CreateArea(request.ToPivot()).ToMessage();
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
        /// Change Area informations.
        /// </summary>
        /// <param name="request">area request.</param>
        /// <returns>Area message.</returns>
        public AreaMessage UpdateArea(AreaRequest request)
        {
            AreaMessage message = new AreaMessage();
            try
            {
                _serviceArea.UpdateArea(request.ToPivot());
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
        /// Delete Area
        /// </summary>
        /// <param name="request">area request.</param>
        /// <returns>Area message.</returns>
        public AreaMessage DeleteArea(AreaRequest request)
        {
            AreaMessage message = new AreaMessage();
            try
            {
                _serviceArea.DeleteArea(request.ToPivot());
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
        /// Get list of Area
        /// </summary>
        /// <returns>Area message.</returns>
        public AreaMessage GetAllAreas()
        {
            AreaMessage message = new AreaMessage();
            try
            {
                message = _serviceArea.GetAllAreas().ToMessage();
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
        /// Search Area
        /// </summary>
        /// <param name="request">area request.</param>
        /// <returns>Area message.</returns>
        public AreaMessage FindAreas(AreaRequest request)
        {
            AreaMessage message = new AreaMessage();
            try
            {
                message = _serviceArea.FindAreas(request.ToPivot()).ToMessage();
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