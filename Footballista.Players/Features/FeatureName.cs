using Footballista.BuildingBlocks.Domain;
using System;
using System.Diagnostics;

namespace Footballista.Players.Features
{
	[DebuggerDisplay("{Name}")]
	public class FeatureName : ValueObject
	{
		public string Name { get; }

		private FeatureName(string name)
		{
			if (string.IsNullOrEmpty(name)) throw new ArgumentException(nameof(name));

			Name = name;
		}

		public static FeatureName Finishing => new FeatureName(nameof(Finishing));
		public static FeatureName PenaltyKick => new FeatureName(nameof(PenaltyKick));
		public static FeatureName Cross => new FeatureName(nameof(Cross));
		public static FeatureName FreeKick => new FeatureName(nameof(FreeKick));
		public static FeatureName Acceleration => new FeatureName(nameof(Acceleration));
		public static FeatureName TopSpeed => new FeatureName(nameof(TopSpeed));
		public static FeatureName Header => new FeatureName(nameof(Header));
		public static FeatureName ReactionSpeed => new FeatureName(nameof(ReactionSpeed));
		public static FeatureName PassingSpeed => new FeatureName(nameof(PassingSpeed));
		public static FeatureName PassingAccuracy => new FeatureName(nameof(PassingAccuracy));
		public static FeatureName Power => new FeatureName(nameof(Power));
		public static FeatureName Stamina => new FeatureName(nameof(Stamina));
		public static FeatureName Agility => new FeatureName(nameof(Agility));
		public static FeatureName Vista => new FeatureName(nameof(Vista));
		public static FeatureName Interception => new FeatureName(nameof(Interception));
		public static FeatureName Tackling => new FeatureName(nameof(Tackling));
		public static FeatureName Focus => new FeatureName(nameof(Focus));
		public static FeatureName Composure => new FeatureName(nameof(Composure));
		public static FeatureName FightingSpirit => new FeatureName(nameof(FightingSpirit));
		public static FeatureName Morale => new FeatureName(nameof(Morale));


		public static FeatureName Goalkeeping => new FeatureName(nameof(Goalkeeping));
	}
}
