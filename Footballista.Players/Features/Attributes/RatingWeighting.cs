namespace Footballista.Players.Features.Attributes
{
    public sealed class RatingWeighting
    {
        private readonly Rating rating;
        public double Weighting { get; }

        public double WeightedValue => this.Weighting * this.rating.Value;

        public RatingWeighting(double weighting, Rating rating)
        {
            this.Weighting = weighting;
            this.rating = rating;
        }
    }
}
