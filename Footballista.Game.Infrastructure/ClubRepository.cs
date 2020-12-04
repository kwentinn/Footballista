using Footballista.Game.Domain.Clubs;
using Footballista.Game.Domain.Clubs.Teams;
using Footballista.Game.Domain.Competitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manager = Footballista.Game.Domain.Clubs.Teams.Manager;

namespace Footballista.Game.Infrastructure
{

    public class ClubRepository : IClubRepository
    {
        private static readonly List<Club> _clubs = new List<Club>
        {
            new ClubBuilder()
                .WithId(new ClubId(1))
                .WithClubName(new ClubName("ANGERS SCO", "ASCO"))
                .WithFirstTeam(new FirstTeam(new Manager(1, "José", "Michel"), new List<TeamPlayer>()
                {

                }))
                .Build(),

            new ClubBuilder()
                .WithClubName(new ClubName("AS MONACO", "ASM"))
                .WithFirstTeam(new FirstTeam(new Manager(2, "", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(2))
                .Build(),

            new ClubBuilder()
                .WithClubName(new ClubName("AS SAINT-ÉTIENNE", "ASSE"))
                .WithFirstTeam(new FirstTeam(new Manager(3, "", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(3))
                .Build(),

            new ClubBuilder()
                .WithClubName(new ClubName("DIJON FCO", "DFCO"))
                .WithFirstTeam(new FirstTeam(new Manager(4, "", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(4))
                .Build(),

            new ClubBuilder()
                .WithClubName(new ClubName("FC GIRONDINS DE BORDEAUX", "FCGB"))
                .WithFirstTeam(new FirstTeam(new Manager(5, "", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(5))
                .Build(),

            new ClubBuilder()
                .WithClubName(new ClubName("FC LORIENT", "FCL"))
                .WithFirstTeam(new FirstTeam(new Manager(6, "", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(6))
                .Build(),

            new ClubBuilder()
                .WithClubName(new ClubName("FC METZ", "FCM"))
                .WithFirstTeam(new FirstTeam(new Manager(7, "", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(7))
                .Build(),

            new ClubBuilder()
                .WithClubName(new ClubName("FC NANTES", "FCN"))
                .WithFirstTeam(new FirstTeam(new Manager(8, "", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(8))
                .Build(),

            new ClubBuilder()
                .WithClubName(new ClubName("LOSC LILLE", "LOSC"))
                .WithFirstTeam(new FirstTeam(new Manager(9, "", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(9))
                .Build(),

            new ClubBuilder()
                .WithClubName(new ClubName("MONTPELLIER HÉRAULT SC", "MHSC"))
                .WithId(new ClubId(10))
                .WithFirstTeam(new FirstTeam(new Manager(10, "Michel", "Der Zakarian"), new List<TeamPlayer>()
                {

                }))
                .Build(),

            new ClubBuilder()
                .WithClubName(new ClubName("NÎMES OLYMPIQUE", "NO"))
                .WithFirstTeam(new FirstTeam(new Manager(11, "", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(10))
                .Build(),

            new ClubBuilder()
                .WithClubName(new ClubName("OGC NICE", "OGCN"))
                .WithFirstTeam(new FirstTeam(new Manager(12, "", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(12))
                .Build(),

            new ClubBuilder()
                .WithClubName(new ClubName("OLYMPIQUE DE MARSEILLE", "OM"))
                .WithFirstTeam(new FirstTeam(new Manager(13, "", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(13))
                .Build(),

            new ClubBuilder()
                .WithClubName(new ClubName("OLYMPIQUE LYONNAIS", "OL"))
                .WithFirstTeam(new FirstTeam(new Manager(14, "", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(14))
                .Build(),

            new ClubBuilder()
                .WithClubName(new ClubName("PARIS SAINT-GERMAIN", "PSG"))
                .WithFirstTeam(new FirstTeam(new Manager(15, "", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(15))
                .Build(),

            new ClubBuilder()
                .WithClubName(new ClubName("RC LENS", "RCL"))
                .WithFirstTeam(new FirstTeam(new Manager(16, "", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(16))
                .Build(),

            new ClubBuilder()
                .WithClubName(new ClubName("RC STRASBOURG ALSACE", "RCSA"))
                .WithFirstTeam(new FirstTeam(new Manager(17, "", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(17))
                .Build(),

            new ClubBuilder()
                .WithClubName(new ClubName("STADE BRESTOIS 29", "SB29"))
                .WithFirstTeam(new FirstTeam(new Manager(18, "", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(18))
                .Build(),

            new ClubBuilder()
                .WithClubName(new ClubName("STADE DE REIMS", "SDR"))
                .WithFirstTeam(new FirstTeam(new Manager(19, "", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(19))
                .Build(),

            new ClubBuilder()
                .WithClubName(new ClubName("STADE RENNAIS FC", "SRFC"))
                .WithFirstTeam(new FirstTeam(new Manager(20, "", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(20))
                .Build()
        };

        public async Task<Club> GetByIdAsync(ClubId id)
        {
            return _clubs.FirstOrDefault(c => c.Id == id);
        }

        public async Task<IEnumerable<Club>> GetByIdsAsync(params ClubId[] ids)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Club>> GetClubsInCompetition(CompetitionId competitionId)
        {
            return _clubs;
        }
    }
}
