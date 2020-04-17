using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Builders.Generators;
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
		private readonly Random _random = new Random();
		public NameGenerator
		(
			IFirstnameRecordsLoader firstnameRecordsLoader,
			ILastnameRecordsLoader lastnameRecordsLoader
		)
		{
			_firstnameRecordsLoader = firstnameRecordsLoader;
			_lastnameRecordsLoader = lastnameRecordsLoader;
		}

		public Name Generate(Gender gender, Country country)
		{
			FirstnameRecord firstnameRecord = GetFirstnameRecord(gender, country);

			LastnameRecord lastnameRecord = GetLastnameRecord(gender, country);

			return new Name(new Firstname(firstnameRecord.Firstname), new Lastname(lastnameRecord.Lastname));
		}

		private FirstnameRecord GetFirstnameRecord(Gender gender, Country country)
		{
			List<FirstnameRecord> firstnamesRecords = _firstnameRecordsLoader.GetRecords();

			int firstnamesCount = firstnamesRecords
				.Count(fnr => fnr.Genders.Contains(gender)); // && fnr.Languages.Contains(country.Languages.)
			int firstnamesIndex = _random.Next(firstnamesCount);

			return firstnamesRecords.ElementAt(firstnamesIndex);
		}

		private LastnameRecord GetLastnameRecord(Gender gender, Country country)
		{
			List<LastnameRecord> lastnameRecords = _lastnameRecordsLoader.GetRecords(country);
			int lastnamesCount = lastnameRecords.Count;
			int lastnamesIndex = _random.Next(lastnamesCount);
			return lastnameRecords.ElementAt(lastnamesIndex);
		}
	}
}
