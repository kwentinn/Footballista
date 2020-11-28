﻿using Itenso.TimePeriod;

namespace Footballista.Wasm.Client.Dto.Models.Careers
{
	public class SimpleDateDto
	{
		public int Year { get; set; }
		public int Month { get; set; }
		public int Day { get; set; }

		public Date ToDate() => new Date(Year, Month, Day);
	}
}