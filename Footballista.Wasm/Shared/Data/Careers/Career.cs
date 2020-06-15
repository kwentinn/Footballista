namespace Footballista.Wasm.Shared.Data.Careers
{
	public class Career
	{
		public string Name { get; set; }
		public DateDto CurrentDate { get; set; }
		public Manager Manager { get; set; }

		public static Career DefaultCareer
			=> new Career("Default career", new DateDto(2020, 7, 1), Manager.DefaultManager);
		public Career()
		{
		}
		public Career(string name, DateDto currentDate, Manager manager)
		{
			Name = name;
			CurrentDate = currentDate;
			Manager = manager;
		}
	}
}
