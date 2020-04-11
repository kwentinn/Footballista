using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.BuildingBlocks.Domain.ValueObjects.Units;
using Footballista.Players.Persons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Footballista.Players.Evolutions
{
	public class StatureGrowthCurve : GrowthCurve
	{
		public ReadOnlyCollection<LengthGrowth> Items => _items.AsReadOnly();
		private List<LengthGrowth> _items = new List<LengthGrowth>();

		public StatureGrowthCurve
		(
			Percentile percentile,
			Country country,
			Gender gender,
			SystemOfUnitsType systemOfUnitsType,
			List<LengthGrowth> items
		) : base(percentile, country, gender, systemOfUnitsType)
		{
			if (items is null) throw new ArgumentNullException(nameof(items));
			
			_items.AddRange(items);
		}
	}
}
