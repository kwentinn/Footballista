using AutoMapper;
using Footballista.Wasm.Client.Dto.Models.Careers;
using Footballista.Wasm.Shared.Data.Competitions;

namespace Footballista.Wasm.Client.Infra.MappingProfiles.Converters
{
	public class CompetitionDtoToCompetitionConverter : ITypeConverter<CompetitionDto, Competition>
	{
		public Competition Convert(CompetitionDto source, Competition destination, ResolutionContext context)
		{
			return Competition.Instantiate(source.Id, source.Name, source.Division, source.Country);
		}
	}
}
