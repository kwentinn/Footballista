using Footballista.Players.Persons;
using System;
using System.Collections.Generic;

namespace Footballista.Players.Growths
{
	public sealed class FemalePercentileGrowthSet : AbstractPercentileGrowthSet
	{
		public FemalePercentileGrowthSet(List<PercentileGrowth> growths) : base(growths)
		{
			foreach (var g in growths)
			{
				if (g.Gender != Gender.Female)
				{
					throw new ApplicationException("Inccorect gender for MalePercentileGrowthSet");
				}
			}
		}
	}
}
