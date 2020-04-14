using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Evolutions;
using Footballista.Players.Persons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Footballista.Players.Growths
{
	[DebuggerDisplay("{Percentile} {Country} {Gender} {SystemOfUnitsType}")]
	public class Growth
	{
		public Percentile Percentile { get; }
		public Country Country { get; }
		public Gender Gender { get; }

		// private Dictionary<Percentile, List<StatureForAge>> 

		public ReadOnlyCollection<StatureForAge> StaturesForAges => _staturesForAges.AsReadOnly();
		private List<StatureForAge> _staturesForAges = new List<StatureForAge>();

		public ReadOnlyCollection<WeightForAge> WeightForAges => _weightForAges.AsReadOnly();
		private List<WeightForAge> _weightForAges = new List<WeightForAge>();

		protected Growth(Percentile percentile, Country country, Gender gender, List<WeightForAge> weightsForAges, List<StatureForAge> staturesForAges)
		{
			Percentile = percentile ?? throw new ArgumentNullException(nameof(percentile));
			Country = country ?? throw new ArgumentNullException(nameof(country));
			Gender = gender ?? throw new ArgumentNullException(nameof(gender));

			_weightForAges.AddRange(weightsForAges);
			_staturesForAges.AddRange(staturesForAges);
		}

		public class ActualGrowth
		{
			public ReadOnlyCollection<StatureForAge> StaturesForAges => _staturesForAges.AsReadOnly();
			private List<StatureForAge> _staturesForAges = new List<StatureForAge>();

			public ReadOnlyCollection<WeightForAge> WeightForAges => _weightForAges.AsReadOnly();
			private List<WeightForAge> _weightForAges = new List<WeightForAge>();
		}

		//public ActualGrowth Build()
		//{
			
		//}
	}
}
