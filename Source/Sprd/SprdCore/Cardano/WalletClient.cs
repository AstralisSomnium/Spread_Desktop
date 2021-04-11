using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IO.Swagger.Api;
using Serilog;
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
            Log.Verbose("GetSprdPoolInfos");

            var sprdPoolInfos = await _sprdServer.GetPoolInformationsAsync();
            Log.Information("Found in SPRD database {0} in total", sprdPoolInfos.Count());
            return sprdPoolInfos;
        }

        public async Task<List<StakePool>> GetAllPoolsAsync()
        {
            var basePath = string.Format("http://localhost:{0}/v2", _port);
            Log.Verbose("Sending request for list all stake pools..");

            var stakePoolApi = new StakePoolsApi(basePath);
            var alListStakePools = await stakePoolApi.ListStakePoolsAsync(0);
            Log.Information("Found {0} stake pools", alListStakePools.Count);


            var sprdPoolInfos = await GetSprdPoolInfos();
            var myStakePools = new List<StakePool>();
            foreach (var stakePoolApiResponse in alListStakePools)
            {
                myStakePools.Add(new StakePool(stakePoolApiResponse, sprdPoolInfos));
            }
            return myStakePools;
        }

        public async Task<IEnumerable<Wallet>> GetAllWalletsAsync()
        {
            var basePath = string.Format("http://localhost:{0}/v2", _port);
            Log.Verbose("Sending request for list all stake pools..");

            var walletsApi = new WalletsApi(basePath);
            var listWallets = await walletsApi.ListWalletsAsync();

            Log.Information("Found in Daedalus {0} wallets", listWallets.Count);


            var sprdPoolInfos = await GetSprdPoolInfos();
            var myWallets = new List<Wallet>();
            foreach (var stakePoolApiResponse in listWallets)
            {
                myWallets.Add(new Wallet(stakePoolApiResponse, sprdPoolInfos));
            }
            return myWallets;
        }
    }
}
