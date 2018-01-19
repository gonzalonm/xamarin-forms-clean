using XamarinCleanApp.Core.Data.Cache;

namespace XamarinCleanApp.Core.Data.Repository.DataSource
{
	public class CityDataStoreFactory
	{
		ICityCache CityCache = new CityCache();

		public ICityDataStore Create(bool useCache = false)
		{
			if (useCache && CityCache.HasData())
			{
				return CreateDiskCityDataStore();
			}
			return CreateCloudCityDataStore();
		}

		ICityDataStore CreateDiskCityDataStore()
		{
			return new DiskCityDataStore { CityCache = this.CityCache };
		}

		ICityDataStore CreateCloudCityDataStore()
		{
			return new CloudCityDataStore { CityCache = this.CityCache };
		}
	}
}
