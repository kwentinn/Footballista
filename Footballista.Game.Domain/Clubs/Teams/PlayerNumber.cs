using Footballista.BuildingBlocks.Domain;
using Footballista.Game.Domain.Clubs.Teams.Rules;
using System.Diagnostics;

namespace Footballista.Game.Domain.Clubs.Teams
{
    public record PlayerNumber : ValueObjectRecord
    {
        private readonly short number;

        public PlayerNumber(short number)
        {
            CheckRule(new PlayerNumberMustBeBetween1And99(number));

            this.number = number;
        }

        public static implicit operator short(PlayerNumber playerNumber) => playerNumber.number;
    }
}
