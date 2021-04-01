using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using DynamicData;
using IO.Swagger.Api;
using IO.Swagger.Model;
using Newtonsoft.Json;
using ReactiveUI;
using Serilog;
using SprdCore;
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

        string StakePoolListDatabase =
            System.IO.Path.Join(System.IO.Path.GetTempPath(), "SPRD\\SPRD_StakePoolList_Cache.json");

        private readonly int _nodePort = 41799;
        readonly SprdServer _sprdServer;
        readonly CardanoServer _cardanoServer;
        readonly WalletClient _walletClient;

        private ObservableCollection<Wallet> _allWallets;
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
        
        public Avalonia.Collections.DataGridCollectionView AllZeroStakePools
        {
            get
            {
                return new DataGridCollectionView(AllStakePools.Where(p =>
                    p.LifeTimeBlocks == 0 && (p.ActiveBlockChance < 0.5 || p.SprdStakeBlockChance < 0.5)));
            }
        }
        
        public Avalonia.Collections.DataGridCollectionView AlmostFundedPools
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

        public MainWindowViewModel(Window desktopMainWindow)
        {
            _desktopMainWindow = desktopMainWindow;

            BlockChainCache = new BlockChainCache();
            BlockChainCache.StakePools = new ObservableCollection<StakePool>();
            var stakePoolDbFileInfo = new FileInfo(StakePoolListDatabase);
            if (stakePoolDbFileInfo.Exists)
            {
                var jsonCacheStakePools = File.ReadAllBytes(StakePoolListDatabase);
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
            _walletClient = new WalletClient(_nodePort, _sprdServer);
            desktopMainWindow.Opened += StartCardanoServer;
            desktopMainWindow.Closing += WindowClosing;
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
                var cardanoServerConsoleProcess = _cardanoServer.Start(_nodePort);

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
                await File.WriteAllBytesAsync(StakePoolListDatabase, jsonUtf8Bytes);

                //var allPoolsGrouped = allPools.GroupBy(g=>g.LifeTimeBlocks == 0).ToDictionary(x => x.Key, x => x.ToList());
                var allStakePoolsGroups = new DataGridCollectionView(allPools);
                //allStakePoolsGroups.GroupDescriptions.Add(new DataGridPathGroupDescription("LifeTimeBlocks"));
                //allStakePoolsGroups.Filter = FilterProperty;
                AllStakePools = new ObservableCollection<StakePool>(allPools);

                if (BlockChainCache.StakePools.Any())
                    BlockChainCache.StakePools.Clear();
                OnPropertyChanged("BlockChainCache");

                return true;
            }
            catch (Exception e)
            {
                Log.Logger.Fatal(e.Message);
                return false;
            }
        }

        private bool FilterProperty(object arg)
        {
            Log.Verbose("FilterProperty: " + arg);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void Dispose()
        {
            _cardanoServer.Dispose();
        }
    }
}