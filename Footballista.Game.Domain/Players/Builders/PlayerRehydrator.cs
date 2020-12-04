using Footballista.BuildingBlocks.Domain.Percentiles;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Game.Domain.Players;
using Footballista.Game.Domain.Players.Features;
using Footballista.Game.Domain.Players.Persons;
using Footballista.Game.Domain.Players.Physique;
using Footballista.Game.Domain.Players.PlayerNames;
using Footballista.Game.Domain.Players.Positions;
using Itenso.TimePeriod;
using System.Collections.Generic;
using System.Linq;
using UnitsNet;

namespace Footballista.Players.Builders
{
	public class PlayerRehydrator
    {
		private PersonId _personId;
        private Firstname firstname;
        private Lastname lastname;
		private Gender _gender;
		private Foot? _playerFoot;
		private Length height;
		private Mass mass;
		private Percentile _percentile;
		private PhysicalFeatureSet _playerFeatureSet;
		private PlayerPosition _position;
		private IEnumerable<Country> _countries;
        private Date _birthdate;
        private Location _location;

        public PlayerRehydrator() { }

        public PlayerRehydrator WithFirstname(Firstname firstname)
        {
            this.firstname = firstname;
            return this;
        }
		public PlayerRehydrator WithLastname(Lastname lastname)
		{
			this.lastname = lastname;
			return this;
		}
		public PlayerRehydrator WithGender(Gender gender)
		{
			_gender = gender;
			return this;
		}
		public PlayerRehydrator WithFoot(Foot foot)
		{
			_playerFoot = foot;
			return this;
		}
		public PlayerRehydrator WithPercentile(Percentile percentile)
		{
			_percentile = percentile;
			return this;
		}
		public PlayerRehydrator WithId(PersonId personId)
		{
			_personId = personId;
			return this;
		}
		public PlayerRehydrator WithFeatureSet(PhysicalFeatureSet featureSet)
		{
			_playerFeatureSet = featureSet;
			return this;
		}
		public PlayerRehydrator WithPlayerPosition(PlayerPosition position)
		{
			_position = position;
			return this;
		}
		public PlayerRehydrator WithCountries(IEnumerable<Country> countries)
		{
			_countries = countries;
			return this;
		}
		public PlayerRehydrator WithBirthdate(Date date)
		{
			_birthdate = date;
			return this;
		}
		public PlayerRehydrator WithMass(Mass mass)
        {
            this.mass = mass;
            return this;
        }
        public PlayerRehydrator WithHeight(Length height)
        {
            this.height = height;
            return this;
        }
        public PlayerRehydrator WithBirthLocation(Location location)
        {
            this._location = location;
            return this;
        }

		public Player Rehydrate()
		{
			return Player.Rehydrate(
				_personId,
				new PersonName(this.firstname, this.lastname),
				_gender,
				new BirthInfo(_birthdate, _location),
				_playerFoot.Value,
				new BodyMassIndex(this.height, this.mass),
				_percentile,
				_playerFeatureSet,
				_position,
				_countries.ToArray());
		}
	}
}
