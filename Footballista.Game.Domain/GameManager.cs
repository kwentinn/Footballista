using Footballista.BuildingBlocks.Domain.Game;

namespace Footballista.Game.Domain
{
	public interface IGameManager
	{
		IGame Load(string filename);
	}
	public class GameManager : IGameManager
	{
		public IGame Load(string filename)
		{
			throw new System.NotImplementedException();
		}
	}
}
