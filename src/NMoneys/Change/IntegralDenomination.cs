﻿using System;

namespace NMoneys.Change
{
	internal struct IntegralDenomination
	{
		public Denomination Denomination { get; }
		public long IntegralAmount { get; }

		public IntegralDenomination(Denomination denomination, Currency operationCurrency)
		{
			Denomination = denomination;
			IntegralAmount = Convert.ToInt64(Money.CalculateMinorAmount(denomination.Value, operationCurrency));
		}

		public static IntegralDenomination Default(Currency operationCurrency)
		{
			return new IntegralDenomination(new Denomination(1), operationCurrency);
		}
	}
}