using System;
using IO.Swagger.Model;

namespace SprdCore
{
    public class StakePool
    {
        public StakePool()
        {
        }

        public StakePool(StakePoolApiResponse apiResponse)
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

            SprdStakeADA = Convert.ToInt64(ActiveStakeAda *0.23); // Its just a dummy implementaiton with 23 % toDo!
            var missingAda = BlochChainInfo.GetMinimumAdaForOneBlock() - (ActiveStakeAda + SprdStakeADA);
            if (missingAda < 0)
                missingAda = 0;
            MissingAdaForBlock = Convert.ToInt64(missingAda);
            SprdStakeBlockChance = BlochChainInfo.GetBlockChance(ActiveStakeAda+SprdStakeADA);

            PoolRegistered = DateTime.MinValue; // ToDo
        }

        public StakePoolApiResponse Base { get; internal set; }
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