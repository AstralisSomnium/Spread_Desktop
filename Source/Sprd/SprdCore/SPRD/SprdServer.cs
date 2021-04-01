using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Serilog;

namespace SprdCore.SPRD
{
    public interface ISprdServer
    {
        Task<IEnumerable<SprdPoolInfo>> GetPoolInformationsAsync();
        SprdPoolInfo AddNewPoolInfo(SprdPoolInfo sprdPoolInfo);
    }

    public class SprdServer : ISprdServer
    {
        public Uri BaseUrl { get; set; }
        public string AzureCode { get; set; }
        public string RelativeUrlQueryPool { get; set; }

        public SprdServer()
        {
            AzureCode = "HGm1H8cQua6DvDUxlM5tkp9RuPuEfNj4lj57aas1QpFaE6lHr44VcQ==";

            BaseUrl = new Uri("https://spread-api.azurewebsites.net/api");
            RelativeUrlQueryPool = "/list_pool_commits";

            Log.Verbose(string.Format("SPRD BaseUrl {0}", BaseUrl));
        }

        public async Task<IEnumerable<SprdPoolInfo>> GetPoolInformationsAsync()
        {
            Log.Verbose("GetPoolInformations");

            var response = (await BaseUrl.AppendPathSegment(RelativeUrlQueryPool).SetQueryParam("code", AzureCode).GetJsonAsync<IEnumerable<SprdPoolInfo>>());

            return response;
        }

        public SprdPoolInfo AddNewPoolInfo(SprdPoolInfo sprdPoolInfo)
        {
            throw new NotImplementedException();
        }
    }
}