using Footballista.BuildingBlocks.Domain.Percentiles;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Domain;
using Footballista.Players.Domain.Features;
using Footballista.Players.Domain.Persons;
using Footballista.Players.Domain.Physique;
using Footballista.Players.Domain.PlayerNames;
using Footballista.Players.Domain.Positions;
using Itenso.TimePeriod;
using System.Collections.Generic;
using System.Linq;

namespace Footballista.Players.Builders
{
	public class PlayerBuilder
	{
		private PersonName _name;
		private Gender _gender;
		private Foot? _playerFoot;
		private BodyMassIndex _bmi;
		private Percentile _percentile;
		private PhysicalFeatureSet _playerFeatureSet;
		private PlayerPosition _position;
		private IEnumerable<Country> _countries;
        private BirthInfo _birthInfo;

        public PlayerBuilder() { }

		public PlayerBuilder WithName(PersonName name)
		{
			_name = name;
			return this;
		}
		public PlayerBuilder WithGender(Gender gender)
		{
			_gender = gender;
			return this;
		}
		public PlayerBuilder WithBirthInfo(BirthInfo birthInfo)
        {
			_birthInfo = birthInfo;
			return this;
        }
		public PlayerBuilder WithFoot(Foot foot)
		{
			_playerFoot = foot;
			return this;
		}
		public PlayerBuilder WithBodyMassIndex(BodyMassIndex bmi)
		{
			_bmi = bmi;
			return this;
		}
		public PlayerBuilder WithPercentile(Percentile percentile)
		{
			_percentile = percentile;
			return this;
		}
		public PlayerBuilder WithFeatureSet(PhysicalFeatureSet featureSet)
		{
			_playerFeatureSet = featureSet;
			return this;
		}
		public PlayerBuilder WithPlayerPosition(PlayerPosition position)
		{
			_position = position;
			return this;
		}
		public PlayerBuilder WithCountries(IEnumerable<Country> countries)
		{
			_countries = countries;
			return this;
		}

		public Player Build()
		{
			return Player.CreatePlayer
			(
				_name,
				_gender,
				_birthInfo,
				_playerFoot.Value,
				_bmi,
				_percentile,
				_playerFeatureSet,
				_position,
				_countries.ToArray()
			);
		}
	}
}
