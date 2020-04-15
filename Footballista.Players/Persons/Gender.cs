using System.Diagnostics;

namespace Footballista.Players.Persons
{
	//[DebuggerDisplay("{_value}")]
	//public class Gender
	//{
	//	private readonly bool _isFemale;
	//	private readonly string _value;

	//	private Gender(bool isFemale, string value)
	//	{
	//		_isFemale = isFemale;
	//		_value = value;
	//	}

	//	public static Gender Male => new Gender(false, nameof(Male));
	//	public static Gender Female => new Gender(true, nameof(Female));
	//}
	public enum Gender
	{
		Male,
		Female
	}
}
