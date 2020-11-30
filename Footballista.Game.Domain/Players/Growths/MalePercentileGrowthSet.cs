using Footballista.Game.Domain.Players.Persons;
using System;
using System.Collections.Generic;

namespace Footballista.Game.Domain.Players.Growths
{
	public sealed class MalePercentileGrowthSet : AbstractPercentileGrowthSet
	{
		public MalePercentileGrowthSet(List<PercentileGrowth> growths) : base(growths)
		{
			foreach (var g in growths)
			{
				if (g.Gender != Gender.Male)
				{
					throw new ApplicationException("Incorrect gender for MalePercentileGrowthSet");
				}
			}
		}
	}
}
