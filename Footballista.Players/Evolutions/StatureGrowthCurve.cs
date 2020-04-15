using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Growths;
using Footballista.Players.Persons;
using Footballista.Units;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Footballista.Players.Evolutions
{
	public class StatureGrowthCurve : GrowthCurve
	{
		public ReadOnlyCollection<StatureForAge> Items => _items.AsReadOnly();
		private List<StatureForAge> _items = new List<StatureForAge>();

		public StatureGrowthCurve
		(
			Percentile percentile,
			Country country,
			Gender gender,
			SystemOfUnitsType systemOfUnitsType,
			List<StatureForAge> items
		) : base(percentile, country, gender, systemOfUnitsType)
		{
			if (items is null) throw new ArgumentNullException(nameof(items));
			
			_items.AddRange(items);
		}

		public UnitsNet.Length GetLengthForAge(int ageInYears)
		{
			return _items.FirstOrDefault(lg => lg.Age == Age.FromYears(ageInYears)).Stature;
		}
	}
}
