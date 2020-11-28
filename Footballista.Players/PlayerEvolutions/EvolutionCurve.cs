using Footballista.BuildingBlocks.Domain;
using Footballista.Players.PlayerEvolutions.Rules;

namespace Footballista.Players.PlayerEvolutions
{
	public record EvolutionCurve : ValueObjectRecord
	{
		public static EvolutionCurve Fastest => new EvolutionCurve(0.1);
		public static EvolutionCurve Faster => new EvolutionCurve(0.5);
		public static EvolutionCurve Linear => new EvolutionCurve(1);
		public static EvolutionCurve Slow => new EvolutionCurve(2);
		public static EvolutionCurve Slower => new EvolutionCurve(2);
		public static EvolutionCurve Slowest => new EvolutionCurve(4);

		public double Value { get; }

		private EvolutionCurve(double value)
		{
			CheckRule(new EvaluationCurveMustBeWithinRangeRule(value));

			Value = value;
		}
	}
}
