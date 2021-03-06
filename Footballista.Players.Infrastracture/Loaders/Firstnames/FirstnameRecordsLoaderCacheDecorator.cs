﻿using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Infrastracture.Loaders.Firstnames.Records;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Footballista.Players.Infrastracture.Loaders.Firstnames
{
	public class FirstnameRecordsLoaderCacheDecorator : IFirstnameRecordsLoader
	{
		private readonly IMemoryCache _cache;
		private readonly IFirstnameRecordsLoader _decorated;
		public FirstnameRecordsLoaderCacheDecorator
		(
			IMemoryCache cache,
			IFirstnameRecordsLoader decorated
		)
		{
			_cache = cache;
			_decorated = decorated;
		}
		public Maybe<List<FirstnameRecord>> GetRecords()
		{
			return _cache.GetOrCreate("FIRSTNAME_RECORDS", (entry) =>
			{
				entry.SlidingExpiration = TimeSpan.FromDays(1);
				return _decorated.GetRecords();
			});
		}

		public async Task<Maybe<List<FirstnameRecord>>> GetRecordsAsync()
		{
			return await _cache.GetOrCreateAsync("FIRSTNAME_RECORDS", async(entry) =>
			{
				entry.SlidingExpiration = TimeSpan.FromDays(1);
				return await _decorated.GetRecordsAsync();
			});
		}
	}
}
