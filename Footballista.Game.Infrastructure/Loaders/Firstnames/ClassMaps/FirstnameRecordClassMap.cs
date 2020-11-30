using CsvHelper.Configuration;
using Footballista.Players.Infrastracture.Loaders.Firstnames.ClassMaps.Converters;
using Footballista.Players.Infrastracture.Loaders.Firstnames.Records;

namespace Footballista.Players.Infrastracture.Loaders.Firstnames.ClassMaps
{
	public class FirstnameRecordClassMap : ClassMap<FirstnameRecord>
	{
		public FirstnameRecordClassMap()
		{
			Map(m => m.Firstname)
				.Name("01_prenom");

			Map(m => m.Genders)
				.Name("02_genre")
				.TypeConverter<GenderConverter>();

			Map(m => m.Languages)
				.Name("03_langage")
				.TypeConverter<LanguagesConverter>();

			Map(m => m.Frequency)
				.Name("04_fréquence");
		}
	}
}
