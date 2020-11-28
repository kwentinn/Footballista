using Footballista.BuildingBlocks.Domain;
using Footballista.BuildingBlocks.Domain.KNNs;
using Footballista.BuildingBlocks.Domain.KNNs.Models;
using Footballista.BuildingBlocks.Domain.Percentiles;
using Footballista.Players.Domain.Positions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Footballista.Players.Builders.Generators
{
	public interface IPlayerPositionGenerator
	{
		PlayerPosition Generate();
	}
	public class PlayerPositionGenerator : IPlayerPositionGenerator
	{
		private readonly IPercentileGenerator _percentileGenerator;

		private static List<PercentileData<PositionCategory>> _percentileCategories = new List<PercentileData<PositionCategory>>
		{
			new PercentileData<PositionCategory>(Percentile.Min, PositionCategory.GoalKeeper),
			new PercentileData<PositionCategory>(new Percentile(24), PositionCategory.GoalKeeper),

			new PercentileData<PositionCategory>(new Percentile(25), PositionCategory.Defender),
			new PercentileData<PositionCategory>(new Percentile(49), PositionCategory.Defender),

			new PercentileData<PositionCategory>(new Percentile(50), PositionCategory.Midfielder),
			new PercentileData<PositionCategory>(new Percentile(74), PositionCategory.Midfielder),

			new PercentileData<PositionCategory>(new Percentile(75), PositionCategory.Forward),
			new PercentileData<PositionCategory>(Percentile.Max, PositionCategory.Forward),

		};
		private static List<PercentileData<PlayerPosition>> _percentilePositions = new List<PercentileData<PlayerPosition>>
		{
			new PercentileData<PlayerPosition>(Percentile.Min, PlayerPosition.GoalKeeper),
			new PercentileData<PlayerPosition>(new Percentile(7), PlayerPosition.GoalKeeper),

			new PercentileData<PlayerPosition>(new Percentile(8), PlayerPosition.CentreBack),
			new PercentileData<PlayerPosition>(new Percentile(15), PlayerPosition.CentreBack),

			new PercentileData<PlayerPosition>(new Percentile(16), PlayerPosition.Sweeper),
			new PercentileData<PlayerPosition>(new Percentile(23), PlayerPosition.Sweeper),

			new PercentileData<PlayerPosition>(new Percentile(24), PlayerPosition.WingBack),
			new PercentileData<PlayerPosition>(new Percentile(31), PlayerPosition.WingBack),

			new PercentileData<PlayerPosition>(new Percentile(32), PlayerPosition.FullBack),
			new PercentileData<PlayerPosition>(new Percentile(39), PlayerPosition.FullBack),

			new PercentileData<PlayerPosition>(new Percentile(40), PlayerPosition.DefensiveMidfield),
			new PercentileData<PlayerPosition>(new Percentile(47), PlayerPosition.DefensiveMidfield),

			new PercentileData<PlayerPosition>(new Percentile(48), PlayerPosition.CentreMidfield),
			new PercentileData<PlayerPosition>(new Percentile(55), PlayerPosition.CentreMidfield),

			new PercentileData<PlayerPosition>(new Percentile(56), PlayerPosition.WideMidfield),
			new PercentileData<PlayerPosition>(new Percentile(63), PlayerPosition.WideMidfield),

			new PercentileData<PlayerPosition>(new Percentile(64), PlayerPosition.AttackingMidfield),
			new PercentileData<PlayerPosition>(new Percentile(69), PlayerPosition.AttackingMidfield),

			new PercentileData<PlayerPosition>(new Percentile(70), PlayerPosition.CentreForward),
			new PercentileData<PlayerPosition>(new Percentile(77), PlayerPosition.CentreForward),

			new PercentileData<PlayerPosition>(new Percentile(78), PlayerPosition.SecondStriker),
			new PercentileData<PlayerPosition>(new Percentile(86), PlayerPosition.SecondStriker),

			new PercentileData<PlayerPosition>(new Percentile(87), PlayerPosition.Winger),
			new PercentileData<PlayerPosition>(Percentile.Max, PlayerPosition.Winger),
		};


		public PlayerPositionGenerator(IPercentileGenerator percentileGenerator)
		{
			_percentileGenerator = percentileGenerator;
		}

		public PlayerPosition Generate()
		{
			// we generate a random percentile
			Percentile percentileCategory = _percentileGenerator.Generate();

			// then, using the 1-NN calculator, we get the nearest neighbour to the percentile
			var categoryCalculator = new PercentileNearestNeighbourCalculator<PositionCategory>(
				percentileCategory, _percentileCategories.ToArray());
			
			// and we get the category from the nearest neighbour
			PositionCategory category = categoryCalculator.GetNearestNeighbourUnderlyingType();

			// retrieve positions from the category
			List<PercentileData<PlayerPosition>> positionsData = _percentilePositions
				.Where(pp => pp.Object.PositionCategory == category)
				.ToList();
			var min = positionsData.Min(p => p.Percentile);
			var max = positionsData.Max(p => p.Percentile);
			var positionPercentile = _percentileGenerator.Generate(min, max);

			var positionCalculator = new PercentileNearestNeighbourCalculator<PlayerPosition>(
				positionPercentile, positionsData.ToArray());
			return positionCalculator.GetNearestNeighbourUnderlyingType();
		}
	}
}
