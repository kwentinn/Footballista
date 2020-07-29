using AutoMapper;
using Footballista.Wasm.Client.Dto.Models.Careers;
using Footballista.Wasm.Shared.Data.Careers;
using Footballista.Wasm.Shared.Data.Competitions;

namespace Footballista.Wasm.Client.Infra.MappingProfiles.Converters
{
	public class CareerDtoToCareerConverter : ITypeConverter<CareerDto, Career>
	{
		public Career Convert(CareerDto source, Career destination, ResolutionContext context)
		{
			Competition cpt = context.Mapper.Map<Competition>(source.CurrentCompetition);
			return Career.Instantiate(source.Id, source.Name, cpt);
		}
	}
}
