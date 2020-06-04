namespace Footballista.Wasm.Shared.Data
{
	public class Season
	{
		public int Start { get; }
		public int End { get; }

		public Season(int start, int end)
		{
			Start = start;
			End = end;
		}

		public override string ToString() 
			=> $"{Start}-{End}";
	}
}
