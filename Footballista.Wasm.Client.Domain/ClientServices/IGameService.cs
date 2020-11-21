using Footballista.Wasm.Shared.Data.Careers;
using Footballista.Wasm.Shared.Data.Clubs;
using Footballista.Wasm.Shared.Data.Competitions;
using System.Threading.Tasks;

namespace Footballista.Wasm.Client.Domain.ClientServices
{
	public interface IGameService
	{
		Career CurrentGame { get; }

		void Load();
		Task StartNewCareerAsync(string careerName, Club club, Competition competition, Manager manager);
		Career GetCurrentCareer();
		void ExitCareer();
	}
}