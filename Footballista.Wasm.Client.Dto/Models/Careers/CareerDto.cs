using System;

namespace Footballista.Wasm.Client.Dto.Models.Careers
{
	public class CareerDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public SimpleDateDto CurrentDate { get; set; }
		public ManagerDto Manager { get; set; }

		public CompetitionDto CurrentCompetition { get; set; }
		public SeasonDto CurrentSeason { get; set; }
		public int CurrentRank { get; set; } = 0;
		public string UpcomingEvents { get; set; }
	}
}
