﻿using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Infrastracture.Loaders.Lastnames.Records;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Footballista.Players.Infrastracture.Loaders.Lastnames
{
	public interface ILastnameRecordsLoader
	{
		// make use of the TwoLetterISORegionName property of RegionInfo class
		List<LastnameRecord> GetRecords(Country country);
		Task<List<LastnameRecord>> GetRecordsAsync(Country country);
	}
}
