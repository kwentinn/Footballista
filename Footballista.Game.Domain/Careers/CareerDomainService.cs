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
        private readonly ICareerRepository careerRepository;
        private readonly IClubRepository clubRepository;
        private readonly ICompetitionRepository competitionRepository;
        private readonly ISeasonRepository seasonRepository;
        private readonly IPlayerGenerator playerGenerator;

        public CareerDomainService(
            ICareerRepository careerRepository,
            IClubRepository clubRepository,
            ICompetitionRepository competitionRepository,
            ISeasonRepository seasonRepository,
            IPlayerGenerator playerGenerator)
        {
            this.careerRepository = careerRepository;
            this.clubRepository = clubRepository;
            this.competitionRepository = competitionRepository;
            this.seasonRepository = seasonRepository;
            this.playerGenerator = playerGenerator;
        }

        public async Task CreateCareerAsync(string name, ClubId clubId, CompetitionId competitionId, SeasonId seasonId, Date date, Manager manager)
        {
            // paramétrage de la carrière
            //  - choix de la compétition
            //  - équipe principale
            //  
            // générer les joueurs
            // sauvegarder les joueurs générés

            IEnumerable<Player> players = await GeneratePlayers();

            // récupérer le club par son id 
            Club club = await clubRepository.GetByIdAsync(clubId);

            club.FirstTeam.AddPlayers(players);

            Competition competition = competitionRepository.GetById(competitionId);
            Season season = seasonRepository.GetById(seasonId);

            Career newCareer = new Career(name, club, competition, date, manager, season);

            await this.careerRepository.SaveAsync(newCareer);
        }

        private async Task<IEnumerable<Player>> GeneratePlayers()
        {
            List<Player> players = new List<Player>();
            foreach (var position in PlayerPosition.AllPositions)
            {
                players.AddRange(await this.playerGenerator.GenerateManyAsync(4, Gender.Male, new Country[] { Country.France }, playerPosition: position));
            }
            return players;
        }
    }
}
