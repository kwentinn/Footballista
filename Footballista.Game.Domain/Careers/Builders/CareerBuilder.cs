using Footballista.Game.Domain.Clubs;
using Footballista.Game.Domain.Clubs.Teams;
using Footballista.Game.Domain.Competitions;
using Footballista.Game.Domain.Competitions.Seasons;
using Itenso.TimePeriod;

namespace Footballista.Game.Domain.Careers
{
    public class CareerBuilder
    {
        private CareerId _id;
        private readonly string _name;
        private Club _club;
        private Competition _competition;
        private Date _currentDate;
        private Manager _manager;
        private Season _season;

        public CareerBuilder(string name)
        {
            this._name = name;
        }

        public Career Build()
        {
            return Career.NewCareer
            (
                this._name,
                this._club,
                this._competition,
                this._currentDate,
                this._manager,
                this._season
            );
        }

        public CareerBuilder WithId(CareerId id)
        {
            this._id = id;
            return this;
        }
        public CareerBuilder WithClub(Club club)
        {
            this._club = club;
            return this;
        }
        public CareerBuilder WithCompetition(Competition competition)
        {
            this._competition = competition;
            return this;
        }
        public CareerBuilder WithCurrentDate(Date date)
        {
            this._currentDate = date;
            return this;
        }
        public CareerBuilder WithManager(Manager manager)
        {
            this._manager = manager;
            return this;
        }
        public CareerBuilder WithSeason(Season season)
        {
            this._season = season;
            return this;
        }
    }
}
