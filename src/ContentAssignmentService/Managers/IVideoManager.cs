using ContentAssignmentService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContentAssignmentService.Managers
{
	public interface IVideoManager
	{
		Task<IEnumerable<UserVideo>> GetUserVideos(int userId, string priority);
		Task<IEnumerable<VideoPath>> GetUserVideoPaths(int userId, int videoId, string priority);
	}
}
