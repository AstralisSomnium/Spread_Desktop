using System.Collections.Generic;
using System.Linq;
using IO.Swagger.Model;
using Serilog;
using SprdCore.SPRD;

namespace SprdCore.Cardano
{
    public class Wallet
    {
        public Wallet()
        {
        }

        public Wallet(InlineResponse200 apiResponse, IEnumerable<SprdPoolInfo> sprdPoolInfos)
        {
            Base = apiResponse;

            Name = apiResponse.Name;
            BalanceAda = ((int) apiResponse.Balance.Available.Quantity) / BlochChainInfo.LovelaceToAda;

            var sprdPoolInfosForThisWallet = sprdPoolInfos.Where(p => p.wallet_id == apiResponse.Id).ToList();
            if (sprdPoolInfosForThisWallet.Any())
            {
                Log.Verbose("Found already a comitted SPRD for this wallet " + Name);
                CurrentSprdPool = sprdPoolInfosForThisWallet.First();
            }

            if (apiResponse.Delegation != null)
            {
                CurrentEpochDelegationStatus = apiResponse.Delegation.Active.Status.ToString();
                if (apiResponse.Delegation.Active.Status == WalletsDelegationActive.StatusEnum.Delegating)
                    CurrentEpochDelegationStatus = string.Format("{0} {1}", apiResponse.Delegation.Active.Status, apiResponse.Delegation.Active.Target);
                
                if (apiResponse.Delegation.Next.Count >= 1)
                {
                    var nextDelegation = apiResponse.Delegation.Next[0];
                    NextEpochDelegationStatus = nextDelegation.Status.ToString();
                    if (nextDelegation.Status == WalletsDelegationNext.StatusEnum.Delegating)
                        CurrentEpochDelegationStatus = string.Format("{0} {1} in {2} (Epoch {3})", nextDelegation.Status,
                            nextDelegation.Target, nextDelegation.ChangesAt.EpochStartTime,
                            nextDelegation.ChangesAt.EpochNumber);
                }

                if (apiResponse.Delegation.Next.Count >= 2)
                {
                    var nextDelegation = apiResponse.Delegation.Next[1];
                    LastEpochDelegationStatus = nextDelegation.Status.ToString();
                    if (nextDelegation.Status == WalletsDelegationNext.StatusEnum.Delegating)
                        LastEpochDelegationStatus = string.Format("{0} {1} in {2} (Epoch {3})", nextDelegation.Status,
                            nextDelegation.Target, nextDelegation.ChangesAt.EpochStartTime,
                            nextDelegation.ChangesAt.EpochNumber);
                }
            }

            WalletStatus = apiResponse.State.Status.ToString();
            if (apiResponse.State.Status == WalletsState.StatusEnum.Syncing)
                WalletStatus = string.Format("{0} {1} / 100", apiResponse.State.Status,
                    apiResponse.State.Progress.Quantity);
        }

        public InlineResponse200 Base { get; private set; }
        public string Name { get; set; }
        public decimal BalanceAda { get; private set; }
        public string WalletStatus { get; private set; }
        public SprdPoolInfo CurrentSprdPool { get; private set; }
        public string CurrentEpochDelegationStatus { get; private set; }
        public string NextEpochDelegationStatus { get; private set; }
        public string LastEpochDelegationStatus { get; private set; }
    }
}