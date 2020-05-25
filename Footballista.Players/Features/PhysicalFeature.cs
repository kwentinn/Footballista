using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Features.LinkedFeatures;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Footballista.Players.Features
{
	[DebuggerDisplay("{FeatureType}={Rating} [{_id}]")]
	public class PhysicalFeature : ValueObject
	{
		[IgnoreMember]
		private readonly Guid _id = Guid.NewGuid();

		public FeatureType FeatureType { get; }
		public Rating Rating { get; protected set; }

		private readonly List<PhysicalFeature> _commonFeatures;

		[IgnoreMember]
		public ReadOnlyCollection<PhysicalFeature> OutfieldPlayerFeatures => _outfieldPlayerFeatures.AsReadOnly();
		private readonly List<PhysicalFeature> _outfieldPlayerFeatures;

		[IgnoreMember]
		public ReadOnlyCollection<PhysicalFeature> GoalKeeperFeatures => _goalkeeperFeatures.AsReadOnly();
		private readonly List<PhysicalFeature> _goalkeeperFeatures;

		public PhysicalFeature()
		{
			_commonFeatures = new List<PhysicalFeature>
			{
				new  PhysicalFeature(FeatureType.Morale),
				new  PhysicalFeature(FeatureType.Focus),
				new  PhysicalFeature(FeatureType.Stamina),
				new  PhysicalFeature(FeatureType.FightingSpirit),
				new  PhysicalFeature(FeatureType.Cross),
				new  PhysicalFeature(FeatureType.FreeKick),
				new  PhysicalFeature(FeatureType.PenaltyKick),
				new  PhysicalFeature(FeatureType.ReactionSpeed),
				new  PhysicalFeature(FeatureType.Composure),
				new  PhysicalFeature(FeatureType.Agility)
			};
			_outfieldPlayerFeatures = new List<PhysicalFeature>(_commonFeatures)
			{
				new  PhysicalFeature(FeatureType.Acceleration),
				new  TopSpeedFeature(),
				new  PhysicalFeature(FeatureType.Finishing),
				new  PhysicalFeature(FeatureType.Header),
				new  PhysicalFeature(FeatureType.PassingSpeed),
				new  PhysicalFeature(FeatureType.PassingAccuracy),
				new  PhysicalFeature(FeatureType.Power),
				new  PhysicalFeature(FeatureType.Vista),
				new  PhysicalFeature(FeatureType.Interception),
				new  PhysicalFeature(FeatureType.Tackling),
			};
			_goalkeeperFeatures = new List<PhysicalFeature>(_commonFeatures)
			{
				new  PhysicalFeature(FeatureType.Goalkeeping),
			};
		}

		public PhysicalFeature(FeatureType type, Rating value = null)
		{
			FeatureType = type;
			Rating = value;
		}

		public void ChangeRating(Rating newRating)
		{
			Rating = newRating;
		}
	}
}
