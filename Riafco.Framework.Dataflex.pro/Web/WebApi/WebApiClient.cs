using Newtonsoft.Json;
using Riafco.Framework.Dataflex.pro.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Riafco.Framework.Dataflex.pro.Web.WebApi
{
    /// <summary>
    /// The WebApiClient class
    /// </summary>
    public static class WebApiClient
    {
        #region private properties
        /// <summary>
        /// The web api url
        /// </summary>
        private static string WebApiUrl => ConfigurationManagerHelper.GetAppSettingsToString(Constant.WebApiUrl, Constant.DefaultWebApiUrl);

        /// <summary>
        /// The token response.
        /// </summary>
        public static object TokenResponse => null;

        #endregion

        #region public methods
        /// <summary>
        /// The Get Async method
        /// </summary>
        /// <typeparam name="TEntity">The specified type</typeparam>
        /// <param name="controller">The api controller</param>
        /// <param name="action">The api action</param>
        /// <returns>deserialized object</returns>
        public static async Task<TEntity> GetAsync<TEntity>(string controller, string action)
        {
            try
            {
                string result = await GetAsyncHelper(FormatUrl(controller, action));
                if (!string.IsNullOrEmpty(result))
                {
                    return JsonConvert.DeserializeObject<TEntity>(result);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
            return default(TEntity);
        }

        /// <summary>
        /// The Get Async method
        /// </summary>
        /// <typeparam name="TEntity">The specified type</typeparam>
        /// <param name="controller">The api controller</param>
        /// <param name="action">The api action</param>
        /// <param name="queryStrings"></param>
        /// <returns>deserialized object</returns>
        public static async Task<TEntity> GetAsync<TEntity>(string controller, string action, IDictionary<string, string> queryStrings)
        {
            try
            {
                string result = await GetAsyncHelper(FormatUrl(controller, action, queryStrings));
                if (!string.IsNullOrEmpty(result))
                {
                    return JsonConvert.DeserializeObject<TEntity>(result);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.Message);
            }

            return default(TEntity);
        }

        /// <summary>
        /// The Get Async method
        /// </summary>
        /// <typeparam name="TEntity">The specified type</typeparam>
        /// <param name="controller">The api controller</param>
        /// <param name="action">The api action</param>
        /// <param name="param">The param</param>
        /// <returns>deserialized object</returns>
        public static async Task<TEntity> GetAsync<TEntity>(string controller, string action, string param)
        {
            try
            {
                string result = await GetAsyncHelper(FormatUrl(controller, action, param));
                if (!string.IsNullOrEmpty(result))
                {
                    return JsonConvert.DeserializeObject<TEntity>(result);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.Message);
            }

            return default(TEntity);
        }

        /// <summary>
        /// The Get Async method
        /// </summary>
        /// <typeparam name="TEntity">The specified type</typeparam>
        /// <param name="controller">The api controller</param>
        /// <param name="action">The api action</param>
        /// <param name="param">The param</param>
        /// <param name="token">The access token</param>
        /// <returns>deserialized object</returns>
        public static async Task<TEntity> GetAsync<TEntity>(string controller, string action, string param, string token)
        {
            try
            {
                string result = await GetAsyncHelper(FormatUrl(controller, action, param));
                if (!string.IsNullOrEmpty(result))
                {
                    return JsonConvert.DeserializeObject<TEntity>(result);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.Message);
            }

            return default(TEntity);
        }

        /// <summary>
        /// The delete async method
        /// </summary>
        /// <typeparam name="TEntity">The specified type</typeparam>
        /// <param name="controller">The api controller</param>
        /// <param name="action">The api action</param>
        /// <param name="queryStrings">The dictionary of query strings</param>
        /// <returns>The deserialized object</returns>
        public static async Task<TEntity> DeleteAsync<TEntity>(string controller, string action, IDictionary<string, string> queryStrings)
        {
            try
            {
                string result = await DeleteAsyncHelper(FormatUrl(controller, action, queryStrings));
                if (!string.IsNullOrEmpty(result))
                {
                    return JsonConvert.DeserializeObject<TEntity>(result);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.Message);
            }

            return default(TEntity);
        }

        /// <summary>
        /// The delete async method
        /// </summary>
        /// <typeparam name="TEntity">The specified type</typeparam>
        /// <param name="controller">The api controller</param>
        /// <param name="action">The api action</param>
        /// <param name="param"></param>
        /// <returns>The deserialized object</returns>
        public static async Task<TEntity> DeleteAsync<TEntity>(string controller, string action, string param)
        {
            try
            {
                string result = await DeleteAsyncHelper(FormatUrl(controller, action, param));
                if (!string.IsNullOrEmpty(result))
                {
                    return JsonConvert.DeserializeObject<TEntity>(result);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.Message);
            }

            return default(TEntity);
        }

        public static Task<T2> PostFormJsonAsync<T1, T2>(string webApiControllerActivite, object webApiDeleteActivite, T1 findRequest)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The post async method
        /// </summary>
        /// <typeparam name="TRequest">The specified request type</typeparam>
        /// <typeparam name="TResponse">The specified response type</typeparam>
        /// <param name="controller">The api controller</param>
        /// <param name="action">The api action</param>
        /// <param name="data">The request as TRequest</param>
        /// <returns>The deserialized object as TResponse</returns>
        public static async Task<TResponse> PostFormJsonAsync<TRequest, TResponse>(string controller, string action, TRequest data = default(TRequest))
        {
            try
            {
                using (var client = new HttpClient())
                {
                    HttpRequestMessage request = new HttpRequestMessage
                    {
                        RequestUri = new Uri(FormatUrl(controller, action)),
                        Method = HttpMethod.Post
                    };

                    if (data != null)
                    {
                        string jsonObject = JsonConvert.SerializeObject(data);
                        request.Content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                    }

                    var response = await client.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = JsonConvert.DeserializeObject<TResponse>(response.Content.ReadAsStringAsync().Result);
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
            return default(TResponse);
        }

        /// <summary>
        /// Post Form Url Encoded
        /// </summary>
        /// <typeparam name="TResponse">The response object</typeparam>
        /// <param name="controller">The controller name</param>
        /// <param name="action">The action name</param>
        /// <param name="postData">the post data</param>
        /// <returns>The response object as Task</returns>
        public static async Task<TResponse> PostFormUrlEncoded<TResponse>(string controller, string action, IEnumerable<KeyValuePair<string, string>> postData)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var content = new FormUrlEncodedContent(postData))
                    {
                        content.Headers.Clear();
                        content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

                        HttpResponseMessage response = await httpClient.PostAsync(FormatUrl(controller, action), content);
                        return JsonConvert.DeserializeObject<TResponse>(response.Content.ReadAsStringAsync().Result);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        /// <summary>
        /// Post Form Url Encoded
        /// </summary>
        /// <typeparam name="TRequest">The request object</typeparam>
        /// <typeparam name="TResponse">The response object</typeparam>
        /// <param name="controller">The controller name</param>
        /// <param name="action">The action name</param>
        /// <param name="data"></param>
        /// <returns>The response object as Task</returns>
        public static async Task<TResponse> PostFormUrlEncoded<TRequest, TResponse>(string controller, string action, TRequest data = default(TRequest))
        {
            List<KeyValuePair<string, string>> postData = new List<KeyValuePair<string, string>>();
            PropertyInfo[] propInfos = typeof(TRequest).GetProperties();
            foreach (PropertyInfo propInfo in propInfos)
            {
                postData.Add(new KeyValuePair<string, string>(propInfo.Name, propInfo.GetValue(data).ToString()));
            }

            using (var httpClient = new HttpClient())
            {
                using (var content = new FormUrlEncodedContent(postData))
                {
                    content.Headers.Clear();
                    content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

                    HttpResponseMessage response = await httpClient.PostAsync(FormatUrl(controller, action), content);
                    return JsonConvert.DeserializeObject<TResponse>(response.Content.ReadAsStringAsync().Result);
                }
            }
        }
        #endregion

        #region private methods

        /// <summary>
        /// format url
        /// </summary>
        /// <param name="controller">The controller name</param>
        /// <param name="action">The action name</param>
        /// <param name="queryStrings">dictionary of query strings</param>
        /// <returns>Url params</returns>
        private static string FormatUrl(string controller, string action, IDictionary<string, string> queryStrings = null)
        {
            if (queryStrings == null || !queryStrings.Any()) return $"{WebApiUrl}{controller}/{action}";
            var param = string.Concat("?", queryStrings.Select(query => $"{query.Key}={query.Value}").Aggregate((s1, s2) => s1 + "&" + s2));
            return $"{WebApiUrl}{controller}/{action}/{param}";
        }

        /// <summary>
        /// format url
        /// </summary>
        /// <param name="controller">The controller name</param>
        /// <param name="action">The action name</param>
        /// <param name="param">The parameter</param>
        /// <returns>Url params</returns>
        private static string FormatUrl(string controller, string action, string param)
        {
            return $"{WebApiUrl}{controller}/{action}?{param}";
        }

        /// <summary>
        /// Get async helper
        /// </summary>
        /// <param name="url">The url</param>
        /// <returns>The result coming from Web API</returns>
        private static async Task<string> GetAsyncHelper(string url)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                return responseMessage.Content.ReadAsStringAsync().Result;
            }
            return string.Empty;
        }

        /// <summary>
        /// Delete async helper
        /// </summary>
        /// <param name="url">The url</param>
        /// <returns>The result coming from Web API</returns>
        private static async Task<string> DeleteAsyncHelper(string url)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.DeleteAsync(url);
            return responseMessage.IsSuccessStatusCode ? responseMessage.Content.ReadAsStringAsync().Result : string.Empty;
        }
        #endregion
    }
}
