using Footballista.Players.Domain.Persons;

namespace Footballista.Players.Domain.Growths
{
	public interface IPercentileGrowthSetRepository
	{
		AbstractPercentileGrowthSet GetPercentileGrowthSet(Gender gender);
		MalePercentileGrowthSet GetMalePercentileGrowthSet();
		FemalePercentileGrowthSet GetFemalePercentileGrowthSet();
	}
}
