using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Footballista.BuildingBlocks.Domain
{
	public static class Ensure
	{
		public static void IsNotNull<T>(T parameter, [CallerMemberName] string parameterName = "") where T : class
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(parameterName);
			}
		}
		public static void IsNotNullOrEmpty(string stringParameter, [CallerMemberName]string parameterName = "")
		{
			if (string.IsNullOrEmpty(stringParameter))
			{
				throw new ArgumentNullException(parameterName);
			}
		}
		public static void IsNotNullOrEmpty<T>(IEnumerable<T> source, [CallerMemberName]string parameterName = "")
		{
			if (source is null || !source.Any())
			{
				throw new ArgumentNullException(parameterName);
			}
		}
	}
}
