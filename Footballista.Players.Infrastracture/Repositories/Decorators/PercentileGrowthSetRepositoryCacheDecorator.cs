using Footballista.Players.Growths;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace Footballista.Players.Infrastracture.Repositories.Decorators
{
	public class PercentileGrowthSetRepositoryCacheDecorator : IPercentileGrowthSetRepository
	{
		private readonly IPercentileGrowthSetRepository _decorated;
		private readonly IMemoryCache _cache;

		public PercentileGrowthSetRepositoryCacheDecorator
		(
			IMemoryCache cache,
			IPercentileGrowthSetRepository decorated
		)
		{
			_cache = cache;
			_decorated = decorated;
		}

		public FemalePercentileGrowthSet GetFemalePercentileGrowthSet()
		{
			return _cache.GetOrCreate("FEMALE_PERCENTILE_GROWTH_SET", (entry) =>
			{
				entry.SlidingExpiration = TimeSpan.FromDays(1);
				return _decorated.GetFemalePercentileGrowthSet();
			});
		}

		public MalePercentileGrowthSet GetMalePercentileGrowthSet()
		{
			return _cache.GetOrCreate("MALE_PERCENTILE_GROWTH_SET", (entry) =>
			{
				entry.SlidingExpiration = TimeSpan.FromDays(1);
				return _decorated.GetMalePercentileGrowthSet();
			});
		}
	}
}
