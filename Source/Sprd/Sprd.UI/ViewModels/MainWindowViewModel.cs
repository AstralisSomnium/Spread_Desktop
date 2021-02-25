using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Avalonia.Controls;
using IO.Swagger.Api;
using SprdCore;

namespace Sprd.UI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IDisposable
    {
        readonly Window _desktopMainWindow;

        readonly CardanoServer _cardanoServer;

        public ObservableCollection<StakePool> AllTimeZeroBlocksPools
        {
            get { return new ObservableCollection<StakePool>
            {
                new StakePool
                {
                    PoolName = "SPRD",
                    ActiveStake = 10000,
                    BlockChance = 1,
                    LifetimeBlocks = 0,
                    RegistredDate = DateTime.Now,
                    SprdStake = 100000
                }
            }; }
        }

        public MainWindowViewModel()
        {
        }

        public MainWindowViewModel(Window desktopMainWindow)
        {
            _desktopMainWindow = desktopMainWindow;
            _cardanoServer = new CardanoServer();
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

            var cardanoServerConsoleProcess = _cardanoServer.Start();
        }

        public void Dispose()
        {
            _cardanoServer.Dispose();
        }
    }

    public class StakePool
    {
        public string PoolName { get; set; }
        public int LifetimeBlocks { get; set; }
        public double ActiveStake { get; set; }
        public double BlockChance { get; set; }
        public double SprdStake { get; set; }
        public DateTime RegistredDate { get; set; }
    }
}