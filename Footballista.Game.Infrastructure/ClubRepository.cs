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
            new ClubBuilder("ANGERS SCO")
                .WithId(new ClubId(1))
                .WithFirstTeam(new FirstTeam(new Manager(1, "José", "Michel"), new List<TeamPlayer>()
                {

                }))
                .Build(),

            new ClubBuilder("AS MONACO")
                .WithFirstTeam(new FirstTeam(new Manager(2, "", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(2))
                .Build(),

            new ClubBuilder("AS SAINT-ÉTIENNE")
                .WithFirstTeam(new FirstTeam(new Manager(3, "", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(3))
                .Build(),

            new ClubBuilder("DIJON FCO")
                .WithFirstTeam(new FirstTeam(new Manager(4, "", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(4))
                .Build(),

            new ClubBuilder("FC GIRONDINS DE BORDEAUX")
                .WithFirstTeam(new FirstTeam(new Manager(5, "", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(5))
                .Build(),

            new ClubBuilder("FC LORIENT")
                .WithFirstTeam(new FirstTeam(new Manager(6, "", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(6))
                .Build(),

            new ClubBuilder("FC METZ")
                .WithFirstTeam(new FirstTeam(new Manager(7, "", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(7))
                .Build(),

            new ClubBuilder("FC NANTES")
                .WithFirstTeam(new FirstTeam(new Manager(8, "", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(8))
                .Build(),

            new ClubBuilder("LOSC LILLE")
                .WithFirstTeam(new FirstTeam(new Manager(9, "", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(9))
                .Build(),

            new ClubBuilder("MONTPELLIER HÉRAULT SC")
                .WithId(new ClubId(10))
                .WithFirstTeam(new FirstTeam(new Manager(10, "Michel", "Der Zakarian"), new List<TeamPlayer>()
                {

                }))
                .Build(),

            new ClubBuilder("NÎMES OLYMPIQUE")
                .WithFirstTeam(new FirstTeam(new Manager(11, "", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(10))
                .Build(),

            new ClubBuilder("OGC NICE")
                .WithFirstTeam(new FirstTeam(new Manager(12, "", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(12))
                .Build(),

            new ClubBuilder("OLYMPIQUE DE MARSEILLE")
                .WithFirstTeam(new FirstTeam(new Manager(13, "", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(13))
                .Build(),

            new ClubBuilder("OLYMPIQUE LYONNAIS")
                .WithFirstTeam(new FirstTeam(new Manager(14, "", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(14))
                .Build(),

            new ClubBuilder("PARIS SAINT-GERMAIN")
                .WithFirstTeam(new FirstTeam(new Manager(15, "", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(15))
                .Build(),

            new ClubBuilder("RC LENS")
                .WithFirstTeam(new FirstTeam(new Manager(16, "", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(16))
                .Build(),

            new ClubBuilder("RC STRASBOURG ALSACE")
                .WithFirstTeam(new FirstTeam(new Manager(17, "", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(17))
                .Build(),

            new ClubBuilder("STADE BRESTOIS 29")
                .WithFirstTeam(new FirstTeam(new Manager(18, "", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(18))
                .Build(),

            new ClubBuilder("STADE DE REIMS")
                .WithFirstTeam(new FirstTeam(new Manager(19, "", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(19))
                .Build(),

            new ClubBuilder("STADE RENNAIS FC")
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
