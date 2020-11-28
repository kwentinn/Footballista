﻿using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Domain.Persons;
using Footballista.Players.Domain.PlayerNames;
using System.Threading.Tasks;

namespace Footballista.Players.Builders.Generators
{
	public interface IFirstnameGenerator
	{
		Firstname Generate(Gender gender, Country country);
		Task<Firstname> GenerateAsync(Gender gender, Country country);
	}
}