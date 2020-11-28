using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Domain.PlayerEvolutions.Rules;

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

		private readonly double _value;

		private EvolutionCurve(double value)
		{
			CheckRule(new EvaluationCurveMustBeWithinRangeRule(value));

			this._value = value;
		}

		public static double operator *(double left, EvolutionCurve right) => left * right._value;
		public static double operator *(EvolutionCurve left, double right) => left._value * right;

		public static implicit operator double(EvolutionCurve curve) => curve._value;
	}
}
