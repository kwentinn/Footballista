using Footballista.Cqrs.Base.Queries;
using Footballista.Wasm.Shared.Data.Competitions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Footballista.Cqrs.Queries.GetCompetitionRankings
{
    public class GetCompetitionRankingQueryHandler : QueryHandler<GetCompetitionRanking, List<CompetitionRanking>>
    {
        public override Task<List<CompetitionRanking>> Handle(GetCompetitionRanking request)
        {
            return Task.FromResult(new List<CompetitionRanking>
            {
                new CompetitionRanking
                {
                    ClubName = "Montpellier",
                    Position = 1,
                    GamesPlayed = 38,
                    Won = 25,
                    Drawn = 7,
                    Lost = 6,
                    GoalsFor = 68,
                    GoalsAgainst = 34,
                    GoalsDifference = 34,
                    Points = 82
                },
                new CompetitionRanking
                {
                    ClubName = "Paris Saint-Germain",
                    Position = 2,
                    GamesPlayed = 38,
                    Won = 23,
                    Drawn = 10,
                    Lost = 5,
                    GoalsFor = 75,
                    GoalsAgainst = 41,
                    GoalsDifference = 34,
                    Points = 79
                },
                new CompetitionRanking
                {
                    ClubName = "Lille",
                    Position = 3,
                    GamesPlayed = 38,
                    Won = 21,
                    Drawn = 11,
                    Lost = 6,
                    GoalsFor = 72,
                    GoalsAgainst = 39,
                    GoalsDifference = 33,
                    Points = 74
                },
                new CompetitionRanking
                {
                    ClubName = "Olympique Lyonnais",
                    Position = 4,
                    GamesPlayed = 38,
                    Won = 19,
                    Drawn = 7,
                    Lost = 12,
                    GoalsFor = 64,
                    GoalsAgainst = 51,
                    GoalsDifference = 13,
                    Points = 64
                },
                new CompetitionRanking
                {
                    ClubName = "Girondins de Bordeaux",
                    Position = 5,
                    GamesPlayed = 38,
                    Won = 16,
                    Drawn = 13,
                    Lost = 9,
                    GoalsFor = 53,
                    GoalsAgainst = 74,
                    GoalsDifference = 12,
                    Points = 61
                },
                new CompetitionRanking
                {
                    ClubName = "Stade Rennais",
                    Position = 6,
                    GamesPlayed = 38,
                    Won = 17,
                    Drawn = 9,
                    Lost = 12,
                    GoalsFor = 53,
                    GoalsAgainst = 44,
                    GoalsDifference = 9,
                    Points = 60
                }
            });
        }
    }
}
