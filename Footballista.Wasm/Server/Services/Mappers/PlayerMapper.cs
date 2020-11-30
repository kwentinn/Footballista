using Footballista.Players.Domain;
using Footballista.Wasm.Shared;
using Footballista.Wasm.Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Footballista.Wasm.Server.Services.Mappers
{
	/// <summary>
	/// Map domain to dto/client
	/// </summary>
	public class PlayerMapper : IMapper<Player, Shared.Data.Players.Player>
	{
		public Shared.Data.Players.Player Map(Player player)
		{
			if (player is null)
			{
				return null;
			}

			return new Shared.Data.Players.Player
			{
				Id = player.Id,
				Firstname = player.Name.Firstname.Value,
				Lastname = player.Name.Lastname.Value,
				Nationalities = string.Join(", ", player.Nationalities.Select(n => n.CountryCode)),
				BirthInfo = new Shared.Data.Players.BirthInfo
				{
					City = new City
					(
						player.BirthInfo.Location.City.Name,
						player.BirthInfo.Location.Country.RegionInfo.EnglishName
					),
					DateOfBirth = player.BirthInfo.Date
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
				GeneralRating = player.GeneralRating.ToRoundedPercent(),
				Ratings = player.PhysicalFeatureSet.PhysicalFeatures
					.Select(feat => new Shared.Data.Players.Rating
					{
						Feature = feat.FeatureType.ToString(),
						Value = feat.Rating.ToRoundedPercent()
					})
					.ToList()
			};
		}
		public IEnumerable<Shared.Data.Players.Player> Map(IEnumerable<Player> players)
		{
			return players
				.Select(player => Map(player));
		}
	}
}
