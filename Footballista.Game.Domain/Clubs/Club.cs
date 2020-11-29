using Footballista.BuildingBlocks.Domain;
using Footballista.Game.Domain.Clubs.Teams;
using System;
using System.Collections.Generic;

namespace Footballista.Game.Domain.Clubs
{
    public class Club
	{
		public ClubId Id { get; }
		public string Name { get; }
		public int? YearOfCreation { get; }
        public string Abbreviation { get; set; }

        //public ReadOnlyCollection<Team> Teams => _teams.AsReadOnly();
        private readonly List<Team> _teams = new List<Team>();

		//private readonly List<ClubRegistration> _clubRegistrations = new List<ClubRegistration>();

		internal Club(
			ClubId id,
			string name,
			string abbreviation,
			int? yearOfCreation,
			List<Team> teams)
		{
			Ensure.IsNotNull(id, nameof(id));
			Ensure.IsNotNullOrEmpty(name, nameof(name));

			Id = id;
			Name = name;
            this.Abbreviation = abbreviation;
            YearOfCreation = yearOfCreation;
			_teams = teams ?? throw new ArgumentNullException(nameof(teams));
		}
	}

	public record ClubId(int Value);
}