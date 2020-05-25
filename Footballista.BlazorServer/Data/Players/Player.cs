﻿using System.Collections.Generic;

namespace Footballista.BlazorServer.Data.Players
{
	public class Player
	{
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public List<string> Nationalities { get; set; }
		public BirthInfo BirthInfo { get; set; }
		public Bmi Bmi { get; set; }
		public string Foot { get; set; }
		public string Gender { get; set; }
		public int Rating { get; set; }
	}
}
