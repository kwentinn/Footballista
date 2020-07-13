using Footballista.BuildingBlocks.Domain;
using Footballista.Clubs.Domain.Teams.Rules;

namespace Footballista.Clubs.Domain.Teams
{
	public class PlayerNumber : ValueObject
	{
		public int Number { get; }

		public PlayerNumber(int number)
		{
			CheckRule(new PlayerNumberMustBeBetween1And99(number));

			Number = number;
		}
	}
}
