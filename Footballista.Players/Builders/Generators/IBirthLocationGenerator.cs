using Footballista.BuildingBlocks.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Footballista.Players.Builders.Generators
{
	public interface IBirthLocationGenerator
	{
		Location Generate(Country country);
	}
	public class BirthLocationGenerator : IBirthLocationGenerator
	{
		private Random _random = new Random();

		private List<Country> _countries = new List<Country>
		{
			Country.China,
			Country.CzechRepublic,
			Country.Denmark,
			Country.Spain,
			Country.France,
			Country.England,
			Country.NorthernIreland,
			Country.Ireland,
			Country.Greece,
			Country.India,
			Country.Italy,
			Country.Korea,
			Country.Netherlands,
			Country.Poland,
			Country.Portugal,
			Country.Russia,
			Country.USA
		};

		public Location Generate(Country country)
		{
			// TODO : renvoyer qqch
			return null;
		}
	}
}
