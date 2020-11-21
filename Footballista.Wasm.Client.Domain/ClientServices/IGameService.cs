using Footballista.Wasm.Shared.Data.Careers;
using Footballista.Wasm.Shared.Data.Clubs;
using Footballista.Wasm.Shared.Data.Competitions;

namespace Footballista.Wasm.Client.Domain.ClientServices
{
	public interface IGameService
	{
		Career CurrentGame { get; }

		void Load();
		void StartNewCareer(string careerName, Club club, Competition competition, Manager manager);
		Career GetCurrentCareer();
		void ExitCareer();
	}
}