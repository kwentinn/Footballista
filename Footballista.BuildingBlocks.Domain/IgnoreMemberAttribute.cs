﻿using System;

namespace Footballista.BuildingBlocks.Domain
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class IgnoreMemberAttribute : Attribute
	{
	}
}
