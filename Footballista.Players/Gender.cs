namespace Footballista.Players
{
	public class Gender
	{
		private bool _isFemale = false;

		private Gender(bool isFemale)
		{
			_isFemale = isFemale;
		}

		public static Gender Male => new Gender(false);
		public static Gender Female => new Gender(true);
	}
}
