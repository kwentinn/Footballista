using Footballista.Players.Infrastracture.Records;
using Footballista.Players.Persons;
using System.Collections.Generic;

namespace Footballista.Players.Infrastracture
{
	public interface IWeightGrowthRecordLoader
	{
		List<GrowthRecord> GetRecords(Gender gender);
	}
}
