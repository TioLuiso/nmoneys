# 3.6.0.0 #
2015/01/08 @[revision 319](https://code.google.com/p/nmoneys/source/detail?r=319)
  * Apply ISO4217 amendment 159: deprecate `LTL` and change `CVE`
  * support for currencies without symbols
  * fix [issue #28](https://code.google.com/p/nmoneys/issues/detail?id=#28) by overloading `Money.Parse()`

# 2.0.0.0 #
2014/08/06 @[revision 296](https://code.google.com/p/nmoneys/source/detail?r=296)
  * Breaking change of _NuGet_ package `NMoneys.Serialization.Json_NET` as it is now a source code package with no binary dependency on _Json.NET_
  * Add source code package to support custom serialization for _ServiceStack.Text_
  * Add source code package to support custom serialization for _RavenDB_

# 3.5.1.0 #
2014/06/19 @[revision 283](https://code.google.com/p/nmoneys/source/detail?r=283)
  * Update symbol and native name for `BYR`
  * Update symbol for `BGN`
  * Update native name for `CZK`
  * Update version of _NuGet_
  * Update version of _psake_
  * Improve build scripts
  * Add facility to strongly name `NMoneys.dll` in order to upload to bin repository

# 3.5.0.0 #
2014/04/15 @[revision 273](https://code.google.com/p/nmoneys/source/detail?r=273)
  * Exposed fast equality comparer for `CurrencyIsoCode` via _Currency.Code_

# 3.4.1.0 #
2014/03/14 @[revision 268](https://code.google.com/p/nmoneys/source/detail?r=268)
  * Apply ISO4217 amendment 155: increase significative decimals for `CLF`
  * Update currencies based on newest OS/framework information: `AFN`, `BOB`, `CDF`, `CLF`, `HTG`, `IRR`, `KES`, `MDL`, `MMK`, `PHP`, `SOS` `UZS`, `XAF`
  * fixed _NUnit_ report to support UTF-8
  * Upgraded version of _NuGet_

# 3.4.0.0 #
2014/01/21 @[revision 262](https://code.google.com/p/nmoneys/source/detail?r=262)
  * Integral multiplication `.Times()` and `.Multiply()` added to _Money_

# 3.3.0.0 #
2014/01/06 @[revision 259](https://code.google.com/p/nmoneys/source/detail?r=259)
  * Changed native name: `CLF`
  * Apply ISO4217 amendment 156: deprecate `LVL`
  * Upgraded version of _NuGet_

# 3.2.0.0 #
2013/04/06 @[revision 250](https://code.google.com/p/nmoneys/source/detail?r=250)
  * Added `.Ceiling()` to _Money_
  * Removed faulty `ZMV` and replaced for correct `ZMW`, let's hope not a lot of people persisted information with the non-existing currency
  * Changed representation: `ALL`, `BWP`, `COP`, `DOP`, `ERN`, `ETB`, `GTQ`, `IRR`, `KGS`, `LTL`, `MNT`, `NIO`, `RUB`, `RWF`, `SEK`, `TJS`, `UYU`, `XCD`
  * Changed currency symbol: `AMD`, `GEL`, `INR`, `KZT`, `NGN`, `PYG`, `TJS`, `TRY`, `VEF`, `XCD`
  * Changed native name: `BGN`, `CZK`, `ERN`, `IRR`, `KZT`, `TJS`

# 2.1.1.0 #
2013/03/17 @[revision 247](https://code.google.com/p/nmoneys/source/detail?r=247)
  * Released 2.1.1.0 of _NMoney.Exchange_, including [issue 21](https://code.google.com/p/nmoneys/issues/detail?id=21)
  * Upgraded version of _NuGet_

# 3.1.0.0 #
2013/01/01 @[revision 241](https://code.google.com/p/nmoneys/source/detail?r=241)
  * Applied rest of changes from ISO4217 amendment 154: `ZMK` is deprecated, and `ZMV` has been added
  * Changed number of decimals for `UGX` as per ISO website
  * Changed misspelled denominations of `XBC` and `XBD`
  * Added _.chm_ documentation to _NMoneys_, _NMoneys.Exchange_ and _NMoneys.Serialization.Json\_NET_
  * Upgraded dependency of _NMoneys.Serialization.Json\_NET_ to latest _Json.NET_
  * Upgraded version of _NuGet_
  * Build migrated to _psake_ instead of _MSBuild_

# 3.0.0.0 #
2012/08/02 @[revision 215](https://code.google.com/p/nmoneys/source/detail?r=215)
  * _NMoneys_ version bump due to client profile targeting and some breaking changes
  * _NMoneys.Exchange_ version bump due to client profile targeting
  * **breaking change**: deprecated `CurrencyConverter`, `CurrencyCodeConverter` and `MoneyConverter` that used the old undeprecated, but well on its way out, `System.Web.Script.Serialization.JavasScriptConverter`
  * custom JSON serialiation can be performed using the `DataContractJsonSerializer` and customized with `DataContractSurrogate`
  * removed _System.Web_ dependency
  * added project _NMoneys.Serialization.Json\_NET_ which follows a parallel distribution method (different binaries and packages) to support custom JSON serialization using the popular "Json.NET" library

# 2.5.0.0 #
2012/06/25 @[revision 176](https://code.google.com/p/nmoneys/source/detail?r=176)
  * version bump due to some breaking changes
  * **breaking change**: `Allocators` namespace is now `Allocations`
  * **breaking change**: `Money.Allocate(int)` returns an `Allocation` instance, instead of `Money[]`
  * **breaking change**: `IRemainderAllocator.Allocate()` signature change. Custom implementations of the interface need to be rewritten :-(
  * **breaking change**: extension method on money instances `.Currency()` renamed to `.GetCurrency()`
  * Added `Money.Allocate(RatioCollection)` to allow pro-rated allocations. Again, many thanks to Berryl Hesh for his contribution.
  * Surfaced `EvenAllocator` to perform strictly fair allocations
  * Added `ProRatedAllocator` to perform strictly pro-rated allocations
  * Added `Money.Zero()` static factory methods that initialize arrays
  * Added `Money.Some()` static factory methods that initialize arrays
  * Added `Money.HasSameCurrencyAs()` and `Money.AssertSameCurrency` instance method that operate on collections of moneys

# 2.2.0.0 #
2012/02/13 @[revision 146](https://code.google.com/p/nmoneys/source/detail?r=146)
  * Added `Money.Allocate()`. Thanks to Berryl Hesh for the contribution
  * Added `Currency.MinAmount`, `CurrencyIsoCode.AsCurrency()` extension, `Money.Currency()` and `IEnumerable<decimal>.ToMoney()` extensions
  * updated currency definitions as per latest ISO amendment 153: GHS renamed to _Ghana Cedi_, MZN renamed to _Mozambique Metical_, RON renamed to _New Romanian Leu_ and TMT renamed to _Turkmenistan New Manat_
  * All currencies have their English name as defined per the ISO. The following currencies have been renamed and their native names updated: ALL, ANG, BAM, BDT, BOV, BRL, BYR, CLF, COU, GBP, GHS, GTQ, HNL, HUF, IDR, ILS, ISK, JPY, KGS, KRW, MKD, MOP, MXV, MZN, NAD, NGN, NIO, NPR, OMR, PAB, PEN, PLN, PYG, RON, RWF, SVC, THB, TJS, TMT, TOP, TTD, UAH, UYI, UZS, VEF, VND, XBA, XDR, ZAR
  * All currencies have their `SignificantDecimalDigits` as defined per the ISO. The following currencies have been changed: BIF, BND, BYR, CLF, CLP, DJF, GNF, IDR, IQD, KMF, MYR, PYG, RWF, UYI, UZS, VND, VUV, XAF, XOF, XPF
  * Updated _NuGet_ to v1.6.21205.9031

# 2.1.0.0 #
2011/09/01 @[revision 129](https://code.google.com/p/nmoneys/source/detail?r=129)
  * South Sudanese Pound (SSP) has been added
  * changed name of ARW to Aruban Florin
  * updated assembly description to match the one in the NuGet package
  * Updated _NuGet_ to v1.5.20830.9001

# 2.0.0.0 #
2011/06/30 @[revision 123](https://code.google.com/p/nmoneys/source/detail?r=123)
  * Breaking change: all currency code parsing/conversion methods are accessed through `Currency.Code`
  * Updated _NuGet_ to v1.4.20615.182
  * Added project _NMoneys.Exchange_ which follows a parallel distribution method (different binaries and packages)

# 1.6.0.0 #
2011/06/02 @[revision 85](https://code.google.com/p/nmoneys/source/detail?r=85)
  * Added methods `Currency.ParseCode()` and `Currency.TryParseCode()` that allow parsing `CurrencyIsoCode` strings

# 1.5.1.0 #
2011/05/15 @[revision 72](https://code.google.com/p/nmoneys/source/detail?r=72)
  * Included source code for [CodeProject](http://www.codeproject.com/KB/dotnet/NMoneys.aspx) article
  * Solved [Issue 16](https://code.google.com/p/nmoneys/issues/detail?id=16). Now, currencies can be obtained from case-insensitive three-letter codes
  * Added `AlphabeticCode()` to `Currency` and `CurrencyIsoCode` to reflect terms used by ISO
  * Updated `Money.Total()` tests to exemplify its usage

# 1.5.0.0 #
2011/05/03 @[revision 53](https://code.google.com/p/nmoneys/source/detail?r=53)
  * ADB Unit of Account (XUA) has been added
  * Updated _NuGet_ to v1.3.20425.372
  * Updated _NUnit_ to v2.5.10.11092

# 1.4.0.0 #
2011/03/17 @[revision 51](https://code.google.com/p/nmoneys/source/detail?r=51)
  * Performance improvement for unitialized `Money` instances
  * Sucre (XSU) has been added
  * checked for CLS compliancy
  * `MissconfiguredCurrencyException` renamed to `MisconfiguredCurrencyException`
  * `Currency.ObsoleteCurrency` is now an event
  * `<` and `>` operators implemented for `Currency`
  * `Money` arithmetic methods implemented as alternative to operators for languages that cannot consume operators
  * Extensive null parameter checking
  * Updated _NuGet_ to v1.1


# 1.3.1.0 #
2011/02/24 @[revision 43](https://code.google.com/p/nmoneys/source/detail?r=43)
  * Fix for unexpected behavior of unitialized `Money` instances. Now default instances have a defined currency ISO code (`XXX`)

# 1.3.0.0 #
2011/02/11 @[revision 37](https://code.google.com/p/nmoneys/source/detail?r=37)
  * Support for deprecated currencies
  * Estonian Kroon (EEK) has been deprecated
  * `Currency.Get()`, `Currency.Get()` can receive a `RegionInfo` as argument
  * Added support for HTML/XML entities (such as &eur;)
  * Updated _NuGet_ to v1.0 RTM.
  * _NuGet_ [package](http://nuget.org/Packages/Packages/Details/NMoneys-1-3-0-0) published.
  * [Gem](https://rubygems.org/gems/nmoneys) published.
  * Updated _NUnit_ to 2.5.9.10348
  * Changed MSBuild script to ease usage
    * Creates more correct _NuGet_ package
    * Copies to output _release_ directory

# 1.2.0.0 #
2010/11/20 @[revision 24](https://code.google.com/p/nmoneys/source/detail?r=24)
  * Completed Xml documentation for public members
  * `Currency.TryGet()`, `Currency.TryParse()` and `Money.TryParse()` do not throw any exception anymore
  * Added USN and USS after merging all information back from the ISO website
  * Added _NuGet_ package. It should be available from the public feed
  * Added MSBuild script to ease usage
    * Run tests and creates reports
    * Compiles binaries
    * Creates _NuGet_ package
    * Copies to output _build_ directory

# 1.1.0.0 #
2010/11/20 @[revision 15](https://code.google.com/p/nmoneys/source/detail?r=15)
  * Added `Currency.FindAll()`
  * Added `Money.Parse()` and `Money.TryParse()`
  * Implemented `IComparable` and `IComparabe<>` on `Currency`
  * Added _Joda-Money_ features:
    * Creation methods: `Money.Zero()`, `Money.ForMajor()`, `Money.ForMinor()`, and `Money.Total()`
    * Properties `Money.MinorAmount`, `Money.MajorAmount`, `Money.HasDecimals`
  * Removed "long" obsolete currency: Guinea-Bissau Franc GWP (624).
# 1.0.0.0 #
2010/10/25 @[revision 11](https://code.google.com/p/nmoneys/source/detail?r=11)
  * Baseline version