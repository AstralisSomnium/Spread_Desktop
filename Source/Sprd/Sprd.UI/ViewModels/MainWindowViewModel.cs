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
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Sprd.UI.ViewModels
{
    public interface IMainWindowViewModel
    {
        ObservableCollection<Wallet> AllWallets { get; set; }
        Avalonia.Collections.DataGridCollectionView AllStakePools { get; set; }
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
            System.IO.Path.Join(System.IO.Path.GetTempPath(), "SPRD_StakePoolList_Cache.json");

        private readonly int _nodePort = 41799;
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
        
        public BlockChainCache BlockChainCache { get; set; }

        private Avalonia.Collections.DataGridCollectionView _allStakePools;
        public Avalonia.Collections.DataGridCollectionView AllStakePools
        {
            get
            {
                return _allStakePools;
            }
            set
            {
                _allStakePools = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
        }

        public MainWindowViewModel(Window desktopMainWindow)
        {
            _desktopMainWindow = desktopMainWindow;

            BlockChainCache = new BlockChainCache();
            var stakePoolDbFileInfo = new FileInfo(StakePoolListDatabase);
            if (stakePoolDbFileInfo.Exists)
            {
                var jsonCacheStakePools = File.ReadAllText(StakePoolListDatabase);
                BlockChainCache = JsonConvert.DeserializeObject<BlockChainCache>(jsonCacheStakePools);
                _allStakePools = new DataGridCollectionView(BlockChainCache.StakePools);
                OnPropertyChanged("BlockChainCache");
            }
            else
            {
                _allStakePools = new Avalonia.Collections.DataGridCollectionView(Enumerable.Empty<StakePool>());
            }
            _allWallets = new ObservableCollection<Wallet>();

            _cardanoServer = new CardanoServer();
            _walletClient = new WalletClient(_nodePort);
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
                allPools = allPools.Where(p => p.LifeTimeBlocks == 0).ToList(); //ToDO Remove when filtering is implemented: The user should be able to make custom filtering on the columns

                var blockChainCache = new BlockChainCache();
                blockChainCache.StakePools = new ObservableCollection<StakePool>(allPools);
                blockChainCache.CacheDate = DateTime.Now;
                string jsonString = JsonConvert.SerializeObject(blockChainCache);
                await File.WriteAllTextAsync(StakePoolListDatabase, jsonString);

                //var allPoolsGrouped = allPools.GroupBy(g=>g.LifeTimeBlocks == 0).ToDictionary(x => x.Key, x => x.ToList());
                var allStakePoolsGroups = new DataGridCollectionView(allPools);
                //allStakePoolsGroups.GroupDescriptions.Add(new DataGridPathGroupDescription("LifeTimeBlocks"));
                //allStakePoolsGroups.Filter = FilterProperty;
                AllStakePools = allStakePoolsGroups;

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