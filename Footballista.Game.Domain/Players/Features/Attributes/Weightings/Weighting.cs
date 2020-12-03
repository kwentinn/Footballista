namespace Footballista.Players.Features.Attributes.Weightings
{
    public sealed record Weighting
    {
        private readonly double _value;

        public Weighting(double value)
        {
            this._value = value;
        }

        public static implicit operator double(Weighting w) => w._value;
        public static implicit operator Weighting(double d) => new Weighting(d);

        public static WeightingResult operator *(Weighting left, double right) => new WeightingResult(left._value * right);
        public static WeightingResult operator *(double left, Weighting right) => new WeightingResult(left * right._value);

        public static Weighting operator +(Weighting left, Weighting right)
        {
            return new Weighting(left._value + right._value);
        }
    }
}
