# https://editor.swagger.io/

$walletExe = "C:\Program Files\Daedalus Mainnet\cardano-wallet.exe"


# http://localhost:41799/v2/
$dataBase = "C:\Users\grube\AppData\Roaming\Daedalus Mainnet\wallets"
& $walletExe serve --port 41799 --database $dataBase --sync-tolerance 300s --mainnet --node-socket \\.\pipe\cardano-node-mainnet #--tls-ca-cert "C:\Users\grube\AppData\Roaming\Daedalus Mainnet\tls\server\ca.crt" --tls-sv-cert "C:\Users\grube\AppData\Roaming\Daedalus Mainnet\tls\server\server.crt" --tls-sv-key "C:\Users\grube\AppData\Roaming\Daedalus Mainnet\tls\server\server.key" 

$walletExe = "C:\Program Files\Daedalus Mainnet\cardano-wallet.exe"
# --ca-cert "C:\Users\grube\AppData\Roaming\Daedalus Mainnet\tls\client\ca.crt" --client-cert "C:\Users\grube\AppData\Roaming\Daedalus Mainnet\tls\client\server.crt" --client-key "C:\Users\grube\AppData\Roaming\Daedalus Mainnet\tls\client\server.key"

& $walletExe stake-pool list --port 41799
& $walletExe wallet list --port 41799
& $walletExe -h-help

#Command line: C:\Program Files\Daedalus Mainnet\cardano-wallet.exe serve --shutdown-handler --port 52800 --database C:\Users\grube\AppData\Roaming\Daedalus Mainnet\wallets --tls-ca-cert C:\Users\grube\AppData\Roaming\Daedalus Mainnet\tls\server\ca.crt --tls-sv-cert C:\Users\grube\AppData\Roaming\Daedalus Mainnet\tls\server\server.crt --tls-sv-key C:\Users\grube\AppData\Roaming\Daedalus Mainnet\tls\server\server.key --sync-tolerance 300s --mainnet --node-socket \\.\pipe\cardano-node-mainnet
#  Port 52800
# Node socket \\.\pipe\cardano-node-mainnet
# Wallet databases: Using directory: C:\Users\grube\AppData\Roaming\Daedalus Mainnet\wallets


