namespace Footballista.Players.Features.Attributes.Weightings
{
    public sealed record Weighting
    {
        private readonly double value;

        public Weighting(double value)
        {
            this.value = value;
        }

        public static implicit operator double(Weighting w) => w.value;
        public static implicit operator Weighting(double d) => new Weighting(d);

        public static WeightingResult operator *(Weighting left, double right) => new WeightingResult(left.value * right);
        public static WeightingResult operator *(double left, Weighting right) => new WeightingResult(left * right.value);

        public static Weighting operator +(Weighting left, Weighting right)
        {
            return new Weighting(left.value + right.value);
        }
    }
}
