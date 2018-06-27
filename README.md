# TcmbSharp

[![FixerSharp Nuget](https://img.shields.io/nuget/v/FixerSharp.svg?style=flat)](https://www.nuget.org/packages/TcmbSharp)

Currency exchange rate to Turkish Lira (TL) using the Central Bank of the Republic of Turkey (TCMB) daily xml. 

PS: Rates updated every day at 15.31.

## Installation

Can be installed as a [NuGet package](https://www.nuget.org/packages/TcmbSharp). In the package manager console, enter the following:

```text
Install-Package TcmbSharp -Version 1.0.0
```

## Usage

```c#
using TcmbSharp;

...

decimal tlRate = Tcmb.Rate("USD");

```

You can reach bellowing currencies rates to TL (Turkish Lira) using this lib;
- USD
- AUD
- DKK
- EUR
- GBP
- CHF
- SEK
- CAD
- KWD
- NOK
- SAR
- JPY
- BGN
- RON
- RUB
- IRR
- CNY
- PKR

### Tcmb Xml Resources

http://www.tcmb.gov.tr/kurlar/today.xml
