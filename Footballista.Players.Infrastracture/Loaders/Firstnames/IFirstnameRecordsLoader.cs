using Footballista.Players.Infrastracture.Loaders.Firstnames.Records;
using System.Collections.Generic;

namespace Footballista.Players.Infrastracture.Loaders.Firstnames
{
	public interface IFirstnameRecordsLoader
	{
		List<FirstnameRecord> GetRecords();
	}
}
