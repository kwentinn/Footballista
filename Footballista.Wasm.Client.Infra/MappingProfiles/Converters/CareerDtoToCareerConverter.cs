using AutoMapper;
using Footballista.Wasm.Client.Dto.Models.Careers;
using Footballista.Wasm.Shared.Data.Careers;
using Footballista.Wasm.Shared.Data.Clubs;
using Footballista.Wasm.Shared.Data.Competitions;

namespace Footballista.Wasm.Client.Infra.MappingProfiles.Converters
{
	public class CareerDtoToCareerConverter : ITypeConverter<CareerDto, Career>
	{
		public Career Convert(CareerDto source, Career destination, ResolutionContext context)
		{
			Competition competition = context.Mapper.Map<Competition>(source.CurrentCompetition);
			Club club = context.Mapper.Map<Club>(source.Club);

			return Career.Instantiate
			(
				source.Id,
				source.Name,
				club,
				competition
			);
		}
	}
}
