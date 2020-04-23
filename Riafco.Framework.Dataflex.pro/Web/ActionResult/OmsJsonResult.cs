using System.Runtime.Serialization.Json;
using System.Web.Mvc;

namespace Riafco.Framework.Dataflex.pro.Web.ActionResult
{
    /// <summary>
    /// The OMS json result
    /// </summary>
    public class OmsJsonResult : JsonResult
    {
        /// <summary>
        /// The content type property
        /// </summary>
        private readonly string _contentType;

        /// <summary>
        /// Initializes a new instance of the <see cref="OmsJsonResult"/> class.
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="contentType">The content type</param>
        public OmsJsonResult(object data, string contentType = "application/json")
        {
            Data = data;
            _contentType = contentType;
        }

        /// <summary>
        /// override the execute result
        /// </summary>
        /// <param name="context">The controller context</param>
        public override void ExecuteResult(ControllerContext context)
        {
            var serializer = new DataContractJsonSerializer(Data.GetType());
            context.HttpContext.Response.ContentType = _contentType;
            serializer.WriteObject(context.HttpContext.Response.OutputStream, Data);
        }
    }
}
