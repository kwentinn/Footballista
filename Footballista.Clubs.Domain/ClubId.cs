using System;

namespace Footballista.Clubs.Domain
{
	public record ClubId
	{
		private readonly int _value;

		public ClubId(int value)
		{
			_value = value;
		}

		public static implicit operator int(ClubId clubId) => clubId._value;

		internal static ClubId New()
		{
			throw new NotImplementedException();
		}
	}
}