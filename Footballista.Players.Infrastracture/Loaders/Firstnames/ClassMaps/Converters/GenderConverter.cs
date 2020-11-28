using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Footballista.Players.Domain.Persons;
using System;

namespace Footballista.Players.Infrastracture.Loaders.Firstnames.ClassMaps.Converters
{
	public class GenderConverter : DefaultTypeConverter
	{
		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData) =>
			text switch
			{
				"f" => new Gender[] { Gender.Female },
				"m" => new Gender[] { Gender.Male },
				"m,f" => new Gender[] { Gender.Male, Gender.Female },
				"f,m" => new Gender[] { Gender.Male, Gender.Female },
				_ => throw new ArgumentException($"Incorrect value: {text}")
			};
	}
}
