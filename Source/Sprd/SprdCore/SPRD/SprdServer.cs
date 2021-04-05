using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Serilog;

namespace SprdCore.SPRD
{
    public interface ISprdServer
    {
        Task<IEnumerable<SprdPoolInfo>> GetPoolInformationsAsync();
        Task<IFlurlResponse> AddNewPoolInfoAsync(SprdPoolInfo sprdPoolInfo);
    }

    public class SprdServer : ISprdServer
    {
        public Uri BaseUrl { get; set; }
        public string AzureCode_QueryPools_TestEnvironment { get; set; }
        public string AzureCode_AddSprd_TestEnvironment { get; set; }
        public string AzureCode_ProductionEnvironment { get; set; }
        public string RelativeUrlQueryPool { get; set; }
        public string RelativeUrlAddPoolSprd { get; set; }

        public SprdServer()
        {
            AzureCode_QueryPools_TestEnvironment = "HGm1H8cQua6DvDUxlM5tkp9RuPuEfNj4lj57aas1QpFaE6lHr44VcQ==";
            AzureCode_AddSprd_TestEnvironment = "ADaAMTjWF62MydzOM6TZvn70C3WTnOHuyHHH2DlfpiRKnbsSbRdTSw==";
            AzureCode_ProductionEnvironment = ""; // ToDo: Only SPRD contributors have access to this token

            BaseUrl = new Uri("https://spread-api.azurewebsites.net/api");
            RelativeUrlQueryPool = "/list_pool_commits";
            RelativeUrlAddPoolSprd = "/add_pool_commitment";

            Log.Verbose(string.Format("SPRD BaseUrl {0}", BaseUrl));
        }

        public async Task<IEnumerable<SprdPoolInfo>> GetPoolInformationsAsync()
        {
            Log.Verbose("GetPoolInformationsAsync");
            
            var response = (await BaseUrl.AppendPathSegment(RelativeUrlQueryPool).SetQueryParam("code", AzureCode_QueryPools_TestEnvironment).GetJsonAsync<IEnumerable<SprdPoolInfo>>());

            return response;
        }
        
        public async Task<IFlurlResponse> AddNewPoolInfoAsync(SprdPoolInfo sprdPoolInfo)
        {
            Log.Verbose("AddNewPoolInfo");
            
            var response = (await BaseUrl.AppendPathSegment(RelativeUrlAddPoolSprd)
                .SetQueryParam("code", AzureCode_AddSprd_TestEnvironment).PostJsonAsync(sprdPoolInfo));

            Log.Verbose("Response received from AddNewPoolInfo");
            return response;
        }
    }
}