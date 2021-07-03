using Neo4j.Driver.Extensions;

namespace DataAccess.Models
{
	public class FlowToVideo
	{
		[Neo4jProperty(Name = "flowId")]
		public int FlowId { get; set; }

		[Neo4jProperty(Name = "videoId")]
		public int VideoId { get; set; }
	}
}
