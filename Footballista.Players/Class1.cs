using Footballista.Players.Units.Length;
using Footballista.Players.Units.Mass;
using Itenso.TimePeriod;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Footballista.Players
{

	public class TimedPhysicalFeature
	{
		public LengthUnit Height { get; }
		public MassUnit Weight { get; }
		public Date Date { get; }
	}

	public interface IEvolution { }


	public class AgeInYear
	{
		public int Year { get; set; }
	}

	public class Growth 
	{
		public int Age { get; set; }
		public MassUnit Mass { get; set; }
		public LengthUnit Length { get; set; }
	}

	public class NormalGrowth
	{
		private readonly List<Growth> _growthItems = new List<Growth>();
		public ReadOnlyCollection<Growth> GrowthItems => _growthItems.AsReadOnly();
	}
}
