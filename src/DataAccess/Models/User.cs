using Neo4j.Driver.Extensions;

namespace DataAccess.Models
{
	public class User
	{
		[Neo4jProperty(Name = "id")]
		public int Id { get; set; }
	}
}
