using Footballista.Cqrs.BuildingBlocks.Commands;
using System.Threading.Tasks;

namespace Footballista.Cqrs.Commands
{
	public class CreateCareerCommandHandler : CommandHandler<CreateCareerCommand>
	{
		public async override Task HandleAsync(CreateCareerCommand command)
		{
			await Task.Delay(0);
		}
	}
}
