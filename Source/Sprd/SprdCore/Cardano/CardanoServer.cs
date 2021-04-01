using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Serilog;

namespace SprdCore.Cardano
{
    public class CardanoServer : WalletBase, INotifyPropertyChanged
    {
        public Process Start(int port)
        {
            var startWithDaedalus = StartWithDaedalus(port);

            return startWithDaedalus;
        }

        Process StartWithDaedalus(int port)
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

                var timeout = 14 * 1000;
                Thread.Sleep(timeout);
            }
            Log.Verbose("Starting server...");


            var daedaelusWalletPath = @"""C:\Users\grube\AppData\Roaming\Daedalus Mainnet\wallets""";

            var arguments = new[]
            {
                "--port " + port,
                "--database " + daedaelusWalletPath,
                "--sync-tolerance 300s",
                "--mainnet",
                @"--node-socket \\.\pipe\cardano-node-mainnet"
            };
            var startArguments = string.Format("serve {0}", string.Join(" ", arguments));
            return ExecuteWalletCommand(startArguments);
        }
        

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
