using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Infrastracture.Loaders.Growths.Records;
using Footballista.Players.Persons;
using System.Collections.Generic;

namespace Footballista.Players.Infrastracture.Loaders.Growths
{
	public interface IWeightGrowthRecordLoader
	{
		Maybe<List<GrowthRecord>> GetRecords(Gender gender);
	}
}
