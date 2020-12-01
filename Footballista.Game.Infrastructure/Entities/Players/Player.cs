using System;
using System.Collections.Generic;

namespace Footballista.Game.Infrastructure.Entities.Players
{
	public class Player
	{
		public Guid Id { get; set; }
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public string Nationalities { get; set; }
		public BirthInfo BirthInfo { get; set; }
		public Bmi Bmi { get; set; }
		public string Foot { get; set; }
		public string Gender { get; set; }
		public int GeneralRating { get; set; }
		public List<Rating> Ratings { get; set; }
		public int Percentile { get; set; }
		public string Position { get; set; }
	}
}
