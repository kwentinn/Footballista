using System;

namespace Footballista.Game.Domain.Careers
{
    public record Competition
    {
        public CompetitionId Id { get; }
        public string Name { get; }


    }
    public record CompetitionId(int Value);
}