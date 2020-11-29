using Footballista.BuildingBlocks.Domain;
using Footballista.Game.Domain.Clubs.Teams.Rules;

namespace Footballista.Game.Domain.Clubs.Teams
{
    public record PlayerNumber : ValueObjectRecord
    {
        public int Number { get; }

        public PlayerNumber(int number)
        {
            CheckRule(new PlayerNumberMustBeBetween1And99(number));

            Number = number;
        }
    }
}
