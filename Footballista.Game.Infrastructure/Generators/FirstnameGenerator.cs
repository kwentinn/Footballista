using Footballista.BuildingBlocks.Domain;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Builders.Generators;
using Footballista.Players.Builders.Randomisers;
using Footballista.Game.Domain.Players.Persons;
using Footballista.Game.Domain.Players.PlayerNames;
using Footballista.Players.Infrastracture.Loaders.Firstnames;
using Footballista.Players.Infrastracture.Loaders.Firstnames.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Footballista.Players.Infrastracture.Generators
{
	public class FirstnameGenerator : IFirstnameGenerator
	{
		private readonly IFirstnameRecordsLoader _firstnameRecordsLoader;
		private readonly IListRandomiser _listRandomiser;

		public FirstnameGenerator(
			IFirstnameRecordsLoader firstnameRecordsLoader,
			IListRandomiser listRandomiser)
		{
			_firstnameRecordsLoader = firstnameRecordsLoader;
			_listRandomiser = listRandomiser;
		}

		public Firstname Generate(Gender gender, Country country)
		{
			List<string> languages = country.Languages
				.Select(l => l.Value.ToLower())
				.ToList();

			List<FirstnameRecord> firstnamesRecords = _firstnameRecordsLoader.GetRecords().Value
				.Where(r => r.Genders.Contains(gender)
					&& r.Frequency > 0d
					&& languages.Any(l => r.Languages.Contains(l)))
				.ToList();
			if (firstnamesRecords == null)
			{
				throw new ApplicationException("Cannot find any firstname record.");
			}

			FirstnameRecord record = _listRandomiser.GetRandomisedItem(firstnamesRecords);

			return new Firstname(record.Firstname);
		}
		public async Task<Firstname> GenerateAsync(Gender gender, Country country)
		{
			List<string> languages = country.Languages
				.Select(l => l.Value.ToLower())
				.ToList();
			Maybe<List<FirstnameRecord>> recordsMaybe = await _firstnameRecordsLoader.GetRecordsAsync();
			List<FirstnameRecord> records = recordsMaybe
				.ValueOrThrow(new ApplicationException("No records were loaded. Cannot generate Firstname."));
			
			// filter records
			List<FirstnameRecord> firstnamesRecords = records
				.Where(r => r.Genders.Contains(gender)
					&& r.Frequency > 0d
					&& languages.Any(l => r.Languages.Contains(l)))
				.ToList();
			if (firstnamesRecords == null)
			{
				throw new ApplicationException("Cannot find any firstname record.");
			}

			FirstnameRecord record = _listRandomiser.GetRandomisedItem(firstnamesRecords);

			return new Firstname(record.Firstname);
		}
	}
}
