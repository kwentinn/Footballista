using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Infrastracture.Loaders.Firstnames.Records;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Footballista.Players.Infrastracture.Loaders.Firstnames
{
	public interface IFirstnameRecordsLoader
	{
		Maybe<List<FirstnameRecord>> GetRecords();
		Task<Maybe<List<FirstnameRecord>>> GetRecordsAsync();
	}
}
