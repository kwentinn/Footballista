using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Infrastracture.Loaders.Cities.Records;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Footballista.Players.Infrastracture.Loaders.Cities
{
	public interface IWorldCitiesLoader
	{
		Maybe<List<WorldCityRecord>> GetRecords();
		Task<Maybe<List<WorldCityRecord>>> GetRecordsAsync();
	}
}
