/* 
 * Cardano Wallet Backend API
 *
 * <p align=\"right\"><img style=\"position: relative; top: -10em; margin-bottom: -12em;\" width=\"20%\" src=\"https://cardanodocs.com/img/cardano.png\"></img></p> 
 *
 * OpenAPI spec version: 2021.2.15
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace IO.Swagger.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
        public interface ICoinSelectionsApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Random
        /// </summary>
        /// <remarks>
        /// &lt;p align&#x3D;\&quot;right\&quot;&gt;status: &lt;strong&gt;stable&lt;/strong&gt;&lt;/p&gt;  Select coins to cover the given set of payments.  Uses the &lt;a href&#x3D;\&quot;https://iohk.io/blog/self-organisation-in-coin-selection/\&quot;&gt; Random-Improve coin selection algorithm&lt;/a&gt;. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="walletId"></param>
        /// <returns>InlineResponse2008</returns>
        InlineResponse2008 SelectCoins (Body10 body, string walletId);

        /// <summary>
        /// Random
        /// </summary>
        /// <remarks>
        /// &lt;p align&#x3D;\&quot;right\&quot;&gt;status: &lt;strong&gt;stable&lt;/strong&gt;&lt;/p&gt;  Select coins to cover the given set of payments.  Uses the &lt;a href&#x3D;\&quot;https://iohk.io/blog/self-organisation-in-coin-selection/\&quot;&gt; Random-Improve coin selection algorithm&lt;/a&gt;. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="walletId"></param>
        /// <returns>ApiResponse of InlineResponse2008</returns>
        ApiResponse<InlineResponse2008> SelectCoinsWithHttpInfo (Body10 body, string walletId);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Random
        /// </summary>
        /// <remarks>
        /// &lt;p align&#x3D;\&quot;right\&quot;&gt;status: &lt;strong&gt;stable&lt;/strong&gt;&lt;/p&gt;  Select coins to cover the given set of payments.  Uses the &lt;a href&#x3D;\&quot;https://iohk.io/blog/self-organisation-in-coin-selection/\&quot;&gt; Random-Improve coin selection algorithm&lt;/a&gt;. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="walletId"></param>
        /// <returns>Task of InlineResponse2008</returns>
        System.Threading.Tasks.Task<InlineResponse2008> SelectCoinsAsync (Body10 body, string walletId);

        /// <summary>
        /// Random
        /// </summary>
        /// <remarks>
        /// &lt;p align&#x3D;\&quot;right\&quot;&gt;status: &lt;strong&gt;stable&lt;/strong&gt;&lt;/p&gt;  Select coins to cover the given set of payments.  Uses the &lt;a href&#x3D;\&quot;https://iohk.io/blog/self-organisation-in-coin-selection/\&quot;&gt; Random-Improve coin selection algorithm&lt;/a&gt;. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="walletId"></param>
        /// <returns>Task of ApiResponse (InlineResponse2008)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2008>> SelectCoinsAsyncWithHttpInfo (Body10 body, string walletId);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
        public partial class CoinSelectionsApi : ICoinSelectionsApi
    {
        private IO.Swagger.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="CoinSelectionsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public CoinSelectionsApi(String basePath)
        {
            this.Configuration = new IO.Swagger.Client.Configuration { BasePath = basePath };

            ExceptionFactory = IO.Swagger.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CoinSelectionsApi"/> class
        /// </summary>
        /// <returns></returns>
        public CoinSelectionsApi()
        {
            this.Configuration = IO.Swagger.Client.Configuration.Default;

            ExceptionFactory = IO.Swagger.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CoinSelectionsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public CoinSelectionsApi(IO.Swagger.Client.Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = IO.Swagger.Client.Configuration.Default;
            else
                this.Configuration = configuration;

            ExceptionFactory = IO.Swagger.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete("SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public IO.Swagger.Client.Configuration Configuration {get; set;}

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public IO.Swagger.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public IDictionary<String, String> DefaultHeader()
        {
            return new ReadOnlyDictionary<string, string>(this.Configuration.DefaultHeader);
        }

        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            this.Configuration.AddDefaultHeader(key, value);
        }

        /// <summary>
        /// Random &lt;p align&#x3D;\&quot;right\&quot;&gt;status: &lt;strong&gt;stable&lt;/strong&gt;&lt;/p&gt;  Select coins to cover the given set of payments.  Uses the &lt;a href&#x3D;\&quot;https://iohk.io/blog/self-organisation-in-coin-selection/\&quot;&gt; Random-Improve coin selection algorithm&lt;/a&gt;. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="walletId"></param>
        /// <returns>InlineResponse2008</returns>
        public InlineResponse2008 SelectCoins (Body10 body, string walletId)
        {
             ApiResponse<InlineResponse2008> localVarResponse = SelectCoinsWithHttpInfo(body, walletId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Random &lt;p align&#x3D;\&quot;right\&quot;&gt;status: &lt;strong&gt;stable&lt;/strong&gt;&lt;/p&gt;  Select coins to cover the given set of payments.  Uses the &lt;a href&#x3D;\&quot;https://iohk.io/blog/self-organisation-in-coin-selection/\&quot;&gt; Random-Improve coin selection algorithm&lt;/a&gt;. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="walletId"></param>
        /// <returns>ApiResponse of InlineResponse2008</returns>
        public ApiResponse< InlineResponse2008 > SelectCoinsWithHttpInfo (Body10 body, string walletId)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling CoinSelectionsApi->SelectCoins");
            // verify the required parameter 'walletId' is set
            if (walletId == null)
                throw new ApiException(400, "Missing required parameter 'walletId' when calling CoinSelectionsApi->SelectCoins");

            var localVarPath = "/wallets/{walletId}/coin-selections/random";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (walletId != null) localVarPathParams.Add("walletId", this.Configuration.ApiClient.ParameterToString(walletId)); // path parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("SelectCoins", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2008>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2008) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2008)));
        }

        /// <summary>
        /// Random &lt;p align&#x3D;\&quot;right\&quot;&gt;status: &lt;strong&gt;stable&lt;/strong&gt;&lt;/p&gt;  Select coins to cover the given set of payments.  Uses the &lt;a href&#x3D;\&quot;https://iohk.io/blog/self-organisation-in-coin-selection/\&quot;&gt; Random-Improve coin selection algorithm&lt;/a&gt;. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="walletId"></param>
        /// <returns>Task of InlineResponse2008</returns>
        public async System.Threading.Tasks.Task<InlineResponse2008> SelectCoinsAsync (Body10 body, string walletId)
        {
             ApiResponse<InlineResponse2008> localVarResponse = await SelectCoinsAsyncWithHttpInfo(body, walletId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Random &lt;p align&#x3D;\&quot;right\&quot;&gt;status: &lt;strong&gt;stable&lt;/strong&gt;&lt;/p&gt;  Select coins to cover the given set of payments.  Uses the &lt;a href&#x3D;\&quot;https://iohk.io/blog/self-organisation-in-coin-selection/\&quot;&gt; Random-Improve coin selection algorithm&lt;/a&gt;. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="walletId"></param>
        /// <returns>Task of ApiResponse (InlineResponse2008)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2008>> SelectCoinsAsyncWithHttpInfo (Body10 body, string walletId)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling CoinSelectionsApi->SelectCoins");
            // verify the required parameter 'walletId' is set
            if (walletId == null)
                throw new ApiException(400, "Missing required parameter 'walletId' when calling CoinSelectionsApi->SelectCoins");

            var localVarPath = "/wallets/{walletId}/coin-selections/random";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (walletId != null) localVarPathParams.Add("walletId", this.Configuration.ApiClient.ParameterToString(walletId)); // path parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("SelectCoins", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2008>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2008) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2008)));
        }

    }
}
