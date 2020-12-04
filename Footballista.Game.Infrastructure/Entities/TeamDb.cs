using System.Collections.Generic;

namespace Footballista.Game.Infrastructure.Entities
{
    public class TeamDb
    {
        public virtual ICollection<TeamPlayerDb> TeamPlayers { get; set; }
    }
}
