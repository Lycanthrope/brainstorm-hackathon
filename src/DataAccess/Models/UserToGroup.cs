using Neo4j.Driver.Extensions;

namespace DataAccess.Models
{
	public class UserToGroup
	{
		[Neo4jProperty(Name = "userId")]
		public int UserId { get; set; }

		[Neo4jProperty(Name = "groupId")]
		public int GroupId { get; set; }
	}
}
