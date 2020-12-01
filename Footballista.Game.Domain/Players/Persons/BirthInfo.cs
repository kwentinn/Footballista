using Footballista.BuildingBlocks.Domain;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Game.Domain.Players.Persons.Rules;
using Itenso.TimePeriod;

namespace Footballista.Game.Domain.Players.Persons
{
	public record BirthInfo : ValueObjectRecord
	{
		public Location Location { get; }
		public Date Date { get; }

		public BirthInfo(Date birthdate, Location location)
		{
			CheckRule(new BirthMustHaveADateRule(birthdate));

			Date = birthdate;
			Location = location;
		}
		public BirthInfo(int year, int month, int day)
		{
			Date = new Date(year, month, day);
		}
		public BirthInfo(int year, int month, int day, string city = null, Country country = null)
			: this(year, month, day)
		{
			Ensure.IsNotNullOrEmpty(city);
			Ensure.IsNotNull(country);

			Location = new Location(new City(city), country);
		}
	}
}
