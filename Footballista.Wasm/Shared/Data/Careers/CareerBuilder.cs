using Footballista.Wasm.Shared.Data.Clubs;
using Footballista.Wasm.Shared.Data.Competitions;
using System;

namespace Footballista.Wasm.Shared.Data.Careers
{
	public class CareerBuilder
	{
		private Guid _id;
		private string _name;
		private Club _club;
		private Competition _competition;
		private SimpleDate _currentDate;
		private Manager _manager;
		private Season _season;

		public CareerBuilder()
		{
		}

		public Career Build()
		{
			return Career.Instantiate
			(
				_id,
				_name,
				_club,
				_competition,
				_currentDate,
				_manager,
				_season
			);
		}

		public CareerBuilder WithId(Guid id)
		{
			_id = id;
			return this;
		}
		public CareerBuilder WithName(string name)
		{
			_name = name;
			return this;
		}
		public CareerBuilder WithClub(Club club)
		{
			_club = club;
			return this;
		}
		public CareerBuilder WithCompetition(Competition competition)
		{
			_competition = competition;
			return this;
		}
		public CareerBuilder WithCurrentDate(SimpleDate date)
		{
			_currentDate = date;
			return this;
		}
		public CareerBuilder WithManager(Manager manager)
		{
			_manager = manager;
			return this;
		}
		public CareerBuilder WithSeason(Season season)
		{
			_season = season;
			return this;
		}
	}
}
