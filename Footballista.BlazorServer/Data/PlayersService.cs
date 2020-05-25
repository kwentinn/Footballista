using Footballista.BlazorServer.Data.Players;
using Footballista.Players.Builders;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Footballista.BlazorServer.Data
{
	public class PlayersService
	{
		private readonly IPlayerBuilder _builder;

		public PlayersService(IPlayerBuilder builder)
		{
			_builder = builder;
		}

		public async Task<Player[]> GetPlayersAsync()
		{
			var players = await _builder.BuildManyAsync(50);

			return players
				.Select(player => new Player
				{
					Firstname = player.Firstname.Value,
					Lastname = player.Lastname.Value,
					Nationalities = player.Nationalities.Select(n => n.RegionInfo.EnglishName).ToList(),
					BirthInfo = new BirthInfo
					{
						City = new City
						{
							Name = player.BirthInfo.BirthLocation.City.Name,
							Country = player.BirthInfo.BirthLocation.Country.RegionInfo.EnglishName
						},
						DateOfBirth = player.BirthInfo.DateOfBirth
					},
					Foot = player.FavouriteFoot.ToString(),
					Bmi = new Bmi
					{
						HeightInCentimeters = Convert.ToInt32(player.Bmi.Height.Centimeters),
						WeightInKilograms = Convert.ToInt32(player.Bmi.Weight.Kilograms)
					},
					Gender = player.Gender.ToString(),
					Rating = Convert.ToInt32(player.GeneralRating.Value * 100)
				})
				.ToArray();
			}
	}
}
