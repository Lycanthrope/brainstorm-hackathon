using ContentAssignmentService.Managers;
using ContentAssignmentService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContentAssignmentService.Controllers
{
	[Route("users/{userId}/[controller]")]
	[ApiController]
	public class VideosController : ControllerBase
	{
		private readonly IVideoManager _videoManager;

		public VideosController(IVideoManager videoManager)
		{
			_videoManager = videoManager;
		}

		[HttpGet]
		public async Task<IEnumerable<UserVideo>> GetVideos([FromRoute] int userId, [FromQuery] string priority)
		{
			return await _videoManager.GetUserVideos(userId, priority);
		}

		[HttpGet("{videoId}/paths")]
		public async Task<IEnumerable<VideoPath>> GetVideoPaths([FromRoute] int userId, [FromRoute] int videoId, [FromQuery] string priority)
		{
			return await _videoManager.GetUserVideoPaths(userId, videoId, priority);
		}
	}
}
