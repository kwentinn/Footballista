namespace Footballista.Players.Features.Goalies
{
	public class GoaliePhysicalFeatureSet : PhysicalFeatureSet
	{
		public GoaliePhysicalFeatureSet()
		{
			_items.Add(new GoaliePhysicalFeature(FeatureName.Finishing));
		}
	}
}
