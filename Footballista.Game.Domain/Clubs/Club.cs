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
		public string Name { get; }
		public int? YearOfCreation { get; }
        public string Abbreviation { get; set; }

        private readonly List<Team> _teams = new List<Team>();

		public Team FirstTeam => _teams.FirstOrDefault(t => t is FirstTeam);

		internal Club(
			ClubId id,
			string name,
			string abbreviation,
			int? yearOfCreation,
			List<Team> teams)
		{
			Ensure.IsNotNull(id);
			Ensure.IsNotNullOrEmpty(name);

			Id = id;
			Name = name;
            this.Abbreviation = abbreviation;
            YearOfCreation = yearOfCreation;
			_teams = teams ?? throw new ArgumentNullException(nameof(teams));
		}
	}

	public record ClubId(int Value);
}