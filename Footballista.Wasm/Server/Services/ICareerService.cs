using Footballista.Wasm.Shared.Data.Careers;
using System.Collections.Generic;

namespace Footballista.Wasm.Server.Services
{
	public interface ICareerService
	{
		List<string> GetAll();
		Career GetByName(string careerName);
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
	}
}
