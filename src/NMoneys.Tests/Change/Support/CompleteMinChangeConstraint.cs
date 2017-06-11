﻿using System.Linq;
using NUnit.Framework.Constraints;
using Testing.Commons.NUnit.Constraints;

namespace NMoneys.Tests.Change.Support
{
	internal class CompleteMinChangeConstraint : DelegatingConstraint
	{
		public CompleteMinChangeConstraint(QDenomination[] denominations)
		{
			Delegate = new ConjunctionConstraint(
				new ConstrainedEnumerable(
					denominations.Select(d => new QuantifiedDenominationConstraint(d))
					));
		}

		protected override ConstraintResult matches(object current)
		{
			return Delegate.ApplyTo(current);
		}
	}
}