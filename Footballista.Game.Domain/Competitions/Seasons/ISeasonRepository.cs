namespace Footballista.Game.Domain.Competitions.Seasons
{
    public interface ISeasonRepository
    {
        Season GetById(SeasonId id);
    }
}