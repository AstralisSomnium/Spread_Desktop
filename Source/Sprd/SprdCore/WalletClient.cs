using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using IO.Swagger.Api;
using IO.Swagger.Model;
using Serilog;
using SprdCore.Annotations;

namespace SprdCore
{
    public class StakePool
    {
        public string PoolName { get; set; }
        public int LifetimeBlocks { get; set; }
        public double ActiveStake { get; set; }
        public double BlockChance { get; set; }
        public double SprdStake { get; set; }
        public DateTime RegistredDate { get; set; }
    }

    public class WalletClient : WalletBase
    {
        readonly int _port;

        public WalletClient(int port)
        {
            _port = port;
        }

        public async Task<List<StakePoolApiResponse>> GetAllPoolsAsync()
        {
            var basePath = string.Format("http://localhost:{0}/v2", _port);
            Log.Verbose("Sending request for list all stake pools..");

            var stakePoolApi = new StakePoolsApi(basePath);
            var alListStakePools = await stakePoolApi.ListStakePoolsAsync(1);
            return alListStakePools;
        }

        public List<StakePoolApiResponse> GetAllPools()
        {
            var basePath = string.Format("http://localhost:{0}/v2", _port);
            Log.Verbose("Sending request for list all stake pools..");

            var stakePoolApi = new StakePoolsApi(basePath);
            var alListStakePools = stakePoolApi.ListStakePools(0);
            return alListStakePools;
        }
    }
}
