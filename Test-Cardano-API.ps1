
# T E S T E D  with Daedalus version 4.0.4#17475 on Windows

# This prototype starts a wallet server by connecting to the daedalus cardano
# It tried to connect directly to the wallet server of daedalus but without success see 'Connect-ToDaedalusWallet'

$walletExe = "C:\Program Files\Daedalus Mainnet\cardano-wallet.exe"
$dataBase = "C:\Users\grube\AppData\Roaming\Daedalus Mainnet\wallets"


$daedalusProcesses = Get-Process -Name "Daedalus Mainnet"
if($daedalusProcesses.Count -ne 1) {
    $daedalusProcesses = $daedalusProcesses | where { $_.MainWindowTitle -like "*Daedalus Mainnet*" }
    if($daedalusProcesses.Count -ne 1) {
        throw "Failed to find main process of Daedalus Mainnet! Its required in order to connect to the started cardano node!"
    }
}
$nodeSocket = "\\.\pipe\cardano-node-mainnet.$($daedalusProcesses.Id).0"
& $walletExe serve --shutdown-handler --port 41799 --database $dataBase --token-metadata-server https://tokens.cardano.org --sync-tolerance 300s --mainnet --node-socket $nodeSocket #--tls-ca-cert "C:\Users\grube\AppData\Roaming\Daedalus Mainnet\tls\server\ca.crt" --tls-sv-cert "C:\Users\grube\AppData\Roaming\Daedalus Mainnet\tls\server\server.crt" --tls-sv-key "C:\Users\grube\AppData\Roaming\Daedalus Mainnet\tls\server\server.key" 

# Now the server runs, access it in the browser like 
# http://localhost:41799/v2/


# Test calls agains the started wallet server 
& $walletExe stake-pool list --port 41799
& $walletExe wallet list --port 41799
& $walletExe -h-help

# Calculation for absolute stake
$totalStaked = 22790000000
$relativeStake = 0.010
$absoluteStake = $totalStaked * $relativeStake
$absoluteStake / 100 -f "d2"


function Connect-ToDaedalusWallet {
    # Accessing wallet which is started by Daedalus is not possible
    # It requires to send the client certificate because the wallet was started secure
    # The wallet API does not support it to send it to every request but also sending HTTPS request on my own does not work, see below
    # https://localhost:56460/v2/wallets

    $clientCert = "C:\Users\grube\AppData\Roaming\Daedalus Mainnet\tls\client\ca.crt"
    $serverCert = "C:\Users\grube\AppData\Roaming\Daedalus Mainnet\tls\client\server.crt"

    $content = [System.IO.File]::ReadAllBytes($clientCert)
    $cer = [system.security.cryptography.x509certificates.x509certificate2]::new($content)

    #[System.Net.ServicePointManager]::ServerCertificateValidationCallback = {$true}
    [Net.ServicePointManager]::SecurityProtocol = "Tls, Tls11, Tls12, Ssl3"
    Invoke-RestMethod -Uri "https://localhost:56460/v2/wallets" -Certificate $cer #-CertificateThumbprint $cer.Thumbprint
}