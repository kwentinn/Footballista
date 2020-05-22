using Footballista.BuildingBlocks.Domain;
using System;
using System.Diagnostics;

namespace Footballista.Players.Features
{
	[DebuggerDisplay("{Name}")]
	public class Feature : ValueObject
	{
		public string Name { get; }

		private Feature(string name)
		{
			if (string.IsNullOrEmpty(name)) throw new ArgumentException(nameof(name));

			Name = name;
		}

		public static Feature Finishing => new Feature(nameof(Finishing));
		public static Feature PenaltyKick => new Feature(nameof(PenaltyKick));
		public static Feature Cross => new Feature(nameof(Cross));
		public static Feature FreeKick => new Feature(nameof(FreeKick));
		public static Feature Acceleration => new Feature(nameof(Acceleration));
		public static Feature TopSpeed => new Feature(nameof(TopSpeed));
		public static Feature Header => new Feature(nameof(Header));
		public static Feature ReactionSpeed => new Feature(nameof(ReactionSpeed));
		public static Feature PassingSpeed => new Feature(nameof(PassingSpeed));
		public static Feature PassingAccuracy => new Feature(nameof(PassingAccuracy));
		public static Feature Power => new Feature(nameof(Power));
		public static Feature Stamina => new Feature(nameof(Stamina));
		public static Feature Agility => new Feature(nameof(Agility));
		public static Feature Vista => new Feature(nameof(Vista));
		public static Feature Interception => new Feature(nameof(Interception));
		public static Feature Tackling => new Feature(nameof(Tackling));
		public static Feature Focus => new Feature(nameof(Focus));
		public static Feature Composure => new Feature(nameof(Composure));
		public static Feature FightingSpirit => new Feature(nameof(FightingSpirit));
		public static Feature Morale => new Feature(nameof(Morale));

		public static Feature Goalkeeping => new Feature(nameof(Goalkeeping));
	}
	public enum FeatureType
	{
		Finishing,
		PenaltyKick,
		Cross,
		FreeKick,
		Acceleration,
		TopSpeed,
		Header,
		ReactionSpeed,
		PassingSpeed,
		PassingAccuracy,
		Power,
		Stamina, 
		Agility,
		Vista,
		Interception,
		Tackling,
		Focus,
		Composure,
		FightingSpirit,
		Morale,
		Goalkeeping,
	}
}
