using Footballista.BuildingBlocks.Domain;

namespace Footballista.Game.Domain.Clubs.Teams.Rules
{
    internal class PlayerNumberMustBeBetween1And99 : IBusinessRule
    {
        private readonly short _number;

        private static readonly BoundedRange<int> _allowedNumbers = BoundedRange<int>.CreateIncluded(1, 99);

        public string Message => "Number must be between 1 and 99.";

        public PlayerNumberMustBeBetween1And99(short number)
        {
            _number = number;
        }

        public bool IsBroken() => !_allowedNumbers.IsValueInRange(_number);
    }
}
