using System;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using SprdCore;

namespace Sprd.UI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        readonly Window _desktopMainWindow;

        readonly CardanoServer _cardanoServer;
        public string ServerStatus => _cardanoServer.ServerLogs.LastOrDefault() ?? string.Empty;
        public string ServerConsoleOutput => _cardanoServer.ServerConsoleOutput;
        public string ServerConsoleErrorOutput => _cardanoServer.ServerConsoleErrorOutput;

        public string ServerLogs
        {
            get { return string.Join(Environment.NewLine, _cardanoServer.ServerLogs); }
        }

        public MainWindowViewModel(Window desktopMainWindow)
        {
            _desktopMainWindow = desktopMainWindow;
            _cardanoServer = new CardanoServer();
            desktopMainWindow.Opened += StartCardanoServer;
        }

        public void StartCardanoServer(object? sender, EventArgs e)
        {

            //DoTheThing = ReactiveCommand.Create<string>(RunTheThing);

            var cardanoServerConsoleProcess = _cardanoServer.Start();

            // Use Win32API to set the command process to the panel
            // Win32API.SetParent(cardanoServerConsoleProcess.MainWindowHandle, panel.Handle);        }

        }
    }
}
