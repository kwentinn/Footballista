using Footballista.BuildingBlocks.Domain.KNNs;
using Footballista.BuildingBlocks.Domain.Percentiles;
using Footballista.Game.Domain.Players;
using System;

namespace Footballista.Players.Builders.Generators
{
	public interface IFavouriteFootGenerator
	{
		Foot Generate();
	}

	public class FavouriteFootGenerator : IFavouriteFootGenerator
	{
		private readonly PercentileData<Foot>[] _data = new PercentileData<Foot>[]
		{
			// around 30% are lefties
			new PercentileData<Foot>(Percentile.Min, Foot.Left),
			new PercentileData<Foot>(new Percentile(30), Foot.Left),

			// ~40% righties
			new PercentileData<Foot>(new Percentile(31), Foot.Right),
			new PercentileData<Foot>(new Percentile(90), Foot.Right),

			// ~10% both (ambidextrous)
			new PercentileData<Foot>(new Percentile(91), Foot.Both),
			new PercentileData<Foot>(Percentile.Max, Foot.Both),
		};
		private readonly IPercentileGenerator _percentileGenerator;

		public FavouriteFootGenerator(IPercentileGenerator percentileGenerator)
		{
			_percentileGenerator = percentileGenerator;
		}

		public Foot Generate()
		{

			Percentile rndPct = _percentileGenerator.Generate();

			var calculator = new PercentileKNearestNeighborCalculator<Foot>(rndPct, _data);
			return calculator.GetNearestNeighbours().Value[0].Value.Object;
		}
	}
}
