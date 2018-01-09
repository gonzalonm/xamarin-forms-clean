using System.Collections.Generic;
using XamarinCleanApp.Core.Data.Cache;
using XamarinCleanApp.Core.Data.Entity;
using XamarinCleanApp.Core.Data.Net;

namespace XamarinCleanApp.Core.Data.Repository.DataSource
{
	public class CloudCityDataStore : ICityDataStore
	{
		public ICityCache CityCache { get; set; }
		IRestApi RestApi = new RestApi();

		public List<CityEntity> Cities()
		{
			var entities = RestApi.GetAllCities();
			CityCache.ClearAll();
			CityCache.PutAll(entities);
			return entities;
		}
	}
}
