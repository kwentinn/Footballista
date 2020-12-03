using Footballista.BuildingBlocks.Domain;
using Footballista.Game.Domain.Clubs.Teams.Rules;

namespace Footballista.Game.Domain.Clubs.Teams
{
	public record PlayerNumber : ValueObjectRecord
    {
        private readonly short _number;

        public PlayerNumber(short number)
        {
            CheckRule(new PlayerNumberMustBeBetween1And99(number));

            this._number = number;
        }

        public static implicit operator short(PlayerNumber playerNumber) => playerNumber._number;
    }
}
