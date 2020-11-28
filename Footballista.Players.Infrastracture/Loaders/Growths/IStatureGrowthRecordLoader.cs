using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Domain.Persons;
using Footballista.Players.Infrastracture.Loaders.Growths.Records;
using System.Collections.Generic;

namespace Footballista.Players.Infrastracture.Loaders.Growths
{
	public interface IStatureGrowthRecordLoader
	{
		Maybe<List<GrowthRecord>> GetRecords(Gender gender);
	}
}
