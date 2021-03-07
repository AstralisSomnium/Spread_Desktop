using System;
using IO.Swagger.Model;

namespace SprdCore
{
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
            ActiveStakeAda = apiResponse.Metrics.RelativeStake.Quantity; // ToDO
            ActiveBlockChance = 100; // ToDO
            SprdStakeADA = 0; // toDo
            SprdStakeBlockChance = 0; // ToDo

            PoolRegistered = DateTime.MinValue; // ToDo
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