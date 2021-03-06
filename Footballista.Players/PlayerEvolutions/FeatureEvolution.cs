﻿using Footballista.BuildingBlocks.Domain;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.PlayerEvolutions.Rules;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Footballista.BuildingBlocks.Domain.UnitTests")]
[assembly: InternalsVisibleTo("Footballista.PlayersUnitTests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace Footballista.Players.PlayerEvolutions
{
	public class PlayerEvolution
	{
		private readonly Range<PersonAge> _ageRange;
		private readonly Duration _duration;

		internal ReadOnlyCollection<FeatureEvolution> Phases => _phases.AsReadOnly();
		private readonly List<FeatureEvolution> _phases = new List<FeatureEvolution>
		{
			Phase1Evolution.Value,
			Phase2Evolution.Value,
			Phase3Evolution.Value
		};

		public PlayerEvolution()
		{
			List<Range<PersonAge>> ranges = _phases
				.Select(p => p.AgeRange)
				.ToList();

			_ageRange = Range<PersonAge>.MergeRanges(ranges);

			_duration = Duration.FromAgeRange(_ageRange);
		}
	}

	internal sealed class Phase1Evolution : FeatureEvolution
	{
		private const int AGE_MIN = 14;
		private const int AGE_MAX = 28;

		public static Phase1Evolution Value => new Phase1Evolution
		(
			new Range<PersonAge>(PersonAge.FromYears(AGE_MIN), PersonAge.FromYears(AGE_MAX)),
			EvolutionCurve.Slow
		);

		public static Phase1Evolution Create(EvolutionCurve evolutionCurve)
			=> new Phase1Evolution(new Range<PersonAge>(PersonAge.FromYears(AGE_MIN), PersonAge.FromYears(AGE_MAX)), evolutionCurve);

		private Phase1Evolution(Range<PersonAge> ageRange, EvolutionCurve evolutionCurve)
			: base(ageRange, new FeatureImprovementRatio(0.5), evolutionCurve) 
		{ 
		}
	}
	internal sealed class Phase2Evolution : FeatureEvolution
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
	internal sealed class Phase3Evolution : FeatureEvolution
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

	internal class FeatureEvolution : ValueObject
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
			double x = (age.Years - AgeRange.Lower.Years) / Duration.FromAgeRange(AgeRange).Years;

			// calculer y entre 0 et 1
			double y = Math.Pow(x, EvolutionCurve.Value) * MaxFeatureImprovement.Value;


			return new FeatureImprovementRatio(y);
		}
		public FeatureImprovementRatio GetImprovementFromAgeRange(Range<PersonAge> ageRange)
		{
			var improvement = GetImprovementFromAge(ageRange.Upper).Value - GetImprovementFromAge(ageRange.Lower).Value;
			return new FeatureImprovementRatio(improvement);
		}

		public AgeRating ImproveRatingFromAge(AgeRating currentAgeRating, Duration evolutionDuration)
		{
			if (currentAgeRating is null) throw new ArgumentNullException(nameof(currentAgeRating));
			if (evolutionDuration is null) throw new ArgumentNullException(nameof(evolutionDuration));

			// on ajoute la durée à l'âge du joueur (PersonAge + Duration = PersonAge)
			PersonAge futureAge = currentAgeRating.Age + evolutionDuration;

			FeatureImprovementRatio improvement = GetImprovementFromAge(futureAge) - GetImprovementFromAge(currentAgeRating.Age);

			return new AgeRating(futureAge, improvement.ImproveRating(currentAgeRating.Rating));
		}
	}
}
