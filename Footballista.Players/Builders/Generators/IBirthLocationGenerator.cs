using Footballista.BuildingBlocks.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Footballista.Players.Builders.Generators
{
	public interface IBirthLocationGenerator
	{
		Location Generate(Country country);
	}
	
}
