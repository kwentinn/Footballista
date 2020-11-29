using System.Collections.Generic;
using System.Linq;

namespace Footballista.Game.Domain.Competitions.Seasons
{
    public class SeasonRepository : ISeasonRepository
    {
        private static readonly List<Season> seasons = new List<Season>
        {
            new Season(new SeasonId(1), new Itenso.TimePeriod.Date(2020, 7, 1))
        };
        public Season GetById(SeasonId id)
        {
            return seasons.FirstOrDefault(s => s.Id == id);
        }
    }
}
