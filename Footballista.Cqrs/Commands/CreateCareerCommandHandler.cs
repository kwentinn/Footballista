using Footballista.Cqrs.BuildingBlocks.Commands;
using System.Threading.Tasks;

namespace Footballista.Cqrs.Commands
{
	public class CreateCareerCommandHandler : CommandHandler<CreateCareerCommand>
	{
		// private readonly IPlayerService playerService;
		public async override Task HandleAsync(CreateCareerCommand command)
		{
            await Task.Delay(0);

            // should generate players (only main team for starters)
			// call generate command
            // persist the generated players (json for example)

        }
	}
}
