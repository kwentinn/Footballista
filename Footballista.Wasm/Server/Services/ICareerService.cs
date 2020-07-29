using Footballista.Wasm.Client.Dto.Models.Careers;
using Footballista.Wasm.Shared.Data.Careers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Footballista.Wasm.Server.Services
{
	public interface ICareerService
	{
		List<string> GetAll();
		Career GetByName(string careerName);
		Task<Career> LoadCareerAsync(Guid careerGuid);
	}
	public class CareerService : ICareerService
	{
		public List<string> GetAll()
		{
			throw new System.NotImplementedException();
		}

		public Career GetByName(string careerName)
		{
			throw new System.NotImplementedException();
		}

		public Task<Career> LoadCareerAsync(Guid careerGuid)
		{
			throw new NotImplementedException();
		}
	}
}
