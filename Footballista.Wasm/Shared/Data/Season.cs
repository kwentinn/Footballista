namespace Footballista.Wasm.Shared.Data
{
	public class Season
	{
		public DateDto Start { get; set; }
		public DateDto End { get; set; }

		public static Season Default = new Season(2020, 2021);

		public Season() { }
		private Season(int startYear, int endYear)
		{
			Start = new DateDto(startYear, 7, 1);
			End = new DateDto(endYear, 6, 30);
		}

		public override string ToString() 
			=> $"{Start.Year}-{End.Year}";

		public Season Next() => new Season(Start.Year + 1, End.Year + 1);
	}
}
