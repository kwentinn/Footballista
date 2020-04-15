using CsvHelper;
using Footballista.Players.Infrastracture.Records;
using Footballista.Players.Persons;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Footballista.Players.Infrastracture
{
	public abstract class AbstractGrowthRecordsLoader
	{
		public List<GrowthRecord> GetRecords(Gender gender)
		{
			List<GrowthRecord> result;
			using (var reader = new StreamReader(GetCompletePath(gender)))
			using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
			{
				result = csv.GetRecords<GrowthRecord>().ToList();
			}
			return result;
		}
		protected abstract string GetCompletePath(Gender gender);
	}
}

