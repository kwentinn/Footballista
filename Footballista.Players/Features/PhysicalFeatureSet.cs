using Footballista.Players.Positions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace Footballista.Players.Features
{
	[DebuggerDisplay("{_id} - {PositionCategory}")]
	public class PhysicalFeatureSet
	{
		private readonly Guid _id = Guid.NewGuid();

		public PositionCategory PositionCategory { get; }
		public ReadOnlyCollection<PhysicalFeature> PhysicalFeatures => _physicalFeatures.AsReadOnly();
		private readonly List<PhysicalFeature> _physicalFeatures = new List<PhysicalFeature>();

		public static PhysicalFeatureSet ForwardFeatureSet => new PhysicalFeatureSet(
			PositionCategory.Forward, new PhysicalFeature().OutfieldPlayerFeatures.ToList());
		public static PhysicalFeatureSet MidfielderFeatureSet => new PhysicalFeatureSet(
			PositionCategory.Midfielder, new PhysicalFeature().OutfieldPlayerFeatures.ToList());
		public static PhysicalFeatureSet DefenderFeatureSet => new PhysicalFeatureSet(
			PositionCategory.Defender, new PhysicalFeature().OutfieldPlayerFeatures.ToList());
		public static PhysicalFeatureSet GoalKeeperFeatureSet => new PhysicalFeatureSet(
			PositionCategory.GoalKeeper, new PhysicalFeature().GoalKeeperFeatures.ToList());


		private readonly static List<PhysicalFeatureSet> _featureSets = new List<PhysicalFeatureSet>
		{
			ForwardFeatureSet,
			MidfielderFeatureSet,
			DefenderFeatureSet,
			GoalKeeperFeatureSet
		};

		public static PhysicalFeatureSet CreateFeatureSet(PositionCategory positionCategory)
		{
			PhysicalFeatureSet set = _featureSets.FirstOrDefault(fs => fs.PositionCategory == positionCategory);
			List<PhysicalFeature> list = new List<PhysicalFeature>();
			foreach (PhysicalFeature feature in set.PhysicalFeatures)
			{
				list.Add(new PhysicalFeature(feature.FeatureType));
			}
			return new PhysicalFeatureSet(positionCategory, list);
		}

		private PhysicalFeatureSet(PositionCategory positionCategory, List<PhysicalFeature> physicalFeatures)
		{
			PositionCategory = positionCategory ?? throw new System.ArgumentNullException(nameof(positionCategory));
			_physicalFeatures = physicalFeatures ?? throw new System.ArgumentNullException(nameof(physicalFeatures));
		}
	}
}
