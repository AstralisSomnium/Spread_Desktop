using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using Avalonia.Controls;
using IO.Swagger.Api;
using IO.Swagger.Model;
using SprdCore;

namespace Sprd.UI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IDisposable
    {
        readonly Window _desktopMainWindow;

        private readonly int _nodePort = 41799;
        readonly CardanoServer _cardanoServer;
        readonly WalletClient _walletClient;

        private IObservable<StakePoolApiResponse> _allTimeZeroBlocksPools;
        public IObservable<StakePoolApiResponse> AllTimeZeroBlocksPools
        {
            get { return _allTimeZeroBlocksPools; 
        }
        }

        public MainWindowViewModel()
        {
        }

        public MainWindowViewModel(Window desktopMainWindow)
        {
            _desktopMainWindow = desktopMainWindow;
            
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

            var result = StartServerAsync();

        }

        async Task<bool> StartServerAsync()
        {
            var cardanoServerConsoleProcess = _cardanoServer.Start(_nodePort);

            var test = await _walletClient.GetAllPools();
            _allTimeZeroBlocksPools = test.ToObservable();
            return true;
        }

        public void Dispose()
        {
            _cardanoServer.Dispose();
        }
    }

}