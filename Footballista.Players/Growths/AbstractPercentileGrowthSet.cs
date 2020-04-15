using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Footballista.Players.Growths
{
	public abstract class AbstractPercentileGrowthSet
	{
		public ReadOnlyCollection<PercentileGrowth> Growths => _growths.AsReadOnly();
		private List<PercentileGrowth> _growths = new List<PercentileGrowth>();
		protected AbstractPercentileGrowthSet(List<PercentileGrowth> growths)
		{
			_growths = growths ?? throw new ArgumentNullException(nameof(growths));
		}
	}
}
