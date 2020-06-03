using Footballista.Wasm.Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Footballista.Wasm.Server.Services.Mappers
{
	/// <summary>
	/// Map domain to dto/client
	/// </summary>
	public class PlayerMapper : IMapper<Players.Player, Shared.Data.Players.Player>
	{
		public Shared.Data.Players.Player Map(Players.Player player)
		{
			if (player is null)
			{
				return null;
			}

			return new Shared.Data.Players.Player
			{
				Firstname = player.Firstname.Value,
				Lastname = player.Lastname.Value,
				Nationalities = string.Join(", ", player.Nationalities.Select(n => n.CountryCode)),
				BirthInfo = new Shared.Data.Players.BirthInfo
				{
					City = new City
					{
						Name = player.BirthInfo.BirthLocation.City.Name,
						Country = player.BirthInfo.BirthLocation.Country.RegionInfo.EnglishName
					},
					DateOfBirth = player.BirthInfo.DateOfBirth
				},
				Foot = player.FavouriteFoot.ToString(),
				Bmi = new Shared.Data.Players.Bmi
				{
					HeightInCentimeters = Convert.ToInt32(player.Bmi.Height.Centimeters),
					WeightInKilograms = Convert.ToInt32(player.Bmi.Weight.Kilograms)
				},
				Gender = player.Gender.ToString(),
				Percentile = player.Percentile.Value,
				Position = player.PlayerPosition.Name,
				GeneralRating = Convert.ToInt32(player.GeneralRating.Value * 100),
				Ratings = player.PhysicalFeatureSet.PhysicalFeatures
						.Select(feat => new Shared.Data.Players.Rating
						{
							Feature = feat.FeatureType.ToString(),
							Value = Convert.ToInt32(feat.Rating.Value * 100)
						})
						.ToList()
			};
		}
		public IEnumerable<Shared.Data.Players.Player> Map(IEnumerable<Players.Player> players)
		{
			return players
				.Select(player => Map(player));
		}
	}
}
