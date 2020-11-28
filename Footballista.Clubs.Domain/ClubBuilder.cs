using Footballista.Clubs.Domain.Teams;
using System.Collections.Generic;

namespace Footballista.Clubs.Domain
{
	public class ClubBuilder
	{
		private ClubId _clubId;
		private readonly string _name;
		private int? _creationYear;
		private List<Team> _teams;

		public ClubBuilder(string name)
		{
			_name = name;
		}

		public ClubBuilder WithId(ClubId clubId)
		{
			_clubId = clubId;
			return this;
		}
		public ClubBuilder WithCreationYear(int creationYear)
		{
			_creationYear = creationYear;
			return this;
		}
		public ClubBuilder WithTeams(List<Team> teams)
		{
			_teams = teams;
			return this;
		}
		public ClubBuilder WithTeam(Team team)
		{
			_teams = new List<Team> { team };
			return this;
		}
		public ClubBuilder WithFirstTeam(FirstTeam team)
		{
			_teams = new List<Team> { team };
			return this;
		}

		public Club Build()
		{
			return new Club(_clubId, _name, _creationYear, _teams);
		}
	}
}
