using System;

namespace Footballista.BuildingBlocks.Domain
{
	public static class Ensure
	{
		public static void IsNotNull<T>(T parameter, string parameterName) where T : class
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(parameterName);
			}
		}
		public static void IsNotNullOrEmpty(string stringParameter, string parameterName)
		{
			if (string.IsNullOrEmpty(stringParameter))
			{
				throw new ArgumentNullException(parameterName);
			}
		}
	}
}
