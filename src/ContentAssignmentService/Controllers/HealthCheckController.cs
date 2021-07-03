using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Neo4j.Driver;
using Neo4j.Driver.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ContentAssignmentService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HealthCheckController : ControllerBase
	{
		private readonly IDriver _driver;

		public HealthCheckController(IDriver driver)
		{
			_driver = driver;
		}

		[HttpGet("ping")]
		public string Ping()
		{
			return DateTime.UtcNow.ToString("O");
		}

		[HttpGet("database")]
		public async Task<string> Database()
		{
			try
			{
				var query = @$"MATCH (m:{nameof(Video)}) RETURN m";

				var session = _driver.AsyncSession();

				var videos = await session.RunReadTransactionForObjects<Video>(query, null, "m");

				return $"database is accessible and contains {videos.Count()} videos.";
			}
			catch (Exception ex)
			{
				return $"Error occurred when trying to fetch videos from database: {ex.Message}";
			}
		}
	}
}
