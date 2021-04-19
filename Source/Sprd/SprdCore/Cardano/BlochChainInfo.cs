namespace SprdCore.Cardano
{
    public static class BlochChainInfo
    {
        public static int LovelaceToAda = 1000000;
        public static long TotalSupplyAda = 32100000000; // Updated 19.04.2021 from AdaPools.org  ToDo: should be replaced with cardano-db-sync
        public static long TotalStakedAda = 22710000000; // Updated 19.04.2021 from AdaPools.org  ToDo: should be replaced with cardano-db-sync
        public static double DecentralacationFactor = 0.02; // Updated 19.04.2021 from AdaPools.org  ToDo: should be replaced with cardano-db-sync
        public static int BlocksPerEpoch = 21000; // Updated 19.04.2021 from AdaPools.org  ToDo: should be replaced with cardano-db-sync
        public static int KValue = 500; // Updated 19.04.2021 from AdaPools.org  ToDo: should be replaced with cardano-db-sync

        public static double GetBlockChance(long activeStake)
        {
            if (activeStake == 0)
                return 0;
            var blockPerEachAda = GetBlocksForPools() / TotalStakedAda;
            var avgBlockPerEpoch = activeStake * blockPerEachAda;
            var blockChancePerEpoch = avgBlockPerEpoch;// * 100;
            return blockChancePerEpoch;
        }

        public static long GetSaturationAda()
        {
            return TotalSupplyAda / KValue;

        }
        public static double GetMinimumAdaForOneBlock()
        {
            var blockPerEachAda = GetBlocksForPools() / TotalStakedAda;
            var requiredActiveStakeForBlock = 1 / blockPerEachAda;
            return requiredActiveStakeForBlock;
        }
        public static double GetBlocksForPools()
        {
            return BlocksPerEpoch * (1 - DecentralacationFactor);
        }

    }
}