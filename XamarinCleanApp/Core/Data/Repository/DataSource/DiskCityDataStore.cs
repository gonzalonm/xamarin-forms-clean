using System.Collections.Generic;
using XamarinCleanApp.Core.Data.Cache;
using XamarinCleanApp.Core.Data.Entity;

namespace XamarinCleanApp.Core.Data.Repository.DataSource
{
	public class DiskCityDataStore : ICityDataStore
	{
		public ICityCache CityCache { get; set; }

		public List<CityEntity> Cities()
		{
			return CityCache.GetAll();
		}
	}
}
