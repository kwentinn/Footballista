using Footballista.BuildingBlocks.Domain.Game;
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
		private readonly Random _random = new Random();

		public DateOfBirthGenerator(IGame game)
		{
			_game = game ?? throw new ArgumentNullException(nameof(game));
		}

		public Date Generate()
		{
			// retrieve game current date
			DateTime gameDate = _game.CurrentDate;

			// create a random player between 14 and 18 years old
			Age age = Age.FromDays(_random.Next(14 * 365, 18 * 365));

			return new Date(gameDate.AddDays(-age.Days));
		}
	}
}
