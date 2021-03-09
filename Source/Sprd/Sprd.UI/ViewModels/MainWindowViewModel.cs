using System;
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
using SprdCore;

namespace Sprd.UI.ViewModels
{
    public interface IMainWindowViewModel
    {
        ObservableCollection<Wallet> AllWallets { get; set; }
        Avalonia.Collections.DataGridCollectionView AllStakePools { get; set; }
    }

    public class MainWindowViewModel : ViewModelBase, IDisposable, INotifyPropertyChanged, IMainWindowViewModel
    {
        readonly Window _desktopMainWindow;

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

            _allStakePools = new Avalonia.Collections.DataGridCollectionView(Enumerable.Empty<StakePool>());
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
            var cardanoServerConsoleProcess = _cardanoServer.Start(_nodePort);

            var allWallets = await _walletClient.GetAllWalletsAsync();
            AllWallets = new ObservableCollection<Wallet>(allWallets);

            var allPools = await _walletClient.GetAllPoolsAsync();
            var allPoolsGrouped = allPools.GroupBy(g=>g.LifeTimeBlocks).ToDictionary(x => x.Key, x => x.ToList());
            var allStakePoolsGroups = new DataGridCollectionView(allPools);
            allStakePoolsGroups.GroupDescriptions.Add(new DataGridPathGroupDescription("LifeTimeBlocks"));
            allStakePoolsGroups.Filter = FilterProperty;
            AllStakePools = allStakePoolsGroups;
            return true;
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