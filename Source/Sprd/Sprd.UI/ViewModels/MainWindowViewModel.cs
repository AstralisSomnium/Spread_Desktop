using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;
using Avalonia.Collections;
using Avalonia.Controls;
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

    public class BlockChainCache
    {
        public ObservableCollection<StakePool> StakePools { get; set; }
        public DateTime CacheDate { get; set; }
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

            SpreadAdaCommand = ReactiveCommand.Create(SpreadAda, this.WhenAnyValue(x => x.CanExecuteSprd));

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

                var canExecuteSprd = SprdSelection.Wallet?.Name == string.Empty || SprdSelection.Wallet?.Base == null ||
                                     SprdSelection.Wallet?.Name == "<Select Wallet>" ||
                                     SprdSelection.Pool?.Name == string.Empty ||
                                     SprdSelection.Pool?.Name == "<Select Pool>" || SprdSelection.Pool?.Base == null ||
                                     SprdSelection.NotifyEmail == string.Empty;
                Log.Verbose("CanExecuteSprd " + canExecuteSprd);

                return !canExecuteSprd;
            }
        }

        async void SpreadAda()
        {
            try
            {
                Log.Verbose("Clicked button: SpreadAda");
                if (CanExecuteSprd)
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
                _cardanoServer.ConnectToDaedalus(_sprdSettings.WalletSettings);
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
                _cardanoServer.ConnectToDaedalus(_sprdSettings.WalletSettings);
            }

            try
            {
                var allWallets = await _walletClient.GetAllWalletsAsync();
                AllWallets = new ObservableCollection<Wallet>(allWallets);

                var allPools = await _walletClient.GetAllPoolsAsync();

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
                var errorMessag = string.Format("While starting the Cardano wallet API following error occurred: {0}", e.Message);
                await ShowException(errorMessag);
                return false;
            }

            try
            {
                if (!AllWallets.Any())
                    throw new Exception("No wallet found in Daedalus. You cannot SPRD any ADA since a Wallet must be selected in order to verify your identity!");

                SprdSelection.Wallet = AllWallets.First();
            }
            catch (Exception e)
            {
                await ShowException(e.Message);
                return false;
            }

            return true;
        }

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
            _cardanoServer.Dispose();
            _walletClient.Dispose();
        }
    }
}