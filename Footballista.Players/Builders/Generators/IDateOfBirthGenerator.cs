using Footballista.BuildingBlocks.Domain.Game;
using Footballista.BuildingBlocks.Domain.ValueObjects;
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
		private readonly IRandomiser<PersonAge> _ageRandomiser;

		public DateOfBirthGenerator(IGame game, IRandomiser<PersonAge> ageRandomiser)
		{
			_game = game ?? throw new ArgumentNullException(nameof(game));
			_ageRandomiser = ageRandomiser;
		}

		public Date Generate()
		{
			// retrieve game current date
			DateTime gameDate = _game.CurrentDate;

			// create a random player between 14 and 18 years old
			PersonAge age = _ageRandomiser.Randomise(
				PersonAge.FromDays(14 * 365), 
				PersonAge.FromDays(18 * 365 + 1));

			return new Date(gameDate.AddDays(-age.Days));
		}
	}
}
