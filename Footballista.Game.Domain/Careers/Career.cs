using Footballista.Game.Domain.Clubs;
using Footballista.Game.Domain.Clubs.Teams;
using Footballista.Game.Domain.Competitions;
using Footballista.Game.Domain.Competitions.Seasons;
using Itenso.TimePeriod;
using System;

namespace Footballista.Game.Domain.Careers
{
    public record CareerId
    {
        private readonly Guid _id;

        public CareerId(Guid id)
        {
            this._id = id;
        }

        public static CareerId New() => new CareerId(Guid.NewGuid());

        public static implicit operator Guid(CareerId careerId) => careerId._id;
    };
    public class Career
    {
        public CareerId Id { get; }
        public string Name { get; }
        public Club Club { get; }
        public Competition Competition { get; }
        public Date CurrentDate { get; }
        public Manager Manager { get; }
        public Season Season { get; }

        private Career(string name, Club club, Competition competition, Date currentDate, Manager manager, Season season)
        {
            this.Name = name;
            this.Club = club;
            this.Competition = competition;
            this.CurrentDate = currentDate;
            this.Manager = manager;
            this.Season = season;
        }
        private Career(CareerId id, string name, Club club, Competition competition, Date currentDate, Manager manager, Season season)
            : this(name, club, competition, currentDate, manager, season)
        {
            this.Id = id;
        }

        public static Career NewCareer(string name, Club club, Competition competition, Date currentDate, Manager manager, Season season)
        {
            return new Career(CareerId.New(), name, club, competition, currentDate, manager, season);
        }

        //      /// <summary>
        //      /// Creates a new instance from the infrastructure layer
        //      /// </summary>
        //      /// <param name="id"></param>
        //      /// <param name="name"></param>
        //      /// <param name="club"></param>
        //      /// <param name="competition"></param>
        //      /// <param name="currentDate"></param>
        //      /// <param name="manager"></param>
        //      /// <param name="season"></param>
        //      /// <returns></returns>
        //public static Career Rehydrate(CareerId id, string name, Club club, Competition competition, Date currentDate, Manager manager, Season season)
        //{
        //          return new Career(id, name, club, competition, currentDate, manager, season);
        //      }

        public static CareerBuilder RehydrateWithBuilder() => new CareerBuilder();
	}
}