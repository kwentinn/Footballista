using Footballista.Players.Evolutions;
using Footballista.Players.Persons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Footballista.Players.Growths
{
	[DebuggerDisplay("{Percentile} {Gender}")]
	public class PercentileGrowth
	{
		public Percentile Percentile { get; }
		public Gender Gender { get; }

		public ReadOnlyCollection<StatureForAge> StaturesForAges => _staturesForAges.AsReadOnly();
		private List<StatureForAge> _staturesForAges = new List<StatureForAge>();

		public ReadOnlyCollection<WeightForAge> WeightForAges => _weightForAges.AsReadOnly();
		private List<WeightForAge> _weightForAges = new List<WeightForAge>();

		public PercentileGrowth(int percentile, Gender gender, List<WeightForAge> weightsForAges, List<StatureForAge> staturesForAges)
		{
			Percentile = new Percentile(percentile);
			Gender = gender;
			_weightForAges.AddRange(weightsForAges);
			_staturesForAges.AddRange(staturesForAges);
		}
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
