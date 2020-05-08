using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Infrastracture.Loaders.Firstnames.Records;
using System.Collections.Generic;

namespace Footballista.Players.Infrastracture.Loaders.Firstnames
{
	public interface IFirstnameRecordsLoader
	{
		Maybe<List<FirstnameRecord>> GetRecords();
	}
}
