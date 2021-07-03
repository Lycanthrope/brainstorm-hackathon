using Neo4j.Driver.Extensions;

namespace DataAccess.Models
{
	public class UserToVideo
	{
		[Neo4jProperty(Name = "userId")]
		public int UserId { get; set; }

		[Neo4jProperty(Name = "videoId")]
		public int VideoId { get; set; }

		[Neo4jProperty(Name = "priority")]
		public int Priority { get; set; }
	}
}
