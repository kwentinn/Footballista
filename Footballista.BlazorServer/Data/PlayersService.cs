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

		public async Task<Player> GetPlayerAsync()
		{
			var players = await _builder.BuildManyAsync(1);

			return players
				.Select(player => new Player
				{
					Firstname = player.Firstname.Value,
					Lastname = player.Lastname.Value,
					Nationalities = player.Nationalities
						.Select(n => n.RegionInfo.EnglishName)
						.ToList(),
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
					GeneralRating = Convert.ToInt32(player.GeneralRating.Value * 100),
					Ratings = player.PhysicalFeatureSet.PhysicalFeatures
						.Select(feat => new Rating
						{
							Feature = feat.FeatureType.ToString(),
							Value = Convert.ToInt32(feat.Rating.Value * 100)
						})
						.ToList()
				})
				.FirstOrDefault();
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
					GeneralRating = Convert.ToInt32(player.GeneralRating.Value * 100),
					Ratings = player.PhysicalFeatureSet.PhysicalFeatures
						.Select(feat => new Rating
						{
							Feature = feat.FeatureType.ToString(),
							Value = Convert.ToInt32(feat.Rating.Value * 100)
						})
						.ToList()
				})
				.ToArray();
		}

	}
}
