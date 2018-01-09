using XamarinCleanApp.Core.Data.Cache;

namespace XamarinCleanApp.Core.Data.Repository.DataSource
{
	public class CityDataStoreFactory
	{
		bool UseCache;
		ICityCache CityCache = new CityCache();

		public CityDataStoreFactory(bool useCache)
		{
			UseCache = useCache;
		}

		public ICityDataStore Create()
		{
			if (UseCache && CityCache.HasData())
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
