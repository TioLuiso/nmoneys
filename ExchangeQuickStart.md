# Target Platforms #

_NMoneys.Exchange_ targets the same platforms as _NMoneys_, that is, the .Net framework 3.5. As a matter of fact, it is just another project in the same solution although its lifecycle as a project is likely to be completely different.

# Build sources #

Building the library is as simple as building _NMoneys_. In fact the same build creates the deployable artifacts for both projects. For more details refer to the corresponding [developer quickstart section](DeveloperQuickStart#Build_sources.md).

# Get the binaries #
As with _NMoneys_, latest binaries can be downloaded from the [Downloads](Downloads.md) section within the project's website.
For [NuGet](http://nuget.org/) users, the [NMoneys.Exchange package](http://nuget.org/List/Packages/NMoneys.Exchange) is available in the official live feed.

![http://nmoneys.googlecode.com/svn/wiki/NMoneysExchange_NuGet.png](http://nmoneys.googlecode.com/svn/wiki/NMoneysExchange_NuGet.png)

For .NET developers that make use of Ruby tools, you are out of luck; the gem will no longer be updated.

# Use the Library #

## Converting moneys ##
Performing conversion operations is really easy. Once the project has a reference to `NMoneys.dll` and to `NMoneys.Exchange.dll` assemblies one can convert from one currency to another using the `.Convert()` and `.TryConvert()` extensions methods on any `Money` instance. By default, that is without any further configuration, conversions are pretty useless as the ratewe get is alway one:
```
var tenEuro = new Money(10m, CurrencyIsoCode.EUR);

var tenDollar = tenEuro.Convert().To(CurrencyIsoCode.USD);
var tenPounds = tenEuro.Convert().To(Currency.Gbp);
```

## Configure a provider ##
As stated, in order to use meaningful rates, one has to implement the `IExchangeRateProvider` interface, or use the already provided `TabulatedExchangeRateProvider` that eases the set up of conversion tables. Once implemented, the provider can be easily configured:
```
var customProvider = new TabulatedExchangeRateProvider();
customProvider.Add(CurrencyIsoCode.EUR, CurrencyIsoCode.USD, 0);

ExchangeRateProvider.Provider = () => customProvider;

var tenEuro = new Money(10m, CurrencyIsoCode.EUR);
var zeroDollars = tenEuro.Convert().To(CurrencyIsoCode.USD);

// go back to default (optional)
ExchangeRateProvider.Provider = ExchangeRateProvider.Default;
```

Being a static provider, all conversions will use the same configured provider. It is up to the developer to decide the life style of the provider instance to be used.

## Custom arithmetic ##
One of tbe reasons for not implementing conversion between quantities of different currencies was the lack of knowledge on the internals of such operations.
Unfortunately this has not changed and the default conversion arithmetics is coded inside the `ExchangeRate` class, which uses standard `decimal` multiplication.
Fortunately, that default behavior can be changed easily by overriding some methods in that class:
```
public class CustomRateArithmetic : ExchangeRate
{
	public CustomRateArithmetic(CurrencyIsoCode from, CurrencyIsoCode to, decimal rate) : base(from, to, rate) { }

	public override Money Apply(Money from)
	{
		return new Money(0m, To);
	}
}
```
With our implementation of how to apply a rate a provider that uses that custom implementation needs to be implemented and configured:
```
public class CustomArithmeticProvider : IExchangeRateProvider
{
	public ExchangeRate Get(CurrencyIsoCode from, CurrencyIsoCode to)
	{
		return new CustomRateArithmetic(from, to, 1m);
	}

	public bool TryGet(CurrencyIsoCode from, CurrencyIsoCode to, out ExchangeRate rate)
	{
		rate = new CustomRateArithmetic(from, to, 1m);
		return true;
	}
}
```
## Overpassing the Provider ##
If one does not want to use the whole provider architecture, one can go completely custom, implementing its own set of extension methods, which can have as simple or as complex semantics as desired. In this case we want to chain two calls so that it "reads" like English:
```
public static UsingImplementor Using(this IExchangeConversion conversion, decimal rate)
{
	return new UsingImplementor(conversion.From, rate);
}

public class UsingImplementor
{
	private readonly Money _from;
	private readonly decimal _rate;

	public UsingImplementor(Money from, decimal rate)
	{
		_from = from;
		_rate = rate;
	}

	public Money To(CurrencyIsoCode to)
	{
		var rateCalculator = new ExchangeRate(_from.CurrencyCode, to, _rate);
		return rateCalculator.Apply(_from);	
	}
}
```
And those custom extensions can be used on _Money_ instances:
```
var hundredDollars = new Money(100m, CurrencyIsoCode.USD);

var hundredEuros = hundredDollars.Convert().Using(1m).To(CurrencyIsoCode.EUR);
```