using Footballista.BuildingBlocks.Domain.ValueObjects.Units;
using System.Collections.Generic;

namespace Footballista.Players.Evolutions
{
	public interface IStatureGrowthCurveRepository
	{
		List<StatureGrowthCurve> GetAll(SystemOfUnitsType systemOfUnitsType);
	}
	public interface IWeightGrowthCurveRepository
	{
		List<WeightGrowthCurve> GetAll(SystemOfUnitsType systemOfUnitsType);
	}
}
