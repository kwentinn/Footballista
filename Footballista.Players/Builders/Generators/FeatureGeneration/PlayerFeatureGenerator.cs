﻿using Footballista.BuildingBlocks.Domain;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Builders.Generators.FeatureGeneration.PlayerPositions.Base;
using Footballista.Players.Builders.Generators.FeatureGeneration.RatingRanges;
using Footballista.Players.Builders.Randomisers;
using Footballista.Players.Features;
using Footballista.Players.Physique;
using Footballista.Players.Positions;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Footballista.Players.Builders.Generators.FeatureGeneration
{
    public class PlayerFeatureGenerator
    {
        private static Range<Rating> YoungPlayerFeatureRatingRange => new Range<Rating>(.3, .65);

        private PlayerPosition position;
        private BodyMassIndex bmi;
        private Country country;
        private PersonAge playerAge;
        private PlayerStatus playerStatus;

        private readonly IRandomiser<Rating> randomiser;

        public PlayerFeatureGenerator(IRandomiser<Rating> randomiser)
        {
            this.randomiser = randomiser;
        }

        public PlayerFeatureGenerator ForPosition(PlayerPosition position)
        {
            this.position = position;
            return this;
        }
        public PlayerFeatureGenerator ForBmi(BodyMassIndex bmi)
        {
            this.bmi = bmi;
            return this;
        }
        public PlayerFeatureGenerator ForCountry(Country country)
        {
            this.country = country;
            return this;
        }
        public PlayerFeatureGenerator ForPersonAge(PersonAge playerAge)
        {
            this.playerAge = playerAge;
            return this;
        }
        public PlayerFeatureGenerator ForPlayerStatus(PlayerStatus playerStatus)
        {
            this.playerStatus = playerStatus;
            return this;
        }

        private Range<Rating> CalculateRatingRange()
        {
            Range<Rating> rating = PlayerStatus.GetRatingForStatus(this.playerStatus ?? PlayerStatus.Average);

            Range<Rating> weightedRating = AgeRange.GetRatingForAge(this.playerAge);

            double lower = Math.Max(0.01, rating.Lower.Value * weightedRating.Lower.Value);

            double upper = Math.Min(0.99, rating.Upper.Value * weightedRating.Upper.Value);

            return new Range<Rating>(lower, upper);
        }

        public PhysicalFeatureSet Generate()
        {
            PlayerPositionGenerationRangeDefinition playerPositionGenRange =
                PlayerPositionGenerationRangeDefinition.GetFromPosition(position);

            ReadOnlyCollection<GenRange> positionGenRanges = playerPositionGenRange.GetGenerationRangeDefinitions();
            ReadOnlyCollection<GenRange> bmiGenRanges = BodyMassIndexGenerationRangeDefinition.Generate(bmi, playerAge);

            // plages de génération différentes en fonction de 
            // - la position du joueur
            // - du BMI
            // - [TODO] du pays (à voir plus tard)
            // - [TODO] de l'âge du joueur

            PhysicalFeatureSet set = PhysicalFeatureSet.CreateFeatureSet(position.PositionCategory);

            Parallel.ForEach(set.PhysicalFeatures, feature =>
            {
                Rating rating;

                GenRange genRangeFromPosition = positionGenRanges.FirstOrDefault(c => c.FeatureType == feature.FeatureType);
                GenRange genRangeFromBmi = bmiGenRanges.FirstOrDefault(c => c.FeatureType == feature.FeatureType);

                if (genRangeFromBmi != null && genRangeFromPosition != null)
                {
                    Range<Rating> range = Range<Rating>.MergeRanges(new Range<Rating>[]
                    {
                        genRangeFromBmi.RatingRange,
                        genRangeFromPosition.RatingRange
                    });
                    rating = this.randomiser.Randomise(range);
                }
                else
                {
                    if (genRangeFromPosition != null)
                    {
                        rating = this.randomiser.Randomise(genRangeFromPosition.RatingRange);
                    }
                    else
                    {
                        //if (feature.FeatureType == FeatureType.Morale)
                        //{
                        //	rating = _randomiser.Randomise();
                        //}
                        //else
                        //{
                        Range<Rating> range = CalculateRatingRange();
                        rating = this.randomiser.Randomise(range);
                        //}
                    }
                }
                feature.ChangeRating(rating);
            });
            return set;
        }
    }
}
