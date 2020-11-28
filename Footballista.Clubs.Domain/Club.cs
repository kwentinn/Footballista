using Footballista.BuildingBlocks.Domain;
using Footballista.Clubs.Domain.Registrations;
using Footballista.Clubs.Domain.Teams;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Footballista.Clubs.Domain
{
	public class Club
	{
		public ClubId Id { get; }
		public string Name { get; }
		public int? YearOfCreation { get; }

		public ReadOnlyCollection<Team> Teams => _teams.AsReadOnly();
		private readonly List<Team> _teams = new List<Team>();

		private readonly List<ClubRegistration> _clubRegistrations = new List<ClubRegistration>();

		internal Club(
			ClubId id,
			string name,
			int? yearOfCreation,
			List<Team> teams)
		{
			Ensure.IsNotNullOrEmpty(name, nameof(name));

			Id = id;
			Name = name;
			YearOfCreation = yearOfCreation;
			_teams = teams ?? throw new ArgumentNullException(nameof(teams));
		}
	}
}
