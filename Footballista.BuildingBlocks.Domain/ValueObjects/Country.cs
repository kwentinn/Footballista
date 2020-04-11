using System;
using System.Globalization;

namespace Footballista.BuildingBlocks.Domain.ValueObjects
{
	public class Country : ValueObject
	{
		public RegionInfo RegionInfo { get; }

		public Country(string countryCode)
		{
			if (countryCode is null) throw new ArgumentNullException(nameof(countryCode));

			RegionInfo = new RegionInfo(countryCode);
		}
	}
}
