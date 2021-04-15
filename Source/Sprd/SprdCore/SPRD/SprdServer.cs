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
        public string AzureCode_DeleteSprd_TestEnvironment { get; set; }
        public string AzureCode_ProductionEnvironment { get; set; }
        public string RelativeUrlQueryPool { get; set; }
        public string RelativeUrlAddPoolSprd { get; set; }
        public string RelativeUrlDeletePoolSprd { get; set; }

        public SprdServer()
        {
            AzureCode_QueryPools_TestEnvironment = "HGm1H8cQua6DvDUxlM5tkp9RuPuEfNj4lj57aas1QpFaE6lHr44VcQ==";
            AzureCode_AddSprd_TestEnvironment = "ADaAMTjWF62MydzOM6TZvn70C3WTnOHuyHHH2DlfpiRKnbsSbRdTSw==";
            AzureCode_DeleteSprd_TestEnvironment = "W/D8J7d4Q1SHIVI65umLfF3xG8aVhOXOcp3OaKkiaIv9spL/kN2KFg==";

            AzureCode_ProductionEnvironment = ""; // ToDo: Only SPRD contributors have access to this token

            BaseUrl = new Uri("https://spread-api.azurewebsites.net/api");
            RelativeUrlQueryPool = "/list_pool_commits";
            RelativeUrlAddPoolSprd = "/add_pool_commitment";
            RelativeUrlDeletePoolSprd = "/del_pool_commit";

            Log.Verbose(string.Format("SPRD BaseUrl {0}", BaseUrl));
        }

        public async Task<IEnumerable<SprdPoolInfo>> GetPoolInformationsAsync()
        {
            Log.Verbose("GetPoolInformationsAsync");
            
            var response = (await BaseUrl.AppendPathSegment(RelativeUrlQueryPool).SetQueryParam("code", AzureCode_QueryPools_TestEnvironment).GetJsonAsync<IEnumerable<SprdPoolInfo>>());

            return response;
        }
        // https://spread-api.azurewebsites.net/api/del_pool_commit/{id}?code=W/D8J7d4Q1SHIVI65umLfF3xG8aVhOXOcp3OaKkiaIv9spL/kN2KFg==
        public async Task<IFlurlResponse> AddNewPoolInfoAsync(SprdPoolInfo sprdPoolInfo)
        {
            Log.Verbose("AddNewPoolInfo");

            var response = (await BaseUrl.AppendPathSegment(RelativeUrlAddPoolSprd)
                .SetQueryParam("code", AzureCode_AddSprd_TestEnvironment).PostJsonAsync(sprdPoolInfo));

            Log.Verbose("Response received from AddNewPoolInfo");
            return response;
        }

        public async Task<IFlurlResponse> DeletePoolInfoAsync(SprdPoolInfo sprdPoolInfo)
        {
            Log.Verbose("DeletePoolInfoAsync");

            var response = (await BaseUrl.AppendPathSegments(RelativeUrlDeletePoolSprd, sprdPoolInfo._id)
                .SetQueryParam("code", AzureCode_DeleteSprd_TestEnvironment).DeleteAsync());

            Log.Verbose("Response received from DeletePoolInfoAsync");
            return response;
        }
    }
}