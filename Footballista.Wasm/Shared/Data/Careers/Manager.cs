﻿namespace Footballista.Wasm.Shared.Data.Careers
{
	public class Manager
	{
		public Gender Gender { get; set; }
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public DateDto DateOfBirth { get; set; }
		public string Country { get; set; }


		public Manager()
		{
		}

		public static Manager DefaultManager
			=> new Manager(Gender.Male, "John", "Doe", new DateDto(1975, 1, 1), "England");

		internal Manager(Gender gender, string firstname, string lastname, DateDto dateOfBirth, string country)
		{
			Gender = gender;
			Firstname = firstname;
			Lastname = lastname;
			DateOfBirth = dateOfBirth;
			Country = country;
		}

		public static Manager CreateManager(Gender gender, string firstname, string lastname, DateDto dateOfBirth, string country)
			=> new Manager(gender, firstname, lastname, dateOfBirth, country);
	}
}
