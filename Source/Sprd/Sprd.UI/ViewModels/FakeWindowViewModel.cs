using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using IO.Swagger.Model;
using Sprd.UI.ViewModels;
using SprdCore.Cardano;
using SprdCore.SPRD;

namespace Sprd.UI
{
    public static class DesignData
    {
        private static readonly IEnumerable<SprdPoolInfo> sprdPoolInfos = new List<SprdPoolInfo>
        {
            new SprdPoolInfo
            {
                pool_id = "MyPoolId1",
                wallet_id = "w1",
                commited_ada = 100.23m,
                commiter_email = "gruberpatrickit@gmail.com"
            }
        };

        public static IMainWindowViewModel FakeViewModel { get; } = new FakeMainWindowViewModel(
            new ObservableCollection<StakePool>(new[]
            {
                new StakePool(new StakePoolApiResponse("MyPoolId1",
                    new StakepoolsMetrics(
                        new StakepoolsMetricsNonMyopicMemberRewards(0,
                            StakepoolsMetricsNonMyopicMemberRewards.UnitEnum.Lovelace),
                        new StakepoolsMetricsRelativeStake(0.17M, StakepoolsMetricsRelativeStake.UnitEnum.Percent),
                        0.57M, new StakepoolsMetricsProducedBlocks(15, StakepoolsMetricsProducedBlocks.UnitEnum.Block)),
                    new StakepoolsCost(340000, StakepoolsCost.UnitEnum.Lovelace),
                    new StakepoolsMargin(1, StakepoolsMargin.UnitEnum.Percent),
                    new StakepoolsPledge(1000000, StakepoolsPledge.UnitEnum.Lovelace),
                    new StakepoolsMetadata("SPRD", "Spread Fairness - Stake Pool",
                        "We do it for a fair world! The goal is that every stake pool mints a block (check the website). You get rewards when we reach like 1.5m active stake, support us now. Be fair, thanks!",
                        "https://sprd-pool.org/"), new StakepoolsRetirement(0, DateTime.Now.ToLongDateString()),
                    new List<StakePoolApiResponse.FlagsEnum>()), sprdPoolInfos),
                new StakePool(new StakePoolApiResponse("MyPoolId2",
                    new StakepoolsMetrics(
                        new StakepoolsMetricsNonMyopicMemberRewards(0,
                            StakepoolsMetricsNonMyopicMemberRewards.UnitEnum.Lovelace),
                        new StakepoolsMetricsRelativeStake(0.001M, StakepoolsMetricsRelativeStake.UnitEnum.Percent),
                        0.01M, new StakepoolsMetricsProducedBlocks(0, StakepoolsMetricsProducedBlocks.UnitEnum.Block)),
                    new StakepoolsCost(340000, StakepoolsCost.UnitEnum.Lovelace),
                    new StakepoolsMargin(1, StakepoolsMargin.UnitEnum.Percent),
                    new StakepoolsPledge(1000000, StakepoolsPledge.UnitEnum.Lovelace),
                    new StakepoolsMetadata("SPRD2", "Spread Fairness - Stake Pool",
                        "We do it for a fair world! The goal is that every stake pool mints a block (check the website). You get rewards when we reach like 1.5m active stake, support us now. Be fair, thanks!",
                        "http://sprd-pool.org/"), new StakepoolsRetirement(0, DateTime.Now.ToLongDateString()),
                    new List<StakePoolApiResponse.FlagsEnum>()),sprdPoolInfos)
            }));
    }

    public class FakeMainWindowViewModel : IMainWindowViewModel
    {
        public ObservableCollection<Wallet> AllWallets { get; set; }
        public ObservableCollection<StakePool> AllStakePools { get; set; }

        public FakeMainWindowViewModel(ObservableCollection<StakePool> allStakePools)
        {
            AllStakePools = allStakePools;;
        }
    }
}