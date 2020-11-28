using Footballista.Players.Domain.Persons;
using System.Diagnostics;

namespace Footballista.Players.Infrastracture.Loaders.Firstnames.Records
{
	[DebuggerDisplay("{Firstname} {Frequency}")]
	public class FirstnameRecord
	{
		public string Firstname { get; set; }

		public Gender[] Genders { get; set; }

		public string[] Languages { get; set; }

		public double Frequency { get; set; }
	}
}
