# Target Platform #

_NMoneys_ is a .Net library. It is developed in C# in Visual Studio 2010 targeting the 3.5 version of the framework.
In theory, it should run in every platform that supports the .Net Framework as it is "pure" .Net (no explicit Interop, P/Invoke or OS function calls). But we expect the community of users to tell us in which platform they use the library and whether they are experiencing problems or not.

# Build sources #

Building the library is as simple as getting the latest source code from the trunk of the repository and from a powershell prompt that contains .Net framework _MsBuild.exe_ in the path, invoke:
```
path_to_source_code\build.ps1
```
and the built binary and XML documentation can be copied from
`path_to_source_code\release` into the folder that contains dependencies for your solution.

# Get the binaries #
Latest binaries can be downloaded from [Bintray](https://bintray.com/danielgonnet/nMoneys/bin/view).

For [NuGet](http://nuget.org/) users, the [NMoneys package](http://nuget.org/List/Packages/NMoneys) is available in the official live feed.

![http://nmoneys.googlecode.com/svn/wiki/NMoneys_NuGet.png](http://nmoneys.googlecode.com/svn/wiki/NMoneys_NuGet.png)

Older versions of the library are available from the [Downloads](http://code.google.com/p/nmoneys/downloads/list) section within the project's website.

For .NET developers that make use of Ruby tools, you are out of luck; the gem will no longer be updated.

## Strong naming ##
I took the decision of not strong-naming my assembly by default, as I think it causes more trouble than anything with NuGet.

In quite a few years of .NET development I have been able to dodge the need to strong name my assemblies; I suggest you do the same.

However, I see edge cases in which this decission might be preventing a limited number of users to use the library. For those unlucky few that have to live in strongly-namef land, signed versions of `NMoneys.dll` will be available from the binaries repository in [Bintray](https://bintray.com/danielgonnet/nMoneys/bin/view)

If you want to build a strongly-named version of the assembly from source, invoke:
```
path_to_source_code\build.ps1 -task Sign
```
and a strongly-named version of `NMoneys.dll` will be available in `path_to_source_code\release\signed`.
# Use the Library #

## Currencies ##

### Obtain an instance ###
`Currency` cannot be instantiated through a constructor. An instance has to be retrieved using either one of the static fields:
```
Currency euro = Currency.Eur;
```

Or one of the static creation methods:
```
Currency cad = Currency.Get(CurrencyIsoCode.CAD);
Currency australianDollar = Currency.Get("AUD");
Currency euro = Currency.Get(CultureInfo.GetCultureInfo("es-ES"));

Currency itMightNotBe;
string isoSymbol;
CurrencyIsoCode isoCode;
CultureInfo culture;
bool wasFound = Currency.TryGet(isoSymbol, out itMightNotBe);
wasFound = Currency.TryGet(isoCode, out itMightNotBe);
wasFound = Currency.TryGet(culture, out itMightNotBe);
```

The `Get()` creation method may throw if an invalid currency identifier is supplied. To prevent exceptions use the `TryGet()` methods.

### Using a currency ###
There is little to do with the type, it only contain properties such as symbol, ISO code , ISO symbol and properties that drive how a monetary quantity with this currency might look like.

### Dealing with codes ###
ISO 4417 codes are implemented as enumeration values. That means that the standard class `Enum` can be used. But the behaviors of this class can be "surprising" sometimes. In order to be consistent, we can use the `Currency.Code` class to obtain `CurrencyIsoCode` instances:
```
CurrencyIsoCode usd = Currency.Code.Cast(840);
CurrencyIsoCode eur = Currency.Code.Parse("eur");

CurrencyIsoCode? maybeAud;
Currency.Code.TryCast(36, out maybeAud);
Currency.Code.TryParse("036", out maybeAud);
```
A number of extension methods are also provided to get more information from `CurrencyIsoCode`:
```
short thirtySix = CurrencyIsoCode.AUD.NumericCode();
string USD = CurrencyIsoCode.USD.AlphabeticCode();
string zeroThreeSix = CurrencyIsoCode.AUD.PaddedNumericCode();
```
## Moneys ##

### Get an instance ###
`Money`, unlike _currencies_, can be directly instantiated.
```
var threeDollars = new Money(3m, Currency.Usd);
var twoandAHalfPounds = new Money(2.5m, CurrencyIsoCode.GBP);
var tenEuro = new Money(10m, "EUR");
var thousandWithMissingCurrency = new Money(1000m);
```

### Comparisons ###
Moneys of the same currency can be compared and its value equality asserted:
```
int isPositive = new Money(3m, Currency.Nok).CompareTo(new Money(2m, CurrencyIsoCode.NOK));
bool isFalse = new Money(2m) > new Money(3m);
bool areEqual = new Money(1m, Currency.Xxx).Equals(new Money(1m, Currency.Xxx));
bool areNotEqual = new Money(2m) != new Money(5m);
```

### Arithmetic Operations ###
Simple arithmetic operations can be performed on `Money` instances:
```
var three = new Money(3m);
var two = new Money(2m);
Money five = three.Plus(two);
Money oneOwed = two - three;
Money one = oneOwed.Abs();
```

Arihtmetic operations between instances of the same currency are open to the user via `Perform()` methods:
```
Money alsoTwo = two.Perform(ten, (amt1, amt2) => amt1 % amt2);
Money three = new Money(3.9m).Perform(amt => Math.Floor(amt));
```

### Allocations ###
Complex allocation logic is performed via the `Allocate()` methods. For example, to perform split allocations:
```
Allocation fair = 40m.Eur().Allocate(4);
// fair.IsComplete --> true
// fair.Remainder --> 0€
// fair --> < 10€, 10€, 10€ >

Allocation unfair = 40m.Eur().Allocate(3, RemainderAllocator.LastToFirst);
// unfair.IsComplete --> false
// unfair.Remainder --> 0€
// unfair --> < 13.33€, 13.33€, 13.33€, 13.34€ >
```
Pro-rated allocations are also possible:
```
var foemmelsConundrumSolution = .05m.Usd().Allocate(new RatioCollection(.3m, 0.7m));
// foemmelsConundrumSolution --> < $0.02, $0.03 >

var anotherFoemmelsConundrumSolution = .05m.Usd().Allocate(new RatioCollection(.3m, 0.7m), RemainderAllocator.LastToFirst);
// anotherFoemmelsConundrumSolution --> < $0.01, $0.04 >
```


### Formatting ###
Of course a `Money` instance can be formatted in several ways:
```
string s = tenEuro.ToString(); // default formatting "10,00 €"
s = threeDollars.ToString("N"); // format applied to currency "3.00"
s = threeDollars.ToString(CultureInfo.GetCultureInfo("es-ES")); // format provider used "3,00 €", better suited for countries with same currency and different number formatting
s = threeDollars.Format("{1} {0:00.00}"); // formatting with placeholders for currency symbol and amount "$ 03.00"
s = new Money(1500, Currency.Eur).Format("{1} {0:#,#.00}"); // rich formatting "€ 1.500,00"
```

### Extensions ###
Extension methods are provided as shortcuts for creation of money and currency instances:

```
3m.Gbp();
1000m.Pounds();
CurrencyIsoCode.NOK.ToMoney(3m);
```