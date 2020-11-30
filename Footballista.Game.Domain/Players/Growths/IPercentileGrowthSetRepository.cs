using Footballista.Game.Domain.Players.Persons;

namespace Footballista.Game.Domain.Players.Growths
{
	public interface IPercentileGrowthSetRepository
	{
		AbstractPercentileGrowthSet GetPercentileGrowthSet(Gender gender);
		MalePercentileGrowthSet GetMalePercentileGrowthSet();
		FemalePercentileGrowthSet GetFemalePercentileGrowthSet();
	}
}
