using Footballista.Game.Domain.Clubs;

namespace Footballista.Game.Domain.Fixtures
{
    public class ClubLight
    {
        public ClubId ClubId { get; }
        public ClubName ClubName { get; }

        public ClubLight(ClubId clubId, ClubName clubName)
        {
            this.ClubId = clubId;
            this.ClubName = clubName;
        }
    }
}
