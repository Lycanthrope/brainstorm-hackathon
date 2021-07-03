using ContentAssignmentService.Models;
using DataAccess.Models;
using Neo4j.Driver;
using Neo4j.Driver.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentAssignmentService.Managers
{
	public class VideoManager : IVideoManager
	{
		private readonly IDriver _driver;

		public VideoManager(IDriver driver)
		{
			_driver = driver;
		}

		public async Task<IEnumerable<UserVideo>> GetUserVideos(int userId, string priority)
		{
			var query = @$"match (u:User {{{nameof(User.Id)}{userId}}})-[r:User_To_Video]->(v:video)
						return v as video, collect(r.priority) as priority
						union
						match (u:User {{{nameof(User.Id)}{userId}}})-[r:User_To_Flow]->(f:flow)-[rv:Flow_To_Video]->(v:video)
						return v as video, collect(r.priority) as priority
						union
						match (u:User {{{nameof(User.Id)}{userId}}})-[rg:User_To_Group]->(g:group)-[r:Group_To_Video]->(v:video)
						return v as video, collect(r.priority) as priority
						union
						match (u:User {{{nameof(User.Id)}{userId}}})-[rg:User_To_Group]->(g:group)-[r:Group_To_Flow]->(f:flow)-[rv:Flow_To_Video]->(v:video)
						return v as video, collect(r.priority) as priority";

			var session = _driver.AsyncSession();

			var videos = await session.RunReadTransactionForObjects<UserVideo>(query, null, "m");

			return videos.Select(v => new UserVideo
			{
				Video = v.Video,
				Priority = GetPriority(v.Priority)
			}).ToList();
		}

		public Task<IEnumerable<VideoPath>> GetUserVideoPaths(int userId, int videoId, string priority)
		{
			throw new NotImplementedException();
		}

		private static string GetPriority(string priority)
		{
			if (priority.Contains("critical"))
				return "critical";

			if (priority.Contains("high"))
				return "high";

			if (priority.Contains("medium"))
				return "medium";

			if (priority.Contains("low"))
				return "low";

			return "";
		}
	}
}
