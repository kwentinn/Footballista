using Footballista.BlazorServer.Data.Players;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Footballista.BlazorServer.Data.Mappers
{
	public class PlayerMapper : IMapper<Footballista.Players.Player, Player>
	{
		public Player Map(Footballista.Players.Player player)
		{
			if (player is null)
			{
				return null;
			}

			return new Player
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
			};
		}
		public IEnumerable<Player> Map(IEnumerable<Footballista.Players.Player> players)
		{
			return players
				.Select(player => Map(player));
		}
	}
}
