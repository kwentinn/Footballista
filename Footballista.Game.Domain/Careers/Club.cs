using System;

namespace Footballista.Game.Domain.Careers
{
    public record Club
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }

    public record ClubId(Guid Value);
}