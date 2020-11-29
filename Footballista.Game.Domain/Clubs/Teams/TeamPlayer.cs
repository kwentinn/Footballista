using Footballista.BuildingBlocks.Domain.ValueObjects;
using Itenso.TimePeriod;

namespace Footballista.Game.Domain.Clubs.Teams
{
    public class TeamPlayer
    {
        public PlayerNumber Number { get; }
        public string Firstname { get; }
        public string Lastname { get; }
        public string Nickname { get; }
        public Date DateOfBirth { get; }
        public Country Country { get; }

        public TeamPlayer
        (
            string firstname,
            string lastname,
            Date dateOfBirth,
            Country country,
            string nickname = null
        )
        {
            Firstname = firstname;
            Lastname = lastname;
            DateOfBirth = dateOfBirth;
            Country = country;
            Nickname = nickname;
        }
    }
}
