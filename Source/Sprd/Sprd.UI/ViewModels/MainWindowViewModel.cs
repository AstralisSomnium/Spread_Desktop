using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Avalonia.Controls;
using DynamicData;
using IO.Swagger.Api;
using IO.Swagger.Model;
using ReactiveUI;
using Serilog;
using SprdCore;

namespace Sprd.UI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IDisposable, INotifyPropertyChanged
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

        private ObservableCollection<StakePool> _allStakePools;
        public ObservableCollection<StakePool> AllStakePools
        {
            get
            {
                return new ObservableCollection<StakePool>(_allStakePools.OrderBy(o => o.LifeTimeBlocks));
            }
            set
            {
                _allStakePools = value;
                OnPropertyChanged();
                OnPropertyChanged("AllTimeZeroBlocksPools");
                OnPropertyChanged("AlmostFundedPools");
            }
        }

        public ObservableCollection<StakePool> AllTimeZeroBlocksPools
        {
            get { return new ObservableCollection<StakePool>(AllStakePools.Where(p => p.LifeTimeBlocks == 0).OrderBy(o=>o.Name)); }
        }

        public ObservableCollection<StakePool> AlmostFundedPools
        {
            get { return new ObservableCollection<StakePool>(AllStakePools.Where(p => p.SprdStakeBlockChance > 50).OrderBy(o=>o.SprdStakeBlockChance)); }
        }

        public MainWindowViewModel()
        {
        }

        public MainWindowViewModel(Window desktopMainWindow)
        {
            _desktopMainWindow = desktopMainWindow;

            _allStakePools = new ObservableCollection<StakePool>();
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
            //DoTheThing = ReactiveCommand.Create<string>(RunTheThing);

            //var result = StartServerAsync();
            var result = StartServerAsync();
        }

        async Task<bool> StartServerAsync()
        {
            var cardanoServerConsoleProcess = _cardanoServer.Start(_nodePort);


            var allWallets = await _walletClient.GetAllWalletsAsync();
            AllWallets = new ObservableCollection<Wallet>(allWallets);

            var allPools = await _walletClient.GetAllPoolsAsync();
            AllStakePools = new ObservableCollection<StakePool>(allPools);
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