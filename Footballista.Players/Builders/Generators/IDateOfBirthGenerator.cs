using Footballista.BuildingBlocks.Domain.Game;
using Footballista.Players.Builders.Randomisers;
using Itenso.TimePeriod;
using System;

namespace Footballista.Players.Builders.Generators
{
	public interface IDateOfBirthGenerator
	{
		Date Generate();
	}
	public class DateOfBirthGenerator : IDateOfBirthGenerator
	{
		private readonly IGame _game;
		private readonly IRandomiser<Age> _ageRandomiser;

		public DateOfBirthGenerator(IGame game, IRandomiser<Age> ageRandomiser)
		{
			_game = game ?? throw new ArgumentNullException(nameof(game));
			_ageRandomiser = ageRandomiser;
		}

		public Date Generate()
		{
			// retrieve game current date
			DateTime gameDate = _game.CurrentDate;

			// create a random player between 14 and 18 years old
			Age age = _ageRandomiser.Randomise(
				Age.FromDays(14 * 365), 
				Age.FromDays(18 * 365 + 1));

			return new Date(gameDate.AddDays(-age.Days));
		}
	}
}
