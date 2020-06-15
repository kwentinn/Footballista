using Itenso.TimePeriod;
using System;
using System.Collections.Generic;
using System.Text;

namespace Footballista.Wasm.Shared.Data.Careers
{
	public class Career
	{
		public string Name { get; private set; }
		public Date CurrentDate { get; private set; }

		public Career(string name, Date currentDate)
		{
			Name = name;
			CurrentDate = currentDate;
		}
	}
}
