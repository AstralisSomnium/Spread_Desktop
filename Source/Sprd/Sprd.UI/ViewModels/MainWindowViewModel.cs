using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading.Tasks;
using Avalonia.Collections;
using Avalonia.Controls;
using JetBrains.Annotations;
using MessageBox.Avalonia.Enums;
using Newtonsoft.Json;
using ReactiveUI;
using Serilog;
using SprdCore.Cardano;
using SprdCore.SPRD;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Sprd.UI.ViewModels
{
    public interface IMainWindowViewModel
    {
        ObservableCollection<Wallet> AllWallets { get; set; }
        ObservableCollection<StakePool> AllStakePools { get; set; }
    }

    public class BlockChainCache : INotifyPropertyChanged
    {
        private ObservableCollection<StakePool> _stakePools;

        public ObservableCollection<StakePool> StakePools
        {
            get
            {
                return _stakePools;
            }
            set
            {
                _stakePools = value;
                OnPropertyChanged();
            }
        }

        public DateTime CacheDate { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class MainWindowViewModel : ViewModelBase, IDisposable, INotifyPropertyChanged, IMainWindowViewModel
    {
        readonly Window _desktopMainWindow;
        private readonly SprdSettings _sprdSettings;

        readonly string _stakePoolListDatabase = System.IO.Path.Join(System.IO.Path.GetTempPath(), "SPRD\\SPRD_StakePoolList_Cache.json");
        
        readonly SprdServer _sprdServer;
        readonly CardanoServer _cardanoServer;
        readonly WalletClient _walletClient;

        ObservableCollection<Wallet> _allWallets;
        public ObservableCollection<Wallet> AllWallets
        {
            get
            {
                return new ObservableCollection<Wallet>(_allWallets.OrderBy(o => o.Name));
            }
            set
            {
                _allWallets = value;
                OnPropertyChanged();
            }
        }

        ObservableCollection<SprdPoolInfo> _lastComittedAdaPools;
        public ObservableCollection<SprdPoolInfo> LastComittedAdaPools
        {
            get
            {
                return new ObservableCollection<SprdPoolInfo>(_lastComittedAdaPools.OrderBy(o => o._id));
            }
            set
            {
                _lastComittedAdaPools = value;
                OnPropertyChanged();
            }
        }

        SprdSelection _sprdSelection;
        public SprdSelection SprdSelection
        {
            get
            {
                return _sprdSelection;
            }
            set
            {
                _sprdSelection = value;
                OnPropertyChanged();
            }
        }

        public bool ShowCaching
        {
            get
            {
                return !AllStakePools.Any() && !BlockChainCache.StakePools.Any();
            }
        }
        public BlockChainCache BlockChainCache { get; set; }

        private ObservableCollection<StakePool> _allStakePools;

        public ObservableCollection<StakePool> AllStakePools
        {
            get
            {
                return new ObservableCollection<StakePool>(_allStakePools.OrderByDescending(x => x.Saturation));
            }
            set
            {
                _allStakePools = value;
                OnPropertyChanged();
                OnPropertyChanged("AllZeroStakePools");
                OnPropertyChanged("AlmostFundedPools");
            }
        }

        public DataGridCollectionView AllZeroStakePools
        {
            get
            {
                return new DataGridCollectionView(AllStakePools.Where(p =>
                    p.LifeTimeBlocks == 0 && (p.ActiveBlockChance < 0.5 || p.SprdStakeBlockChance < 0.5)));
            }
        }

        public DataGridCollectionView AlmostFundedPools
        {
            get
            {
                return new DataGridCollectionView(AllStakePools.Where(p =>
                    p.LifeTimeBlocks == 0 && (p.ActiveBlockChance >= 0.5 || p.SprdStakeBlockChance >= 0.5)));
            }
        }

        public MainWindowViewModel()
        {
        }

        public MainWindowViewModel(Window desktopMainWindow, SprdSettings sprdSettings)
        {
            _desktopMainWindow = desktopMainWindow;
            _sprdSettings = sprdSettings;
            _sprdSelection = new SprdSelection
            {
                Pool = new StakePool { Name = "<Select Pool>" },
                Wallet = new Wallet { Name = "<Select Wallet>" },
            };

            SpreadAdaCommand = ReactiveCommand.Create(SpreadAda);//, this.WhenAnyValue(x => x.CanExecuteSprd));

            BlockChainCache = new BlockChainCache
            {
                StakePools = new ObservableCollection<StakePool>()
            };
            var stakePoolDbFileInfo = new FileInfo(_stakePoolListDatabase);
            if (stakePoolDbFileInfo.Exists)
            {
                var jsonCacheStakePools = File.ReadAllBytes(_stakePoolListDatabase);
                var readOnlySpan = new ReadOnlySpan<byte>(jsonCacheStakePools);
                BlockChainCache = JsonSerializer.Deserialize<BlockChainCache>(readOnlySpan);

                _allStakePools = BlockChainCache.StakePools;
                OnPropertyChanged("BlockChainCache");
            }
            else
            {
                _allStakePools = new ObservableCollection<StakePool>();
            }
            _allWallets = new ObservableCollection<Wallet>();
            LastComittedAdaPools = new ObservableCollection<SprdPoolInfo>();

            _cardanoServer = new CardanoServer();
            _sprdServer = new SprdServer();
            _walletClient = new WalletClient(_sprdSettings.WalletSettings.Port, _sprdServer);
            desktopMainWindow.Opened += StartCardanoServer;
            desktopMainWindow.Closing += WindowClosing;
        }

        public ReactiveCommand<Unit, Unit> SpreadAdaCommand { get; }

        public bool CanExecuteSprd
        {
            get
            {
                Log.Verbose("CanExecuteSprd");

                var canExecuteSprd = SprdSelection.Wallet?.Name != string.Empty && 
                                     SprdSelection.Wallet?.Base != null &&
                                     SprdSelection.Wallet?.Name != "<Select Wallet>" &&
                                     SprdSelection.Pool?.Name != string.Empty &&
                                     SprdSelection.Pool?.Name != "<Select Pool>" &&
                                     SprdSelection.Pool?.Base != null &&
                                     SprdSelection.NotifyEmail != string.Empty;
                Log.Verbose("CanExecuteSprd " + canExecuteSprd);

                return canExecuteSprd;
            }
        }

        public bool CanExecuteDeleteSprd
        {
            get
            {
                Log.Verbose("CanExecuteDeleteSprd");

                var canExecuteSprd = SprdSelection.Wallet?.CurrentSprdPool?.pool_id == string.Empty || 
                                     SprdSelection.Wallet?.CurrentSprdPool?.wallet_id == null ||
                                     SprdSelection.Wallet?.CurrentSprdPool?._id == null;
                Log.Verbose("CanExecuteDeleteSprd " + canExecuteSprd);

                return !canExecuteSprd;
            }
        }

        async void DeleteCurrentSprd()
        {
            try
            {
                Log.Verbose("Clicked button: DeleteCurrentSprd");
                if (!CanExecuteDeleteSprd)
                {
                    var warnMessage = string.Format(
                        "Your wallet has no commitments in the SPRD database therefore cannot delete it. If the problem persists contact support@sprd-pool.org");

                    Log.Warning(warnMessage);
                    var msgBox = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("SPRD: Missing data", warnMessage, ButtonEnum.Ok, Icon.Warning);
                    var msgBoxResult = msgBox.ShowDialog(_desktopMainWindow);
                    return;
                }

                var sprdInfo = new SprdPoolInfo()
                {
                    commited_ada = SprdSelection.Wallet.CurrentSprdPool.commited_ada,
                    commiter_email = SprdSelection.Wallet.CurrentSprdPool.commiter_email,
                    pool_id = SprdSelection.Wallet.CurrentSprdPool.pool_id,
                    wallet_id = SprdSelection.Wallet.CurrentSprdPool.wallet_id,
                    _id = SprdSelection.Wallet.CurrentSprdPool._id
                };
                var response = await _sprdServer.DeletePoolInfoAsync(sprdInfo);
                var msgBoxSuccess = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("SPRD: Sucessfully deleted spread",
                    string.Format(
                        "Deleted succesfully your SPRD for the pool {0}{1}We hope you will support another pool with your ADA!",
                        sprdInfo.pool_id, Environment.NewLine), ButtonEnum.Ok, Icon.Info);
                var msgBoxResultSuccess = await msgBoxSuccess.ShowDialog(_desktopMainWindow);
                SprdSelection.Wallet.CurrentSprdPool = null;
            }
            catch (Exception e)
            {
                var msgBox = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("SPRD: Unexpected error",
                    string.Format(
                        "While sending your deletion of SPRD to the server following error occurred: {0}{1}If the problem persists contact support@sprd-pool.org",
                        e.Message, Environment.NewLine), ButtonEnum.Ok, Icon.Error);
                var msgBoxResult = await msgBox.ShowDialog(_desktopMainWindow);
                Log.Logger.Fatal(e.Message);
            }
        }

        async void SpreadAda()
        {
            try
            {
                Log.Verbose("Clicked button: SpreadAda");
                if (!CanExecuteSprd)
                {
                    var warnMessage = string.Format(
                        "Thanks for your engagement but spreading your ADA failed because some data is missing! Select a pool, wallet and insert an email address and try again. If the problem persists contact support@sprd-pool.org");
                    
                    Log.Warning(warnMessage);
                    var msgBox = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("SPRD: Missing data", warnMessage, ButtonEnum.Ok, Icon.Warning);
                    var msgBoxResult = msgBox.ShowDialog(_desktopMainWindow);
                    return;
                }

                var sprdInfo = new SprdPoolInfo()
                {
                    commited_ada = SprdSelection.Wallet.BalanceAda,
                    commiter_email = SprdSelection.NotifyEmail,
                    pool_id = SprdSelection.Pool.Base.Id,
                    wallet_id = SprdSelection.Wallet.Base.Id
                };
                var response = await _sprdServer.AddNewPoolInfoAsync(sprdInfo);
                var msgBoxSuccess = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("SPRD: Sucessful spread",
                    string.Format(
                        "Thanks for supporting the pool {0}{1}You will get notified when enough other delegators SPRD there ADA to this pool in order to be ready to mine a block!",
                        SprdSelection.Pool.Name, Environment.NewLine), ButtonEnum.Ok, Icon.Info);
                var msgBoxResultSuccess = await msgBoxSuccess.ShowDialog(_desktopMainWindow);
            }
            catch (Exception e)
            {
                var msgBox = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("SPRD: Unexpected error",
                    string.Format(
                        "While sending your SPRD to the server following error occurred: {0}{1}If the problem persists contact support@sprd-pool.org",
                        e.Message, Environment.NewLine), ButtonEnum.Ok, Icon.Error);
                var msgBoxResult = await msgBox.ShowDialog(_desktopMainWindow);
                Log.Logger.Fatal(e.Message);
            }
        }

        void WindowClosing(object? sender, CancelEventArgs e)
        {
            Dispose();
        }

        public void StartCardanoServer(object? sender, EventArgs e)
        {
            var result = StartServerAsync();
        }

        async Task<bool> StartServerAsync()
        {
            try
            {
                WalletApiProcess = _cardanoServer.ConnectToDaedalus(_sprdSettings.WalletSettings);
            }
            catch (Exception e)
            {
                var msgBox = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("SPRD: Daedalus not running", string.Format("{0}{1}Do you want start Daedalus automatically now? SPRD requires Daedalus to be run.", e.Message, Environment.NewLine), ButtonEnum.YesNo, Icon.Stop);
                var msgBoxResult = await msgBox.ShowDialog(_desktopMainWindow);
                if (msgBoxResult == ButtonResult.No) 
                {
                    _desktopMainWindow.Close();
                    Environment.Exit(0);
                    return false;
                }
                _cardanoServer.StartDaedalus();
                WalletApiProcess = _cardanoServer.ConnectToDaedalus(_sprdSettings.WalletSettings);
            }

            try
            {
                var allWallets = await _walletClient.GetAllWalletsAsync();
                AllWallets = new ObservableCollection<Wallet>(allWallets);

                if (!AllWallets.Any())
                    throw new Exception("No wallet found in Daedalus. You cannot SPRD any ADA since a Wallet must be selected in order to verify your identity!");

                foreach (var allWallet in AllWallets)
                {
                    if (allWallet.CurrentSprdPool == null) continue;
                    var poolForWallet = BlockChainCache.StakePools.Where(p => p.Base?.Id == allWallet.CurrentSprdPool?.pool_id).ToList();
                    if(poolForWallet.Any())
                        allWallet.CurrentSprdPool.pool_id = poolForWallet.First().Name;
                }
                SprdSelection.Wallet = AllWallets.First();

                var lastCommitedPoolInformations = await _sprdServer.GetPoolInformationsAsync();
                LastComittedAdaPools = new ObservableCollection<SprdPoolInfo>(lastCommitedPoolInformations);

                var allPools = await _walletClient.GetAllPoolsAsync();
                foreach (var allWallet in AllWallets)
                {
                    if (allWallet.CurrentSprdPool == null) continue;
                    var poolForWallet = AllStakePools.Where(p => p.Base?.Id == allWallet.CurrentSprdPool?.pool_id).ToList();
                    if (poolForWallet.Any())
                        allWallet.CurrentSprdPool.pool_id = poolForWallet.First().Name;
                }

                BlockChainCache = new BlockChainCache();
                BlockChainCache.StakePools = new ObservableCollection<StakePool>(allPools);
                BlockChainCache.CacheDate = DateTime.Now;
                string jsonString = JsonConvert.SerializeObject(BlockChainCache);

                byte[] jsonUtf8Bytes;
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(BlockChainCache, options);
                await File.WriteAllBytesAsync(_stakePoolListDatabase, jsonUtf8Bytes);
                AllStakePools = new ObservableCollection<StakePool>(allPools);

                if (BlockChainCache.StakePools.Any())
                    BlockChainCache.StakePools.Clear();
                OnPropertyChanged("BlockChainCache");
            }
            catch (Exception e)
            {
                if (e.Message.Contains("The operation has timed out."))
                {
                    Log.Warning("Timeout happened, try to restart servers");
                    Dispose();
                    var started = await StartServerAsync();
                    if (started)
                        return started;
                }
                var errorMessag = string.Format("While starting the Cardano wallet API following error occurred: {0}", e.Message);
                await ShowException(errorMessag);
                return false;
            }

            return true;
        }

        public Process WalletApiProcess { get; set; }

        async Task<ButtonResult> ShowException(string message, string title = "SPRD: Unexpected error")
        {
            var msgBox = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow(title, string.Format("{0}{1}If the problem persists contact support@sprd-pool.org", message, Environment.NewLine), ButtonEnum.Ok, Icon.Error);
            var msgBoxResult = await msgBox.ShowDialog(_desktopMainWindow);
            Log.Logger.Fatal(message);
            return msgBoxResult;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void Dispose()
        {
            Log.Information("Calling Dispose");

            _cardanoServer.Dispose();
            _walletClient.Dispose();
        }
    }
}