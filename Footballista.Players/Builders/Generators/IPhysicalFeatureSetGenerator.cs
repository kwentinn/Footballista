using Footballista.Players.Features;

namespace Footballista.Players.Builders.Generators
{
	public interface IPhysicalFeatureSetGenerator
	{
		PhysicalFeatureSet Generate();
	}
	public class PhysicalFeatureSetGenerator : IPhysicalFeatureSetGenerator
	{
		public PhysicalFeatureSet Generate()
		{
			return PhysicalFeatureSet.ForwardFeatureSet;
		}
	}
}
