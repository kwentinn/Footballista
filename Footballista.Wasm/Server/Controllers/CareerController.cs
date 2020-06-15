using Footballista.Wasm.Server.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Footballista.Wasm.Server.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CareerController : ControllerBase
	{
		private readonly ICareerService _careerService;

		public CareerController(ICareerService careerService)
		{
			_careerService = careerService;
		}

		[HttpGet]
		[Route("all")]
		public List<string> GetAll()
		{
			return _careerService.GetAll();
		}
	}
}
