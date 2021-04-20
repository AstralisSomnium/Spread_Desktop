using System;
using System.Collections.Generic;
using System.Linq;
using IO.Swagger.Model;
using SprdCore.SPRD;

namespace SprdCore.Cardano
{
    public class StakePool
    {
        public StakePool()
        {
        }

        public StakePool(StakePoolApiResponse apiResponse, IEnumerable<SprdPoolInfo> sprdPoolInfos)
        {
            Base = apiResponse;

            if (apiResponse.Metadata == null)
                Name = apiResponse.Id;
            else
            {
                Name = apiResponse.Metadata.Name;
                Ticker = apiResponse.Metadata.Ticker;
            }

            LifeTimeBlocks = apiResponse.Metrics.ProducedBlocks.Quantity;
            Saturation = apiResponse.Metrics.Saturation;

            ActiveStakeAda = Convert.ToInt64(BlochChainInfo.GetSaturationAda() * apiResponse.Metrics.Saturation);
            ActiveBlockChance = BlochChainInfo.GetBlockChance(ActiveStakeAda);

            var sprdPoolInfosForThisPool = sprdPoolInfos.Where(p => p.pool_id == apiResponse.Id).ToList();
            if (sprdPoolInfosForThisPool.Any())
            {
                SprdStakeADA = Convert.ToInt64(sprdPoolInfosForThisPool.Sum(p=>p.commited_ada));
            }
            else
                SprdStakeADA = 0;

            var missingAda = BlochChainInfo.GetMinimumAdaForOneBlock() - (ActiveStakeAda + SprdStakeADA);
            if (missingAda < 0)
                missingAda = 0;
            MissingAdaForBlock = Convert.ToInt64(missingAda);
            SprdStakeBlockChance = BlochChainInfo.GetBlockChance(ActiveStakeAda+SprdStakeADA);

            PoolRegistered = DateTime.MinValue; // ToDo
        }

        public StakePoolApiResponse Base { get; set; }
        public string Ticker { get;  set; }
        public string Name { get;  set; }
        public int? LifeTimeBlocks { get;  set; }
        public decimal? Saturation { get;  set; }
        public long ActiveStakeAda { get;  set; }
        public long MissingAdaForBlock { get;  set; }
        public double ActiveBlockChance { get;  set; }
        public long SprdStakeADA { get;  set; }
        public double SprdStakeBlockChance { get;  set; }
        public DateTime PoolRegistered { get;  set; }
    }
}