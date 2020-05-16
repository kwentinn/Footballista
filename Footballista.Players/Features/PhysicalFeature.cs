using Footballista.BuildingBlocks.Domain;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Footballista.Players.Features
{
	[DebuggerDisplay("{Name}={Value}")]
	public class PhysicalFeature : ValueObject
	{
		public Feature Name { get; }
		public Rating Value { get; protected set; }

		public static PhysicalFeature Acceleration => new PhysicalFeature(Feature.Acceleration);
		public static PhysicalFeature TopSpeed => new PhysicalFeature(Feature.TopSpeed);
		public static PhysicalFeature Finishing => new PhysicalFeature(Feature.Finishing);
		public static PhysicalFeature Header => new PhysicalFeature(Feature.Header);
		public static PhysicalFeature ReactionSpeed => new PhysicalFeature(Feature.ReactionSpeed);
		public static PhysicalFeature PassingSpeed => new PhysicalFeature(Feature.PassingSpeed);
		public static PhysicalFeature PassingAccuracy => new PhysicalFeature(Feature.PassingAccuracy);
		public static PhysicalFeature Power => new PhysicalFeature(Feature.Power);
		public static PhysicalFeature Stamina => new PhysicalFeature(Feature.Stamina);
		public static PhysicalFeature Agility => new PhysicalFeature(Feature.Agility);
		public static PhysicalFeature Vista => new PhysicalFeature(Feature.Vista);
		public static PhysicalFeature Interception => new PhysicalFeature(Feature.Interception);
		public static PhysicalFeature Tackling => new PhysicalFeature(Feature.Tackling);
		public static PhysicalFeature Focus => new PhysicalFeature(Feature.Focus);
		public static PhysicalFeature Composure => new PhysicalFeature(Feature.Composure);
		public static PhysicalFeature Cross => new PhysicalFeature(Feature.Cross);
		public static PhysicalFeature FreeKick => new PhysicalFeature(Feature.FreeKick);
		public static PhysicalFeature PenaltyKick => new PhysicalFeature(Feature.PenaltyKick);
		public static PhysicalFeature FightingSpirit => new PhysicalFeature(Feature.FightingSpirit);
		public static PhysicalFeature Morale => new PhysicalFeature(Feature.Morale);
		public static PhysicalFeature Goalkeeping => new PhysicalFeature(Feature.Goalkeeping);

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



		public PhysicalFeature(Feature name)
		{
			Name = name;
		}
		public PhysicalFeature(Feature name, Rating value)
		{
			Name = name;
			Value = value;
		}

		public void ChangeRating(Rating value)
		{
			Value = value;
		}
	}
}
