using AutoMapper;
using Footballista.Wasm.Client.Dto.Models.Careers;
using Footballista.Wasm.Shared.Data.Clubs;

namespace Footballista.Wasm.Client.Infra.MappingProfiles.Converters.DtoToDomain
{
	public class ClubDtoToClubConverter : ITypeConverter<ClubDto, Club>
	{
		public Club Convert(ClubDto source, Club destination, ResolutionContext context)
		{
			return new Club
			(
				id: source.Id,
				name: source.Name,
				abbreviation: source.Abbreviation,
				city: new Shared.Data.City(source.City, source.Country)
			);
		}
	}
}
