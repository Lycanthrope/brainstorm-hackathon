using Neo4j.Driver.Extensions;

namespace DataAccess.Models
{
	public class Group
	{
		[Neo4jProperty(Name = "id")]
		public int Id { get; set; }
	}
}
