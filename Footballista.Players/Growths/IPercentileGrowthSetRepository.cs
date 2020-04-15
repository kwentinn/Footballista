namespace Footballista.Players.Growths
{
	public interface IPercentileGrowthSetRepository
	{
		MalePercentileGrowthSet GetMalePercentileGrowthSet();
		FemalePercentileGrowthSet GetFemalePercentileGrowthSet();
	}
}
