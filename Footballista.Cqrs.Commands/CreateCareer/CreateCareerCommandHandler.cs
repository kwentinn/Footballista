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
            //Game.App.CreateCareer appCommand = command.ToCareer();

            careerDomainService.CreateCareerAsync(command.Name, command.ClubId, command.CompetitionId, command.SeasonId, command.Date, command.Manager);
            // should generate players (only main team for starters)
            // call generate command
            // persist the generated players (json for example)
            // Career careerToCreate = new CareerBuilder(command.Name)
            //    .WithPlayerClub(command.Club)
            // domainService.createCareer()
            await Task.Delay(0);
        }
    }
}
