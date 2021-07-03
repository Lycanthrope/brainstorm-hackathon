using Neo4j.Driver.Extensions;

namespace DataAccess.Models
{
	public class GroupToFlow
	{
		[Neo4jProperty(Name = "groupId")]
		public int GroupId { get; set; }

		[Neo4jProperty(Name = "flowId")]
		public int FlowId { get; set; }

		[Neo4jProperty(Name = "priority")]
		public string Priority { get; set; }
	}
}
