using Neo4j.Driver.Extensions;

namespace DataAccess.Models
{
	public class Video
	{
		[Neo4jProperty(Name = "id")]
		public int Id { get; set; }

		[Neo4jProperty(Name = "name")]
		public string Name { get; set; }
	}
}
