using Footballista.Players.Positions;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Footballista.Players.Features
{
	public class PhysicalFeatureSet
	{
		public PositionCategory PositionCategory { get; }
		public ReadOnlyCollection<PhysicalFeature> PhysicalFeatures => _physicalFeatures.AsReadOnly();
		private readonly List<PhysicalFeature> _physicalFeatures = new List<PhysicalFeature>();

		public static PhysicalFeatureSet ForwardFeatureSet => new PhysicalFeatureSet(PositionCategory.Forward, new List<PhysicalFeature>
		{
			new PhysicalFeature(FeatureName.Header),
			new PhysicalFeature(FeatureName.Finishing),
			new PhysicalFeature(FeatureName.Power),
			new PhysicalFeature(FeatureName.PassingAccuracy),
		});

		private PhysicalFeatureSet(PositionCategory positionCategory, List<PhysicalFeature> physicalFeatures)
		{
			PositionCategory = positionCategory ?? throw new System.ArgumentNullException(nameof(positionCategory));
			_physicalFeatures = physicalFeatures ?? throw new System.ArgumentNullException(nameof(physicalFeatures));
		}
	}
}
