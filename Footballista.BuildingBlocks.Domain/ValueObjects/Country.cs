using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace Footballista.BuildingBlocks.Domain.ValueObjects
{

	[DebuggerDisplay("{RegionInfo}")]
	public class Country : ValueObject
	{

		public RegionInfo RegionInfo { get; }
		public ReadOnlyCollection<Language> Languages => _languages.AsReadOnly();
		private readonly List<Language> _languages = new List<Language>();

		public Country(string countryCode, params Language[] languages)
		{
			if (countryCode is null) throw new ArgumentNullException(nameof(countryCode));

			RegionInfo = countryCode.ToLowerInvariant() switch
			{
				// mandatory exception for great britain :)
				"gb-eng" => new RegionInfo("gb"),
				"gb-sct" => new RegionInfo("gb"),
				"gb-wls" => new RegionInfo("gb"),
				"gb-nir" => new RegionInfo("gb"),

				// default : try to create a region info according to the country code
				_ => new RegionInfo(countryCode)
			};

			if (languages != null && languages.Any()) _languages.AddRange(languages);
		}

		public static Country France => new Country("fr", Language.French);
		public static Country China => new Country("cn", Language.Chinese);
		public static Country CzechRepublic => new Country("cz", Language.Czech);
		public static Country Denmark => new Country("de", Language.Danish);
		public static Country Spain => new Country("es", Language.Spanish);
		public static Country Greece => new Country("gr", Language.Greek);
		public static Country India => new Country("in", Language.Hindi, Language.English);
		public static Country Ireland => new Country("ie", Language.English, Language.Irish);
		public static Country Italy => new Country("it", Language.Italian);
		public static Country Korea => new Country("ko-KR", Language.Korean);
		public static Country Netherlands => new Country("nl", Language.Dutch);
		public static Country Poland => new Country("pl", Language.Polish);
		public static Country Portugal => new Country("pt", Language.Portuguese);
		public static Country Russia => new Country("ru", Language.Russian);
		public static Country England => new Country("gb-eng", Language.English);
		public static Country Scotland => new Country("gb-sct", Language.English, Language.ScottishGaelic);
		public static Country Wales => new Country("gb-wls", Language.English, Language.Welsh);
		public static Country NorthernIreland => new Country("gb-nir", Language.English, Language.Irish);
		public static Country USA => new Country("us", Language.English);
		public static Country Japan => new Country("jp", Language.Japanese);
	}
}
