using System;

namespace Footballista.BuildingBlocks.Domain.Game
{
	public interface IGame
	{
		string Name { get; }
		DateTime CurrentDate { get; }
	}
}
