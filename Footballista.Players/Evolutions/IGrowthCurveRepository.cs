using Footballista.BuildingBlocks.Domain.ValueObjects.Units;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Footballista.Players.Evolutions
{
	public interface IStatureGrowthCurveRepository
	{
		Task<List<StatureGrowthCurve>> GetAllAsync(SystemOfUnitsType systemOfUnitsType);
	}
	public interface IWeightGrowthCurveRepository
	{
		Task<List<WeightGrowthCurve>> GetAllAsync(SystemOfUnitsType systemOfUnitsType);
	}
}
