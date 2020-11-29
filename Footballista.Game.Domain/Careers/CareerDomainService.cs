using Footballista.Game.Domain.Clubs;
using Footballista.Game.Domain.Competitions;
using Footballista.Game.Domain.Competitions.Seasons;
using Itenso.TimePeriod;
using System.Threading.Tasks;

namespace Footballista.Game.Domain.Careers
{
    public class CareerDomainService : ICareerDomainService
    {
        private readonly ICareerRepository careerRepository;
        private readonly IClubRepository clubRepository;
        private readonly ICompetitionRepository competitionRepository;
        private readonly ISeasonRepository seasonRepository;

        public CareerDomainService(
            ICareerRepository careerRepository, 
            IClubRepository clubRepository, 
            ICompetitionRepository competitionRepository, 
            ISeasonRepository seasonRepository)
        {
            this.careerRepository = careerRepository;
            this.clubRepository = clubRepository;
            this.competitionRepository = competitionRepository;
            this.seasonRepository = seasonRepository;
        }

        public async Task CreateCareerAsync(string name, ClubId clubId, CompetitionId competitionId, SeasonId seasonId, Date date, Manager manager)
        {
            // paramétrage de la carrière
            //  - choix de la compétition
            //  - équipe principale
            //  
            // générer les joueurs
            // sauvegarder les joueurs générés

            // récupérer le club par son id 
            Club club = await clubRepository.GetByIdAsync(clubId);
            Competition competition = competitionRepository.GetById(competitionId);
            Season season = seasonRepository.GetById(seasonId);

            Career newCareer = new Career(name, club, competition, date, manager, season);

            await this.careerRepository.SaveAsync(newCareer);
        }
    }
}
