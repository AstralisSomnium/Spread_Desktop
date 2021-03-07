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

        public async Task<List<StakePool>> GetAllPoolsAsync()
        {
            var basePath = string.Format("http://localhost:{0}/v2", _port);
            Log.Verbose("Sending request for list all stake pools..");

            var stakePoolApi = new StakePoolsApi(basePath);
            var alListStakePools = await stakePoolApi.ListStakePoolsAsync(0);
            Log.Information("Found {0} stake pools", alListStakePools.Count);

            var myStakePools = new List<StakePool>();
            foreach (var stakePoolApiResponse in alListStakePools)
            {
                myStakePools.Add(new StakePool(stakePoolApiResponse));
            }
            return myStakePools;
        }

        public async Task<IEnumerable<Wallet>> GetAllWalletsAsync()
        {
            var basePath = string.Format("http://localhost:{0}/v2", _port);
            Log.Verbose("Sending request for list all stake pools..");

            var walletsApi = new WalletsApi(basePath);
            var listWallets = await walletsApi.ListWalletsAsync();

            Log.Information("Found in Daedalus {0} wallets", listWallets.Count);

            var myWallets = new List<Wallet>();
            foreach (var stakePoolApiResponse in listWallets)
            {
                myWallets.Add(new Wallet(stakePoolApiResponse));
            }
            return myWallets;
        }
    }


    public class Wallet
    {
        const int lovealceToAda = 1000000;

        public Wallet(InlineResponse200 apiResponse)
        {
            Base = apiResponse;

            Name = apiResponse.Name;
            BalanceAda = ((int) apiResponse.Balance.Available.Quantity) / lovealceToAda;
            CurrentEpochDelegationStatus = apiResponse.Delegation.Active.Status.ToString();
            if (apiResponse.Delegation.Active.Status == WalletsDelegationActive.StatusEnum.Delegating)
                CurrentEpochDelegationStatus = string.Format("{0} {1}", apiResponse.Delegation.Active.Status,
                    apiResponse.Delegation.Active.Target);

            WalletStatus = apiResponse.State.Status.ToString();
            if (apiResponse.State.Status == WalletsState.StatusEnum.Syncing)
                WalletStatus = string.Format("{0} {1} / 100", apiResponse.State.Status,
                    apiResponse.State.Progress.Quantity);
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

        public InlineResponse200 Base { get; private set; }
        public string Name { get; private set; }
        public decimal BalanceAda { get; private set; }
        public string WalletStatus { get; private set; }
        public string CurrentEpochDelegationStatus { get; private set; }
        public string NextEpochDelegationStatus { get; private set; }
        public string LastEpochDelegationStatus { get; private set; }
    }
}
