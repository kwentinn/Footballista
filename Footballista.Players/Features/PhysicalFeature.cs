using Footballista.BuildingBlocks.Domain;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Footballista.Players.Features
{
	[DebuggerDisplay("{Name}={Value}")]
	public class PhysicalFeature : ValueObject
	{
		public FeatureName Name { get; }
		public FeatureRating Value { get; protected set; }

		public static PhysicalFeature Acceleration => new PhysicalFeature(FeatureName.Acceleration);
		public static PhysicalFeature TopSpeed => new PhysicalFeature(FeatureName.TopSpeed);
		public static PhysicalFeature Finishing => new PhysicalFeature(FeatureName.Finishing);
		public static PhysicalFeature Header => new PhysicalFeature(FeatureName.Header);
		public static PhysicalFeature ReactionSpeed => new PhysicalFeature(FeatureName.ReactionSpeed);
		public static PhysicalFeature PassingSpeed => new PhysicalFeature(FeatureName.PassingSpeed);
		public static PhysicalFeature PassingAccuracy => new PhysicalFeature(FeatureName.PassingAccuracy);
		public static PhysicalFeature Power => new PhysicalFeature(FeatureName.Power);
		public static PhysicalFeature Stamina => new PhysicalFeature(FeatureName.Stamina);
		public static PhysicalFeature Agility => new PhysicalFeature(FeatureName.Agility);
		public static PhysicalFeature Vista => new PhysicalFeature(FeatureName.Vista);
		public static PhysicalFeature Interception => new PhysicalFeature(FeatureName.Interception);
		public static PhysicalFeature Tackling => new PhysicalFeature(FeatureName.Tackling);
		public static PhysicalFeature Focus => new PhysicalFeature(FeatureName.Focus);
		public static PhysicalFeature Composure => new PhysicalFeature(FeatureName.Composure);
		public static PhysicalFeature Cross => new PhysicalFeature(FeatureName.Cross);
		public static PhysicalFeature FreeKick => new PhysicalFeature(FeatureName.FreeKick);
		public static PhysicalFeature PenaltyKick => new PhysicalFeature(FeatureName.PenaltyKick);
		public static PhysicalFeature FightingSpirit => new PhysicalFeature(FeatureName.FightingSpirit);
		public static PhysicalFeature Morale => new PhysicalFeature(FeatureName.Morale);
		public static PhysicalFeature Goalkeeping => new PhysicalFeature(FeatureName.Goalkeeping);

		private static readonly List<PhysicalFeature> _commonFeatures = new List<PhysicalFeature>
		{
			Morale,
			Focus,
			Stamina,
			FightingSpirit,
			Cross,
			FreeKick,
			PenaltyKick,
			ReactionSpeed,
			Composure,
			Agility
		};

		public static ReadOnlyCollection<PhysicalFeature> OutfieldPlayerFeatures => _outfieldPlayerFeatures.AsReadOnly();
		private static readonly List<PhysicalFeature> _outfieldPlayerFeatures = new List<PhysicalFeature>(_commonFeatures)
		{
			Acceleration,
			TopSpeed,
			Finishing,
			Header,
			PassingSpeed,
			PassingAccuracy,
			Power,
			Vista,
			Interception,
			Tackling,
		};

		public static ReadOnlyCollection<PhysicalFeature> GoalKeeperFeatures => _goalkeeperFeatures.AsReadOnly();
		private static readonly List<PhysicalFeature> _goalkeeperFeatures = new List<PhysicalFeature>(_commonFeatures)
		{
			Goalkeeping
		};



		public PhysicalFeature(FeatureName name)
		{
			Name = name;
		}
		public PhysicalFeature(FeatureName name, FeatureRating value)
		{
			Name = name;
			Value = value;
		}

		public void ChangeRating(FeatureRating value)
		{
			Value = value;
		}
	}
}
