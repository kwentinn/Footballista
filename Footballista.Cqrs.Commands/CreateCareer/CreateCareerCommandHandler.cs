using Footballista.Cqrs.Base.Commands;
using Footballista.Game.Domain.Careers;
using System.Threading.Tasks;

namespace Footballista.Cqrs.Commands.CreateCareer
{
    public class CreateCareerCommandHandler : CommandHandler<CreateCareerCommand>
    {
        private readonly ICareerDomainService _careerDomainService;

        public CreateCareerCommandHandler(ICareerDomainService careerDomainService)
        {
            this._careerDomainService = careerDomainService;
        }

        public async override Task HandleAsync(CreateCareerCommand command)
        {
            await _careerDomainService.CreateCareerAsync(command.Name, command.ClubId, command.CompetitionId, command.SeasonId, command.Date, command.Manager);
        }
    }
}
