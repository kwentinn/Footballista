using Footballista.Game.Domain.Clubs;
using Footballista.Game.Domain.Clubs.Teams;
using Footballista.Game.Domain.Competitions;
using Footballista.Game.Domain.Competitions.Seasons;
using Itenso.TimePeriod;
using System;

namespace Footballista.Game.Domain.Careers
{
    public class CareerBuilder
	{
		private CareerId _id;
		private string _name;
		private Club _club;
		private Competition _competition;
		private Date _currentDate;
		private Manager _manager;
		private Season _season;

		public CareerBuilder(string name)
		{
			_name = name;
		}

		public Career Build()
		{
			return new Career
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

		public CareerBuilder WithId(CareerId id)
		{
			_id = id;
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
		public CareerBuilder WithCurrentDate(Date date)
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
