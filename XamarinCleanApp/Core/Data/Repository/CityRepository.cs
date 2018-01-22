using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading.Tasks;
using XamarinCleanApp.Core.Data.Entity;
using XamarinCleanApp.Core.Data.Entity.Mapper;
using XamarinCleanApp.Core.Data.Repository.DataSource;
using XamarinCleanApp.Core.Model;
using XamarinCleanApp.Core.Model.Repository;

namespace XamarinCleanApp.Core.Data.Repository
{
	public class CityRepository : ICityRepository
	{
		CityMapper Mapper = new CityMapper();
		CityDataStoreFactory Factory = new CityDataStoreFactory();

		public IObservable<List<City>> Cities(bool useCache)
		{
			var dataSource = Factory.Create(useCache);
			var entities = dataSource.Cities();
			return dataSource.Cities().Select(x => Mapper.TransformList(x));
		}
	}
}
