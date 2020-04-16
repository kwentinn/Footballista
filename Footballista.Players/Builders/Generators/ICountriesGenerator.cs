using Footballista.BuildingBlocks.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Footballista.Players.Builders.Generators
{
	public interface ICountriesGenerator
	{
		Country[] Generate();
	}
	public class CountriesGenerator : ICountriesGenerator
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
			Country.Scotland,
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

		public Country[] Generate()
		{
			throw new System.NotImplementedException();
		}
	}
}
