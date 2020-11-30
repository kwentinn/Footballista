using Footballista.BuildingBlocks.Domain;
using Footballista.Game.Domain.Players.Persons;
using Footballista.Players.Infrastracture.Loaders.Growths.Records;
using System.Collections.Generic;

namespace Footballista.Players.Infrastracture.Loaders.Growths
{
	public interface IWeightGrowthRecordLoader
	{
		Maybe<List<GrowthRecord>> GetRecords(Gender gender);
	}
}
