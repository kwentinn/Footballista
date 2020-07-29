using Footballista.Wasm.Shared.Data.Careers;
using Footballista.Wasm.Shared.Data.Competitions;

namespace Footballista.Wasm.Client.Domain.ClientServices
{
	public interface IGameService
	{
		Career CurrentGame { get; }

		void Load();
		void StartNewCareer(string careerName, Competition competition, Manager manager);
		Career GetCurrentCareer();
		void ExitCareer();
	}
}