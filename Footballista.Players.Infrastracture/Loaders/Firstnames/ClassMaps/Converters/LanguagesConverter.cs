using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace Footballista.Players.Infrastracture.Loaders.Firstnames.ClassMaps.Converters
{
	public class LanguagesConverter : DefaultTypeConverter
	{
		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			if (string.IsNullOrEmpty(text)) return new string[] { };

			string[] languages = text.Split(",", System.StringSplitOptions.RemoveEmptyEntries);

			return languages;
		}
		public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
		{
			if (value is null)
				return "";

			if (!(value is string[] languages))
				return "";

			return string.Join(",", languages);
		}
	}
}
