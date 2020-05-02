using Footballista.Players.Persons;

namespace Footballista.Players.Growths
{
	public interface IPercentileGrowthSetRepository
	{
		AbstractPercentileGrowthSet GetPercentileGrowthSet(Gender gender);
		MalePercentileGrowthSet GetMalePercentileGrowthSet();
		FemalePercentileGrowthSet GetFemalePercentileGrowthSet();
	}
}
