using Itenso.TimePeriod;
using System.Threading.Tasks;

namespace Footballista.Game.Domain.Careers
{
    public interface ICareerDomainService
    {
        Task CreateCareerAsync(string name, ClubId clubId, CompetitionId competitionId, SeasonId seasonId, Date date, Manager manager);
    }

    public class CareerDomainService : ICareerDomainService
    {
        private readonly ICareerRepository careerRepository;

        public CareerDomainService(ICareerRepository careerRepository)
        {
            this.careerRepository = careerRepository;
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
            //Club club = clubRepository.getClubByIdAsync(clubId);
            // 


            //Career newCareer = new Career(name, club, competition, date, manager, season);

            //await careerRepository.SaveAsync(newCareer);
        }
    }

}
