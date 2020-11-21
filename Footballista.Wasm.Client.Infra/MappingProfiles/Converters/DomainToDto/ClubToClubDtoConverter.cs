using AutoMapper;
using Footballista.Wasm.Client.Dto.Models.Careers;
using Footballista.Wasm.Shared.Data.Clubs;

namespace Footballista.Wasm.Client.Infra.MappingProfiles.Converters.DomainToDto
{
	public class ClubToClubDtoConverter : ITypeConverter<Club, ClubDto>
	{
		public ClubDto Convert(Club source, ClubDto destination, ResolutionContext context)
		{
			return new ClubDto
			{
				Name = source.Name,
				Abbreviation = source.Abbreviation,
				City = source.City.Name,
				Country = source.City.Country,
				Id = source.Id
			};
		}
	}
}
