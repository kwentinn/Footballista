using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Footballista.Clubs.Domain.Teams
{
	public class Team
	{
		public string Name { get; }
		public Coach Coach { get; }
		public AgeCategory AgeCategory { get; }

		public ReadOnlyCollection<TeamPlayer> Players => _players.AsReadOnly();
		private readonly List<TeamPlayer> _players = new List<TeamPlayer>();

		public Team(
			string name, 
			Coach coach, 
			AgeCategory ageCategory,
			List<TeamPlayer> teamPlayers)
		{
			Name = name;
			Coach = coach;
			AgeCategory = ageCategory;
			_players = teamPlayers.ToList();
		}
	}
}
