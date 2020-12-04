using Footballista.BuildingBlocks.Domain;
using Footballista.Game.Domain.Clubs.Teams;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Footballista.Game.Domain.Clubs
{
    public class Club
	{
		public ClubId Id { get; }
		public ClubName ClubName { get; }
		public CreationYear YearOfCreation { get; }

        private readonly List<Team> _teams = new List<Team>();

		public Team FirstTeam => this._teams.FirstOrDefault(t => t is FirstTeam);

		internal Club
		(
			ClubId id,
			ClubName clubName,
			CreationYear yearOfCreation,
			List<Team> teams
		)
		{
			Ensure.IsNotNull(id);
			Ensure.IsNotNull(clubName);

            this.Id = id;
            this.ClubName = clubName;
            this.YearOfCreation = yearOfCreation;
            this._teams = teams ?? throw new ArgumentNullException(nameof(teams));
		}
	}
}