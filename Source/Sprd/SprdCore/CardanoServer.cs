using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Serilog;
using SprdCore.Annotations;

namespace SprdCore
{
    public class CardanoServer : INotifyPropertyChanged, IDisposable
    {
        Process _cardanoNodeProcess;
        private const string DaedalusInstallPath = "C:\\Program Files\\Daedalus Mainnet\\";

        public CardanoServer()
        {
        }

        public Process Start()
        {
            var startWithDaedalus = StartWithDaedalus();

            return startWithDaedalus;
        }

        Process StartWithDaedalus()
        {
            Log.Verbose("Searching Daedalus installation...");
            var DaedalusExePath = new FileInfo(string.Format("{0}cardano-launcher.exe", DaedalusInstallPath));
            if (!DaedalusExePath.Exists)
            {
                var errorMsg = string.Format("Not found Daedalus installation: {0} ", DaedalusExePath.FullName);
                Log.Error(errorMsg);
                throw new Exception(errorMsg);
            }

            Log.Verbose("Found Daedalus installation");
            var currentProcesses = Process.GetProcesses();
            var DaedalusProcesses = currentProcesses.Where(p => p.ProcessName.StartsWith("Daedalus"));
            if (DaedalusProcesses.Any())
            {
                Log.Verbose("Daedalus is already running");
            }
            else
            {
                Log.Verbose("Starting Daedalus now...");
                var process = Process.Start(DaedalusExePath.FullName);

                var timeout = 100000;
                var started = process.WaitForInputIdle(timeout);
                if (!started)
                {
                    var errorMsg = string.Format("Timed-out after {0} to start {1}", timeout, DaedalusExePath.Name); 
                    Log.Error(errorMsg);
                    throw new Exception(errorMsg);
                }
            }

            Log.Verbose("Starting server...");


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
            return ExecuteCommand(daedaelusWalletFile, command);
        }

        Process ExecuteCommand(FileInfo file, string command)
        {
            _cardanoNodeProcess = new Process();
            var psi = new ProcessStartInfo {FileName = file.FullName, Arguments = command};
            _cardanoNodeProcess.StartInfo = psi;
            _cardanoNodeProcess.Start();
            return _cardanoNodeProcess;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Dispose()
        {
            _cardanoNodeProcess.Kill();
        }
    }
}
