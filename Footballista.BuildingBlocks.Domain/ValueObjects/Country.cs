using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace Footballista.BuildingBlocks.Domain.ValueObjects
{
	[DebuggerDisplay("{EnglishName}")]
	public record Country : ValueObjectRecord
	{
		public string CountryCode { get; }
		public string EnglishName { get; }
		public RegionInfo RegionInfo { get; }

		public ReadOnlyCollection<Language> Languages => _languages.AsReadOnly();
		private readonly List<Language> _languages = new List<Language>();

		private Country(string countryCode, string englishName, params Language[] languages)
		{
			if (countryCode is null) throw new ArgumentNullException(nameof(countryCode));

			CountryCode = countryCode.ToLowerInvariant();
			EnglishName = englishName;

			RegionInfo = CountryCode switch
			{
				// mandatory exception for great britain :)

				// England
				"gb-eng" => new RegionInfo("gb"),

				// Scotland
				"gb-sct" => new RegionInfo("gb"),

				// Wales
				"gb-wls" => new RegionInfo("gb"),

				// Northern Ireland
				"gb-nir" => new RegionInfo("gb"),

				// default : try to create a region info according to the country code
				_ => new RegionInfo(countryCode)
			};

			if (languages != null && languages.Any())
			{
				_languages.AddRange(languages);
			}
		}

		public static Country France => new Country("fr", nameof(France), Language.French);
		public static Country China => new Country("cn", nameof(China), Language.Chinese);
		public static Country CzechRepublic => new Country("cz", nameof(CzechRepublic), Language.Czech);
		public static Country Denmark => new Country("de", nameof(Denmark), Language.Danish);
		public static Country Spain => new Country("es", nameof(Spain), Language.Spanish);
		public static Country Greece => new Country("gr", nameof(Greece), Language.Greek);
		public static Country India => new Country("in", nameof(India), Language.Hindi, Language.English);
		public static Country Ireland => new Country("ie", nameof(Ireland), Language.English, Language.Irish);
		public static Country Italy => new Country("it", nameof(Italy), Language.Italian);
		public static Country Korea => new Country("ko-KR", nameof(Korea), Language.Korean);
		public static Country Netherlands => new Country("nl", nameof(Netherlands), Language.Dutch);
		public static Country Poland => new Country("pl", nameof(Poland), Language.Polish);
		public static Country Portugal => new Country("pt", nameof(Portugal), Language.Portuguese);
		public static Country Russia => new Country("ru", nameof(Russia), Language.Russian);
		public static Country England => new Country("gb-eng", nameof(England), Language.English);
		public static Country Scotland => new Country("gb-sct", nameof(Scotland), Language.English, Language.ScottishGaelic);
		public static Country Wales => new Country("gb-wls", nameof(Wales), Language.English, Language.Welsh);
		public static Country NorthernIreland => new Country("gb-nir", nameof(NorthernIreland), Language.English, Language.Irish);
		public static Country USA => new Country("us", nameof(USA), Language.English);
		public static Country Japan => new Country("jp", nameof(Japan), Language.Japanese);
		public static Country Germany => new Country("de", nameof(Germany), Language.German);

		public static Country GetFromName(string name) => _countries.FirstOrDefault(c => c.EnglishName == name);
		public static Country GetFromCode(string countryCode) => _countries.FirstOrDefault(c => c.CountryCode == countryCode);

		private static readonly List<Country> _countries = new List<Country>
		{
			France,
			China,
			CzechRepublic,
			Denmark,
			Spain,
			Greece,
			India,
			Ireland,
			Italy,
			Korea,
			Netherlands,
			Poland,
			Portugal,
			Russia,
			England,
			Scotland,
			Wales,
			NorthernIreland,
			USA,
			Japan,
			Germany
		};
		public static ReadOnlyCollection<Country> Countries => _countries.AsReadOnly();
	}
}
