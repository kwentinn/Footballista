using Footballista.Units;

namespace Footballista.Players.Evolutions
{
	public interface IGrowth
	{
		Age Age { get; }
		IUnit Value { get; }
	}
}
