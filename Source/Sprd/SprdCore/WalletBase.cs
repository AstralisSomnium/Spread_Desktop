using System;
using System.Diagnostics;
using System.IO;

namespace SprdCore
{
    public abstract class WalletBase : IDisposable
    {
        public const string DaedalusInstallPath = "C:\\Program Files\\Daedalus Mainnet\\";
        protected Process CardanoNodeProcess;

        protected Process ExecuteWalletCommand(string command)
        {
            var daedaelusWalletFile = new FileInfo(string.Format(@"{0}cardano-wallet.exe", DaedalusInstallPath));
            return ExecuteCommand(daedaelusWalletFile, command);
        }

        Process ExecuteCommand(FileInfo file, string command)
        {
            CardanoNodeProcess = new Process();
            var psi = new ProcessStartInfo { FileName = file.FullName, Arguments = command };
            CardanoNodeProcess.StartInfo = psi;
            CardanoNodeProcess.Start();
            return CardanoNodeProcess;
        }

        public void Dispose()
        {
            CardanoNodeProcess.Kill();
        }
    }
}