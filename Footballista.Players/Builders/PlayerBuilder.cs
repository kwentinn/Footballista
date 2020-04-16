using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Growths;
using Footballista.Players.PlayerNames;
using Footballista.Players.Positions;
using System;

namespace Footballista.Players.Builders
{


	public class YoungPlayerBuilder : IPlayerBuilder
	{
		private readonly IPercentileGrowthSetRepository _percentileGrowthSetRepository;
		private readonly INameGenerator _nameGenerator;
		private readonly IGame _game;

		public YoungPlayerBuilder(
			IPercentileGrowthSetRepository percentileGrowthSetRepository,
			INameGenerator nameGenerator,
			IGame game)
		{
			_percentileGrowthSetRepository = percentileGrowthSetRepository;
			_nameGenerator = nameGenerator;
			_game = game;
		}

		public Player Build(Country country = null, PlayerPosition playerPosition = null)
		{
			// first name & last name => according to the player's country

			// young player dob
			return null;
		}
	}

}
