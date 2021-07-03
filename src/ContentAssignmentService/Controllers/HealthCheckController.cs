using Microsoft.AspNetCore.Mvc;
using System;

namespace ContentAssignmentService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HealthCheckController : ControllerBase
	{
		[HttpGet("ping")]
		public string Ping()
		{
			return DateTime.UtcNow.ToString("O");
		}
	}
}
