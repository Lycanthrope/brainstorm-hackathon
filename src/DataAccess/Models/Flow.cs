using Neo4j.Driver.Extensions;

namespace DataAccess.Models
{
	public class Flow
	{
		[Neo4jProperty(Name = "id")]
		public int Id { get; set; }
	}
}
