using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.BuildingBlocks.Domain.ValueObjects.Units;
using Footballista.BuildingBlocks.Domain.ValueObjects.Units.Length;
using Footballista.Players.Persons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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

		public ILengthUnit GetLengthForAge(int ageInYears)
		{
			return _items.FirstOrDefault(lg => lg.Age == new AgeInYear(ageInYears))?.Value;
		}
	}
}
