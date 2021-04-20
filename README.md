[Twitter](https://twitter.com/PoolSprd)

# SPREAD Fairness

We do it for a fair world and therefore we are **boosting the real decentralization** of the _Cardano_ blockchain in two ways:
1. Developing this Software to **help delegators** to decentralize ADA.
2. We support the network by operating a **single stake pool** [[SPRD]](https://adapools.org/pool/2064da38531dad327135edd98003032cefa059c4c8c50c2b0440c63d). Single stake pool operators are guaranteeing that there is no concentration of ADA stake.

_Visit the website for more details: https://sprd-pool.org/_

# Software

We support true decentralization, this means pushing single pool operators. The unique advantage of our software is for small and big delegators to have guaranteed rewards and support true decentralization.

Overview of the SPRD software:
1. Brings awareness
   1. The software shows the true decentralization potential and helps to choose a pool for delegator
1. Helps choosing a pool
   1. Over 2000 registred stake pools are a lot. No doubt, it’s a hard choice if you need to pick one. SPRD is a tool to make the choice simpler and faster.
1. Ensures delegators rewards
   1. If the desired pool owns too low ADA for mining a block then the software collects all  “committed” delegators. When enough delegators are found then all of them are notified in order to make the delegation happen!

# Requirements

This page includes useful information on the supported Operating Systems as well that are needed to install and use SPRD.

## Operating Systems

Supported:
+ Linux distributions
+ Microsoft Windows
+ MacOs

## Software requirements

### Daedalus Wallet

+ Daedalus Version **4.0.14** and later
  + _Download from [offical source](
https://daedaluswallet.io/en/download/)_
  + _But no major version change is supported!_

### Installation

Gettings started:
1. Verify all the software requirments above
2. Go to the [Release](https://github.com/AstralisSomnium/Spread_Desktop/releases) page on Github
3. Download under `Assets` the file named "SPRD_Beta.zip"
4. [Unblock](https://www.tenforums.com/tutorials/5357-unblock-file-windows-10-a.html) and unzip to any directory


#### Start SPRD

1. Start [Daedalus](
https://daedaluswallet.io/en/download/) and wait until its synced
1. Execute `Sprd.UI.exe`
   1. If Daedalus is not running then it will fail, because SPRD will start the `wallet-api` and connects to the running cardano full node of Daedalus. This is required to prevent scaming by verify the wallet balance.

### Logging

+ Default log location: `%TEMP%\SPRD\sprd-{Date}.log`
+ Configuration file `Sprd.UI.dll.config`

## Open source software to collaborate on code

We want to make it as easy as possible for SPRD users to become SPRD contributors, so for now you can create issues, pulls requests, forks and communicate it with [Patrick](https://sprd-pool.org/#team) aka [@AstralisSomnium](https://github.com/AstralisSomnium)

#### Technology

We use [Microsoft .Net Core](https://dotnet.microsoft.com/download) with UI of [AvaloniUI](https://avaloniaui.net/)


#### Cardano API

SPRD uses the wallet API of cardano:
+ But all available other APIs for cardano, see [here](https://docs.cardano.org/projects/adrestia/en/latest/api-reference.html)
+ Currently this project uses only the `wallet-api` and it was used swagger to generate the c# SDK:
  + Opend https://editor.swagger.io/
    + Insert https://input-output-hk.github.io/cardano-wallet/api/edge/swagger.yaml
     + Version: 2021.2.15

### Licensing

See the [LICENSE](LICENSE) file for licensing information as it pertains to
files in this repository.

### Hiring

We're **not** developers, support people, and production engineers at the moment.


# 2. Our stake pool [SPRD]

Time is valuable and we deliver you valuable software with our time:
+ The software is free to use
+ We believe that every downloader has a heart and supports us by paypal, patreaon or by delegating ADA to our stake pool. _(see below the details)_

**Be fair and support us now!**


## Delegate ADA to our stake pool [SPRD]

_How can I delegate my ADA?_

You find [here the answer you need.](https://forum.cardano.org/t/staking-and-delegating-for-beginners-a-step-by-step-guide/36681)

Our pool:
+ Ticker **[SPRD]**
+ Pool ID [`2064da38531dad327135edd98003032cefa059c4c8c50c2b0440c63d`](https://pooltool.io/pool/2064da38531dad327135edd98003032cefa059c4c8c50c2b0440c63d)

Contributor pool:
+ Arthur supports the SPRD development a lot, so show him your gratitude:
  + Ticker **[WISE]**
  + Website: https://wise-pool.eu/

## Donate

+ [Paypal donation](https://www.paypal.com/donate?hosted_button_id=3YHSULMSHWHH6)
+ [Become a patreon](https://www.patreon.com/SprdStakePool)