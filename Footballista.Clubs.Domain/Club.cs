using Footballista.Clubs.Domain.Teams;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Footballista.Clubs.Domain
{
	public class Club
	{
		public ClubId Id { get; }
		public string Name { get; }
		public int YearOfCreation { get; }

		public ReadOnlyCollection<Team> Teams => _teams.AsReadOnly();
		private readonly List<Team> _teams = new List<Team>();

		private Club(ClubId id, string name, int yearOfCreation)
		{
			Id = id;
			Name = name;
			YearOfCreation = yearOfCreation;
		}
		private Club(string name, int yearOfCreation)
		{
			Name = name;
			YearOfCreation = yearOfCreation;
		}

		internal static Club Instantiate(ClubId id, string name, int yearOfCreation)
		{
			return new Club(id, name, yearOfCreation);
		}
	}
}
