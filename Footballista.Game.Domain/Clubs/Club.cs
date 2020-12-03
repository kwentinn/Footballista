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

		public Team FirstTeam => this._teams.FirstOrDefault(t => t is FirstTeam);

		internal Club
		(
			ClubId id,
			string name,
			string abbreviation,
			int? yearOfCreation,
			List<Team> teams
		)
		{
			Ensure.IsNotNull(id);
			Ensure.IsNotNullOrEmpty(name);

            this.Id = id;
            this.Name = name;
            this.Abbreviation = abbreviation;
            this.YearOfCreation = yearOfCreation;
            this._teams = teams ?? throw new ArgumentNullException(nameof(teams));
		}
	}

	public record ClubId(int Value)
    {
        public static implicit operator int(ClubId clubId)
        {
            return clubId.Value;
        }
    }
}