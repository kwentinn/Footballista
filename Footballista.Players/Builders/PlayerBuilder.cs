using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Growths;
using Footballista.Players.Positions;
using System;

namespace Footballista.Players.Builders
{
	public interface IPlayerBuilder
	{
		Player Build(Country country = null, PlayerPosition playerPosition = null);
	}
	public class YoungPlayerBuilder : IPlayerBuilder
	{
		private readonly IPercentileGrowthSetRepository _percentileGrowthSetRepository;
		private readonly IGame _game;

		public YoungPlayerBuilder(IPercentileGrowthSetRepository percentileGrowthSetRepository, IGame game)
		{
			_percentileGrowthSetRepository = percentileGrowthSetRepository;
			_game = game;
		}

		public Player Build(Country country = null, PlayerPosition playerPosition = null)
		{
			// first name & last name => according to the player's country

			// young player dob
			return null;
		}
	}

	public interface IGame
	{
		DateTime CurrentDate { get; }
	}
}
