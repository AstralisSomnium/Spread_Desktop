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
            Saturation = apiResponse.Metrics.Saturation/100;

            var totalStakeAda = BlochChainInfo.TotalStakedAda / 100;
            //ActiveStakeAda = Convert.ToInt64(totalStakeAda * apiResponse.Metrics.RelativeStake.Quantity / 100);

            ActiveStakeAda = Convert.ToInt64(BlochChainInfo.GetSaturationAda() * apiResponse.Metrics.Saturation);
            ActiveBlockChance = BlochChainInfo.GetBlockChance(ActiveStakeAda);

            SprdStakeADA = 0; // toDo
            SprdStakeBlockChance = 0; // ToDo

            PoolRegistered = DateTime.MinValue; // ToDo
        }


        public StakePoolApiResponse Base { get; internal set; }
        public string Ticker { get; internal set; }
        public string Name { get; internal set; }
        public int? LifeTimeBlocks { get; internal set; }
        public decimal? Saturation { get; internal set; }
        public long ActiveStakeAda { get; internal set; }
        public double ActiveBlockChance { get; internal set; }
        public double SprdStakeADA { get; internal set; }
        public double SprdStakeBlockChance { get; internal set; }
        public DateTime PoolRegistered { get; internal set; }
    }
}