$decentralacationFactor = 0.10
$totalStakedAda = 23000000000
$activeStake = 1000000

$blockPerEpoch = 21600 * (1-$decentralacationFactor)

$blockPorEachAda = $blockPerEpoch  / $totalStakedAda
$requiredActiveStakeForBlock = 1 / $blockPorEachAda
$avgBlockPerEpoch = $activeStake * $blockPorEachAda
$blockChancePerEpoch = $avgBlockPerEpoch * 100

Write-Host ("With your stake of {0:n0}" -f  $activeStake)
Write-Host ("Avg block per epoch {0:n4}" -f  $avgBlockPerEpoch)
Write-Host ("Block chance per epoch {0:p0}" -f $avgBlockPerEpoch)
Write-Host ("Fix block require active stake of miniumum {0:n0}" -f $requiredActiveStakeForBlock)