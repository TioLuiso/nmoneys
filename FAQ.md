# Introduction #

This section will contain questions and answers

## Why DO I Needed IT? ##
As stated in the home page, the .NET framework does not have a separate concept for "_currency_" or "_money_". Instead, cultural and formatting concerns get mixed and the ISO 4217 is not implemented to its entirety.

## Will NMoneys help me to manage Exchange Rates? ##
No and a bit of Yes.
_NMoneys_ won't help you transform a monetary amount into another monetary amount with different currencies. Nor will it update any sort of internal exchange rate table from external sources.
It could help you to represent those amounts correctly according to their currency, though.

## How about NMoneys.Exchange? ##
_NMoneys.Exchange_ will help you to provide exchange operations to monetary quantities. It has several extensibility points that will help in terms of flexibility and accuracy.
But _NMoneys.Exchange_ is NOT a currency exchange service, nor it provides updates rates, but you can use your favorite rate feed to provide current data to _NMoneys.Exchange_.

## My Money instance is not Displayed Correctly! ##
This can be due to two reasons:
  * The monetary amount you are trying to represent is not configured correctly in NMoneys. Its information might be incorrect or simply have default values as we could not figure out which formatting information is correct. We encourage you to contribute to the project providing us with the information on how to represent an amount for a given currency.
  * Your currency is used in more than one country that have a different way of displaying monetary amounts. You can use one of the Money method overloads to pass a different formatting object that will represent your amount the way you want.
For example, monetary amounts in Euros are formatted, by default, as in Germany or the German language. In France, they also have Euros, but monetary amounts are formatted in a different fashion than in Germany (the default). One could pass a French-aware formatting object (like a `CultureInfo` for the "fr-FR" culture, for instance) and have it displayed as French people expect in France.