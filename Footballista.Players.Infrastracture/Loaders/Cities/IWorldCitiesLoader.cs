using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Infrastracture.Loaders.Cities.Records;
using System.Collections.Generic;

namespace Footballista.Players.Infrastracture.Loaders.Cities
{
	public interface IWorldCitiesLoader
	{
		Maybe<List<WorldCityRecord>> GetRecords();
	}
}
