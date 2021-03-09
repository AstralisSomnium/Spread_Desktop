using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Avalonia.Collections;
using Avalonia.Controls;
using DynamicData;
using IO.Swagger.Api;
using IO.Swagger.Model;
using ReactiveUI;
using Serilog;
using Sprd.UI.ViewModels;
using SprdCore;

namespace Sprd.UI
{
    public static class DesignData
    {
        public static IMainWindowViewModel FakeViewModel { get; } = new FakeMainWindowViewModel(
            new DataGridCollectionView(new[]
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
                        "http://sprd-pool.org/"), new StakepoolsRetirement(0, DateTime.Now.ToLongDateString()),
                    new List<StakePoolApiResponse.FlagsEnum>())),
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
                    new List<StakePoolApiResponse.FlagsEnum>())),
            }));
    }

    public class FakeMainWindowViewModel : IMainWindowViewModel
    {
        public ObservableCollection<Wallet> AllWallets { get; set; }
        public DataGridCollectionView AllStakePools { get; set; }

        public FakeMainWindowViewModel(DataGridCollectionView allStakePools)
        {
            AllStakePools = allStakePools;;
        }
    }
}