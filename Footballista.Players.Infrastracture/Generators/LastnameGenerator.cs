using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Builders.Generators;
using Footballista.Players.Builders.Randomisers;
using Footballista.Players.Infrastracture.Loaders.Lastnames;
using Footballista.Players.Infrastracture.Loaders.Lastnames.Records;
using Footballista.Players.Persons;
using Footballista.Players.PlayerNames;
using System;
using System.Collections.Generic;

namespace Footballista.Players.Infrastracture.Generators
{
	public class LastnameGenerator : ILastnameGenerator
	{
		private readonly ILastnameRecordsLoader _lastnameRecordsLoader;
		private readonly IListRandomiser _listRandomiser;

		public LastnameGenerator(
			ILastnameRecordsLoader lastnameRecordsLoader,
			IListRandomiser listRandomiser)
		{
			_lastnameRecordsLoader = lastnameRecordsLoader;
			_listRandomiser = listRandomiser;
		}

		public Lastname Generate(Gender gender, Country country)
		{
			List<LastnameRecord> lastnameRecords = _lastnameRecordsLoader.GetRecords(country);
			if (lastnameRecords == null)
			{
				throw new ApplicationException("Cannot find any lastname record.");
			}

			var lastname = _listRandomiser.GetRandomisedItem(lastnameRecords)
				.Lastname;
			return new Lastname(lastname);
		}
	}
}
