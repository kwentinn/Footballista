namespace Footballista.Players.Features
{
	public class PhysicalFeature
	{
		public FeatureName Name { get; }
		public FeatureValue Value { get; protected set; }

		public PhysicalFeature(FeatureName name)
		{
			Name = name;
		}
		public PhysicalFeature(FeatureName name, FeatureValue value)
		{
			Name = name;
			Value = value;
		}

		public void ChangeValue(FeatureValue value)
		{
			Value = value;
		}
	}
}
