using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Builders.Generators;
using Footballista.Players.Builders.Randomisers;
using Footballista.Players.Infrastracture.Loaders.Firstnames;
using Footballista.Players.Infrastracture.Loaders.Firstnames.Records;
using Footballista.Players.Infrastracture.Loaders.Lastnames;
using Footballista.Players.Infrastracture.Loaders.Lastnames.Records;
using Footballista.Players.Persons;
using Footballista.Players.PlayerNames;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Footballista.Players.Infrastracture.Generators
{
	public class NameGenerator : INameGenerator
	{
		private readonly IFirstnameRecordsLoader _firstnameRecordsLoader;
		private readonly ILastnameRecordsLoader _lastnameRecordsLoader;
		private readonly IListRandomiser _listRandomiser;

		public NameGenerator
		(
			IFirstnameRecordsLoader firstnameRecordsLoader,
			ILastnameRecordsLoader lastnameRecordsLoader,
			IListRandomiser listRandomiser
		)
		{
			_firstnameRecordsLoader = firstnameRecordsLoader;
			_lastnameRecordsLoader = lastnameRecordsLoader;
			_listRandomiser = listRandomiser;
		}

		public Name Generate(Gender gender, Country country)
		{
			FirstnameRecord firstnameRecord = GetRandomFirstnameRecord(gender, country);

			LastnameRecord lastnameRecord = GetRandomLastnameRecord(country);

			return new Name(new Firstname(firstnameRecord.Firstname), new Lastname(lastnameRecord.Lastname));
		}

		private FirstnameRecord GetRandomFirstnameRecord(Gender gender, Country country)
		{
			List<string> languages = country.Languages
				.Select(l => l.Value.ToLower())
				.ToList();

			List<FirstnameRecord> firstnamesRecords = _firstnameRecordsLoader.GetRecords()
				.Where(r => r.Genders.Contains(gender) && r.Frequency > 0d && languages.Any(l => r.Languages.Contains(l)))
				.ToList();
			if (firstnamesRecords == null) throw new ApplicationException("Cannot find any firstname record.");

			return _listRandomiser.GetRandomisedItemFromList(firstnamesRecords);
		}

		private LastnameRecord GetRandomLastnameRecord(Country country)
		{
			List<LastnameRecord> lastnameRecords = _lastnameRecordsLoader.GetRecords(country);
			if (lastnameRecords == null) throw new ApplicationException("Cannot find any lastname record.");

			return _listRandomiser.GetRandomisedItemFromList(lastnameRecords);
		}
	}
}
