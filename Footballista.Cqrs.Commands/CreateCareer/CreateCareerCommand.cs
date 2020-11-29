using Footballista.BuildingBlocks.Domain;
using Footballista.Cqrs.Base.Commands;
using Footballista.Game.Domain.Careers;
using Footballista.Game.Domain.Clubs;
using Footballista.Game.Domain.Clubs.Teams;
using Footballista.Game.Domain.Competitions;
using Footballista.Game.Domain.Competitions.Seasons;
using Itenso.TimePeriod;

namespace Footballista.Cqrs.Commands.CreateCareer
{
    public class CreateCareerCommand : ICommand
    {
        public string Name { get; }
        public CompetitionId CompetitionId { get; }
        public SeasonId SeasonId { get; }
        public Manager Manager { get; }
        public ClubId ClubId { get; }
        public Date Date { get; }

        internal CreateCareerCommand(string name, CompetitionId competitionId, SeasonId seasonId, Manager manager, ClubId clubId, Date date)
        {
            Ensure.IsNotNullOrEmpty(name, nameof(name));
            Ensure.IsNotNull(competitionId, nameof(competitionId));
            Ensure.IsNotNull(seasonId, nameof(seasonId));
            Ensure.IsNotNull(manager, nameof(manager));
            Ensure.IsNotNull(clubId, nameof(clubId));

            this.Name = name;
            this.CompetitionId = competitionId;
            this.SeasonId = seasonId;
            this.Manager = manager;
            this.ClubId = clubId;
            this.Date = date;
        }
    }
}
