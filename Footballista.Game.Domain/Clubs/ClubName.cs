using Footballista.BuildingBlocks.Domain;

namespace Footballista.Game.Domain.Clubs
{
    public record ClubName
    {
		public string Name { get; }
		public string Abbreviation { get; }

        public ClubName(string name, string abbreviation)
        {
			Ensure.IsNotNullOrEmpty(name);
			Ensure.IsNotNullOrEmpty(abbreviation);

            this.Name = name;
            this.Abbreviation = abbreviation;
        }
    }
}
