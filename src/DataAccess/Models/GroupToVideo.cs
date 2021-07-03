using Neo4j.Driver.Extensions;

namespace DataAccess.Models
{
	public class GroupToVideo
	{
		[Neo4jProperty(Name = "groupId")]
		public int GroupId { get; set; }

		[Neo4jProperty(Name = "videoId")]
		public int VideoId { get; set; }

		[Neo4jProperty(Name = "priority")]
		public string Priority { get; set; }
	}
}
