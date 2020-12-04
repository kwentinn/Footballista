using Footballista.Game.Domain.Clubs.Teams;
using System.Collections.Generic;

namespace Footballista.Game.Domain.Clubs
{
    public class ClubBuilder
    {
        private ClubId clubId;
        private CreationYear creationYear;
        private List<Team> _teams;
        private ClubName clubName;

        public ClubBuilder()
        {
        }

        public ClubBuilder WithClubName(ClubName clubName)
        {
            this.clubName = clubName;
            return this;
        }

        public ClubBuilder WithId(ClubId clubId)
        {
            this.clubId = clubId;
            return this;
        }
        public ClubBuilder WithCreationYear(CreationYear creationYear)
        {
            this.creationYear = creationYear;
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
            return new Club(clubId, this.clubName, creationYear, _teams);
        }
    }
}
