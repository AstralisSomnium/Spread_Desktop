using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IO.Swagger.Api;
using IO.Swagger.Model;
using Microsoft.Extensions.Logging;
using SprdCore.SPRD;

namespace SprdCore.Cardano
{
    public class WalletClient : WalletBase
    {
        readonly int _port;
        private readonly ISprdServer _sprdServer;

        public WalletClient(int port, ISprdServer sprdServer)
        {
            _port = port;
            _sprdServer = sprdServer;
        }

        async Task<IEnumerable<SprdPoolInfo>> GetSprdPoolInfos()
        {
            Logging.Logger.LogInformation("GetSprdPoolInfos");

            var sprdPoolInfos = await _sprdServer.GetPoolInformationsAsync();
            Logging.Logger.LogInformation("Found in SPRD database {0} in total", sprdPoolInfos.Count());
            return sprdPoolInfos;
        }

        async Task<List<T>> ApiCallRetry<T>(Func<Task<List<T>>> apiCall)
        {
            int retryCounter = 1;
            int maxRetries = 5;
            var results = new List<T>();
            do
            {
                try
                {
                    results = await apiCall();
                    return results;
                }
                catch (Exception e)
                {
                    if (!e.Message.Contains("The operation has timed out."))
                        throw;
                    Logging.Logger.LogWarning("Timeout happened, trying again {0}/{1}", retryCounter, maxRetries);
                }
                retryCounter++;
            } while (retryCounter >= maxRetries);

            results = await apiCall();
            return results;
        }


        public async Task<List<StakePool>> GetAllPoolsAsync()
        {
            var basePath = string.Format("http://localhost:{0}/v2", _port);
            Logging.Logger.LogInformation("Sending request for list all stake pools..");

            var alListStakePools = await ApiCallRetry<StakePoolApiResponse>(async delegate
            {
                var stakePoolApi = new StakePoolsApi(basePath);
                return await stakePoolApi.ListStakePoolsAsync(0);
            });
            Logging.Logger.LogInformation("Found {0} stake pools", alListStakePools.Count);

            var sprdPoolInfos = await GetSprdPoolInfos();

            var myStakePools = new List<StakePool>();
            foreach (var stakePoolApiResponse in alListStakePools)
                myStakePools.Add(new StakePool(stakePoolApiResponse, sprdPoolInfos));
            return myStakePools;
        }

        public async Task<IEnumerable<Wallet>> GetAllWalletsAsync()
        {
            var basePath = string.Format("http://localhost:{0}/v2", _port);
            Logging.Logger.LogInformation("Sending request for list all wallets ...");

            var walletsApi = new WalletsApi(basePath);
            var listWallets = await walletsApi.ListWalletsAsync();
            Logging.Logger.LogInformation("Found in Daedalus {0} wallets", listWallets.Count);

            var sprdPoolInfos = await GetSprdPoolInfos();

            var myWallets = new List<Wallet>();
            foreach (var stakePoolApiResponse in listWallets)
                myWallets.Add(new Wallet(stakePoolApiResponse, sprdPoolInfos));
            return myWallets;
        }
    }
}
