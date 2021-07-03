using Neo4j.Driver.Extensions;

namespace DataAccess.Models
{
	public class UserToFlow
	{
		[Neo4jProperty(Name = "userId")]
		public int UserId { get; set; }

		[Neo4jProperty(Name = "flowId")]
		public int FlowId { get; set; }

		[Neo4jProperty(Name = "priority")]
		public string Priority { get; set; }
	}
}
