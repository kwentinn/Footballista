using Footballista.Game.Domain.Clubs.Teams;
using System.Collections.Generic;

namespace Footballista.Game.Domain.Clubs
{
    public class ClubRehydrator
	{
		private ClubId clubId;
		private ClubName clubName;
		private CreationYear creationYear;
		private List<Team> teams;

		public ClubRehydrator()
		{
		}

		public ClubRehydrator WithId(ClubId clubId)
		{
			this.clubId = clubId;
			return this;
		}
		public ClubRehydrator WithClubName(ClubName clubName)
        {
            this.clubName = clubName;
            return this;
        }
		public ClubRehydrator WithCreationYear(CreationYear creationYear)
		{
			this.creationYear = creationYear;
			return this;
		}
		public ClubRehydrator WithTeams(List<Team> teams)
		{
			this.teams = teams;
			return this;
		}
		public ClubRehydrator WithTeam(Team team)
		{
			teams = new List<Team> { team };
			return this;
		}
		public ClubRehydrator WithFirstTeam(FirstTeam team)
		{
			teams = new List<Team> { team };
			return this;
		}

		public Club Rehydrate()
		{
			return new Club(clubId, clubName, creationYear, teams);
		}
	}
}
