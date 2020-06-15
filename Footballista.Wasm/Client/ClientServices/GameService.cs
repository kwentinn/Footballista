using Footballista.Wasm.Shared.Data.Careers;
using Itenso.TimePeriod;

namespace Footballista.Wasm.Client.ClientServices
{
	public class GameService
	{
		public Career CurrentGame { get; private set; }

		public void Load()
		{
			CurrentGame = new Career("Dummy", new Date(2020, 6, 4));
		}
	}
}
