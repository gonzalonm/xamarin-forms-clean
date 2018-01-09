using System.Collections.Generic;
using XamarinCleanApp.Core.Data.Entity.Mapper;
using XamarinCleanApp.Core.Data.Repository.DataSource;
using XamarinCleanApp.Core.Model;
using XamarinCleanApp.Core.Model.Repository;

namespace XamarinCleanApp.Core.Data.Repository
{
	public class CityRepository : ICityRepository
	{
		CityMapper Mapper = new CityMapper();
		CityDataStoreFactory Factory;

		public CityRepository(bool useCache)
		{
			Factory = new CityDataStoreFactory(useCache);
		}

		public List<City> Cities()
		{
			var dataSource = Factory.Create();
			var entities = dataSource.Cities();
			return Mapper.TransformList(entities);
		}
	}
}
