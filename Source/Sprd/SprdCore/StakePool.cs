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
                Name = apiResponse.Metadata.Name;

            LifeTimeBlocks = apiResponse.Metrics.ProducedBlocks.Quantity;
            ActiveStakeAda = apiResponse.Metrics.RelativeStake.Quantity; // ToDO
            ActiveBlockChance = 100; // ToDO
            SprdStakeADA = 0; // toDo
            SprdStakeBlockChance = 0; // ToDo

            PoolRegistered = DateTime.MinValue; // ToDo
        }

        public StakePoolApiResponse Base { get; internal set; }
        public string Name { get; internal set; }
        public int? LifeTimeBlocks { get; internal set; }
        public decimal? ActiveStakeAda { get; internal set; }
        public double ActiveBlockChance { get; internal set; }
        public double SprdStakeADA { get; internal set; }
        public double SprdStakeBlockChance { get; internal set; }
        public DateTime PoolRegistered { get; internal set; }
    }
}