using Footballista.Cqrs.Base.Commands;
using System.Threading.Tasks;

namespace Footballista.Cqrs.Commands.CreateCareer
{
    public class CreateCareerCommandHandler : CommandHandler<CreateCareerCommand>
    {
        // private readonly IPlayerService playerService;
        public async override Task HandleAsync(CreateCareerCommand command)
        {
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
