using Footballista.BuildingBlocks.Domain.Percentiles;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Game.Domain.Players.Persons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace Footballista.Game.Domain.Players.Growths
{
	[DebuggerDisplay("{Percentile} {Gender}")]
	public class PercentileGrowth
	{
		public Percentile Percentile { get; }
		public Gender Gender { get; }

		public ReadOnlyCollection<StatureForAge> StaturesForAges => _staturesForAges.AsReadOnly();
		private readonly List<StatureForAge> _staturesForAges = new List<StatureForAge>();

		public ReadOnlyCollection<WeightForAge> WeightForAges => _weightForAges.AsReadOnly();
		private readonly List<WeightForAge> _weightForAges = new List<WeightForAge>();

		public PercentileGrowth(int percentile, Gender gender, List<WeightForAge> weightsForAges, List<StatureForAge> staturesForAges)
		{
			Percentile = new Percentile(percentile);
			Gender = gender;
			_weightForAges.AddRange(weightsForAges);
			_staturesForAges.AddRange(staturesForAges);
		}

		public StatureForAge GetStatureForAge(PersonAge age)
			=> _staturesForAges.FirstOrDefault(sfa => sfa.Age.Equals(age));
		public WeightForAge GetWeightForAge(PersonAge age)
			=> _weightForAges.FirstOrDefault(wfa => wfa.Age.Equals(age));
	}

	[DebuggerDisplay("MaleGrowths: {MaleGrowths.Count} - FemaleGrowths: {FemaleGrowths.Count}")]
	public class GrowthBuilder
	{
		public MalePercentileGrowthSet Male { get; }
		public FemalePercentileGrowthSet Female { get; }

		public GrowthBuilder(MalePercentileGrowthSet male, FemalePercentileGrowthSet female)
		{
			Male = male ?? throw new ArgumentNullException(nameof(male));
			Female = female ?? throw new ArgumentNullException(nameof(female));
		}
	}
}
