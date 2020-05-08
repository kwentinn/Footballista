using Footballista.Players.Positions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Footballista.Players.Features
{
	public class PhysicalFeatureSet
	{
		public PositionCategory PositionCategory { get; }
		public ReadOnlyCollection<PhysicalFeature> PhysicalFeatures => _physicalFeatures.AsReadOnly();
		private readonly List<PhysicalFeature> _physicalFeatures = new List<PhysicalFeature>();

		public static PhysicalFeatureSet ForwardFeatureSet => new PhysicalFeatureSet(
			PositionCategory.Forward, PhysicalFeature.OutfieldPlayerFeatures.ToList());
		public static PhysicalFeatureSet MidfielderFeatureSet => new PhysicalFeatureSet(
			PositionCategory.Midfielder, PhysicalFeature.OutfieldPlayerFeatures.ToList());
		public static PhysicalFeatureSet DefenderFeatureSet => new PhysicalFeatureSet(
			PositionCategory.Defender, PhysicalFeature.OutfieldPlayerFeatures.ToList());
		public static PhysicalFeatureSet GoalKeeperFeatureSet => new PhysicalFeatureSet(
			PositionCategory.GoalKeeper, PhysicalFeature.GoalKeeperFeatures.ToList());


		private readonly static List<PhysicalFeatureSet> _featureSets = new List<PhysicalFeatureSet>
		{
			ForwardFeatureSet,
			MidfielderFeatureSet,
			DefenderFeatureSet,
			GoalKeeperFeatureSet
		};

		public static PhysicalFeatureSet GetFeatureSet(PositionCategory positionCategory)
			=> _featureSets.FirstOrDefault(fs => fs.PositionCategory == positionCategory);

		private PhysicalFeatureSet(PositionCategory positionCategory, List<PhysicalFeature> physicalFeatures)
		{
			PositionCategory = positionCategory ?? throw new System.ArgumentNullException(nameof(positionCategory));
			_physicalFeatures = physicalFeatures ?? throw new System.ArgumentNullException(nameof(physicalFeatures));
		}
	}
}
