using Footballista.Game.Domain.Clubs;
using Footballista.Game.Domain.Clubs.Teams;
using Footballista.Game.Domain.Competitions;
using Footballista.Game.Domain.Competitions.Seasons;
using Itenso.TimePeriod;

namespace Footballista.Game.Domain.Careers
{
    public class CareerBuilder
    {
        private string _name;
        private CareerId _id;
        private Club _club;
        private Competition _competition;
        private Date _currentDate;
        private Manager _manager;
        private Season _season;

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

        public CareerBuilder With(string name)
		{
            this._name = name;
            return this;
        }
        public CareerBuilder With(CareerId id)
        {
            this._id = id;
            return this;
        }
        public CareerBuilder With(Club club)
        {
            this._club = club;
            return this;
        }
        public CareerBuilder With(Competition competition)
        {
            this._competition = competition;
            return this;
        }
        public CareerBuilder With(Date date)
        {
            this._currentDate = date;
            return this;
        }
        public CareerBuilder With(Manager manager)
        {
            this._manager = manager;
            return this;
        }
        public CareerBuilder With(Season season)
        {
            this._season = season;
            return this;
        }
    }
}
