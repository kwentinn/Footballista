using System.Collections.Generic;

namespace Footballista.Game.Infrastructure.Entities
{
    public class TeamDb
    {
        public ManagerDb Manager { get; set; }
        public virtual ICollection<TeamPlayerDb> TeamPlayers { get; set; }
    }
}
