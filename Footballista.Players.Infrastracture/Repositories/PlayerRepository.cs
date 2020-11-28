using Footballista.Players.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Footballista.Players.Infrastracture.Repositories
{
	public class PlayerRepository : IPlayerRepository
    {
        public async Task SaveAsync(IEnumerable<Player> players)
        {
            throw new NotImplementedException();
        }
    }
}
