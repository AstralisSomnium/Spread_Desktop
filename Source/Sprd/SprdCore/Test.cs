using System;
using IO.Swagger.Client;

namespace SprdCore
{
    public class CardanoServer
    {

        void Start()
        {

            var daedaelusWalletPath = @"C:\Users\grube\AppData\Roaming\Daedalus Mainnet\wallets";
            var daedaelusWalletExe = @"C:\Program Files\Daedalus Mainnet\cardano-wallet.exe";

            var startArguments = string.Format("");
            System.Diagnostics.Process.Start("cmd.exe", daedaelusWalletExe)

//& $walletExe serve --port 41799--database $dataBase--sync - tolerance 300s--mainnet--node - socket \\.\pipe\cardano - node - mainnet #--tls-ca-cert "C:\Users\grube\AppData\Roaming\Daedalus Mainnet\tls\server\ca.crt" --tls-sv-cert "C:\Users\grube\AppData\Roaming\Daedalus Mainnet\tls\server\server.crt" --tls-sv-key "C:\Users\grube\AppData\Roaming\Daedalus Mainnet\tls\server\server.key" 

            var client = new ApiClient();
            client.
        }
    }
}
