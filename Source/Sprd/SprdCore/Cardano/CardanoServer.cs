using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.Extensions.Logging;

namespace SprdCore.Cardano
{
    public class WalletSettings
    {
        public int Port { get; set; }
        public string Database{ get; set; }
        public string TokenMetadataServer { get; set; }
        public string SyncTolerance { get; set; }
    }

    public class CardanoServer : WalletBase, INotifyPropertyChanged
    {
        public Process StartDaedalus()
        {
            Logging.Logger.LogInformation("Starting Daedalus now...");
            var daedalusExePath = GetDaedalusExePath();
            var process = Process.Start(daedalusExePath.FullName);
            
            return process;
        }

        FileInfo GetDaedalusExePath()
        {
            Logging.Logger.LogInformation("Searching Daedalus installation...");
            var DaedalusExePath = new FileInfo(string.Format("{0}cardano-launcher.exe", DaedalusInstallPath));
            if (DaedalusExePath.Exists)
                return DaedalusExePath;
            
            var errorMsg = string.Format("Not found Daedalus installation: {0} ", DaedalusExePath.FullName);
            Logging.Logger.LogError(errorMsg);
            throw new Exception(errorMsg);
        }

        public Process ConnectToDaedalus(WalletSettings walletSettings)
        {
            Logging.Logger.LogInformation(string.Format("ConnectToDaedalus port {0}", walletSettings.Port));
            var currentProcesses = Process.GetProcesses();
            var daedalusProcesses = currentProcesses.Where(p => p.ProcessName.StartsWith("Daedalus")).ToList();
            if (daedalusProcesses.Any())
                Logging.Logger.LogInformation("Daedalus is already running");
            else
            {
                var errorMessage = "Failed to connect to Daedalus node! Could not find the running application";
                Logging.Logger.LogError(errorMessage);
                throw new Exception(errorMessage);
            }
            Logging.Logger.LogInformation("Starting wallet server...");

            Process mainDaedalusProcess;
            if (daedalusProcesses.Count() == 1)
            {
                mainDaedalusProcess = daedalusProcesses.First();
            }
            else
            {
                daedalusProcesses = daedalusProcesses.Where(d => d.MainWindowTitle.Contains("Daedalus Mainnet")).ToList();
                if (daedalusProcesses.Count() != 1)
                    throw new Exception(
                        "Failed to find main process of Daedalus Mainnet! Its required in order to connect to the started cardano node!");

                mainDaedalusProcess = daedalusProcesses.First();
            }

            var arguments = new[]
            {
                "--shutdown-handler",
                "--port " + walletSettings.Port,
                string.Format("--database \"{0}\"",walletSettings.Database),
                string.Format("--sync-tolerance {0}s", walletSettings.SyncTolerance),
                "--mainnet",
                string.Format(@"--node-socket \\.\pipe\cardano-node-mainnet.{0}.0", mainDaedalusProcess.Id)
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
