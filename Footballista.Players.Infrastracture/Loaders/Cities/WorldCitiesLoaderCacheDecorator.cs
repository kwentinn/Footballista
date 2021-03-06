﻿using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Infrastracture.Loaders.Cities.Records;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Footballista.Players.Infrastracture.Loaders.Cities
{
	public class WorldCitiesLoaderCacheDecorator : IWorldCitiesLoader
	{
		private readonly IMemoryCache _cache;
		private readonly IWorldCitiesLoader _decorated;

		public WorldCitiesLoaderCacheDecorator(IMemoryCache cache, IWorldCitiesLoader decorated)
		{
			_cache = cache;
			_decorated = decorated;
		}

		public Maybe<List<WorldCityRecord>> GetRecords()
		{
			return _cache.GetOrCreate("WORLD_CITIES", (entry) =>
			{
				entry.SlidingExpiration = TimeSpan.FromDays(1);
				return _decorated.GetRecords();
			});
		}

		public async Task<Maybe<List<WorldCityRecord>>> GetRecordsAsync()
		{
			return await _cache.GetOrCreateAsync("WORLD_CITIES", async (entry) =>
			{
				entry.SlidingExpiration = TimeSpan.FromDays(1);
				return await _decorated.GetRecordsAsync();
			});
		}
	}
}
