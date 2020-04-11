using System;
using System.Diagnostics;
using System.Globalization;

namespace Footballista.BuildingBlocks.Domain.ValueObjects
{
	[DebuggerDisplay("{RegionInfo}")]
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
