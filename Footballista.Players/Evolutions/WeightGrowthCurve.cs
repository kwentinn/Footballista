using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Persons;
using Footballista.Units;
using Footballista.Units.Masses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Footballista.Players.Evolutions
{
	public class WeightGrowthCurve : GrowthCurve
	{
		public ReadOnlyCollection<MassGrowth> Items => _items.AsReadOnly();
		private List<MassGrowth> _items = new List<MassGrowth>();

		public WeightGrowthCurve
		(
			Percentile percentile,
			Country country,
			Gender gender,
			SystemOfUnitsType systemOfUnitsType,
			List<MassGrowth> items
		) : base(percentile, country, gender, systemOfUnitsType)
		{
			if (items is null) throw new ArgumentNullException(nameof(items));

			_items.AddRange(items);
		}

		public IMass GetWeightForAge(int ageInYears)
		{
			return _items.FirstOrDefault(lg => lg.Age == Age.FromYears(ageInYears))?.Value;
		}
	}
}
