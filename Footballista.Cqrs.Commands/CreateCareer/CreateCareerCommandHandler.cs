using Footballista.Cqrs.Base.Commands;
using Footballista.Game.Domain.Careers;
using System.Threading.Tasks;

namespace Footballista.Cqrs.Commands.CreateCareer
{
    public class CreateCareerCommandHandler : CommandHandler<CreateCareerCommand>
    {
        private readonly ICareerDomainService careerDomainService;

        public CreateCareerCommandHandler(ICareerDomainService careerDomainService)
        {
            this.careerDomainService = careerDomainService;
        }

        public async override Task HandleAsync(CreateCareerCommand command)
        {
            await careerDomainService.CreateCareerAsync(command.Name, command.ClubId, command.CompetitionId, command.SeasonId, command.Date, command.Manager);
        }
    }
}
