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
        public interface IAssetsApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Get Asset
        /// </summary>
        /// <remarks>
        /// Fetch a single asset from its &#x60;policy_id&#x60; and &#x60;asset_name&#x60;, with its metadata if any.  The asset must be associated with the wallet. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="walletId"></param>
        /// <param name="policyId"></param>
        /// <param name="assetName"></param>
        /// <returns>InlineResponse2002</returns>
        InlineResponse2002 GetAsset (string walletId, string policyId, string assetName);

        /// <summary>
        /// Get Asset
        /// </summary>
        /// <remarks>
        /// Fetch a single asset from its &#x60;policy_id&#x60; and &#x60;asset_name&#x60;, with its metadata if any.  The asset must be associated with the wallet. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="walletId"></param>
        /// <param name="policyId"></param>
        /// <param name="assetName"></param>
        /// <returns>ApiResponse of InlineResponse2002</returns>
        ApiResponse<InlineResponse2002> GetAssetWithHttpInfo (string walletId, string policyId, string assetName);
        /// <summary>
        /// Get Asset (empty name)
        /// </summary>
        /// <remarks>
        /// Fetch the the asset from &#x60;policy_id&#x60; with an empty name.  The asset must be associated with the wallet. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="walletId"></param>
        /// <param name="policyId"></param>
        /// <returns>InlineResponse2002</returns>
        InlineResponse2002 GetAssetDefault (string walletId, string policyId);

        /// <summary>
        /// Get Asset (empty name)
        /// </summary>
        /// <remarks>
        /// Fetch the the asset from &#x60;policy_id&#x60; with an empty name.  The asset must be associated with the wallet. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="walletId"></param>
        /// <param name="policyId"></param>
        /// <returns>ApiResponse of InlineResponse2002</returns>
        ApiResponse<InlineResponse2002> GetAssetDefaultWithHttpInfo (string walletId, string policyId);
        /// <summary>
        /// List Assets
        /// </summary>
        /// <remarks>
        /// List all assets associated with the wallet, and their metadata if known.  An asset is _associated_ with a wallet if it is involved in a transaction of the wallet. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="walletId"></param>
        /// <returns>List&lt;InlineResponse2001&gt;</returns>
        List<InlineResponse2001> ListAssets (string walletId);

        /// <summary>
        /// List Assets
        /// </summary>
        /// <remarks>
        /// List all assets associated with the wallet, and their metadata if known.  An asset is _associated_ with a wallet if it is involved in a transaction of the wallet. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="walletId"></param>
        /// <returns>ApiResponse of List&lt;InlineResponse2001&gt;</returns>
        ApiResponse<List<InlineResponse2001>> ListAssetsWithHttpInfo (string walletId);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Get Asset
        /// </summary>
        /// <remarks>
        /// Fetch a single asset from its &#x60;policy_id&#x60; and &#x60;asset_name&#x60;, with its metadata if any.  The asset must be associated with the wallet. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="walletId"></param>
        /// <param name="policyId"></param>
        /// <param name="assetName"></param>
        /// <returns>Task of InlineResponse2002</returns>
        System.Threading.Tasks.Task<InlineResponse2002> GetAssetAsync (string walletId, string policyId, string assetName);

        /// <summary>
        /// Get Asset
        /// </summary>
        /// <remarks>
        /// Fetch a single asset from its &#x60;policy_id&#x60; and &#x60;asset_name&#x60;, with its metadata if any.  The asset must be associated with the wallet. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="walletId"></param>
        /// <param name="policyId"></param>
        /// <param name="assetName"></param>
        /// <returns>Task of ApiResponse (InlineResponse2002)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2002>> GetAssetAsyncWithHttpInfo (string walletId, string policyId, string assetName);
        /// <summary>
        /// Get Asset (empty name)
        /// </summary>
        /// <remarks>
        /// Fetch the the asset from &#x60;policy_id&#x60; with an empty name.  The asset must be associated with the wallet. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="walletId"></param>
        /// <param name="policyId"></param>
        /// <returns>Task of InlineResponse2002</returns>
        System.Threading.Tasks.Task<InlineResponse2002> GetAssetDefaultAsync (string walletId, string policyId);

        /// <summary>
        /// Get Asset (empty name)
        /// </summary>
        /// <remarks>
        /// Fetch the the asset from &#x60;policy_id&#x60; with an empty name.  The asset must be associated with the wallet. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="walletId"></param>
        /// <param name="policyId"></param>
        /// <returns>Task of ApiResponse (InlineResponse2002)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2002>> GetAssetDefaultAsyncWithHttpInfo (string walletId, string policyId);
        /// <summary>
        /// List Assets
        /// </summary>
        /// <remarks>
        /// List all assets associated with the wallet, and their metadata if known.  An asset is _associated_ with a wallet if it is involved in a transaction of the wallet. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="walletId"></param>
        /// <returns>Task of List&lt;InlineResponse2001&gt;</returns>
        System.Threading.Tasks.Task<List<InlineResponse2001>> ListAssetsAsync (string walletId);

        /// <summary>
        /// List Assets
        /// </summary>
        /// <remarks>
        /// List all assets associated with the wallet, and their metadata if known.  An asset is _associated_ with a wallet if it is involved in a transaction of the wallet. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="walletId"></param>
        /// <returns>Task of ApiResponse (List&lt;InlineResponse2001&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<InlineResponse2001>>> ListAssetsAsyncWithHttpInfo (string walletId);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
        public partial class AssetsApi : IAssetsApi
    {
        private IO.Swagger.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AssetsApi(String basePath)
        {
            this.Configuration = new IO.Swagger.Client.Configuration { BasePath = basePath };

            ExceptionFactory = IO.Swagger.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetsApi"/> class
        /// </summary>
        /// <returns></returns>
        public AssetsApi()
        {
            this.Configuration = IO.Swagger.Client.Configuration.Default;

            ExceptionFactory = IO.Swagger.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public AssetsApi(IO.Swagger.Client.Configuration configuration = null)
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
        /// Get Asset Fetch a single asset from its &#x60;policy_id&#x60; and &#x60;asset_name&#x60;, with its metadata if any.  The asset must be associated with the wallet. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="walletId"></param>
        /// <param name="policyId"></param>
        /// <param name="assetName"></param>
        /// <returns>InlineResponse2002</returns>
        public InlineResponse2002 GetAsset (string walletId, string policyId, string assetName)
        {
             ApiResponse<InlineResponse2002> localVarResponse = GetAssetWithHttpInfo(walletId, policyId, assetName);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get Asset Fetch a single asset from its &#x60;policy_id&#x60; and &#x60;asset_name&#x60;, with its metadata if any.  The asset must be associated with the wallet. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="walletId"></param>
        /// <param name="policyId"></param>
        /// <param name="assetName"></param>
        /// <returns>ApiResponse of InlineResponse2002</returns>
        public ApiResponse< InlineResponse2002 > GetAssetWithHttpInfo (string walletId, string policyId, string assetName)
        {
            // verify the required parameter 'walletId' is set
            if (walletId == null)
                throw new ApiException(400, "Missing required parameter 'walletId' when calling AssetsApi->GetAsset");
            // verify the required parameter 'policyId' is set
            if (policyId == null)
                throw new ApiException(400, "Missing required parameter 'policyId' when calling AssetsApi->GetAsset");
            // verify the required parameter 'assetName' is set
            if (assetName == null)
                throw new ApiException(400, "Missing required parameter 'assetName' when calling AssetsApi->GetAsset");

            var localVarPath = "/wallets/{walletId}/assets/{policyId}/{assetName}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
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
            if (policyId != null) localVarPathParams.Add("policyId", this.Configuration.ApiClient.ParameterToString(policyId)); // path parameter
            if (assetName != null) localVarPathParams.Add("assetName", this.Configuration.ApiClient.ParameterToString(assetName)); // path parameter

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetAsset", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2002>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2002) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2002)));
        }

        /// <summary>
        /// Get Asset Fetch a single asset from its &#x60;policy_id&#x60; and &#x60;asset_name&#x60;, with its metadata if any.  The asset must be associated with the wallet. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="walletId"></param>
        /// <param name="policyId"></param>
        /// <param name="assetName"></param>
        /// <returns>Task of InlineResponse2002</returns>
        public async System.Threading.Tasks.Task<InlineResponse2002> GetAssetAsync (string walletId, string policyId, string assetName)
        {
             ApiResponse<InlineResponse2002> localVarResponse = await GetAssetAsyncWithHttpInfo(walletId, policyId, assetName);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get Asset Fetch a single asset from its &#x60;policy_id&#x60; and &#x60;asset_name&#x60;, with its metadata if any.  The asset must be associated with the wallet. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="walletId"></param>
        /// <param name="policyId"></param>
        /// <param name="assetName"></param>
        /// <returns>Task of ApiResponse (InlineResponse2002)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2002>> GetAssetAsyncWithHttpInfo (string walletId, string policyId, string assetName)
        {
            // verify the required parameter 'walletId' is set
            if (walletId == null)
                throw new ApiException(400, "Missing required parameter 'walletId' when calling AssetsApi->GetAsset");
            // verify the required parameter 'policyId' is set
            if (policyId == null)
                throw new ApiException(400, "Missing required parameter 'policyId' when calling AssetsApi->GetAsset");
            // verify the required parameter 'assetName' is set
            if (assetName == null)
                throw new ApiException(400, "Missing required parameter 'assetName' when calling AssetsApi->GetAsset");

            var localVarPath = "/wallets/{walletId}/assets/{policyId}/{assetName}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
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
            if (policyId != null) localVarPathParams.Add("policyId", this.Configuration.ApiClient.ParameterToString(policyId)); // path parameter
            if (assetName != null) localVarPathParams.Add("assetName", this.Configuration.ApiClient.ParameterToString(assetName)); // path parameter

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetAsset", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2002>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2002) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2002)));
        }

        /// <summary>
        /// Get Asset (empty name) Fetch the the asset from &#x60;policy_id&#x60; with an empty name.  The asset must be associated with the wallet. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="walletId"></param>
        /// <param name="policyId"></param>
        /// <returns>InlineResponse2002</returns>
        public InlineResponse2002 GetAssetDefault (string walletId, string policyId)
        {
             ApiResponse<InlineResponse2002> localVarResponse = GetAssetDefaultWithHttpInfo(walletId, policyId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get Asset (empty name) Fetch the the asset from &#x60;policy_id&#x60; with an empty name.  The asset must be associated with the wallet. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="walletId"></param>
        /// <param name="policyId"></param>
        /// <returns>ApiResponse of InlineResponse2002</returns>
        public ApiResponse< InlineResponse2002 > GetAssetDefaultWithHttpInfo (string walletId, string policyId)
        {
            // verify the required parameter 'walletId' is set
            if (walletId == null)
                throw new ApiException(400, "Missing required parameter 'walletId' when calling AssetsApi->GetAssetDefault");
            // verify the required parameter 'policyId' is set
            if (policyId == null)
                throw new ApiException(400, "Missing required parameter 'policyId' when calling AssetsApi->GetAssetDefault");

            var localVarPath = "/wallets/{walletId}/assets/{policyId}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
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
            if (policyId != null) localVarPathParams.Add("policyId", this.Configuration.ApiClient.ParameterToString(policyId)); // path parameter

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetAssetDefault", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2002>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2002) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2002)));
        }

        /// <summary>
        /// Get Asset (empty name) Fetch the the asset from &#x60;policy_id&#x60; with an empty name.  The asset must be associated with the wallet. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="walletId"></param>
        /// <param name="policyId"></param>
        /// <returns>Task of InlineResponse2002</returns>
        public async System.Threading.Tasks.Task<InlineResponse2002> GetAssetDefaultAsync (string walletId, string policyId)
        {
             ApiResponse<InlineResponse2002> localVarResponse = await GetAssetDefaultAsyncWithHttpInfo(walletId, policyId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get Asset (empty name) Fetch the the asset from &#x60;policy_id&#x60; with an empty name.  The asset must be associated with the wallet. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="walletId"></param>
        /// <param name="policyId"></param>
        /// <returns>Task of ApiResponse (InlineResponse2002)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2002>> GetAssetDefaultAsyncWithHttpInfo (string walletId, string policyId)
        {
            // verify the required parameter 'walletId' is set
            if (walletId == null)
                throw new ApiException(400, "Missing required parameter 'walletId' when calling AssetsApi->GetAssetDefault");
            // verify the required parameter 'policyId' is set
            if (policyId == null)
                throw new ApiException(400, "Missing required parameter 'policyId' when calling AssetsApi->GetAssetDefault");

            var localVarPath = "/wallets/{walletId}/assets/{policyId}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
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
            if (policyId != null) localVarPathParams.Add("policyId", this.Configuration.ApiClient.ParameterToString(policyId)); // path parameter

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetAssetDefault", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2002>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2002) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2002)));
        }

        /// <summary>
        /// List Assets List all assets associated with the wallet, and their metadata if known.  An asset is _associated_ with a wallet if it is involved in a transaction of the wallet. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="walletId"></param>
        /// <returns>List&lt;InlineResponse2001&gt;</returns>
        public List<InlineResponse2001> ListAssets (string walletId)
        {
             ApiResponse<List<InlineResponse2001>> localVarResponse = ListAssetsWithHttpInfo(walletId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// List Assets List all assets associated with the wallet, and their metadata if known.  An asset is _associated_ with a wallet if it is involved in a transaction of the wallet. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="walletId"></param>
        /// <returns>ApiResponse of List&lt;InlineResponse2001&gt;</returns>
        public ApiResponse< List<InlineResponse2001> > ListAssetsWithHttpInfo (string walletId)
        {
            // verify the required parameter 'walletId' is set
            if (walletId == null)
                throw new ApiException(400, "Missing required parameter 'walletId' when calling AssetsApi->ListAssets");

            var localVarPath = "/wallets/{walletId}/assets";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
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

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ListAssets", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<InlineResponse2001>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (List<InlineResponse2001>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<InlineResponse2001>)));
        }

        /// <summary>
        /// List Assets List all assets associated with the wallet, and their metadata if known.  An asset is _associated_ with a wallet if it is involved in a transaction of the wallet. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="walletId"></param>
        /// <returns>Task of List&lt;InlineResponse2001&gt;</returns>
        public async System.Threading.Tasks.Task<List<InlineResponse2001>> ListAssetsAsync (string walletId)
        {
             ApiResponse<List<InlineResponse2001>> localVarResponse = await ListAssetsAsyncWithHttpInfo(walletId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// List Assets List all assets associated with the wallet, and their metadata if known.  An asset is _associated_ with a wallet if it is involved in a transaction of the wallet. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="walletId"></param>
        /// <returns>Task of ApiResponse (List&lt;InlineResponse2001&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<InlineResponse2001>>> ListAssetsAsyncWithHttpInfo (string walletId)
        {
            // verify the required parameter 'walletId' is set
            if (walletId == null)
                throw new ApiException(400, "Missing required parameter 'walletId' when calling AssetsApi->ListAssets");

            var localVarPath = "/wallets/{walletId}/assets";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
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

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ListAssets", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<InlineResponse2001>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (List<InlineResponse2001>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<InlineResponse2001>)));
        }

    }
}
