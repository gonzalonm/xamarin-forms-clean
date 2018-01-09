using System.Collections.Generic;
using XamarinCleanApp.Core.Data.Cache;
using XamarinCleanApp.Core.Data.Entity;

namespace XamarinCleanApp.Core.Data.Net
{
	public class RestApi : IRestApi
	{
		public List<CityEntity> GetAllCities()
		{
			var entities = GetAllCitiesFromApi();
			return new Serializer<List<CityEntity>>().FromJson(entities);
		}

		string GetAllCitiesFromApi()
		{
			var url = ApiConnection.HostUrl;
			return ApiConnection.DoGet(url).Result;
		}
	}
}
