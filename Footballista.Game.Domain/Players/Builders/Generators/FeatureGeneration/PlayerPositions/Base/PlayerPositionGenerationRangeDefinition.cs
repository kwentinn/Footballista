using Footballista.BuildingBlocks.Domain;
using Footballista.Game.Domain.Players.Features;
using Footballista.Game.Domain.Players.Positions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration.PlayerPositions.Base
{
    public abstract class PlayerPositionGenerationRangeDefinition
	{
		private List<GenRange> _generationRanges = new List<GenRange>();

		protected static Range<Rating> MinRange => new Range<Rating>(10, 40);
		protected static Range<Rating> MediumRange => new Range<Rating>(20, 50);
		protected static Range<Rating> MaxRange => new Range<Rating>(30, 65);

		public static ReadOnlyCollection<GenRange> GetGenerationRanges(PlayerPosition position)
		{
			PlayerPositionGenerationRangeDefinition specificGenRange = GetForPosition(position);
			return specificGenRange._generationRanges.AsReadOnly();
		}
		private static PlayerPositionGenerationRangeDefinition GetForPosition(PlayerPosition position)
		{
			if (position == PlayerPosition.Winger)
				return new WingerGenerationRangeDefinition();

			if (position == PlayerPosition.WideMidfield)
				return new WideMidfieldGenerationRangeDefinition();

			if (position == PlayerPosition.WingBack)
				return new WingBackGenerationRangeDefinition();

			if (position == PlayerPosition.Sweeper)
				return new SweeperGenerationRangeDefinition();

			if (position == PlayerPosition.SecondStriker)
				return new SecondStrikerGenerationRangeDefinition();

			if (position == PlayerPosition.GoalKeeper)
				return new GoalKeeperGenerationRangeDefinition();

			if (position == PlayerPosition.FullBack)
				return new FullBackGenerationRangeDefinition();

			if (position == PlayerPosition.DefensiveMidfield)
				return new DefensiveMidfieldGenerationRangeDefinition();

			if (position == PlayerPosition.DefensiveMidfield)
				return new DefensiveMidfieldGenerationRangeDefinition();

			if (position == PlayerPosition.CentreMidfield)
				return new CentreMidfieldGenerationRangeDefinition();

			if (position == PlayerPosition.CentreForward)
				return new CentreForwardGenerationRangeDefinition();

			if (position == PlayerPosition.CentreBack)
				return new CentreBackGenerationRangeDefinition();

			if (position == PlayerPosition.AttackingMidfield)
				return new AttackingMidfieldGenerationRangeDefinition();

			throw new InvalidOperationException("Position not found");
		}

		protected void AddBadSkills(params FeatureType[] featureTypes)
		{
			AddSkills(featureTypes, MinRange);

		}
		protected void AddMediumSkills(params FeatureType[] featureTypes)
		{
			AddSkills(featureTypes, MediumRange);

		}
		protected void AddBestSkills(params FeatureType[] featureTypes)
		{
			AddSkills(featureTypes, MaxRange);
		}

		private void AddSkills(FeatureType[] featureTypes, Range<Rating> range)
		{
			foreach (var featureType in featureTypes)
			{
				_generationRanges.Add(new GenRange(featureType, range));
			}
		}
	}
}
