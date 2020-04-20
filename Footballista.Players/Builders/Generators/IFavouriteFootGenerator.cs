using System;

namespace Footballista.Players.Builders.Generators
{
	public interface IFavouriteFootGenerator
	{
		Foot Generate();
	}
	public class FavouriteFootGenerator
	{
		private Random _random = new Random();
		public Foot Generate()
		{
			return (Foot)_random.Next(1, 4);
		}
	}
}
