using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using Serilog;

namespace SprdCore.Cardano
{
    public abstract class WalletBase : IDisposable
    {
        public const string DaedalusInstallPath = "C:\\Program Files\\Daedalus Mainnet\\";
        protected Process CardanoNodeProcess;

        protected Process ExecuteWalletCommand(string command)
        {
            Log.Verbose("ExecuteWalletCommand: '{0}'", command);

            var walletExe = "cardano-wallet.exe";
            var daedaelusWalletFile = new FileInfo(string.Format(@"{0}{1}", DaedalusInstallPath, walletExe));
            var currentProcesses = Process.GetProcesses();
            var walletProcess = currentProcesses.Where(p => p.ProcessName == Path.GetFileNameWithoutExtension(daedaelusWalletFile.Name)).ToList();
            if (walletProcess.Count > 1) // one time started by Daedalus and one time started by SPRD in INSECURE mode. 
            {
                Log.Verbose("Cardano-wallet.exe is already running");
                return walletProcess.First();
            }
            return ExecuteCommand(daedaelusWalletFile, command);
        }

        Process ExecuteCommand(FileInfo file, string command)
        {
            CardanoNodeProcess = new Process();
            var psi = new ProcessStartInfo
            {
                FileName = file.FullName, 
                Arguments = command,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            };
            CardanoNodeProcess.StartInfo = psi;
            CardanoNodeProcess.Start();
            return CardanoNodeProcess;
        }

        public void Dispose()
        {
            CardanoNodeProcess?.Kill();
            Thread.Sleep(250);
            CardanoNodeProcess?.Kill();
        }
    }
}