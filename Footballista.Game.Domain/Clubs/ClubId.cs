namespace Footballista.Game.Domain.Clubs
{
    public record ClubId(int Value)
    {
        public static implicit operator int(ClubId clubId)
        {
            return clubId.Value;
        }
    }
}