using Footballista.BuildingBlocks.Domain;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Features;
using System;
using System.Diagnostics;

namespace Footballista.Players.PlayerEvolutions
{
	[DebuggerDisplay("{Age} {Rating}")]
	public class AgeRating : ValueObject
	{
		public PersonAge Age { get; }
		public Rating Rating { get; }

		public AgeRating(PersonAge age, Rating rating)
		{
			Age = age ?? throw new ArgumentNullException(nameof(age));
			Rating = rating ?? throw new ArgumentNullException(nameof(rating));
		}
	}
}
