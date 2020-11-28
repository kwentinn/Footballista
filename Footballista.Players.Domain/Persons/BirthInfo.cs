using Footballista.BuildingBlocks.Domain;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Domain.Persons.Rules;
using Itenso.TimePeriod;

namespace Footballista.Players.Domain.Persons
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
			Ensure.IsNotNullOrEmpty(city, nameof(city));
			Ensure.IsNotNull(country, nameof(country));

			Location = new Location(new City(city), country);
		}
	}
}
