using Footballista.BuildingBlocks.Domain;
using Footballista.Players.PlayerEvolutions.Rules;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Footballista.Players.PlayerEvolutions
{
	public class PlayerEvolution
	{
		public Duration Duration { get; }

		public ReadOnlyCollection<FeatureEvolution> Phases => _phases.AsReadOnly();
		private readonly List<FeatureEvolution> _phases = new List<FeatureEvolution>
		{
			Phase1Evolution.Value,
			Phase2Evolution.Value,
			Phase3Evolution.Value
		};

		public PlayerEvolution(Duration duration)
		{
			Duration = duration;
		}
	}

	public sealed class Phase1Evolution : FeatureEvolution
	{
		public static Phase1Evolution Value => new Phase1Evolution
		(
			new Range<PersonAge>(PersonAge.FromYears(14), PersonAge.FromYears(28)),
			EvolutionCurve.Slow
		);

		private Phase1Evolution(Range<PersonAge> ageRange, EvolutionCurve evolutionCurve)
			: base(ageRange, new FeatureImprovementRatio(0.5), evolutionCurve) { }
	}
	public sealed class Phase2Evolution : FeatureEvolution
	{
		public static Phase2Evolution Value => new Phase2Evolution
		(
			new Range<PersonAge>(PersonAge.FromYears(28), PersonAge.FromYears(31)),
			new FeatureImprovementRatio(0.2),
			EvolutionCurve.Slow
		);

		private Phase2Evolution(Range<PersonAge> ageRange, FeatureImprovementRatio maxImprovement, EvolutionCurve evolutionCurve)
			: base(ageRange, maxImprovement, evolutionCurve) { }
	}
	public sealed class Phase3Evolution : FeatureEvolution
	{
		public static Phase3Evolution Value => new Phase3Evolution
		(
			new Range<PersonAge>(PersonAge.FromYears(31), PersonAge.FromYears(50)),
			new FeatureImprovementRatio(-4),
			EvolutionCurve.Slow
		);

		private Phase3Evolution(Range<PersonAge> ageRange, FeatureImprovementRatio maxImprovement, EvolutionCurve evolutionCurve)
			: base(ageRange, maxImprovement, evolutionCurve) { }
	}

	public class FeatureEvolution : ValueObject
	{
		public Range<PersonAge> AgeRange { get; }
		public FeatureImprovementRatio MaxFeatureImprovement { get; }
		public EvolutionCurve EvolutionCurve { get; }

		protected FeatureEvolution(
			Range<PersonAge> ageRange,
			FeatureImprovementRatio maxImprovement,
			EvolutionCurve evolutionCurve)
		{
			AgeRange = ageRange;
			MaxFeatureImprovement = maxImprovement;
			EvolutionCurve = evolutionCurve;
		}

		public FeatureImprovementRatio GetImprovementFromAge(PersonAge age)
		{
			CheckRule(new PersonAgeMustBeWithinAgeRangeRule(age, AgeRange));

			// recalculer l'abscisse pour que 0 <= x <= 1
			double x = (age.Years - AgeRange.Min.Years) / Duration.FromAgeRange(AgeRange).Years;

			// calculer y entre 0 et 1
			double y = Math.Pow(x, EvolutionCurve.Value) * MaxFeatureImprovement.Value;


			return new FeatureImprovementRatio(y);
		}

		public AgeRating ImproveRatingFromAge(AgeRating ageRating, Duration evolutionDuration)
		{
			if (ageRating is null) throw new ArgumentNullException(nameof(ageRating));
			if (evolutionDuration is null)throw new ArgumentNullException(nameof(evolutionDuration));

			var futureAge = PersonAge.FromYears(ageRating.Age.Years + evolutionDuration.Years);

			var improvement = GetImprovementFromAge(futureAge).Value - GetImprovementFromAge(ageRating.Age).Value;
			var ratio = new FeatureImprovementRatio(improvement);


			return new AgeRating(futureAge, ratio.ImproveRating(ageRating.Rating));
		}
	}
}
