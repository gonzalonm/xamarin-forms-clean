using Newtonsoft.Json;
using SQLite;

namespace XamarinCleanApp.Core.Data.Entity
{
	public class CityEntity
	{
		[JsonIgnore]
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		[JsonProperty("image_link")]
		public string ImageLink { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
