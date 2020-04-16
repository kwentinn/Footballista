using Footballista.BuildingBlocks.Domain;
using System;

namespace Footballista.Players.Features
{
	public class FeatureName : ValueObject
	{
		public string Name { get; }

		private FeatureName(string name)
		{
			if (string.IsNullOrEmpty(name)) throw new ArgumentException(nameof(name));

			Name = name;
		}

		public static FeatureName Acceleration => new FeatureName(nameof(Acceleration));
		public static FeatureName TopSpeed => new FeatureName(nameof(TopSpeed));
		public static FeatureName Finishing => new FeatureName(nameof(Finishing));
		public static FeatureName Header => new FeatureName(nameof(Header));
		public static FeatureName Movement => new FeatureName(nameof(Movement));
		public static FeatureName PassingSpeed => new FeatureName(nameof(PassingSpeed));
		public static FeatureName PassingAccuracy => new FeatureName(nameof(PassingAccuracy));
		public static FeatureName Power => new FeatureName(nameof(Power));

	}
}
