using Footballista.BuildingBlocks.Domain.Game;
using System;

namespace Footballista.Game.Domain
{
	public class Game : IGame
	{
		public string Name { get; }
		public string FilePath { get; }
		public DateTime CurrentDate { get; }

		public Game(string name, DateTime currentDate, string filePath = null)
		{
			Name = name;
			CurrentDate = currentDate;
			FilePath = filePath;
		}

		public void Save()
		{
			throw new NotImplementedException();
		}
		public void Delete()
		{
			throw new NotImplementedException();
		}
	}
}
