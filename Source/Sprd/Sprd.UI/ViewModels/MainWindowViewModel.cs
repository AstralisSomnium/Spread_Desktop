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
using SprdCore;

namespace Sprd.UI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IDisposable, INotifyPropertyChanged
    {
        readonly Window _desktopMainWindow;

        private readonly int _nodePort = 41799;
        readonly CardanoServer _cardanoServer;
        readonly WalletClient _walletClient;

        private ObservableCollection<StakePool> _allTimeZeroBlocksPools;
        public ObservableCollection<StakePool> AllTimeZeroBlocksPools
        {
            get { return _allTimeZeroBlocksPools; }
            set
            {
                _allTimeZeroBlocksPools = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
        }

        public MainWindowViewModel(Window desktopMainWindow)
        {
            _desktopMainWindow = desktopMainWindow;
            
            AllTimeZeroBlocksPools = new ObservableCollection<StakePool>();

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
            var result = StartServer();
        }

        async Task<bool> StartServerAsync()
        {
            var cardanoServerConsoleProcess = _cardanoServer.Start(_nodePort);

            var test = await _walletClient.GetAllPoolsAsync();
            //AllTimeZeroBlocksPools.AddRange(test);
            OnPropertyChanged("LoadedPoolMetaDatas");
            return true;
        }

        bool StartServer()
        {
            var cardanoServerConsoleProcess = _cardanoServer.Start(_nodePort);

            var test = _walletClient.GetAllPools();
            AllTimeZeroBlocksPools.AddRange(test);
            //OnPropertyChanged("AllTimeZeroBlocksPools");
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