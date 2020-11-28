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
				.Build(),

			new ClubBuilder("AS MONACO")
				.WithId(new ClubId(2))
				.Build(),

			new ClubBuilder("AS SAINT-ÉTIENNE")
				.WithId(new ClubId(3))
				.Build(),

			new ClubBuilder("DIJON FCO")
				.WithId(new ClubId(4))
				.Build(),

			new ClubBuilder("FC GIRONDINS DE BORDEAUX")
				.WithId(new ClubId(5))
				.Build(),

			new ClubBuilder("FC LORIENT")
				.WithId(new ClubId(6))
				.Build(),

			new ClubBuilder("FC METZ")
				.WithId(new ClubId(7))
				.Build(),

			new ClubBuilder("FC NANTES")
				.WithId(new ClubId(8))
				.Build(),

			new ClubBuilder("LOSC LILLE")
				.WithId(new ClubId(9))
				.Build(),

			new ClubBuilder("MONTPELLIER HÉRAULT SC")
				.WithId(new ClubId(10))
				.WithTeam(new Team(TeamType.FirstTeam, new Coach("Michel", "Derzakarian"), new List<TeamPlayer>()
				{

				}))
				.Build(),

			new ClubBuilder("NÎMES OLYMPIQUE")
				.WithId(new ClubId(10))
				.Build(),

			new ClubBuilder("OGC NICE")
				.WithId(new ClubId(12))
				.Build(),

			new ClubBuilder("OLYMPIQUE DE MARSEILLE")
				.WithId(new ClubId(13))
				.Build(),

			new ClubBuilder("OLYMPIQUE LYONNAIS")
				.WithId(new ClubId(14))
				.Build(),

			new ClubBuilder("PARIS SAINT-GERMAIN")
				.WithId(new ClubId(15))
				.Build(),

			new ClubBuilder("RC LENS")
				.WithId(new ClubId(16))
				.Build(),

			new ClubBuilder("RC STRASBOURG ALSACE")
				.WithId(new ClubId(17))
				.Build(),

			new ClubBuilder("STADE BRESTOIS 29")
				.WithId(new ClubId(18))
				.Build(),

			new ClubBuilder("STADE DE REIMS")
				.WithId(new ClubId(19))
				.Build(),

			new ClubBuilder("STADE RENNAIS FC")
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
