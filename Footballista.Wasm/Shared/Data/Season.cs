namespace Footballista.Wasm.Shared.Data
{
	public class Season
	{
		public SimpleDate Start { get; set; }
		public SimpleDate End { get; set; }

		public static Season Default = new Season(2020, 2021);

		public Season() { }
		private Season(int startYear, int endYear)
		{
			Start = new SimpleDate(startYear, 7, 1);
			End = new SimpleDate(endYear, 6, 30);
		}

		public override string ToString() 
			=> $"{Start.Year}-{End.Year}";

		public Season Next() => new Season(Start.Year + 1, End.Year + 1);
	}
}
