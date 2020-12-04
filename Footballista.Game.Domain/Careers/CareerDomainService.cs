using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Game.Domain.Clubs;
using Footballista.Game.Domain.Clubs.Teams;
using Footballista.Game.Domain.Competitions;
using Footballista.Game.Domain.Competitions.Seasons;
using Footballista.Game.Domain.Players;
using Footballista.Game.Domain.Players.Persons;
using Footballista.Game.Domain.Players.Positions;
using Footballista.Players.Builders;
using Itenso.TimePeriod;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Footballista.Game.Domain.Careers
{
    public class CareerDomainService : ICareerDomainService
    {
        private readonly ICareerRepository _careerRepository;
        private readonly IClubRepository _clubRepository;
        private readonly ICompetitionRepository _competitionRepository;
        private readonly ISeasonRepository _seasonRepository;
        private readonly IPlayerGenerator _playerGenerator;

        public CareerDomainService(
            ICareerRepository careerRepository,
            IClubRepository clubRepository,
            ICompetitionRepository competitionRepository,
            ISeasonRepository seasonRepository,
            IPlayerGenerator playerGenerator)
        {
            this._careerRepository = careerRepository;
            this._clubRepository = clubRepository;
            this._competitionRepository = competitionRepository;
            this._seasonRepository = seasonRepository;
            this._playerGenerator = playerGenerator;
        }

        public async Task CreateCareerAsync(string name, ClubId clubId, CompetitionId competitionId, SeasonId seasonId, Date date, Manager manager)
        {
            IEnumerable<Player> players = await this.GeneratePlayers().ConfigureAwait(false);

            // récupérer le club par son id 
            Club club = await _clubRepository.GetByIdAsync(clubId).ConfigureAwait(false);

            club.FirstTeam.AddPlayers(players);

            Competition competition = this._competitionRepository.GetById(competitionId);
            Season season = this._seasonRepository.GetById(seasonId);

            Career newCareer = new CareerBuilder()
                .With(name)
                .With(club)
                .With(competition)
                .With(date)
                .With(manager)
                .With(season)
                .Build();

            await this._careerRepository.SaveAsync(newCareer).ConfigureAwait(false);
        }

        private async Task<IEnumerable<Player>> GeneratePlayers()
        {
            List<Player> players = new List<Player>();
            foreach (var position in PlayerPosition.AllPositions)
            {
                players.AddRange(await this._playerGenerator.GenerateManyAsync(4, Gender.Male, new Country[] { Country.France }, playerPosition: position));
            }
            return players;
        }
    }
}
