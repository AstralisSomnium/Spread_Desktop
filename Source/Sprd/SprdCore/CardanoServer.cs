using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using IO.Swagger.Client;
using SprdCore.Annotations;

namespace SprdCore
{
    public class CardanoServer : INotifyPropertyChanged
    {
        private const string DaedalusInstallPath = "C:\\Program Files\\Daedalus Mainnet\\";

        public CardanoServer()
        {
            ServerLogs = new ObservableCollection<string>();
            ServerLogs.Add("Cardano Server not started!");
        }

        public Process Start()
        {
            var startWithDaedalus = StartWithDaedalus();

            return startWithDaedalus;
        }

        Process StartWithDaedalus()
        {
            ServerLogs.Add("Searching Daedalus installation...");
            var DaedalusExePath = new FileInfo(string.Format("{0}cardano-launcher.exe", DaedalusInstallPath));
            if (!DaedalusExePath.Exists)
            {
                var errorMsg = string.Format("Not found Daedalus installation: {0} ", DaedalusExePath.FullName);
                ServerLogs.Add(errorMsg);
                throw new Exception(errorMsg);
            }

            ServerLogs.Add("Found Daedalus installation");
            var currentProcesses = Process.GetProcesses();
            var DaedalusProcesses = currentProcesses.Where(p => p.ProcessName.StartsWith("Daedalus"));
            if (DaedalusProcesses.Any())
            {
                ServerLogs.Add("Daedalus is already running");
            }
            else
            {
                ServerLogs.Add("Starting Daedalus now...");
                var process = Process.Start(DaedalusExePath.FullName);

                var timeout = 10000;
                var started = process.WaitForInputIdle(timeout);
                if (!started)
                {
                    var errorMsg = string.Format("Timed-out after {0} to start {1}", timeout, DaedalusExePath.Name); 
                    ServerLogs.Add(errorMsg);
                    throw new Exception(errorMsg);
                }
            }

            ServerLogs.Add("Starting server...");


            var daedaelusWalletPath = @"""C:\Users\grube\AppData\Roaming\Daedalus Mainnet\wallets""";

            var arguments = new[]
            {
                "--port " + 41799,
                "--database " + daedaelusWalletPath,
                "--sync-tolerance 300s",
                "--mainnet",
                @"--node-socket \\.\pipe\cardano-node-mainnet"
            };
            var startArguments = string.Format("serve {0}", string.Join(" ", arguments));
            return ExecuteWalletCommand(startArguments);
        }

        Process ExecuteWalletCommand(string command)
        {
            var daedaelusWalletFile = new FileInfo(string.Format(@"{0}cardano-wallet.exe", DaedalusInstallPath));
            var daedaelusWalletExe = string.Format(@"{0}'", daedaelusWalletFile.FullName);
            var startArguments = string.Format("{0} {1}", daedaelusWalletExe, command);
            return ExecuteCommand(daedaelusWalletFile, command);
        }

        Process ExecuteCommand(FileInfo file, string command)
        {
            var p = new Process();
            //var psi = new ProcessStartInfo {FileName = "cmd.exe", Arguments = @"/c " + command};
            var psi = new ProcessStartInfo {FileName = file.FullName, Arguments = command};
            psi.RedirectStandardError = true;
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;
            psi.WorkingDirectory = Path.GetDirectoryName(file.FullName);
            Task.Factory.StartNew(() =>
            {
                    Process process = new Process();
                    process.StartInfo = psi;
                    process.Start();
                    ServerConsoleOutput = process.StandardOutput.ReadToEnd();
                    ServerConsoleErrorOutput = process.StandardError.ReadToEnd();
            });

            return null;
        }

        private ObservableCollection<string> _serverLogs;
        public ObservableCollection<string> ServerLogs
        {
            get => _serverLogs;
            private set
            {
                _serverLogs = value;
                OnPropertyChanged();
            }
        }

        private string _serverConsoleErrorOutput;
        public string ServerConsoleErrorOutput
        {
            get => _serverConsoleErrorOutput;
            private set
            {
                _serverConsoleErrorOutput = value;
                OnPropertyChanged();
            }
        }

        private string _serverConsoleOutput;
        public string ServerConsoleOutput
        {
            get => _serverConsoleOutput;
            private set
            {
                _serverConsoleOutput = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
