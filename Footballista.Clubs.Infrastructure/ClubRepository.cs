using Footballista.Clubs.Domain;
using Footballista.Clubs.Domain.Teams;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Footballista.Clubs.Infrastructure
{
    public class ClubRepository : IClubRepository
    {
        private static readonly List<Club> _clubs = new List<Club>
        {
            new ClubBuilder("ANGERS SCO")
                .WithId(new ClubId(1))
                .WithFirstTeam(new FirstTeam(new Coach("", ""), new List<TeamPlayer>()
                {

                }))
                .Build(),

            new ClubBuilder("AS MONACO")
                .WithFirstTeam(new FirstTeam(new Coach("", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(2))
                .Build(),

            new ClubBuilder("AS SAINT-ÉTIENNE")
                .WithFirstTeam(new FirstTeam(new Coach("", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(3))
                .Build(),

            new ClubBuilder("DIJON FCO")
                .WithFirstTeam(new FirstTeam(new Coach("", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(4))
                .Build(),

            new ClubBuilder("FC GIRONDINS DE BORDEAUX")
                .WithFirstTeam(new FirstTeam(new Coach("", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(5))
                .Build(),

            new ClubBuilder("FC LORIENT")
                .WithFirstTeam(new FirstTeam(new Coach("", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(6))
                .Build(),

            new ClubBuilder("FC METZ")
                .WithFirstTeam(new FirstTeam(new Coach("", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(7))
                .Build(),

            new ClubBuilder("FC NANTES")
                .WithFirstTeam(new FirstTeam(new Coach("", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(8))
                .Build(),

            new ClubBuilder("LOSC LILLE")
                .WithFirstTeam(new FirstTeam(new Coach("", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(9))
                .Build(),

            new ClubBuilder("MONTPELLIER HÉRAULT SC")
                .WithId(new ClubId(10))
                .WithFirstTeam(new FirstTeam(new Coach("Michel", "Der Zakarian"), new List<TeamPlayer>()
                {

                }))
                .Build(),

            new ClubBuilder("NÎMES OLYMPIQUE")
                .WithFirstTeam(new FirstTeam(new Coach("", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(10))
                .Build(),

            new ClubBuilder("OGC NICE")
                .WithFirstTeam(new FirstTeam(new Coach("", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(12))
                .Build(),

            new ClubBuilder("OLYMPIQUE DE MARSEILLE")
                .WithFirstTeam(new FirstTeam(new Coach("", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(13))
                .Build(),

            new ClubBuilder("OLYMPIQUE LYONNAIS")
                .WithFirstTeam(new FirstTeam(new Coach("", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(14))
                .Build(),

            new ClubBuilder("PARIS SAINT-GERMAIN")
                .WithFirstTeam(new FirstTeam(new Coach("", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(15))
                .Build(),

            new ClubBuilder("RC LENS")
                .WithFirstTeam(new FirstTeam(new Coach("", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(16))
                .Build(),

            new ClubBuilder("RC STRASBOURG ALSACE")
                .WithFirstTeam(new FirstTeam(new Coach("", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(17))
                .Build(),

            new ClubBuilder("STADE BRESTOIS 29")
                .WithFirstTeam(new FirstTeam(new Coach("", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(18))
                .Build(),

            new ClubBuilder("STADE DE REIMS")
                .WithFirstTeam(new FirstTeam(new Coach("", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(19))
                .Build(),

            new ClubBuilder("STADE RENNAIS FC")
                .WithFirstTeam(new FirstTeam(new Coach("", ""), new List<TeamPlayer>()
                {

                }))
                .WithId(new ClubId(20))
                .Build()
        };

        public async Task<Club> GetByIdAsync(ClubId id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Club>> GetByIdsAsync(params ClubId[] ids)
        {
            throw new NotImplementedException();
        }
    }
}
