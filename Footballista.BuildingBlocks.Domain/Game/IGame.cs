using System;

namespace Footballista.BuildingBlocks.Domain.Game
{
	public interface IGame
	{
		string Name { get; }
		string FilePath { get; }
		DateTime CurrentDate { get; }

		void Save();
		void Delete();
	}
}
