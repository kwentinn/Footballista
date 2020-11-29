using Footballista.Game.Domain.Careers;
using Footballista.Game.Domain.Clubs;
using Footballista.Game.Domain.Clubs.Teams;
using Footballista.Game.Domain.Competitions;
using Footballista.Game.Domain.Competitions.Seasons;
using Itenso.TimePeriod;

namespace Footballista.Cqrs.Commands.CreateCareer
{
    public class CreateCareerCommandBuilder
    {
        private readonly string name;
        private CompetitionId competitionId;
        private SeasonId seasonId;
        private Manager manager;
        private ClubId clubId;
        private Date date;

        public CreateCareerCommandBuilder(string name)
        {
            this.name = name;
        }
        public CreateCareerCommandBuilder WithCompetitionId(CompetitionId competitionId)
        {
            this.competitionId = competitionId;
            return this;
        }
        public CreateCareerCommandBuilder WithSeasonId(SeasonId seasonId)
        {
            this.seasonId = seasonId;
            return this;
        }
        public CreateCareerCommandBuilder WithManager(Manager manager)
        {
            this.manager = manager;
            return this;
        }
        public CreateCareerCommandBuilder WithClubId(ClubId clubId)
        {
            this.clubId = clubId;
            return this;
        }
        public CreateCareerCommandBuilder WithDate(Date date)
        {
            this.date = date;
            return this;
        }
        public CreateCareerCommand Build()
        {
            return new CreateCareerCommand(this.name, this.competitionId, this.seasonId, this.manager, this.clubId, this.date);
        }
    }
}
