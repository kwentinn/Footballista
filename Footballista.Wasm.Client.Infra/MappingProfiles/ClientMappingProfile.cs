﻿using AutoMapper;
using Footballista.Wasm.Client.Dto.Models.Careers;
using Footballista.Wasm.Client.Infra.MappingProfiles.Converters;
using Footballista.Wasm.Shared.Data;
using Footballista.Wasm.Shared.Data.Careers;
using Footballista.Wasm.Shared.Data.Competitions;

namespace Footballista.Wasm.Client.Infra.MappingProfiles
{
	public class ClientMappingProfile : Profile
	{
		public ClientMappingProfile()
		{
			CreateMap<Career, CareerDto>();
			CreateMap<Manager, ManagerDto>();
			CreateMap<SimpleDate, SimpleDateDto>();
			CreateMap<Competition, CompetitionDto>();
			CreateMap<Season, SeasonDto>();
			CreateMap<Gender, GenderDto>();

			CreateMap<CareerDto, Career>()
				.ConvertUsing<CareerDtoToCareerConverter>();
			CreateMap<CompetitionDto, Competition>()
				.ConvertUsing<CompetitionDtoToCompetitionConverter>();
			CreateMap<ManagerDto, Manager>()
				.ConvertUsing<ManagerDtoToManagerConverter>();
		}
	}
}
