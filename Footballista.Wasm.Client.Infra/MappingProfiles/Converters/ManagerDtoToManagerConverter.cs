using AutoMapper;
using Footballista.Wasm.Client.Dto.Models.Careers;
using Footballista.Wasm.Shared.Data;
using Footballista.Wasm.Shared.Data.Careers;

namespace Footballista.Wasm.Client.Infra.MappingProfiles.Converters
{
	public class ManagerDtoToManagerConverter : ITypeConverter<ManagerDto, Manager>
	{
		public Manager Convert(ManagerDto source, Manager destination, ResolutionContext context)
		{
			var mapper = context.Mapper;
			return Manager.CreateManager
			(
				mapper.Map<Gender>(source.Gender),
				source.Firstname,
				source.Lastname,
				mapper.Map<SimpleDate>(source.DateOfBirth),
				source.Country
			);
		}
	}
}
