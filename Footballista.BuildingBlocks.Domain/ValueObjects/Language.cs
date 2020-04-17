namespace Footballista.BuildingBlocks.Domain.ValueObjects
{
	public class Language
	{
		public string Value { get; }
		public string Code { get; }

		private Language(string value, string code)
		{
			Value = value;
			Code = code;
		}

		public static Language French => new Language(nameof(French), "fr");
		public static Language English => new Language(nameof(English), "en");
		public static Language Spanish => new Language(nameof(Spanish), "es");
		public static Language Polish => new Language(nameof(Polish), "pl");
		public static Language Danish => new Language(nameof(Danish), "da");
		public static Language German => new Language(nameof(German), "ge");
		public static Language Hungarian => new Language(nameof(Hungarian), "hu");
		public static Language Russian => new Language(nameof(Russian), "ru");
		public static Language Romanian => new Language(nameof(Romanian), "ro");
		public static Language Italian => new Language(nameof(Italian), "it");
		public static Language Dutch => new Language(nameof(Dutch), "nl");
		public static Language Greek => new Language(nameof(Greek), "el");
		public static Language Irish => new Language(nameof(Irish), "ga");
		public static Language ScottishGaelic => new Language(nameof(ScottishGaelic), "gd");
		public static Language Croatian => new Language(nameof(Croatian), "hr");
		public static Language Serbian => new Language(nameof(Serbian), "sr");
		public static Language Bulgarian => new Language(nameof(Bulgarian), "bg");
		public static Language Macedonian => new Language(nameof(Macedonian), "mk");
		public static Language Japanese => new Language(nameof(Japanese), "ja");
		public static Language Portuguese => new Language(nameof(Portuguese), "pt");
		public static Language Norwegian => new Language(nameof(Norwegian), "no");
		public static Language NorwegianNynorsk => new Language(nameof(NorwegianNynorsk), "nn");
		public static Language Chinese => new Language(nameof(Chinese), "zh");
		public static Language Hindi => new Language(nameof(Hindi), "hi");
		public static Language Korean => new Language(nameof(Korean), "ko");
		public static Language Czech => new Language(nameof(Czech), "cs");
		public static Language Welsh => new Language(nameof(Welsh), "cy");
	}
}
