using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Domain.Features;
using System;
using System.Diagnostics;

namespace Footballista.Players.Domain.PlayerEvolutions
{
	[DebuggerDisplay("{Age} {Rating}")]
	public record AgeRating
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
