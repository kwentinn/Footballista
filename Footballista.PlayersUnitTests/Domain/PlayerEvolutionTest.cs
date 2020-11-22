using Footballista.Players.PlayerEvolutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Footballista.PlayersUnitTests.Domain
{
	[TestClass]
	public class PlayerEvolutionTest
	{
		[TestMethod]
		public void MyTestMethod()
		{
			var evo = new PlayerEvolution();

			Assert.IsNotNull(evo);
		}
	}
}
