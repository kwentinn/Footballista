using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players;
using Footballista.Players.Persons;
using Footballista.Players.Physique;
using Footballista.Players.PlayerNames;
using System;
using System.Collections.Generic;
using Player = Footballista.BlazorServer.Data.Players.Player;

namespace Footballista.BlazorServer.Data.Mappers
{
	public class PlayerDomainMapper : IMapper<Player, Footballista.Players.Player>
	{
		public Footballista.Players.Player Map(Player player)
		{
			return Footballista.Players.Player.CreatePlayer(
				new Firstname(player.Firstname),
				new Lastname(player.Lastname),
				player.Gender == Gender.Male.ToString() ? Gender.Male : Gender.Female,
				player.BirthInfo.DateOfBirth,
				new Location(new BuildingBlocks.Domain.ValueObjects.City(player.BirthInfo.City.Name), Country.GetFromName(player.BirthInfo.City.Country)),
				player.Foot == Foot.Left.ToString() ? Foot.Left : Foot.Right,
				new BodyMassIndex(new UnitsNet.Length(player.Bmi.HeightInCentimeters, UnitsNet.Units.LengthUnit.Centimeter), new UnitsNet.Mass(player.Bmi.WeightInKilograms, UnitsNet.Units.MassUnit.Kilogram)), 
				new BuildingBlocks.Domain.Percentiles.Percentile(player.Percentile),
				Footballista.Players.Features.PhysicalFeatureSet.CreateFeatureSet(
			) ;
		}

		public IEnumerable<Footballista.Players.Player> Map(IEnumerable<Player> collectionToMapFrom)
		{
			throw new NotImplementedException();
		}
	}

}
