using Footballista.BuildingBlocks.Domain;

namespace Footballista.Players.Features
{
	public class FeatureName : ValueObject
	{
		public string Name { get; }
		protected FeatureName(string name)
		{
			Name = name;
		}

		public static FeatureName RunningSpeed => new FeatureName(nameof(RunningSpeed));
		public static FeatureName Finishing => new FeatureName(nameof(Finishing));
	}
}
