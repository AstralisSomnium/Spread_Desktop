using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IO.Swagger.Api;
using IO.Swagger.Model;
using Serilog;

namespace SprdCore
{
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

        public IEnumerable<StakePool> GetAllPools()
        {
            var basePath = string.Format("http://localhost:{0}/v2", _port);
            Log.Verbose("Sending request for list all stake pools..");

            var stakePoolApi = new StakePoolsApi(basePath);
            var alListStakePools = stakePoolApi.ListStakePools(0);
            foreach (var stakePoolApiResponse in alListStakePools)
            {
                yield return new StakePool(stakePoolApiResponse);
            }
        }
    }

    public class StakePool
    {
        public StakePool(StakePoolApiResponse apiResponse)
        {
            Base = apiResponse;

            if (apiResponse.Metadata == null)
                Name = apiResponse.Id;
            else
                Name = apiResponse.Metadata.Name;
            LifeTimeBlocks = apiResponse.Metrics.ProducedBlocks.Quantity;
            ActiveStakeAda = apiResponse.Metrics.RelativeStake.Quantity;
            ActiveBlockChance = 100;
            SprdStakeADA = 0;
            SprdStakeBlockChance = 0;

            PoolRegistered = DateTime.MinValue;
        }

        public StakePoolApiResponse Base { get; private set; }
        public string Name { get; private set; }
        public int? LifeTimeBlocks { get; private set; }
        public decimal? ActiveStakeAda { get; private set; }
        public double ActiveBlockChance { get; private set; }
        public double SprdStakeADA { get; private set; }
        public double SprdStakeBlockChance { get; private set; }
        public DateTime PoolRegistered { get; private set; }
    }
}
