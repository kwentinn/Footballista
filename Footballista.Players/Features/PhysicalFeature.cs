﻿namespace Footballista.Players.Features
{
	public class PhysicalFeature
	{
		public FeatureName Name { get; }
		public FeatureRating Value { get; protected set; }

		public PhysicalFeature(FeatureName name)
		{
			Name = name;
		}
		public PhysicalFeature(FeatureName name, FeatureRating value)
		{
			Name = name;
			Value = value;
		}

		public void ChangeValue(FeatureRating value)
		{
			Value = value;
		}
	}
}
